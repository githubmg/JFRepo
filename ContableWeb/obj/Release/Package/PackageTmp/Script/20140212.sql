GO
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[rptFactura_comprobantes] (
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
		   CAST(SUM(pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS total		   
	FROM dbo.factura fa
	JOIN dbo.remito re ON re.idFactura = fa.idFactura
	JOIN dbo.pedidoCabe pe ON re.idPedido = pe.idPedidoCabe
	JOIN dbo.cliente cli ON cli.cuit = pe.cuitCliente
	JOIN dbo.condicionIva civa ON cli.idCondicionIva = civa.idCondicionIva
	JOIN dbo.localidad loc ON cli.idLocalidad = loc.idLocalidad
	JOIN dbo.pedidoItem pit ON pit.idPedido = pe.idPedidoCabe
	JOIN dbo.producto pro ON pro.idProducto = pit.idProducto
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
		   pit.precioUnitario
END
GO
GO

CREATE PROCEDURE [dbo].[FacturaInsert] 
    @fecha date
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
    DECLARE @idFactura INT
	SELECT @idFactura = ISNULL(MAX(idFactura),0)+1 FROM dbo.factura

	INSERT INTO [dbo].factura (idFactura, fecha)
	SELECT @idFactura, @fecha
	
	-- Begin Return Select <- do not remove
	SELECT idFactura, fecha
	FROM   factura
	WHERE  idFactura = @idFactura
	-- End Return Select <- do not remove
               
	COMMIT
GO
GO

CREATE PROCEDURE [dbo].[FacturaRemitoInsert] 
    @idFactura int,
    @idRemito int
AS 
    UPDATE remito set idFactura = @idFactura
	
	-- Begin Return Select <- do not remove
	SELECT @idRemito
	-- End Return Select <- do not remove
               
GO