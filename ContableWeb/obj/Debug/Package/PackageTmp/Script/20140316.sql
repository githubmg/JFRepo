GO
ALTER PROCEDURE [dbo].[rptDeudores] (
	@desde DATE = null,
	@hasta DATE = null
)
AS
BEGIN
	SELECT 
	
	pc.idPedidoCabe as idPedido,
	Convert(varchar(10),CONVERT(date,pc.fechaPedido,106),103) as fechaPedido,
	CAST(c.cuit as varchar) as cuit,
	c.razonSocial, 
	CAST(pc.fechaPedido as date), 
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario * (1 + aliva.valor/100 ))  
	from PedidoItem pit 
	JOIN producto pro on pit.idProducto = pro.idProducto
	JOIN alicuotaIva aliva ON pro.idAlicuotaIva = aliva.idAlicuotaIva
	where pit.idPEdido = pc.idPedidoCabe ),0)) 
	-
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c	INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = pc.idPedidoCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario )  
	from PedidoItem pit 
	where pit.idPEdido = pc.idPedidoCabe
	),0)) 
	)
	as varchar(20)),'0') as 'subtotal',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario * (1 + aliva.valor/100 ))  
	from PedidoItem pit 
	JOIN producto pro on pit.idProducto = pro.idProducto
	JOIN alicuotaIva aliva ON pro.idAlicuotaIva = aliva.idAlicuotaIva
	where pit.idPEdido = pc.idPedidoCabe
	),0)) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario *  aliva.valor/100 )  
	from PedidoItem pit 
	JOIN producto pro on pit.idProducto = pro.idProducto
	JOIN alicuotaIva aliva ON pro.idAlicuotaIva = aliva.idAlicuotaIva
	where pit.idPEdido = pc.idPedidoCabe
	),0)) 
	)
	as varchar(20)),'0') as 'iva',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = pc.idPedidoCabe),0))) 
	as varchar(20)),'0') as 'saldado',
	ISNULL(CAST(re.idFactura as varchar),'Pendiente') as 'factura'
	FROM pedidoCabe pc   
	 LEFT JOIN remito re ON  re.idPedido = pc.idPedidoCabe
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	WHERE (pc.fechaPedido >= @desde or @desde is NULL) AND
			(pc.fechaPedido<= @hasta or @hasta is NULL)
	ORDER BY factura DESC, pc.fechaPedido DESC
END
GO