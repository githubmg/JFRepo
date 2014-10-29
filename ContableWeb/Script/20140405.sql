
GO
ALTER PROCEDURE [dbo].[FacturaVista] 
AS
BEGIN
SELECT 
	fa.idFactura AS idFactura ,
	fa.fecha,
	cli.razonSocial AS cliente,
	civa.letra as letra,
	CAST(SUM(pit.cantidad * pit.precioUnitario + ai.valor/100 * pit.cantidad * pit.precioUnitario ) AS NUMERIC(10,2)) AS total		   
	FROM dbo.factura fa
	JOIN dbo.remito re ON re.idFactura = fa.idFactura
	JOIN dbo.pedidoCabe pe ON re.idPedido = pe.idPedidoCabe
	JOIN dbo.cliente cli ON cli.idCliente = pe.idCliente
	JOIN dbo.condicionIva civa ON cli.idCondicionIva = civa.idCondicionIva
	JOIN dbo.localidad loc ON cli.idLocalidad = loc.idLocalidad
	JOIN dbo.pedidoItem pit ON pit.idPedido = pe.idPedidoCabe
	JOIN dbo.producto pro ON pro.idProducto = pit.idProducto
	JOIN dbo.alicuotaIva ai ON pro.idAlicuotaIva = ai.idAlicuotaIva
	GROUP BY 
		 fa.idFactura ,
		   fa.fecha,
		   cli.razonSocial,
		   civa.letra
		   
END

GO