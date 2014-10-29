GO
CREATE FUNCTION [dbo].[fcnMontoTotalCompra]
 (
  @idCompra int
 )
returns float
as
begin
declare @montoTotal float
declare @tipo int
set @tipo = (SELECT idTipoOrden FROM compraCabe WHERE idCompraCabe = @idCompra)

IF @tipo = 1 OR @tipo is null
begin
	set @montoTotal =
	(SELECT ISNULL(SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100)),0) +  ISNULL(cc.percepcionGanancias,0) + ISNULL(cc.percepcionIva,0) + ISNULL(cc.percepcionIIBB,0)
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	INNER JOIN compraCabe cc ON ci.idCompra = cc.idCompraCabe
	WHERE ci.idCompra = @idCompra
	GROUP BY cc.percepcionGanancias,cc.percepcionIIBB,cc.percepcionIva
	)
end
ELSE
begin
	set @montoTotal = 
	(SELECT SUM(ci.cantidad * ci.precioUnitario) FROM compraItem ci WHERE ci.idCompra = @idCompra)
end
return ISNULL(@montoTotal,0)
END
GO
CREATE FUNCTION [dbo].[fcnMontoSaldadoCompra]
 (
  @idCompra int
 )
returns float
as
BEGIN
declare @pendiente float
set @pendiente = 
(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = @idCompra),0)) 
RETURN @pendiente	
END
GO
GO
ALTER PROCEDURE [dbo].[compraCabeVista] 
AS
BEGIN
	SELECT cc.idCompraCabe,
	p.razonSocial as 'proveedor',
	cc.fechaCompra, 
	ep.descripcion as 'estado',
	(dbo.fcnMontoTotalCompra(cc.idCompraCabe) - dbo.fcnMontoSaldadoCompra(cc.idCompraCabe)) as 'pendiente',
	dbo.fcnMontoSaldadoCompra(cc.idCompraCabe) as 'saldado',
	dbo.fcnMontoTotalCompra(cc.idCompraCabe) as 'total',
	tor.descripcion as 'tipoOrden',
	convert(varchar, cc.fechaCompra, 103)AS fechaString,
	ISNULL(us.descripcion,'') As ubicacionStock,
	cc.percepcionGanancias,
	cc.percepcionIva,
	cc.percepcionIIBB
	 FROM compraCabe cc 
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON cc.idEstado = ep.idEstadoPedido
	 INNER JOIN tipoOrden tor ON cc.idTipoOrden = tor.idTipoOrden
	 LEFT JOIN ubicacionStock us ON cc.idUbicacionStock = us.idUbicacionStock
	 order by cc.idCompraCabe desc
END
GO
ALTER PROCEDURE [dbo].[CompraSSaldarVista] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(c.idCompraCabe as varchar(20)) + ' - ' +  
	p.razonSocial + ' - ' + 
	CONVERT(VARCHAR(10), c.fechaCompra, 103)  + ' - ' + 
	ep.descripcion + ' - ' 
	+ '$' +
	CONVERT(VARCHAR(20),dbo.fcnMontoTotalCompra(idCompraCabe) - dbo.fcnMontoSaldadoCompra(idCompraCabe))
	FROM compraCabe c 
	 INNER JOIN proveedor p ON c.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON c.idEstado = ep.idEstadoPedido
	WHERE 
	(CAST(c.idCompraCabe as varchar(20)) LIKE '%'+@descripcion+'%' OR
	p.razonSocial LIKE '%'+@descripcion+'%') 
	AND 
	--Condicion de que la compra esté sin saldar
	dbo.fcnMontoTotalCompra(c.idCompraCabe) > dbo.fcnMontoSaldadoCompra(c.idCompraCabe)
		
END
GO
CREATE FUNCTION [dbo].[fcnMontoSinImpuestosCompra]
 (
  @idCompra int
 )
returns float
as
begin
declare @monto float
set @monto = 
	(SELECT SUM(ci.cantidad * ci.precioUnitario) FROM compraItem ci WHERE ci.idCompra = @idCompra)
return ISNULL(@monto,0)
END
GO
ALTER PROCEDURE [dbo].[rptAcreedores] (
	@desde datetime = null,
	@hasta datetime = null
)
AS
BEGIN
	SELECT 	
	dbo.fcnMontoTotalCompra(cc.idCompraCabe) - dbo.fcnMontoSaldadoCompra(cc.idCompraCabe) as 'pendiente',
	dbo.fcnMontoSinImpuestosCompra(cc.idCompraCabe)as 'subtotal',
	dbo.fcnMontoTotalCompra(cc.idCompraCabe) as 'total',
	dbo.fcnMontoTotalCompra(cc.idCompraCabe) - dbo.fcnMontoSinImpuestosCompra(cc.idCompraCabe) as 'impuestos',
	dbo.fcnMontoSaldadoCompra(cc.idCompraCabe) as 'saldado',
	p.razonSocial as 'razonSocial',
	cc.fechaCompra as 'fecha',
	p.cuit as 'cuit',
	cc.idCompraCabe
	FROM compraCabe cc   
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	WHERE (cc.fechaCompra >= @desde or @desde is NULL) AND
			(cc.fechaCompra<= @hasta or @hasta is NULL)
	ORDER BY  cc.fechaCompra DESC
END
GO

GO