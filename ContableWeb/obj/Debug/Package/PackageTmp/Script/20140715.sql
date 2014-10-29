GO
ALTER TABLE dbo.factura ADD
	observaciones varchar(100) NULL
GO
-------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[rptFactura_cabe] (
	@idFactura INT
)
AS
BEGIN
	SELECT fa.idFactura AS idFactura ,
		   fa.observaciones AS observaciones,
		   convert(varchar, fa.fecha, 103)AS fecha,
		   CAST(DAY(fa.fecha) as varchar) as dia,
		   cast(Month(fa.fecha) as varchar) as mes,
		   cast(year(fa.fecha) as varchar) as anio,
		   cli.razonSocial AS cli_razonSocial,
		   cli.cuit AS cli_cuit,
		   cli.domicilio AS cli_domicilio,
		   loc.descripcion AS cli_localidad,
		   civa.descripcion AS civa_descripcion,
		   CAST(SUM(ai.valor/100 * pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS ai_ivaTotal,
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
		  fa.observaciones ,
		   fa.fecha,
		   cli.razonSocial,
		   cli.cuit,
		   cli.domicilio,
		   loc.descripcion ,
		   civa.descripcion,
		   civa.idCondicionIva
		  
END
GO

GO
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[rptFactura_detalle] (
	@idFactura INT
)
AS
BEGIN
	SELECT re.idRemito as re_idRemito,
		   CAST(SUM(ai.valor/100 * pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS re_iva,
		   CAST(SUM(pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS re_totalSinIva,
		   CAST(SUM(pit.cantidad * pit.precioUnitario + ai.valor/100 * pit.cantidad * pit.precioUnitario ) AS NUMERIC(10,2)) AS re_totalConIva,
		   MAX(ai.valor)  as fa_aliva
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
		   re.idRemito
END

GO
CREATE PROCEDURE [dbo].[DescripcionMovCajaSelect] 
    @idDescripcionMovCaja INT = NULL
AS 

	SELECT *
	FROM   descripcionMovCaja
	WHERE  (idDescripcionMovCaja = @idDescripcionMovCaja OR @idDescripcionMovCaja IS NULL) 
GO