GO

CREATE TABLE [dbo].[pantalla](
	[idPantalla] [int] NOT NULL,
	[url] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_pantalla] PRIMARY KEY CLUSTERED 
(
	[idPantalla] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GO

CREATE TABLE [dbo].[usuarioPantalla](
	[idUsuario] [int] NOT NULL,
	[idPantalla] [int] NOT NULL,
 CONSTRAINT [PK_usuarioPantalla] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idPantalla] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.pantalla ADD
	tipo varchar(50) NULL
GO

INSERT INTO pantalla VALUES (1,'frmCliente.aspx','Cliente','Tabla')
INSERT INTO pantalla VALUES (2,'frmFamilia.aspx','Familia','Tabla')
INSERT INTO pantalla VALUES (3,'frmProducto.aspx','Producto','Tabla')
INSERT INTO pantalla VALUES (4,'frmProveedor.aspx','Proveedor','Tabla')

INSERT INTO usuarioPantalla
SELECT 1,idPantalla FROM pantalla
GO
CREATE PROCEDURE [dbo].[usuarioPantallasByTipo] (
    @idUsuario INT = NULL,
    @tipo VARCHAR(50) = NULL
)
AS 
	BEGIN TRAN
	SELECT p.*
	FROM   usuarioPantalla up JOIN pantalla p ON up.idPantalla = p.idPantalla
	WHERE (up.idUsuario = @idUsuario OR @idUsuario is Null) AND
	(p.tipo = @tipo OR @tipo is NULL)	
	
	COMMIT
	
GO	


