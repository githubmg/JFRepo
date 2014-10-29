GO
ALTER TABLE dbo.producto ADD
	codProducto char(20) NULL
GO
GO
ALTER PROCEDURE [dbo].[productoInsert] (
   @descripcion varchar(150),
   @idFamilia int,
   @idAlicuotaIva int,
   @codProducto char(20)
)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
    DECLARE @idProducto INT
	SELECT @idProducto = ISNULL(MAX(idProducto),0)+1 FROM dbo.producto

	INSERT INTO producto (idProducto,idFamilia,idAlicuotaIva,descripcion,codProducto)
	SELECT   @idProducto,@idFamilia,@idAlicuotaIva,@descripcion,@codProducto
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   producto
	WHERE  idProducto = @idProducto
	-- End Return Select <- do not remove
               
	COMMIT

GO
GO

ALTER PROCEDURE [dbo].[productoUpdate] (
   @idProducto int,
   @descripcion varchar(150),
   @idFamilia int,
   @idAlicuotaIva int,
   @codProducto char(20)
)
AS 
	BEGIN TRAN
	UPDATE dbo.producto
	SET    idFamilia=@idFamilia,idAlicuotaIva=@idAlicuotaIva,descripcion=@descripcion, codProducto = @codProducto
	WHERE  idProducto = @idProducto
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   producto
	WHERE  idProducto = @idProducto
	-- End Return Select <- do not remove
	COMMIT

GO

GO
ALTER PROCEDURE [dbo].[productoVista]
AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia', a.descripcion as 'alicuotaIva',p.descripcion,
	p.codProducto
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	JOIN dbo.alicuotaIva a ON a.idAlicuotaIva = p.idAlicuotaIva
	ORDER BY p.descripcion
END
GO
ALTER PROCEDURE [dbo].[ProductoVistaByFamilia](
@idFamilia int
)

AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia', a.descripcion as 'alicuotaIva',p.descripcion,
	p.codProducto
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	JOIN dbo.alicuotaIva a ON a.idAlicuotaIva = p.idAlicuotaIva
	WHERE f.idFamilia = @idFamilia 
	ORDER BY p.descripcion
END
GO

update producto set codProducto = ''
GO
ALTER TABLE dbo.pedidoCabe
	DROP COLUMN descuento
GO
GO
ALTER TABLE dbo.pedidoItem
	DROP COLUMN descuentoUnitario
GO
GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeInsert] (
	@cuitCliente INT,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
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
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitCliente ,
	          @fechaPedido ,
	          @orden , 
	          @idEstadoPedido ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
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
	ep.descripcion as 'estado'
	FROM pedidoCabe pc 
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
END
GO

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoItemInsert] (
	@idPedido INT,
	@idProducto INT ,
	@cantidad INT ,
	@chasis Varchar(50),
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
	          chasis ,
	          precioUnitario ,
	          observaciones
	        )
	VALUES  ( @idPedidoItem,
			  @idPedido ,
	          @idProducto ,
	          @cantidad , 
	          @chasis ,
	          @precioUnitario,
	          @observaciones
	        )
	SELECT @idPedidoItem AS idPedidoItem
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeUpdate] (
	@idPedidoCabe int,
	@cuitCliente bigint,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
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


----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeInsert] (
	@cuitCliente BIGINT,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
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
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitCliente ,
	          @fechaPedido ,
	          @orden , 
	          @idEstadoPedido ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO