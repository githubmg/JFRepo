
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UsuarioInsert] (
	@nombreUsuario varchar(100),
	@clave varchar(100),
	@nombre varchar(100),
	@email varchar(255)
	
)
AS
BEGIN
	DECLARE @idUsuario INT
	SELECT @idUsuario = ISNULL(MAX(idUsuario),0)+1 FROM dbo.usuario
	INSERT INTO dbo.usuario
	        ( 
	        idUsuario,
	        nombreUsuario,
	        clave,
	        nombre,
	        email
	        )
	VALUES  ( 
			@idUsuario,
	        @nombreUsuario,
	        @clave,
	        @nombre,
	        @email				
	        )
	SELECT @idUsuario AS 'idUsuario'
END
GO
INSERT INTO pantalla VALUES (21,'frmUsuario.aspx','Usuario','Tabla')
INSERT INTO usuarioPantalla VALUES (1,21,0)

GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UsuarioUpdate] (
	@idUsuario INT,
	@nombreUsuario varchar(100),
	@clave varchar(100),
	@nombre varchar(100),
	@email varchar(255)
	
)
AS
BEGIN
	
	UPDATE dbo.usuario
	        SET
	        nombreUsuario=@nombreUsuario,
	        clave=@clave,
	        nombre=@nombre,
	        email=@email
	WHERE @idUsuario =idUsuario
END
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
	LEFT JOIN usuarioPantalla up ON up.idUsuario = u.idUsuario
	LEFT JOIN pantalla p ON p.idPantalla = up.idPantalla
	WHERE  u.idUsuario = COALESCE(@idUsuario,u.idUsuario) AND
		   u.nombreUsuario = COALESCE(@nombreUsuario,u.nombreUsuario) AND
		   up.esPantallaPrincipal = 1

GO
CREATE PROCEDURE [dbo].[usuarioVista] 
    @idUsuario INT = NULL
AS
	SELECT *  
	FROM   usuario 
	WHERE  (idUsuario = @idUsuario OR @idUsuario IS NULL) 

GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE usuarioVistaAjax (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(u.idUsuario as varchar(20)) + ' - ' +  u.nombreUsuario + ' - ' +  u.nombre AS descripcion
	FROM dbo.usuario u
	WHERE u.nombre LIKE '%'+@descripcion+'%' 
	OR CAST(u.idUsuario as varchar(20)) LIKE '%'+@descripcion+'%'
	OR u.nombreUsuario LIKE  '%'+@descripcion+'%'
	ORDER BY u.nombreUsuario
END
GO