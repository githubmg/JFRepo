GO
CREATE PROCEDURE [dbo].[PantallasUsuarioVista] (
    @idUsuario INT = NULL
)
AS 
	SELECT p.*,CASE up.esPantallaPrincipal WHEN 0 then 'No' WHEN 1 THEN 'Si' END as esPantallaPrincipal
	FROM   usuarioPantalla up JOIN pantalla p ON up.idPantalla = p.idPantalla
	WHERE (up.idUsuario = @idUsuario OR @idUsuario is Null) 

GO
CREATE PROCEDURE [dbo].[UsuarioPantallaInsert] (
	@idPantalla INT ,
	@idUsuario INT ,
	@esPantallaPrincipal INT
)
AS
BEGIN
	INSERT INTO dbo.usuarioPantalla
	        (
	        idUsuario,
	        idPantalla,
			 esPantallaPrincipal 
	        )
	VALUES  ( 
			 @idUsuario,
	        @idPantalla,
			 @esPantallaPrincipal 
	        )
	SELECT @idUsuario AS idUsuario
END
GO
CREATE PROCEDURE usuarioSelectByID
(@idUsuario INT)
AS
BEGIN
SELECT * FROM usuario WHERE idUsuario = @idUsuario
END
GO
GO
CREATE PROCEDURE usuarioPantallaDelete
(@idUsuario INT)
AS
BEGIN
DELETE FROM usuarioPantalla WHERE idUsuario = @idUsuario
END
GO
update usuarioPantalla set esPantallaPrincipal = 0 where esPantallaPrincipal is null