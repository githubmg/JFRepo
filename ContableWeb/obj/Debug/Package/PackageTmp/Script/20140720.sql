GO
CREATE PROCEDURE [dbo].[ubicacionStockSelect] 
    @idUbicacionStock INT = NULL
AS 
	SELECT [idUbicacionStock], [descripcion]  
	FROM   [dbo].[ubicacionStock] 
	WHERE  ([idUbicacionStock] = @idUbicacionStock OR @idUbicacionStock IS NULL) 

GO
GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[CompraCabeInsert] (
	@cuitProveedor BIGINT,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
	@idTipoOrden INT,
	@idUbicacionStock INT,
	@observaciones Varchar(250)
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
	         idUbicacionStock
			  
	        )
	VALUES  ( @idCabe,
			  @cuitProveedor ,
	          @fechaCompra ,
	          @idEstadoPedido ,
	          @idTipoOrden ,
	          @observaciones,
	          @idUbicacionStock 
	        )
	SELECT @idCabe AS idCabe
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[CompraCabeUpdate] (
	@idCompraCabe int,
	@cuitProveedor bigint,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
	@idTipoOrden INT,
	@idUbicacionStock INT,
	@observaciones Varchar(250)
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
	         observaciones=@observaciones
	WHERE idCompraCabe=@idCompraCabe 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   compraCabe
	WHERE  idCompraCabe = @idCompraCabe
	-- End Return Select <- do not remove
	COMMIT

END
GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeInsert] (
	@idCliente INT,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@chasis Varchar(50) ,
	@idEstadoPedido INT ,
	@idTipoOrden INT ,
	@idUbicacionStock INT,
	@observaciones Varchar(250)
)
AS
BEGIN
	DECLARE @idCabe INT
	SELECT @idCabe = ISNULL(MAX(idPedidoCabe),0)+1 FROM dbo.pedidoCabe
	INSERT INTO dbo.pedidoCabe
	        ( idPedidoCabe, 
	         idCliente,
	         fechaPedido,
	         chasis,
	         orden,
	         idEstadoPedido,
	         idTipoOrden,
	         idUbicacionStock,
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @idCliente ,
	          @fechaPedido ,
	          @chasis ,
	          @orden , 
	          @idEstadoPedido ,
	          @idTipoOrden ,
	          @idUbicacionStock,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeUpdate] (
	@idPedidoCabe int,
	@idCliente bigint,
	@fechaPedido DATETIME ,
	@chasis varchar(50),
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
	@idTipoOrden INT ,
	@idUbicacionStock INT,
	@observaciones Varchar(250)
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   pedidoCabe SET
	         idCliente=@idCliente,
	         fechaPedido=@fechaPedido,
	         chasis=@chasis,
	         orden=@orden,
	         idEstadoPedido=@idEstadoPedido,
	         idTipoOrden=@idTipoOrden,
	         observaciones=@observaciones,
	         idUbicacionStock=@idUbicacionStock
	WHERE idPedidoCabe=@idPedidoCabe 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   pedidoCabe
	WHERE  idPedidoCabe = @idPedidoCabe
	-- End Return Select <- do not remove
	COMMIT

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
	c.razonSocial as 'razonSocial',
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
	tor.descripcion as 'tipoOrden',
	convert(varchar, pc.fechaPedido, 103)AS fechaString,
	uc.descripcion as ubicacionStock
	FROM pedidoCabe pc 
	 INNER JOIN cliente c ON pc.idCliente = c.idCliente
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	 INNER JOIN tipoOrden tor ON tor.idTipoOrden = pc.idTipoOrden
	 LEFT JOIN ubicacionStock uc ON pc.idUbicacionStock = uc.idUbicacionStock
END
GO
UPDATE pedidoCabe SET idUbicacionStock = 1
UPDATE compraCabe SET idUbicacionStock = 1
INSERT INTO tipoMovimiento VALUES (3,'Movimiento entre depósitos')
GO
CREATE TABLE dbo.movimientoStockOrigenDestino
	(
	idMovimientoStock int NOT NULL,
	idUbicacionOrigen int NULL,
	idUbicacionDestino int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.movimientoStockOrigenDestino ADD CONSTRAINT
	PK_movimientoStockOrigenDestino PRIMARY KEY CLUSTERED 
	(
	idMovimientoStock
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE dbo.movimientoStockOrigenDestino ADD CONSTRAINT
	FK_movimientoStockOrigenDestino_movimientoStock FOREIGN KEY
	(
	idMovimientoStock
	) REFERENCES dbo.movimientoStock
	(
	idMovimientoStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.movimientoStockOrigenDestino ADD CONSTRAINT
	FK_movimientoStockOrigenDestino_ubicacionStock FOREIGN KEY
	(
	idUbicacionDestino
	) REFERENCES dbo.ubicacionStock
	(
	idUbicacionStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.movimientoStockOrigenDestino ADD CONSTRAINT
	FK_movimientoStockOrigenDestino_ubicacionStock1 FOREIGN KEY
	(
	idUbicacionOrigen
	) REFERENCES dbo.ubicacionStock
	(
	idUbicacionStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

CREATE PROCEDURE [dbo].[movimientoStockOrigenDestinoInsert] 
    @idMovimiento INT,
    @idUbicacionStockOrigen INT,
    @idUbicacionStockDestino INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO movimientoStockOrigenDestino(idMovimientoStock,idUbicacionOrigen,idUbicacionDestino)
	SELECT @idMovimiento,@idUbicacionStockOrigen, @idUbicacionStockDestino
	
	-- Begin Return Select <- do not remove
	SELECT * FROM movimientoStockOrigenDestino WHERE idMovimientoStock = @idMovimiento
	-- End Return Select <- do not remove
               
	COMMIT
GO
CREATE PROCEDURE [dbo].[movimientoStockOrigenDestinoDelete] 
    @idMovimiento INT
   
AS 
	DELETE FROM movimientoStockOrigenDestinoDelete WHERE idMovimientoStock = @idMovimiento
GO