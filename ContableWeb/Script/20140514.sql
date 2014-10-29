INSERT INTO pantalla VALUES (20,'ReporteStock.aspx','Stock','Reporte')
INSERT INTO usuarioPantalla values (1,20,0)

GO
ALTER PROCEDURE [dbo].[rptProductoStock]
  @idProducto INT = NULL
AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia',p.descripcion,
	p.codProducto,
	CAST(ISNULL(SUM(ci.cantidad),0) - ISNULL(SUM(pit.cantidad),0) 
	+ ISNULL(SUM(msi.cantidad),0) - ISNULL(SUM(mse.cantidad),0)
	AS varchar) AS stock
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	LEFT JOIN compraItem ci ON p.idProducto = ci.idProducto
	LEFT JOIN pedidoItem pit ON p.idProducto = pit.idProducto
	LEFT JOIN (SELECT * FROM movimientoStock where idMovimientoStock = 1) as msi
	ON p.idProducto = msi.idProducto
	LEFT JOIN (SELECT * FROM movimientoStock where idMovimientoStock = 2) as mse
	ON p.idProducto = mse.idProducto
	WHERE p.activo = 1
		AND (p.idProducto=@idProducto OR @idProducto is NULL)
	GROUP BY 
	p.idProducto,f.descripcion,p.descripcion,
	p.codProducto
	ORDER BY p.descripcion
END
GO