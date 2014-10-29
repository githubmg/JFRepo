GO
----------------------------------------------------------------------------------------------------------------------------------------
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
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = cc.idCompraCabe ),0)) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = cc.idCompraCabe ),0)) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'saldado'
	 FROM compraCabe cc 
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON cc.idEstado = ep.idEstadoPedido
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[pedidoCabeVista] 
AS
BEGIN
	SELECT pc.idPedidoCabe,
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
	as varchar(20)),'0') as 'saldado'
	FROM pedidoCabe pc 
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
END
GO
GO
CREATE PROCEDURE [dbo].[CobroPedidoInsert] (
   @idCobro int,
   @idPedido int,
   @montoCancelado float
)
AS 
	BEGIN TRAN

	INSERT INTO cobroPedido(idCobro,idPedido,montoCancelado)
	VALUES (@idCobro,@idPedido,@montoCancelado)
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cobroPedido
	WHERE  idCobro = @idCobro AND idPedido = @idPedido
	-- End Return Select <- do not remove
               
	COMMIT
GO
GO
CREATE PROCEDURE [dbo].[CobroChequeInsert] (
   @idCobro int,
   @idCheque int
)
AS 
	BEGIN TRAN

	INSERT INTO cobroCheque(idCobro,idCheque)
	VALUES (@idCobro,@idCheque)
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cobroCheque
	WHERE  idCobro = @idCobro AND idCheque = @idCheque
	-- End Return Select <- do not remove
               
	COMMIT
GO