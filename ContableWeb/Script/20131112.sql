GO
CREATE TABLE [dbo].[alicuotaIva](
	[idAlicuotaIva] [int] NOT NULL,
	[valor] [float] NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_alicuotaIva] PRIMARY KEY CLUSTERED 
(
	[idAlicuotaIva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE PROCEDURE [dbo].[alicuotaIvaSelect] 
    @idAlicuota INT = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT idAlicuotaIva,valor,descripcion
	FROM   dbo.alicuotaIva
	WHERE  (idAlicuotaIva = @idAlicuota OR @idAlicuota IS NULL) 

	COMMIT
GO
GO

CREATE TABLE [dbo].[producto](
	[idProducto] [int] NOT NULL,
	[idFamilia] [int] NULL,
	[idAlicuotaIva] [int] NULL,
	[descripcion] [varchar](150) NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
delete from usuario where idUsuario = 1
INSERT INTO Usuario VALUES (1,'admin','clave','admin','maria.gaska@gmail.com')