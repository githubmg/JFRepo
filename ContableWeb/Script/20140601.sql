GO
ALTER PROCEDURE [dbo].[usuarioSelectByID]
(@idUsuario INT)
AS
BEGIN
DECLARE @PantallaPrincipal INT
SET @PantallaPrincipal = 
(SELECT idpantalla from usuarioPantalla where idUsuario = @idUsuario
and esPantallaPrincipal = 1)
SELECT u.*,@PantallaPrincipal as Pantalla FROM usuario u WHERE idUsuario = @idUsuario
END
GO
GO
CREATE PROCEDURE [dbo].[UsuarioDelete] (@idUsuario INT)
AS
BEGIN
	DELETE
	FROM usuarioPantalla
	WHERE (idUsuario = @idUsuario)
	DELETE
	FROM usuario
	WHERE (idUsuario = @idUsuario)
END
GO