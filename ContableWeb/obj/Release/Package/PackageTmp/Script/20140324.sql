GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[CompraCabeInsert] (
	@cuitProveedor BIGINT,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
	@idTipoOrden INT,
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
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitProveedor ,
	          @fechaCompra ,
	          @idEstadoPedido ,
	          @idTipoOrden ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[CompraCabeUpdate] (
	@idCompraCabe int,
	@cuitProveedor bigint,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
	@idTipoOrden INT,
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
update compraCabe set idTipoOrden = 1
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeUpdate] (
	@idPedidoCabe int,
	@cuitCliente bigint,
	@fechaPedido DATETIME ,
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
---------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeInsert] (
	@cuitCliente BIGINT,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
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
	         orden,
	         idEstadoPedido,
	         idTipoOrden,
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitCliente ,
	          @fechaPedido ,
	          @orden , 
	          @idEstadoPedido ,
	          @idTipoOrden ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO