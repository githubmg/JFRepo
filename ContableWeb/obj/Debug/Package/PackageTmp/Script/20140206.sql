
GO
CREATE PROCEDURE [dbo].[PedidoRemitoInsert] (
   @idPedido int,
   @idFactura int = null
)
AS 
	BEGIN TRAN
	DECLARE @idRemito INT
	SELECT @idRemito = ISNULL(MAX(idRemito),0)+1 FROM dbo.remito

	INSERT INTO remito(idRemito,idPedido,idFactura)
	VALUES (@idRemito,@idPedido,@idFactura)
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   remito
	WHERE  idRemito = @idRemito
	-- End Return Select <- do not remove
               
	COMMIT
GO
GO
--------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[rptRemito_comprobantes] (
	@idRemito INT
)
AS
BEGIN
	SELECT re.idRemito AS idRemito ,
		   convert(varchar, pe.fechaPedido, 103)AS fecha,
		   cli.razonSocial AS cli_razonSocial,
		   cli.cuit AS cli_cuit,
		   cli.domicilio AS cli_domicilio,
		   loc.descripcion AS cli_localidad,
		   civa.descripcion AS civa_descripcion,
		   pit.cantidad AS pit_cantidad,
		   pro.descripcion AS pro_descripcion,
		   pit.precioUnitario AS pit_precioUnitario,
		   CAST(SUM(pit.cantidad * pit.precioUnitario) AS NUMERIC(10,2)) AS total		   
	FROM dbo.remito re
	JOIN dbo.pedidoCabe pe ON re.idPedido = pe.idPedidoCabe
	JOIN dbo.cliente cli ON cli.cuit = pe.cuitCliente
	JOIN dbo.condicionIva civa ON cli.idCondicionIva = civa.idCondicionIva
	JOIN dbo.localidad loc ON cli.idLocalidad = loc.idLocalidad
	JOIN dbo.pedidoItem pit ON pit.idPedido = pe.idPedidoCabe
	JOIN dbo.producto pro ON pro.idProducto = pit.idProducto
	WHERE re.idRemito = @idRemito
	GROUP BY 
		 re.idRemito ,
		   pe.fechaPedido,
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