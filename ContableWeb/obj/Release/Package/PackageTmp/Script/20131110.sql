GO
CREATE TABLE dbo.proveedor
	(
	cuit bigint NOT NULL,
	razonSocial varchar(100) NULL,
	idLocalidad int NULL,
	domicilio varchar(100) NULL,
	codigoPostal char(10) NULL,
	telefono varchar(20) NULL,
	email varchar(100) NULL,
	observaciones varchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.proveedor ADD CONSTRAINT
	PK_proveedor PRIMARY KEY CLUSTERED 
	(
	cuit
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
CREATE PROCEDURE proveedorVista
AS
BEGIN
	SELECT	p.cuit,p.razonSocial,l.descripcion as 'localidad',
	p.domicilio,p.codigoPostal,
	p.telefono,p.email,p.observaciones
	FROM dbo.proveedor p
	JOIN dbo.localidad l ON p.idLocalidad = l.idLocalidad
	ORDER BY p.razonSocial
END
GO
GO
CREATE PROCEDURE [dbo].[proveedorInsert] (
    @cuit bigint,@razonSocial varchar(100),@idLocalidad int,@domicilio varchar(100),
    @codigoPostal char(10),@telefono varchar(20),@email varchar(100),
    @observaciones varchar(250)
)
AS 
	BEGIN TRAN

	INSERT INTO proveedor (cuit,razonSocial,idLocalidad,domicilio,codigoPostal,telefono,email,observaciones)
	SELECT   @cuit,@razonSocial,@idLocalidad,@domicilio,@codigoPostal,@telefono,@email,@observaciones
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   proveedor
	WHERE  cuit = @cuit
	-- End Return Select <- do not remove
               
	COMMIT
GO

CREATE PROCEDURE [dbo].[proveedorUpdate] (
   @cuit bigint,
   @razonSocial varchar(100),
   @idLocalidad int,
   @domicilio varchar(100),
   @codigoPostal char(10),
   @telefono varchar(20),
   @email varchar(100),
   @observaciones varchar(250)
)
AS 
	BEGIN TRAN
	UPDATE dbo.proveedor
	SET     razonSocial = @razonSocial,idLocalidad= @idLocalidad,domicilio = @domicilio,
	codigoPostal=@codigoPostal,telefono=@telefono,
	email=@email,observaciones=@observaciones
	WHERE  cuit = @cuit
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   proveedor
	WHERE  cuit = @cuit
	-- End Return Select <- do not remove
	COMMIT

GO
CREATE PROCEDURE [dbo].[proveedorSelect] (
    @cuit bigint = NULL
)
AS 
	BEGIN TRAN
	SELECT *
	FROM   dbo.proveedor 
	WHERE  (cuit = @cuit OR @cuit IS NULL)
	COMMIT
GO	

CREATE TABLE [dbo].[familia](
	[idFamilia] [int] NOT NULL,
	[descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_familia] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE PROCEDURE [dbo].[familiaInsert] 
    @descripcion varchar(200)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
    DECLARE @idFamilia INT
	SELECT @idFamilia = ISNULL(MAX(idFamilia),0)+1 FROM dbo.familia

	INSERT INTO [dbo].[familia] ([idFamilia], [descripcion])
	SELECT @idFamilia, @descripcion
	
	-- Begin Return Select <- do not remove
	SELECT [idFamilia], [descripcion]
	FROM   [dbo].[familia]
	WHERE  [idFamilia] = @idFamilia
	-- End Return Select <- do not remove
               
	COMMIT
GO
CREATE PROCEDURE [dbo].[familiaSelect] 
    @idFamilia INT = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idFamilia], [descripcion]  
	FROM   [dbo].[familia] 
	WHERE  ([idFamilia] = @idFamilia OR @idFamilia IS NULL) 

	COMMIT
GO
CREATE PROCEDURE [dbo].[familiaUpdate] 
    @idFamilia int,
    @descripcion varchar(100)
   
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[familia]
	SET    [idFamilia] = @idFamilia, [descripcion] = @descripcion
	WHERE  [idFamilia] = @idFamilia
	
	-- Begin Return Select <- do not remove
	SELECT [idFamilia], [descripcion]
	FROM   [dbo].[familia]
	WHERE  [idFamilia] = @idFamilia	
	-- End Return Select <- do not remove

	COMMIT
GO