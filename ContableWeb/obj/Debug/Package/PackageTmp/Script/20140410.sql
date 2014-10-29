GO

CREATE TABLE [dbo].[kit](
	[idKit] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[idProductoPrincipal] [int] NOT NULL,
 CONSTRAINT [PK_kit] PRIMARY KEY CLUSTERED 
(
	[idKit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GO
CREATE TABLE dbo.kitProducto
	(
	idKit int NOT NULL,
	idProducto int NOT NULL,
	cantdad int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.kitProducto ADD CONSTRAINT
	PK_kitProducto PRIMARY KEY CLUSTERED 
	(
	idKit,
	idProducto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
----------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[KitProductosSelect] (@idProducto INT)
AS
BEGIN
	SELECT	idProducto
	FROM dbo.kitproducto
	WHERE (idProducto = @idProducto)
END
GO
INSERT INTO pantalla VALUES (17,'frmKit.aspx','Kit','Tabla')
INSERT INTO usuarioPantalla VALUES (1,17,0)
GO
CREATE PROCEDURE [dbo].[KitVista] 
AS
BEGIN
	SELECT k.idKit,k.descripcion,p.descripcion as productoPrincipal
	FROM kit k INNER JOIN producto p on k.idProductoPrincipal = p.idProducto 
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE KitProductoInsert (
	@idKit INT,
	@idProducto INT ,
	@cantidad INT 
	
)
AS
BEGIN
	INSERT INTO dbo.kitProducto
	VALUES  ( @idKit,			 
	          @idProducto ,
	          @cantidad
	        )
	SELECT @idkit AS idKit
END
GO
GO
CREATE PROCEDURE [dbo].[KitProductoDelete] (@idkit INT)
AS
BEGIN
	DELETE
	FROM dbo.kitProducto
	WHERE (idKit = @idkit)
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[KitUpdate] (
	@idKit int,
	@descripcion varchar(50),
	@idProductoPrincipal INT 

	
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   kit SET
	         descripcion=@descripcion,
	         idProductoPrincipal=@idProductoPrincipal
	        
	WHERE idKit=@idKit 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   kit
	WHERE idKit=@idKit 
	-- End Return Select <- do not remove
	COMMIT

END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[KitInsert] (

	@descripcion varchar(50),
	@idProductoPrincipal INT 

	
)
AS
BEGIN
    BEGIN TRAN
    DECLARE @idkit INT
	SELECT @idkit = ISNULL(MAX(idKit),0)+1 FROM dbo.kit
	UPDATE   kit SET
	         descripcion=@descripcion,
	         idProductoPrincipal=@idProductoPrincipal
	        
	WHERE idKit=@idKit 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   kit
	WHERE idKit=@idKit 
	-- End Return Select <- do not remove
	COMMIT

END


GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[KitInsert] (

	@descripcion varchar(50),
	@idProductoPrincipal INT 

	
)
AS
BEGIN
    BEGIN TRAN
    DECLARE @idkit INT
	SELECT @idkit = ISNULL(MAX(idKit),0)+1 FROM dbo.kit
	INSERT INTO kit(idkit,descripcion,idProductoPrincipal) VALUES (@idkit,@descripcion,@idProductoPrincipal)
	        
	-- Begin Return Select <- do not remove
	SELECT @idKit as idKit
	-- End Return Select <- do not remove
	COMMIT

END
GO

GO
CREATE PROCEDURE [dbo].[kitSelect] 
    @idKit INT = NULL
AS 
	SELECT *
	FROM   kit 
	WHERE  (idKit = @idKit OR @idKit IS NULL) 


GO

GO
----------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[KitProductosSelect] (@idKit INT)
AS
BEGIN
	SELECT	*
	FROM dbo.kitproducto
	WHERE (idKit = @idKit)
END
GO
GO
ALTER PROCEDURE [dbo].[KitProductoDelete] (@idkit INT)
AS
BEGIN
	DELETE
	FROM dbo.kitProducto
	WHERE (idKit = @idkit)
	SELECT @idkit as idkit
END

Go
GO
ALTER PROCEDURE [dbo].[rptChequesCartera] (
	@desde DATE = null,
	@hasta DATE = null
)
AS
BEGIN
select ch.idCheque,
Convert(varchar(10),CONVERT(date,ch.fechaVencimiento,106),103) as fechaVencimiento,
Convert(varchar(10),CONVERT(date,ch.fechaEmision,106),103) as fechaEmision,
ch.enCartera,
ch.idCheque,
ch.idOrigenCheque,ch.importe,ch.numero,
b.descripcion as banco, cp.idPedido, cp.idCobro, cli.cuit, cli.razonSocial  from 
cheque ch inner join banco b
on b.idBanco = ch.idBanco
JOIN cobroCheque cc ON cc.idCheque = ch.idCheque
JOIN cobroPedido cp ON cp.idCobro = cc.idCobro
JOIN pedidoCabe pc on cp.idPedido = pc.idPedidoCabe
JOIN cliente cli on pc.idCliente = cli.idCliente
WHERE enCartera = 1
AND (pc.fechaPedido >= @desde or @desde is NULL) AND
			(pc.fechaPedido<= @hasta or @hasta is NULL)
	ORDER BY  pc.fechaPedido DESC
END
GO