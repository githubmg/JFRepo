GO
CREATE PROCEDURE [dbo].[PedidoCabeSelect] (
    @idPedidoCabe int = NULL
)
AS 
	BEGIN TRAN
	SELECT *
	FROM   dbo.pedidoCabe 
	WHERE  (idPedidoCabe = @idPedidoCabe OR @idPedidoCabe IS NULL)
	COMMIT
GO
----------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoItemSelect] (@idPedidoItem INT = Null)
AS
BEGIN
	SELECT	*
	FROM dbo.pedidoItem
	WHERE (idPedidoItem = @idPedidoItem OR @idPedidoItem is NULL)
END
GO
update pantalla set tipo = 'Proceso' where idPantalla = 5