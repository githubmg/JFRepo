GO
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[rptFactura_comprobantes] (
	@idFactura INT
)
AS
BEGIN
	SELECT fa.idFactura AS idFactura ,
		   convert(varchar, fa.fecha, 103)AS fecha,
		   cli.razonSocial AS cli_razonSocial,
		   cli.cuit AS cli_cuit,
		   cli.domicilio AS cli_domicilio,
		   loc.descripcion AS cli_localidad,
		   civa.descripcion AS civa_descripcion,
		   pit.cantidad AS pit_cantidad,
		   pro.descripcion AS pro_descripcion,
		   pit.precioUnitario AS pit_precioUnitario,
		   pit.precioUnitario * (1+ai.valor/100) AS pit_precioConIva,
		   ai.valor AS ai_alicuta,
		   CAST(ai.valor/100 * pit.cantidad * pit.precioUnitario AS NUMERIC(10,2)) AS ai_ivaTotal,
		   CAST(SUM(pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS totalSinIva,
		   CAST(SUM(pit.cantidad * pit.precioUnitario + ai.valor/100 * pit.cantidad * pit.precioUnitario ) AS NUMERIC(10,2)) AS totalConIva		   
	FROM dbo.factura fa
	JOIN dbo.remito re ON re.idFactura = fa.idFactura
	JOIN dbo.pedidoCabe pe ON re.idPedido = pe.idPedidoCabe
	JOIN dbo.cliente cli ON cli.cuit = pe.cuitCliente
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
		   pit.cantidad,
		   pro.descripcion ,
		   pit.precioUnitario,
		   ai.valor
END

GO

GO
CREATE PROCEDURE RemitosDeFactura (@idFactura INT)
AS
BEGIN
	SELECT	*
	FROM dbo.remito
	WHERE idFactura = @idFactura
END
GO

CREATE PROCEDURE [dbo].[RemitoSelect] 
    @idRemito INT = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT *
	FROM   remito
	WHERE  (idRemito = @idRemito OR @idRemito IS NULL) 

	COMMIT
GO

ALTER PROCEDURE [dbo].[FacturaRemitoInsert] 
    @idFactura int,
    @idRemito int
AS 
    UPDATE remito set idFactura = @idFactura
	WHERE idRemito = @idRemito
	-- Begin Return Select <- do not remove
	SELECT @idRemito
	-- End Return Select <- do not remove
               
GO
CREATE PROCEDURE FacturaVista 
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
	JOIN dbo.cliente cli ON cli.cuit = pe.cuitCliente
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
INSERT INTO pantalla VALUES (12,'frmFactura.aspx','Imprimir Factura','Proceso')
INSERT INTO usuarioPantalla VALUES (1,12,0)