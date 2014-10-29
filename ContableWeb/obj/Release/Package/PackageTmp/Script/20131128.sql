INSERT INTO estadoPedido VALUES (1,'Pendiente')
INSERT INTO estadoPedido VALUES (2,'Terminado')
INSERT INTO estadoPedido VALUES (3,'Anulado')
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[pedidoCabeVista] 
AS
BEGIN
	SELECT pc.idPedidoCabe,
	pc.fechaPedido, 
	pc.orden,
	ep.descripcion as 'estado',
	pc.descuento
	FROM pedidoCabe pc 
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
END
GO
GO
ALTER TABLE dbo.usuarioPantalla ADD
	esPantallaPrincipal int NULL
GO
GO
ALTER PROCEDURE [dbo].[usuarioSelect] (
    @idUsuario INT = NULL,
	@nombreUsuario VARCHAR(100) = NULL
)
AS 

	SELECT u.idUsuario, u.nombreUsuario, u.clave, u.nombre, u.email ,
	p.url as pantalla
	FROM   usuario u
	INNER JOIN usuarioPantalla up ON up.idUsuario = u.idUsuario
	INNER JOIN pantalla p ON p.idPantalla = up.idPantalla
	WHERE  u.idUsuario = COALESCE(@idUsuario,u.idUsuario) AND
		   u.nombreUsuario = COALESCE(@nombreUsuario,u.nombreUsuario) AND
		   up.esPantallaPrincipal = 1

GO
INSERT INTO Pantalla VALUES (5,'frmPedido.aspx','Pedido','Tabla')
INSERT INTO usuarioPantalla VALUES (1,5,0)
GO
CREATE PROCEDURE [dbo].[PedidoItemsSelect] (@idPedido INT)
AS
BEGIN
	SELECT	idPedidoItem
	FROM dbo.pedidoItem
	WHERE idPedido = @idPedido
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoItemInsert] (
	@idPedido INT,
	@idProducto INT ,
	@cantidad INT ,
	@chasis Varchar(50),
	@precioUnitario float,
	@descuentoUnitario float,
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
	          descuentoUnitario ,
	          observaciones
	        )
	VALUES  ( @idPedidoItem,
			  @idPedido ,
	          @idProducto ,
	          @cantidad , 
	          @chasis ,
	          @precioUnitario ,
	          @descuentoUnitario ,
	          @observaciones
	        )
	SELECT @idPedidoItem AS idPedidoItem
END
GO

----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoCabeInsert] (
	@cuitCliente INT,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
	@descuento FLOAT ,
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
	         descuento,
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitCliente ,
	          @fechaPedido ,
	          @orden , 
	          @idEstadoPedido ,
	          @descuento ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO
CREATE PROCEDURE [dbo].[estadoPedidoSelect] 
    @idEstadoPedido INT = NULL
AS 
	SELECT *
	FROM   dbo.estadoPedido
	WHERE  (idEstadoPedido = @idEstadoPedido OR @idEstadoPedido IS NULL) 

GO
UPDATE usuarioPantalla set esPantallaPrincipal = 1 WHERE idUsuario = 1 and 
idPantalla = 1 
