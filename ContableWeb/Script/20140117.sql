GO
ALTER TABLE dbo.pagoCompra ADD
	montoCancelado float(53) NULL
GO
ALTER PROCEDURE [dbo].[PagoCompraInsert] (
   @idPago int,
   @idCompra int,
   @montoCancelado float
)
AS 
	BEGIN TRAN

	INSERT INTO pagoCompra(idPago,idCompra,montoCancelado)
	VALUES (@idPago,@idCompra,@montoCancelado)
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   pagoCompra
	WHERE  idPago = @idPago AND idCompra = @idCompra
	-- End Return Select <- do not remove
               
	COMMIT
GO
delete from pagoCompra
delete from pagoCheque
delete from pago

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[CompraSSaldarVista] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(c.idCompraCabe as varchar(20)) + ' - ' +  
	p.razonSocial + ' - ' + 
	CONVERT(VARCHAR(10), c.fechaCompra, 103)  + ' - ' + 
	ep.descripcion + ' - ' 
	+ '$' +
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = c.idCompraCabe ),0)) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0))
	) as varchar(20)),'0')
	
	FROM compraCabe c 
	 INNER JOIN proveedor p ON c.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON c.idEstado = ep.idEstadoPedido
	WHERE 
	(
	CAST(c.idCompraCabe as varchar(20)) LIKE '%'+@descripcion+'%' OR
	p.razonSocial LIKE '%'+@descripcion+'%') 
	AND 
	--Condicion de que la compra esté sin saldar
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = c.idCompraCabe ),0)
	) 
	> 
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0)
	)	
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[MontoCompraSSaldarVista] (@idCompra int)
AS
BEGIN
	SELECT 
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = c.idCompraCabe ),0)) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0))
	as saldo
	FROM compraCabe c 
	WHERE 
	c.idCompraCabe = @idCompra
END
GO