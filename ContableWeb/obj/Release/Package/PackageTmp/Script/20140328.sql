GO
ALTER TABLE dbo.pedidoItem
	DROP COLUMN chasis
GO
GO
ALTER TABLE dbo.pedidoCabe ADD
	chasis varchar(50) NULL
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeInsert] (
	@cuitCliente BIGINT,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@chasis Varchar(50) ,
	@idEstadoPedido INT ,
	@idTipoOrden INT ,
	@observaciones Varchar(250)
)
AS
BEGIN
	DECLARE @idCabe INT
	SELECT @idCabe = ISNULL(MAX(idPedidoCabe),0)+1 FROM dbo.pedidoCabe
	INSERT INTO dbo.pedidoCabe
	        ( idPedidoCabe, 
	         cuitCliente,
	         fechaPedido,
	         chasis,
	         orden,
	         idEstadoPedido,
	         idTipoOrden,
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitCliente ,
	          @fechaPedido ,
	          @chasis ,
	          @orden , 
	          @idEstadoPedido ,
	          @idTipoOrden ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeUpdate] (
	@idPedidoCabe int,
	@cuitCliente bigint,
	@fechaPedido DATETIME ,
	@chasis varchar(50),
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
	@idTipoOrden INT ,
	@observaciones Varchar(250)
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   pedidoCabe SET
	         cuitCliente=@cuitCliente,
	         fechaPedido=@fechaPedido,
	         chasis=@chasis,
	         orden=@orden,
	         idEstadoPedido=@idEstadoPedido,
	         idTipoOrden=@idTipoOrden,
	         observaciones=@observaciones
	WHERE idPedidoCabe=@idPedidoCabe 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   pedidoCabe
	WHERE  idPedidoCabe = @idPedidoCabe
	-- End Return Select <- do not remove
	COMMIT

END
GO

GO
ALTER PROCEDURE [dbo].[PedidoItemInsert] (
	@idPedido INT,
	@idProducto INT ,
	@cantidad INT ,

	@precioUnitario float,
	@observaciones varchar(100)
)
AS
BEGIN
	DECLARE @idPedidoItem INT
	SELECT @idPedidoItem = ISNULL(MAX(idPedidoItem),0)+1 FROM dbo.pedidoItem
	INSERT INTO dbo.pedidoItem
	        ( idPedidoItem, 
			  idPedido ,
	          idProducto ,
	          cantidad ,

	          precioUnitario ,
	          observaciones
	        )
	VALUES  ( @idPedidoItem,
			  @idPedido ,
	          @idProducto ,
	          @cantidad , 

	          @precioUnitario,
	          @observaciones
	        )
	SELECT @idPedidoItem AS idPedidoItem
END
GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[pedidoCabeVista] 
AS
BEGIN
	SELECT pc.idPedidoCabe,
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
	tor.descripcion as 'tipoOrden'
	FROM pedidoCabe pc 
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	 INNER JOIN tipoOrden tor ON tor.idTipoOrden = pc.idTipoOrden
END
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
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	 ORDER BY factura DESC, pc.fechaPedido DESC
END
GO