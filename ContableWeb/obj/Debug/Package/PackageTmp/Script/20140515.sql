GO
CREATE PROCEDURE VistaProductoStockByDecripcion (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(p.idProducto as varchar(20)) + ' - ' + CAST(p.codProducto as varchar(20)) + ' - ' +  p.descripcion AS descripcion
	FROM dbo.producto p
	WHERE p.descripcion LIKE '%'+@descripcion+'%' 
	OR CAST(p.codProducto as varchar(20)) LIKE '%'+@descripcion+'%'
	AND p.activo = 1
	ORDER BY p.descripcion
END
GO