GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ProveedorVistaPorCuitORazon] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(p.cuit as varchar(20)) + ' - ' +  p.razonSocial AS descripcion
	FROM dbo.proveedor p
	WHERE p.razonSocial LIKE '%'+@descripcion+'%' 
	OR CAST(p.cuit as varchar(20)) LIKE '%'+@descripcion+'%'
	ORDER BY p.cuit
END
GO
CREATE PROCEDURE [dbo].[PedidoItemDelete] (@idPedidoCabe INT)
AS
BEGIN
	DELETE
	FROM dbo.pedidoItem
	WHERE (idPedido = @idPedidoCabe)
END
GO
CREATE PROCEDURE [dbo].[CompraItemsSelect] (@idCompra INT)
AS
BEGIN
	SELECT	idCompraItem
	FROM dbo.compraItem
	WHERE idCompra = @idCompra
END
GO
GO
CREATE PROCEDURE [dbo].[CompraItemDelete] (@idCompraCabe INT)
AS
BEGIN
	DELETE
	FROM dbo.compraItem
	WHERE (idCompra = @idCompraCabe)
END
GO

----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[CompraCabeInsert] (
	@cuitProveedor BIGINT,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
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
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitProveedor ,
	          @fechaCompra ,
	          @idEstadoPedido ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[CompraCabeUpdate] (
	@idCompraCabe int,
	@cuitProveedor bigint,
	@fechaCompra DATETIME ,
	@idEstadoPedido INT ,
	@observaciones Varchar(250)
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   compraCabe SET
	         cuitProveedor=@cuitProveedor,
	         fechaCompra=@fechaCompra,
	         idEstado=@idEstadoPedido,
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
GO
CREATE PROCEDURE [dbo].[CompraCabeSelect] (
    @idCompraCabe int = NULL
)
AS 
	BEGIN TRAN
	SELECT *
	FROM   dbo.compraCabe 
	WHERE  (idCompraCabe = @idCompraCabe OR @idCompraCabe IS NULL)
	COMMIT
GO