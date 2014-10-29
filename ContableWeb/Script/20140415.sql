GO
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[rptFactura_comprobantes] (
	@idFactura INT
)
AS
BEGIN
	SELECT fa.idFactura AS idFactura ,
		   convert(varchar, fa.fecha, 103)AS fecha,
		   CAST(DAY(fa.fecha) as varchar) as dia,
		   cast(Month(fa.fecha) as varchar) as mes,
		   cast(year(fa.fecha) as varchar) as anio,
		   cli.razonSocial AS cli_razonSocial,
		   cli.cuit AS cli_cuit,
		   cli.domicilio AS cli_domicilio,
		   loc.descripcion AS cli_localidad,
		   civa.descripcion AS civa_descripcion,
		   pit.cantidad AS pit_cantidad,
		   pro.descripcion AS pro_descripcion,
		   pit.precioUnitario AS pit_precioUnitario,
		   pit.precioUnitario * (1+ai.valor/100) AS pit_precioConIva,
		   pit.precioUnitario * pit.cantidad AS pit_importe,
		   ai.valor AS ai_alicuta,
		   re.idRemito as re_idRemito,
		   CAST(ai.valor/100 * pit.cantidad * pit.precioUnitario AS NUMERIC(10,2)) AS ai_ivaTotal,
		   CAST(SUM(pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS totalSinIva,
		   CAST(SUM(pit.cantidad * pit.precioUnitario + ai.valor/100 * pit.cantidad * pit.precioUnitario ) AS NUMERIC(10,2)) AS totalConIva,
		    CASE 
			  WHEN civa.idCondicionIva=1 THEN 'X' 
			  WHEN civa.idCondicionIva=11 THEN 'X'
			  ELSE '' 
		     END as civa_letra		   
	FROM dbo.factura fa
	JOIN dbo.remito re ON re.idFactura = fa.idFactura
	JOIN dbo.pedidoCabe pe ON re.idPedido = pe.idPedidoCabe
	JOIN dbo.cliente cli ON cli.idCliente = pe.idCliente
	JOIN dbo.condicionIva civa ON cli.idCondicionIva = civa.idCondicionIva
	JOIN dbo.localidad loc ON cli.idLocalidad = loc.idLocalidad
	JOIN dbo.pedidoItem pit ON pit.idPedido = pe.idPedidoCabe
	JOIN dbo.producto pro ON pro.idProducto = pit.idProducto
	JOIN dbo.alicuotaIva ai ON pro.idAlicuotaIva = ai.idAlicuotaIva
	WHERE fa.idFactura = @idFactura
	GROUP BY 
		 fa.idFactura ,
		   fa.fecha,
		   cli.razonSocial,
		   cli.cuit,
		   cli.domicilio,
		   loc.descripcion ,
		   civa.descripcion,
		   civa.idCondicionIva,
		   pit.cantidad,
		   pro.descripcion ,
		   pit.precioUnitario,
		   ai.valor,
		   re.idRemito
END



GO