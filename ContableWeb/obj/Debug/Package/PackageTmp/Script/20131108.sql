GO
GO

CREATE TABLE [dbo].[condicionIva](
	[idCondicionIva] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[letra] [char](1) NOT NULL,
 CONSTRAINT [pk_condicionIva] PRIMARY KEY CLUSTERED 
(
	[idCondicionIva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GO
CREATE TABLE [dbo].[provincia](
	[idProvincia] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [pk_provincia] PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE dbo.cliente
	(
	cuit int NOT NULL,
	razonSocial varchar(100) NULL,
	idLocalidad int NULL,
	domicilio varchar(100) NULL,
	codigoPostal char(10) NULL,
	idCondicionIva int NULL,
	telefono varchar(20) NULL,
	email varchar(100) NULL,
	observaciones varchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.cliente ADD CONSTRAINT
	PK_cliente PRIMARY KEY CLUSTERED 
	(
	cuit
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
CREATE TABLE dbo.localidad
	(
	idLocalidad int NOT NULL,
	idProvincia int NULL,
	descripcion varchar(150) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.localidad ADD CONSTRAINT
	PK_localidad PRIMARY KEY CLUSTERED 
	(
	idLocalidad
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
INSERT INTO localidad VALUES (1001,1,'AGRONOMIA')INSERT INTO localidad VALUES (1002,1,'ALMAGRO')INSERT INTO localidad VALUES (1003,1,'BALVANERA')INSERT INTO localidad VALUES (1004,1,'BARRACAS')INSERT INTO localidad VALUES (1005,1,'BELGRANO')INSERT INTO localidad VALUES (1006,1,'BOEDO')INSERT INTO localidad VALUES (1007,1,'CABALLITO')INSERT INTO localidad VALUES (1008,1,'CHACARITA')INSERT INTO localidad VALUES (1009,1,'COGHLAN')INSERT INTO localidad VALUES (1010,1,'COLEGIALES')INSERT INTO localidad VALUES (1011,1,'CONSTITUCION')INSERT INTO localidad VALUES (1012,1,'FLORES')INSERT INTO localidad VALUES (1013,1,'FLORESTA')INSERT INTO localidad VALUES (1014,1,'LA BOCA')INSERT INTO localidad VALUES (1015,1,'LA PATERNAL')INSERT INTO localidad VALUES (1016,1,'LINIERS')INSERT INTO localidad VALUES (1017,1,'MATADEROS')INSERT INTO localidad VALUES (1018,1,'MONTE CASTRO')INSERT INTO localidad VALUES (1019,1,'MONTSERRAT')INSERT INTO localidad VALUES (1020,1,'NUEVA POMPEYA')INSERT INTO localidad VALUES (1021,1,'NUÑEZ')INSERT INTO localidad VALUES (1022,1,'PALERMO')INSERT INTO localidad VALUES (1023,1,'PARQUE AVELLANEDA')INSERT INTO localidad VALUES (1024,1,'PARQUE CHACABUCO')INSERT INTO localidad VALUES (1025,1,'PARQUE CHAS')INSERT INTO localidad VALUES (1026,1,'PARQUE PATRICIOS')INSERT INTO localidad VALUES (1027,1,'PUERTO MADERO')INSERT INTO localidad VALUES (1028,1,'RECOLETA')INSERT INTO localidad VALUES (1029,1,'RETIRO')INSERT INTO localidad VALUES (1030,1,'SAAVEDRA')INSERT INTO localidad VALUES (1031,1,'SAN CRISTOBAL')INSERT INTO localidad VALUES (1032,1,'SAN NICOLAS')INSERT INTO localidad VALUES (1033,1,'SAN TELMO')INSERT INTO localidad VALUES (1034,1,'VELEZ SARFIELD')INSERT INTO localidad VALUES (1035,1,'VERSALLES')INSERT INTO localidad VALUES (1036,1,'VILLA CRESPO')INSERT INTO localidad VALUES (1037,1,'VILLA DEL PARQUE')INSERT INTO localidad VALUES (1038,1,'VILLA DEVOTO')INSERT INTO localidad VALUES (1039,1,'VILLA GENERAL MITRE')INSERT INTO localidad VALUES (1040,1,'VILLA LUGANO')INSERT INTO localidad VALUES (1041,1,'VILLA LURO')INSERT INTO localidad VALUES (1042,1,'VILLA ORTUZAR')INSERT INTO localidad VALUES (1043,1,'VILLA PUEYRREDON')INSERT INTO localidad VALUES (1044,1,'VILLA REAL')INSERT INTO localidad VALUES (1045,1,'VILLA RIACHUELO')INSERT INTO localidad VALUES (1046,1,'VILLA SANTA RITA')INSERT INTO localidad VALUES (1047,1,'VILLA SOLDATI')INSERT INTO localidad VALUES (1048,1,'VILLA URQUIZA')INSERT INTO localidad VALUES (2010,2,'ALMIRANTE BROWN')INSERT INTO localidad VALUES (2011,2,'BURZACO')INSERT INTO localidad VALUES (2012,2,'ADROGUE')INSERT INTO localidad VALUES (2013,2,'LONGCHAMPS')INSERT INTO localidad VALUES (2014,2,'JOSE MARMOL')INSERT INTO localidad VALUES (2015,2,'CLAYPOLE')INSERT INTO localidad VALUES (2016,2,'VILLA DOMINICO')INSERT INTO localidad VALUES (2017,2,'GLEW')INSERT INTO localidad VALUES (2021,2,'AVELLANEDA')INSERT INTO localidad VALUES (2022,2,'WILDE')INSERT INTO localidad VALUES (2023,2,'SARANDI')INSERT INTO localidad VALUES (2024,2,'ISLA MACIEL')INSERT INTO localidad VALUES (2025,2,'DOCK SUD')INSERT INTO localidad VALUES (2026,2,'GERLI')INSERT INTO localidad VALUES (2031,2,'PARQUE PEREYRA IRAOLA')INSERT INTO localidad VALUES (2032,2,'VILLA ELISA')INSERT INTO localidad VALUES (2033,2,'RANELAGH')INSERT INTO localidad VALUES (2034,2,'BERAZATEGUI')INSERT INTO localidad VALUES (2035,2,'PLATANOS')INSERT INTO localidad VALUES (2036,2,'GUILLERMO E. HUDSON')INSERT INTO localidad VALUES (2041,2,'CAÑUELAS')INSERT INTO localidad VALUES (2051,2,'ESCOBAR')INSERT INTO localidad VALUES (2052,2,'OTAMENDI')INSERT INTO localidad VALUES (2053,2,'ING. MASCHWITZ')INSERT INTO localidad VALUES (2054,2,'GARIN')INSERT INTO localidad VALUES (2060,2,'ESTEBAN ECHEVERRIA')INSERT INTO localidad VALUES (2061,2,'EZEIZA')INSERT INTO localidad VALUES (2062,2,'MONTE GRANDE')INSERT INTO localidad VALUES (2063,2,'LUIS GUILLON')INSERT INTO localidad VALUES (2064,2,'CARLOS SPEGAZZINI')INSERT INTO localidad VALUES (2071,2,'FLORENCIO VARELA')INSERT INTO localidad VALUES (2081,2,'GRAL. LAS HERAS')INSERT INTO localidad VALUES (2091,2,'SAN MARTIN')INSERT INTO localidad VALUES (2092,2,'VILLA BALLESTER')INSERT INTO localidad VALUES (2093,2,'JOSE LEON SUAREZ')INSERT INTO localidad VALUES (2094,2,'SAN ANDRES')INSERT INTO localidad VALUES (2095,2,'VILLA BONICH')INSERT INTO localidad VALUES (2096,2,'VILLA LYNCH')INSERT INTO localidad VALUES (2097,2,'VILLA MAIPU')INSERT INTO localidad VALUES (2100,2,'GRAL. SARMIENTO')INSERT INTO localidad VALUES (2101,2,'SAN MIGUEL')INSERT INTO localidad VALUES (2102,2,'BELLA VISTA')INSERT INTO localidad VALUES (2103,2,'JOSE C. PAZ')INSERT INTO localidad VALUES (2104,2,'DEL VISO')INSERT INTO localidad VALUES (2105,2,'MUÑIZ')INSERT INTO localidad VALUES (2106,2,'ING.PABLO NOGUES')INSERT INTO localidad VALUES (2111,2,'LANUS')INSERT INTO localidad VALUES (2112,2,'REMEDIOS DE ESCALADA')INSERT INTO localidad VALUES (2113,2,'MONTE CHINGOLO')INSERT INTO localidad VALUES (2114,2,'VALENTIN ALSINA')INSERT INTO localidad VALUES (2121,2,'LLAVALLOL')INSERT INTO localidad VALUES (2122,2,'TEMPERLEY')INSERT INTO localidad VALUES (2123,2,'LOMAS DE ZAMORA')INSERT INTO localidad VALUES (2124,2,'BANFIELD')INSERT INTO localidad VALUES (2131,2,'MARCOS PAZ')INSERT INTO localidad VALUES (2140,2,'LA TABLADA')INSERT INTO localidad VALUES (2141,2,'RAMOS MEJIA')INSERT INTO localidad VALUES (2142,2,'SAN JUSTO')INSERT INTO localidad VALUES (2143,2,'LOMAS DEL MIRADOR')INSERT INTO localidad VALUES (2144,2,'LAFERRERE')INSERT INTO localidad VALUES (2145,2,'ISIDRO CASANOVA')INSERT INTO localidad VALUES (2146,2,'VILLA MADERO')INSERT INTO localidad VALUES (2147,2,'VILLA CELINA')INSERT INTO localidad VALUES (2148,2,'CIUDAD EVITA')INSERT INTO localidad VALUES (2149,2,'TAPIALES')INSERT INTO localidad VALUES (2151,2,'SAN ANTONIO DE PADUA')INSERT INTO localidad VALUES (2152,2,'MERLO')INSERT INTO localidad VALUES (2153,2,'LIBERTAD')INSERT INTO localidad VALUES (2154,2,'MARIANO ACOSTA')INSERT INTO localidad VALUES (2161,2,'MORENO')INSERT INTO localidad VALUES (2162,2,'PASO DEL REY')INSERT INTO localidad VALUES (2163,2,'FRANCISCO ALVAREZ')INSERT INTO localidad VALUES (2171,2,'MORON')INSERT INTO localidad VALUES (2172,2,'CASTELAR')INSERT INTO localidad VALUES (2173,2,'VILLA SARMIENTO')INSERT INTO localidad VALUES (2174,2,'VILLA UDAONDO')INSERT INTO localidad VALUES (2175,2,'HAEDO')INSERT INTO localidad VALUES (2176,2,'VILLA TESEI')INSERT INTO localidad VALUES (2177,2,'HURLINGHAM')INSERT INTO localidad VALUES (2178,2,'ITUZAINGO')INSERT INTO localidad VALUES (2179,2,'EL PALOMAR')INSERT INTO localidad VALUES (2181,2,'PILAR')INSERT INTO localidad VALUES (2182,2,'TORTUGUITAS')INSERT INTO localidad VALUES (2191,2,'QUILMES')INSERT INTO localidad VALUES (2192,2,'BERNAL')INSERT INTO localidad VALUES (2193,2,'EZPELETA')INSERT INTO localidad VALUES (2194,2,'DON BOSCO')INSERT INTO localidad VALUES (2195,2,'SAN FRANCISCO SOLANO')INSERT INTO localidad VALUES (2201,2,'CANAL SAN FERNANDO')INSERT INTO localidad VALUES (2202,2,'RIO PARANA MINI ISLAS')INSERT INTO localidad VALUES (2203,2,'VICTORIA')INSERT INTO localidad VALUES (2204,2,'SAN FERNANDO')INSERT INTO localidad VALUES (2205,2,'PUNTA CHICA')INSERT INTO localidad VALUES (2206,2,'VIRREYES')INSERT INTO localidad VALUES (2211,2,'SAN ISIDRO')INSERT INTO localidad VALUES (2212,2,'MARTINEZ')INSERT INTO localidad VALUES (2213,2,'BOULOGNE SUR MER')INSERT INTO localidad VALUES (2214,2,'VILLA ADELINA')INSERT INTO localidad VALUES (2215,2,'ACASSUSO')INSERT INTO localidad VALUES (2216,2,'BECCAR')INSERT INTO localidad VALUES (2221,2,'SAN VICENTE')INSERT INTO localidad VALUES (2231,2,'TIGRE')INSERT INTO localidad VALUES (2232,2,'GENERAL PACHECO')INSERT INTO localidad VALUES (2233,2,'DON TORCUATO')INSERT INTO localidad VALUES (2234,2,'EL TALAR')INSERT INTO localidad VALUES (2235,2,'BENAVIDEZ')INSERT INTO localidad VALUES (2240,2,'TRES DE FEBRERO')INSERT INTO localidad VALUES (2241,2,'MIGUELETE')INSERT INTO localidad VALUES (2242,2,'CASEROS')INSERT INTO localidad VALUES (2243,2,'CIUDADELA')INSERT INTO localidad VALUES (2244,2,'SAENZ PEÑA')INSERT INTO localidad VALUES (2245,2,'MARTIN CORONADO')INSERT INTO localidad VALUES (2246,2,'SANTOS LUGARES')INSERT INTO localidad VALUES (2247,2,'VILLA BOSCH')INSERT INTO localidad VALUES (2248,2,'PABLO PODESTA')INSERT INTO localidad VALUES (2249,2,'EL PALOMAR')INSERT INTO localidad VALUES (2251,2,'VICENTE LOPEZ')INSERT INTO localidad VALUES (2252,2,'VILLA MARTELLI')INSERT INTO localidad VALUES (2253,2,'OLIVOS')
GO
CREATE PROCEDURE clienteVista
AS
BEGIN
	SELECT	c.cuit,c.razonSocial,l.descripcion as 'localidad',
	c.domicilio,c.codigoPostal,
	ci.descripcion as 'condicionIva',
	c.telefono,c.email,c.observaciones
	FROM dbo.cliente c
	JOIN dbo.localidad l ON c.idLocalidad = l.idLocalidad
	JOIN dbo.condicionIva ci ON c.idCondicionIva = ci.idCondicionIva
	ORDER BY c.razonSocial
END
GO
GO
CREATE PROCEDURE [dbo].[clienteInsert] (
    @cuit bigint,@razonSocial varchar(100),@idLocalidad int,@domicilio varchar(100),
    @codigoPostal char(10),@idCondicionIva int,@telefono varchar(20),@email varchar(100),
    @observaciones varchar(250)
)
AS 
	BEGIN TRAN

	INSERT INTO cliente (cuit,razonSocial,idLocalidad,domicilio,codigoPostal,idCondicionIva,telefono,email,observaciones)
	SELECT   @cuit,@razonSocial,@idLocalidad,@domicilio,@codigoPostal,@idCondicionIva,@telefono,@email,@observaciones
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cliente
	WHERE  cuit = @cuit
	-- End Return Select <- do not remove
               
	COMMIT
GO

CREATE PROCEDURE [dbo].[clienteUpdate] (
   @cuit bigint,
   @razonSocial varchar(100),
   @idLocalidad int,
   @domicilio varchar(100),
   @codigoPostal char(10),
   @idCondicionIva int,
   @telefono varchar(20),
   @email varchar(100),
   @observaciones varchar(250)
)
AS 
	BEGIN TRAN
	UPDATE dbo.cliente
	SET     razonSocial = @razonSocial,idLocalidad= @idLocalidad,domicilio = @domicilio,
	codigoPostal=@codigoPostal,idCondicionIva=@idCondicionIva,telefono=@telefono,
	email=@email,observaciones=@observaciones
	WHERE  cuit = @cuit
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cliente
	WHERE  cuit = @cuit
	-- End Return Select <- do not remove
	COMMIT

GO
CREATE PROCEDURE [dbo].[clienteSelect] (
    @cuit bigint = NULL
)
AS 
	BEGIN TRAN
	SELECT *
	FROM   dbo.cliente 
	WHERE  (cuit = @cuit OR @cuit IS NULL)
	COMMIT
GO	

---------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[LocalidadPorProvinciaSelect] (
	@idProvincia INT = NULL
)
AS
BEGIN
	SELECT	idLocalidad , idProvincia,
	        descripcion
	FROM dbo.localidad
	WHERE idProvincia = @idProvincia
	ORDER BY descripcion
END
GO
GO
CREATE TABLE dbo.Tmp_cliente
	(
	cuit bigint NOT NULL,
	razonSocial varchar(100) NULL,
	idLocalidad int NULL,
	domicilio varchar(100) NULL,
	codigoPostal char(10) NULL,
	idCondicionIva int NULL,
	telefono varchar(20) NULL,
	email varchar(100) NULL,
	observaciones varchar(250) NULL
	)  ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.cliente)
	 EXEC('INSERT INTO dbo.Tmp_cliente (cuit, razonSocial, idLocalidad, domicilio, codigoPostal, idCondicionIva, telefono, email, observaciones)
		SELECT CONVERT(bigint, cuit), razonSocial, idLocalidad, domicilio, codigoPostal, idCondicionIva, telefono, email, observaciones FROM dbo.cliente WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.cliente
GO
EXECUTE sp_rename N'dbo.Tmp_cliente', N'cliente', 'OBJECT' 
GO
ALTER TABLE dbo.cliente ADD CONSTRAINT
	PK_cliente PRIMARY KEY CLUSTERED 
	(
	cuit
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
-------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[localidadSelect] (
	@idLocalidad INT = NULL
)
AS
BEGIN
	SELECT	idLocalidad ,
			idProvincia,
	        descripcion
	FROM dbo.localidad
	WHERE idLocalidad = ISNULL(@idLocalidad,idLocalidad)
	ORDER BY descripcion
END
GO
CREATE PROCEDURE [dbo].[provinciaSelect] (
	@idProvincia INT = NULL
)
AS
BEGIN
	SELECT	idProvincia ,
	        descripcion
	FROM dbo.provincia
	WHERE idProvincia = ISNULL(@idProvincia,idProvincia)
	ORDER BY descripcion
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[condicionIvaSelect] (
	@idCondicionIva INT = NULL
)
AS
BEGIN
	SELECT	idCondicionIva ,
	        descripcion, 
	        letra
	FROM dbo.condicionIva
	WHERE idCondicionIva = ISNULL(@idCondicionIva,idCondicionIva)
	ORDER BY descripcion
END
GO

GO

CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] NOT NULL,
	[nombreUsuario] [varchar](100) NOT NULL,
	[clave] [varchar](100) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[email] [varchar](255) NOT NULL,
 CONSTRAINT [pk_usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uq_usuario_nombreUsuario] UNIQUE NONCLUSTERED 
(
	[nombreUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
CREATE PROCEDURE [dbo].[usuarioSelect] (
    @idUsuario INT = NULL,
	@nombreUsuario VARCHAR(100) = NULL
)
AS 
	BEGIN TRAN
	SELECT [idUsuario], [nombreUsuario], [clave], [nombre], [email] 
	FROM   [dbo].[usuario] 
	WHERE  idUsuario = COALESCE(@idUsuario,idUsuario) AND
		   nombreUsuario = COALESCE(@nombreUsuario,nombreUsuario)
	COMMIT

GO
INSERT INTO provincia VALUES (1,'Capital Federal')
INSERT INTO provincia VALUES (2,'Buenos Aires')

INSERT INTO condicionIva VALUES (	1	,'IVA Responsable inscripto	','A')
INSERT INTO condicionIva VALUES (	2	,'IVA Responsable no inscripto	','B')
INSERT INTO condicionIva VALUES (	3	,'IVA no responsable	','B')
INSERT INTO condicionIva VALUES (	4	,'IVA Sujeto Exento	','B')
INSERT INTO condicionIva VALUES (	5	,'Consumidor Final	','B')
INSERT INTO condicionIva VALUES (	6	,'Responsable Monotributo	','B')
INSERT INTO condicionIva VALUES (	7	,'Sujeto no categorizado	','B')
INSERT INTO condicionIva VALUES (	8	,'Importador del exterior	','E')
INSERT INTO condicionIva VALUES (	9	,'Cliente del Exterior	','E')
INSERT INTO condicionIva VALUES (	10	,'IVA Liberado - Ley N° 19640	','B')
INSERT INTO condicionIva VALUES (	11	,'IVA Responsable Inscripto - Agente de Percepción	','A')

INSERT INTO usuario VALUES (1,'admin','clave','admin','a@a.com')