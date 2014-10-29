GO
CREATE TABLE dbo.factura
	(
	idFactura int NOT NULL,
	fecha date NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.factura ADD CONSTRAINT
	PK_factura PRIMARY KEY CLUSTERED 
	(
	idFactura
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO


GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[remitoVista] 
AS
BEGIN
	SELECT re.idRemito,
	c.razonSocial as 'cliente',
	pc.fechaPedido, 
	pc.orden,
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
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	 ORDER BY factura DESC, pc.fechaPedido DESC
END
GO