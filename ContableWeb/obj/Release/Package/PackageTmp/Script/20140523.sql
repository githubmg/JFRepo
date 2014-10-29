GO
CREATE PROCEDURE [dbo].[pantallaSelect] 
    @idPantalla INT = NULL
AS 
	SELECT *
	FROM   pantalla
	WHERE  (idPantalla=@idPantalla OR @idPantalla is Null) 
GO
