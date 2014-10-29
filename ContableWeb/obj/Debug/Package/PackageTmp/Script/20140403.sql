GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[remitoVista] 
AS
BEGIN
	SELECT re.idRemito,
	c.razonSocial as 'cliente',
	pc.fechaPedido, 
	pc.orden,
	pc.chasis,
	ep.descripcion as 'estado',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from PedidoItem pit where pit.idPEdido = pc.idPedidoCabe ),0)) 
	-
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c	INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = pc.idPedidoCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from PedidoItem pit where pit.idPedido = pc.idPedidoCabe ),0)) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = pc.idPedidoCabe),0))) 
	as varchar(20)),'0') as 'saldado',
	ISNULL(CAST(re.idFactura as varchar),'Pendiente') as 'factura'
	FROM remito re 
	 INNER JOIN pedidoCabe pc  on re.idPedido = pc.idPedidoCabe
	 INNER JOIN cliente c ON pc.idCliente = c.idCliente
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	 ORDER BY factura DESC, pc.fechaPedido DESC
END
GO
GO
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[rptRemito_comprobantes] (
	@idRemito INT
)
AS
BEGIN
	SELECT re.idRemito AS idRemito ,
		   convert(varchar, pe.fechaPedido, 103)AS fecha,
		   cli.razonSocial AS cli_razonSocial,
		   cli.cuit AS cli_cuit,
		   cli.domicilio AS cli_domicilio,
		   loc.descripcion AS cli_localidad,
		   civa.descripcion AS civa_descripcion,
		   pit.cantidad AS pit_cantidad,
		   pro.descripcion AS pro_descripcion,
		   pit.precioUnitario AS pit_precioUnitario,
		   CAST(SUM(pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS total		   
	FROM dbo.remito re
	JOIN dbo.pedidoCabe pe ON re.idPedido = pe.idPedidoCabe
	JOIN dbo.cliente cli ON cli.idCliente = pe.idCliente
	JOIN dbo.condicionIva civa ON cli.idCondicionIva = civa.idCondicionIva
	JOIN dbo.localidad loc ON cli.idLocalidad = loc.idLocalidad
	JOIN dbo.pedidoItem pit ON pit.idPedido = pe.idPedidoCabe
	JOIN dbo.producto pro ON pro.idProducto = pit.idProducto
	WHERE re.idRemito = @idRemito
	GROUP BY 
		 re.idRemito ,
		   pe.fechaPedido,
		   cli.razonSocial,
		   cli.cuit,
		   cli.domicilio,
		   loc.descripcion ,
		   civa.descripcion,
		   pit.cantidad,
		   pro.descripcion ,
		   pit.precioUnitario
END

GO

GO
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[rptFactura_comprobantes] (
	@idFactura INT
)
AS
BEGIN
	SELECT fa.idFactura AS idFactura ,
		   convert(varchar, fa.fecha, 103)AS fecha,
		   cli.razonSocial AS cli_razonSocial,
		   cli.cuit AS cli_cuit,
		   cli.domicilio AS cli_domicilio,
		   loc.descripcion AS cli_localidad,
		   civa.descripcion AS civa_descripcion,
		   pit.cantidad AS pit_cantidad,
		   pro.descripcion AS pro_descripcion,
		   pit.precioUnitario AS pit_precioUnitario,
		   pit.precioUnitario * (1+ai.valor/100) AS pit_precioConIva,
		   ai.valor AS ai_alicuta,
		   CAST(ai.valor/100 * pit.cantidad * pit.precioUnitario AS NUMERIC(10,2)) AS ai_ivaTotal,
		   CAST(SUM(pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS totalSinIva,
		   CAST(SUM(pit.cantidad * pit.precioUnitario + ai.valor/100 * pit.cantidad * pit.precioUnitario ) AS NUMERIC(10,2)) AS totalConIva		   
	FROM dbo.factura fa
	JOIN dbo.remito re ON re.idFactura = fa.idFactura
	JOIN dbo.pedidoCabe pe ON re.idPedido = pe.idPedidoCabe
	JOIN dbo.cliente cli ON cli.idCliente = pe.idCliente
	JOIN dbo.condicionIva civa ON cli.idCondicionIva = civa.idCondicionIva
	JOIN dbo.localidad loc ON cli.idLocalidad = loc.idLocalidad
	JOIN dbo.pedidoItem pit ON pit.idPedido = pe.idPedidoCabe
	JOIN dbo.producto pro ON pro.idProducto = pit.idProducto
	JOIN dbo.alicuotaIva ai ON pro.idAlicuotaIva = ai.idAlicuotaIva
	WHERE fa.idFactura = @idFactura
	GROUP BY 
		 fa.idFactura ,
		   fa.fecha,
		   cli.razonSocial,
		   cli.cuit,
		   cli.domicilio,
		   loc.descripcion ,
		   civa.descripcion,
		   pit.cantidad,
		   pro.descripcion ,
		   pit.precioUnitario,
		   ai.valor
END


GO