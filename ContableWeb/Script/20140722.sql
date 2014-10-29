 GO
 CREATE function StockDeProducto
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
 @msi int,
 @mse int,
 @cIrigoyen int,
 @pitIrigoyen int,
 @msiIrigoyen int,
 @mseIrigoyen int,
 @ingIrigoyen int,
 @egreIrigoyen int,
 @cSI int,
 @pitSI int,
 @msiSI int,
 @mseSI int,
 @ingSI int,
 @egreSI int;
 set @c = ISNULL((SELECT SUM (cantidad) from compraItem where idProducto = @idProducto),0) 
 set @pit = ISNULL((SELECT SUM (cantidad) from pedidoItem where idProducto = @idProducto),0) 
 set @msi = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 1 
														AND idProducto = @idProducto),0)
 set @mse = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 2 
														AND idProducto = @idProducto),0)
 set @cIrigoyen = ISNULL((SELECT SUM (ci.cantidad) from compraItem ci INNER JOIN compraCabe cc ON cc.idCompraCabe = ci.idCompra where idProducto = @idProducto and cc.idUbicacionStock = 1),0)
 set @pitIrigoyen = ISNULL((SELECT SUM (pit.cantidad) from pedidoItem pit INNER JOIN pedidoCabe pc ON pc.idPedidoCabe = pit.idPedido where idProducto = @idProducto and pc.idUbicacionStock = 1),0)
 set @msiIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 1 
														AND idProducto = @idProducto AND idUbicacionStock = 1),0)
 set @mseIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 2 
														AND idProducto = @idProducto AND idUbicacionStock = 1),0)  														
 set @ingIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockDestino = 1 AND idProducto = @idProducto),0)
 set @egreIrigoyen = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockOrigen = 1 AND idProducto = @idProducto),0)
 
 
 set @cSI = ISNULL((SELECT SUM (ci.cantidad) from compraItem ci INNER JOIN compraCabe cc ON ci.idCompra = cc.idCompraCabe where idProducto = @idProducto and cc.idUbicacionStock = 2),0)
 set @pitSI = ISNULL((SELECT SUM (pit.cantidad) from pedidoItem pit INNER JOIN pedidoCabe pc ON pit.idPedido = pc.idPedidoCabe where idProducto = @idProducto and pc.idUbicacionStock = 2),0)
 set @msiSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 1 
														AND idProducto = @idProducto AND idUbicacionStock = 2),0)
 set @mseSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 2 
														AND idProducto = @idProducto AND idUbicacionStock = 2),0)  														
 set @ingSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockDestino = 2 AND idProducto = @idProducto),0)
 set @egreSI = ISNULL((SELECT SUM (cantidad) FROM movimientoStock where idTipoMovimiento = 3 and idUbicacionStockOrigen = 2 AND idProducto = @idProducto),0)
 
 INSERT @stockProducto
 SELECT @c-@pit+@msi-@mse,@cIrigoyen-@pitIrigoyen+@msiIrigoyen-@mseIrigoyen+@ingIrigoyen-@egreIrigoyen,@cSI-@pitSI+@msiSI-@mseSI+@ingSI-@egreSI
 
 RETURN;														
end
GO

ALTER PROCEDURE [dbo].[rptProductoStock]
  @idProducto INT = NULL
AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia',p.descripcion,
	p.codProducto,b.*
	
	
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	CROSS APPLY StockDeProducto(p.idProducto) AS b
	WHERE p.activo = 1
		AND (p.idProducto=@idProducto OR @idProducto is NULL)
	ORDER BY p.descripcion
END

GO
INSERT INTO pantalla values (24,'ReporteCostoProducto.aspx','Costo de Productos','Reporte')
INSERT INTO usuarioPantalla VALUES (1,24,0)
GO
 CREATE function [dbo].[costo]
 (
  @idProducto int
 )
returns float
as
begin
declare @costo float
SELECT TOP 1 @costo = pit.precioUnitario 
from pedidoItem pit
INNER JOIN pedidoCabe pc ON pit.idPedido = pc.idPedidoCabe
WHERE pit.idProducto = @idProducto
ORDER BY pc.fechaPedido desc
return ISNULL(@costo,0)
end
GO
CREATE PROCEDURE [dbo].[rptProductoCosto]
  @idProducto INT = NULL
AS
BEGIN	  
SELECT	p.idProducto,f.descripcion as 'familia',p.descripcion,
p.codProducto, dbo.costo(p.idProducto) as costo
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	WHERE p.activo = 1
		AND (p.idProducto=@idProducto OR @idProducto is NULL)
	ORDER BY p.descripcion
END
GO