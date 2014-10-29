INSERT INTO pantalla VALUES (18,'ReporteVendedores.aspx','Ventas por Vendedor/Técnico',
'Reporte')
INSERT INTO usuarioPantalla VALUES (1,18,0)
GO
CREATE PROCEDURE [dbo].[rptVentasVendedor] (
	@desde DATE = null,
	@hasta DATE = null,
	@idVendedor INT = null
)
AS
BEGIN
	SELECT ve.idVendedor,ve.descripcion,
		   CAST(SUM(pit.cantidad * pit.precioUnitario ) AS NUMERIC(10,2)) AS totalVendedor
		     
	FROM vendedor ve 
	INNER JOIN pedidoItem pit on pit.idVendedor = ve.idVendedor
	INNER JOIN pedidoCabe pc on pit.idPedido = pc.idPedidoCabe
	WHERE (pc.fechaPedido >= @desde OR @desde IS NULL) AND
	(pc.fechaPedido <= @hasta OR @hasta IS NULL) AND
	(ve.idVendedor = @idVendedor OR @idVendedor IS NULL)
	GROUP BY 
		 ve.idVendedor,ve.descripcion
END
GO