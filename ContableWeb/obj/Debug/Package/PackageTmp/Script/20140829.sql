GO
---------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[rptRemitoSinFacturarVista] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(r.idRemito as varchar(20)) + ' - ' +  
	c.razonSocial + ' - ' + 
	CONVERT(VARCHAR(10), p.fechaPedido, 103)  + ' - ' + 
	ep.descripcion + ' - ' +
	p.orden + ' - ' +
	p.chasis + ' - ' +	
	'$' + ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from PedidoItem pit where pit.idPedido = p.idPedidoCabe ),0)) 
	)
	as varchar(20)),'0')
	
	
	FROM remito r 
	 INNER JOIN pedidoCabe p ON p.idPedidoCabe = r.idPedido
	 INNER JOIN estadoPedido ep ON ep.idEstadoPedido = p.idEstadoPedido
	 INNER JOIN cliente c ON p.idCliente = c.idCliente
	WHERE 
	r.idFactura is null
	AND 
	(c.razonSocial LIKE '%'+@descripcion+'%' OR
	 CAST(r.idRemito as varchar(20)) LIKE '%'+@descripcion+'%' OR
	 p.chasis LIKE '%'+@descripcion+'%')
END
GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[remitoVista]
    @idRemito INT = NULL 
AS
BEGIN
	SELECT re.idRemito,
	c.razonSocial as 'cliente',
	pc.fechaPedido, 
	pc.orden,
	pc.chasis,
	ep.descripcion as 'estado',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from PedidoItem pit where pit.idPEdido = pc.idPedidoCabe ),0)) 
	-
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c	INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = pc.idPedidoCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from PedidoItem pit where pit.idPedido = pc.idPedidoCabe ),0)) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = pc.idPedidoCabe),0))) 
	as varchar(20)),'0') as 'saldado',
	ISNULL(CAST(re.idFactura as varchar),'Pendiente') as 'factura'
	FROM remito re 
	 INNER JOIN pedidoCabe pc  on re.idPedido = pc.idPedidoCabe
	 INNER JOIN cliente c ON pc.idCliente = c.idCliente
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	WHERE  (re.idRemito = @idRemito OR @idRemito IS NULL)
	ORDER BY factura DESC, pc.fechaPedido DESC
END
GO
ALTER function [dbo].[costo]
 (
  @idProducto int
 )
returns float
as
begin
declare @costo float
SELECT TOP 1 @costo = cit.precioUnitario 
from compraItem cit
INNER JOIN compraCabe cc ON cit.idCompra = cc.idCompraCabe
WHERE cit.idProducto = @idProducto
ORDER BY cc.fechaCompra desc
return ISNULL(@costo,0)
end

GO
