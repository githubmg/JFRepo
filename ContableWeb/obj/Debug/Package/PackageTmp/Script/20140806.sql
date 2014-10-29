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
	ISNULL(us.descripcion,'') As ubicacionStock
	 FROM compraCabe cc 
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON cc.idEstado = ep.idEstadoPedido
	 INNER JOIN tipoOrden tor ON cc.idTipoOrden = tor.idTipoOrden
	 LEFT JOIN ubicacionStock us ON cc.idUbicacionStock = us.idUbicacionStock
	 order by cc.idCompraCabe desc
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
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
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = c.idCompraCabe ),0))  
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
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = c.idCompraCabe ),0)) 
	> 
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0)
	)	
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[MontoCompraSSaldarVista] (@idCompra int)
AS
BEGIN
	SELECT 
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1+aliva.valor/100))  
	from CompraItem ci 
	INNER JOIN producto p  ON ci.idProducto = p.idProducto
	INNER JOIN alicuotaIva aliva ON aliva.idAlicuotaIva = p.idAlicuotaIva
	where ci.idCompra = c.idCompraCabe ),0)) 
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