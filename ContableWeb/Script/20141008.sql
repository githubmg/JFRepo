GO
ALTER function [dbo].[StockDeProducto]
 (@idProducto int)
RETURNS @stockProducto TABLE 
(
stockTotal INT,
stockIrigoyen INT,
stockSI INT
)
as 
begin
declare @c int,
 @pit int,
 @pitkit int,
 @msi int,
 @mse int,
 @cIrigoyen int,
 @pitkitIrigoyen int, 
 @pitIrigoyen int,
 @msiIrigoyen int,
 @mseIrigoyen int,
 @ingIrigoyen int,
 @egreIrigoyen int,
 @cSI int,
 @pitSI int,
 @pitkitSI int, 
 @msiSI int,
 @mseSI int,
 @ingSI int,
 @egreSI int;
 set @c = ISNULL((SELECT SUM (cantidad) from compraItem where idProducto = @idProducto),0) 
 set @pit = ISNULL((SELECT SUM (cantidad) from pedidoItem where idProducto = @idProducto),0)
 set @pitkit = ISNULL((select SUM (kp.cantdad*pit.cantidad) from pedidoItem pit 
						inner join kit k on k.idProductoPrincipal = pit.idProducto
						inner join  kitProducto kp on kp.idKit = k.idKit
						WHERE kp.idProducto = @idProducto),0)
 
 set @msi = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 1 
														AND idProducto = @idProducto),0)
 set @mse = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 2 
														AND idProducto = @idProducto),0)
 set @cIrigoyen = ISNULL((SELECT SUM (ci.cantidad) from compraItem ci INNER JOIN compraCabe cc ON cc.idCompraCabe = ci.idCompra where idProducto = @idProducto and cc.idUbicacionStock = 1),0)
 set @pitIrigoyen = ISNULL((SELECT SUM (pit.cantidad) from pedidoItem pit INNER JOIN pedidoCabe pc ON pc.idPedidoCabe = pit.idPedido where idProducto = @idProducto and pc.idUbicacionStock = 1),0)
 set @msiIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 1 
														AND idProducto = @idProducto AND idUbicacionStock = 1),0)
														
														
 set @pitkitIrigoyen = ISNULL((select SUM (kp.cantdad*pit.cantidad) from pedidoItem pit 
						inner join kit k on k.idProductoPrincipal = pit.idProducto
						inner join  kitProducto kp on kp.idKit = k.idKit
						inner join pedidoCabe pc ON pc.idPedidoCabe = pit.idPedido
						WHERE kp.idProducto = @idProducto AND pc.idUbicacionStock = 1),0)
 set @mseIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 2 
														AND idProducto = @idProducto AND idUbicacionStock = 1),0)  														
 set @ingIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockDestino = 1 AND idProducto = @idProducto),0)
 set @egreIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockOrigen = 1 AND idProducto = @idProducto),0)
 
 
 set @cSI = ISNULL((SELECT SUM (ci.cantidad) from compraItem ci INNER JOIN compraCabe cc ON ci.idCompra = cc.idCompraCabe where idProducto = @idProducto and cc.idUbicacionStock = 2),0)
 set @pitSI = ISNULL((SELECT SUM (pit.cantidad) from pedidoItem pit INNER JOIN pedidoCabe pc ON pit.idPedido = pc.idPedidoCabe where idProducto = @idProducto and pc.idUbicacionStock = 2),0)
 set @pitkitSI = ISNULL((select SUM (kp.cantdad*pit.cantidad) from pedidoItem pit 
						inner join kit k on k.idProductoPrincipal = pit.idProducto
						inner join  kitProducto kp on kp.idKit = k.idKit
						inner join pedidoCabe pc ON pc.idPedidoCabe = pit.idPedido
						WHERE kp.idProducto = @idProducto AND pc.idUbicacionStock = 2),0)
 set @msiSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 1 
														AND idProducto = @idProducto AND idUbicacionStock = 2),0)
 set @mseSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 2 
														AND idProducto = @idProducto AND idUbicacionStock = 2),0)  														
 set @ingSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockDestino = 2 AND idProducto = @idProducto),0)
 
 set @egreSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockOrigen = 2 AND idProducto = @idProducto),0)
 
 INSERT @stockProducto
 SELECT @c-@pit-@pitkit+@msi-@mse,@cIrigoyen-@pitIrigoyen-@pitKitIrigoyen+@msiIrigoyen-@mseIrigoyen+@ingIrigoyen-@egreIrigoyen,@cSI-@pitSI-@pitkitSI+@msiSI-@mseSI+@ingSI-@egreSI
 
 RETURN;														
end
GO
INSERT INTO pantalla VALUES (26,'frmAgenda.aspx','Agenda','Proceso')
INSERT INTO usuarioPantalla VALUES (1,26,0)
GO
CREATE PROCEDURE [dbo].[eventoSelect] 
    @idEvento INT = NULL,
    @desde date = null,
    @hasta date = null
AS 
	SELECT e.*,c.razonSocial
	FROM   evento e INNER JOIN cliente c ON e.idCliente = c.idCliente
	WHERE  (idEvento = @idEvento OR @idEvento IS NULL) AND
	(e.fecha <= @hasta OR @hasta IS NULL) AND
	(e.fecha >= @desde OR @desde IS NULL)

GO