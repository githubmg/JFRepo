GO
CREATE PROCEDURE [dbo].[rptTotalChequesCedidos] (
	@desde DATE = null,
	@hasta DATE = null,
	@cobrado BIT = null
)
AS
BEGIN
select SUM(ch.importe)
from 
cheque ch 
LEFT JOIN banco b on b.idBanco = ch.idBanco
JOIN pagoCheque pc ON pc.idCheque = ch.idCheque
JOIN pagoCompra paco ON pc.idPago = paco.idPago
JOIN compraCabe cc on cc.idCompraCabe = paco.idCompra
JOIN origenCheque orch ON ch.idOrigenCheque = orch.idOrigenCheque
LEFT JOIN cobroCheque ccq ON ch.idCheque = ccq.idCheque
LEFT JOIN cobroPedido cpe ON ccq.idCobro = cpe.idCobro
LEFT JOIN pedidoCabe ped ON ped.idPedidoCabe = cpe.idPedido
LEFT JOIN cliente cli ON cli.idCliente = ped.idCliente
WHERE enCartera = 0
AND (cc.fechaCompra >= @desde or @desde is NULL) AND
			(cc.fechaCompra<= @hasta or @hasta is NULL) AND
			(ch.cobrado = @cobrado or @cobrado is NULL)

END
GO
ALTER TABLE dbo.compraCabe ADD
	percepcionGanancias float(53) NULL,
	percepcionIIBB float(53) NULL,
	percepcionIva float(53) NULL
GO
UPDATE compraCabe set percepcionGanancias =0,percepcionIIBB =0 ,percepcionIva= 0
GO
ALTER PROCEDURE [dbo].[compraCabeVista] 
AS
BEGIN
	SELECT cc.idCompraCabe,
	p.razonSocial as 'proveedor',
	cc.fechaCompra, 
	ep.descripcion as 'estado',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe ),0)) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe ),0)) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'saldado',
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
ALTER PROCEDURE [dbo].[CompraCabeInsert] (
	@cuitProveedor BIGINT,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
	@idTipoOrden INT,
	@idUbicacionStock INT,
	@observaciones Varchar(250),
	@percepcionIVA float,
	@percepcionGanancias float,
	@percepcionIIBB float
)
AS
BEGIN
	DECLARE @idCabe INT
	SELECT @idCabe = ISNULL(MAX(idCompraCabe),0)+1 FROM dbo.compraCabe
	INSERT INTO dbo.compraCabe
	        ( idCompraCabe, 
	         cuitProveedor,
	         fechaCompra,
	         idEstado,
	         idTipoOrden,
	         observaciones,
	         idUbicacionStock,
	         percepcionIVA ,
	         percepcionGanancias ,
	         percepcionIIBB 
			  
	        )
	VALUES  ( @idCabe,
			  @cuitProveedor ,
	          @fechaCompra ,
	          @idEstadoPedido ,
	          @idTipoOrden ,
	          @observaciones,
	          @idUbicacionStock,
	          @percepcionIVA ,
			  @percepcionGanancias ,
			  @percepcionIIBB  
	        )
	SELECT @idCabe AS idCabe
END
GO
GO
ALTER PROCEDURE [dbo].[CompraCabeUpdate] (
	@idCompraCabe int,
	@cuitProveedor bigint,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
	@idTipoOrden INT,
	@idUbicacionStock INT,
	@observaciones Varchar(250),
	@percepcionIVA float,
	@percepcionGanancias float,
	@percepcionIIBB float
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   compraCabe SET
	         cuitProveedor=@cuitProveedor,
	         fechaCompra=@fechaCompra,
	         idEstado=@idEstadoPedido,
	         idTipoOrden=@idTipoOrden,
	         idUbicacionStock=@idUbicacionStock,
	         observaciones=@observaciones,
	         percepcionIva=@percepcionIVA ,
			 percepcionGanancias = @percepcionGanancias,
			 percepcionIIBB=@percepcionIIBB 
	WHERE idCompraCabe=@idCompraCabe 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   compraCabe
	WHERE  idCompraCabe = @idCompraCabe
	-- End Return Select <- do not remove
	COMMIT

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
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario )  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = c.idCompraCabe ),0) + c.percepcionGanancias + c.percepcionIva + c.percepcionIIBB)  
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0))
	) as varchar(20)),'0')
	
	FROM compraCabe c 
	 INNER JOIN proveedor p ON c.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON c.idEstado = ep.idEstadoPedido
	WHERE 
	(
	CAST(c.idCompraCabe as varchar(20)) LIKE '%'+@descripcion+'%' OR
	p.razonSocial LIKE '%'+@descripcion+'%') 
	AND 
	--Condicion de que la compra esté sin saldar
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario )  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = c.idCompraCabe ),0)+ c.percepcionGanancias + c.percepcionIva + c.percepcionIIBB) 
	> 
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0)
	)	
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
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100) )  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe ),0) + cc.percepcionGanancias + cc.percepcionIva + cc.percepcionIIBB) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100) )  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe ),0)) + cc.percepcionGanancias + cc.percepcionIva + cc.percepcionIIBB
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'saldado',
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
ALTER PROCEDURE [dbo].[MontoCompraSSaldarVista] (@idCompra int)
AS
BEGIN
	SELECT 
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = c.idCompraCabe ),0)+ c.percepcionGanancias + c.percepcionIva + c.percepcionIIBB) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0))
	as saldo
	FROM compraCabe c 
	WHERE 
	c.idCompraCabe = @idCompra
END
GO
ALTER PROCEDURE [dbo].[compraCabeVista] 
AS
BEGIN
	SELECT cc.idCompraCabe,
	p.razonSocial as 'proveedor',
	cc.fechaCompra, 
	ep.descripcion as 'estado',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe ),0)+ cc.percepcionGanancias + cc.percepcionIva + cc.percepcionIIBB) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe ),0)+ cc.percepcionGanancias + cc.percepcionIva + cc.percepcionIIBB) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'saldado',
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