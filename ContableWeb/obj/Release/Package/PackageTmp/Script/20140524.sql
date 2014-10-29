INSERT INTO pantalla VALUES (22,'frmUsuarioPantalla.aspx','Permisos','Proceso')
INSERT INTO usuarioPantalla VALUES (1,22,0)
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[PermisosVistaAjax] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(p.idPantalla as varchar(20)) + ' - ' +  p.descripcion + ' - ' +  p.tipo + ' - ' +  p.url AS descripcion
	FROM dbo.pantalla p
	WHERE p.descripcion LIKE '%'+@descripcion+'%' 
	ORDER BY p.descripcion
END
GO