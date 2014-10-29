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
	(ISNULL((SELECT SUM (p.importe) 
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
	(ISNULL((SELECT SUM (p.importe) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0)
	)	
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ChequeUpdate] (
	@idCheque int,
	@idBanco int,
	@numero varchar(50),
	@fechaEmision datetime,
	@fechaVencimiento datetime,
	@importe float,
	@idOrigenCheque int,
	@enCartera bit
)
AS
BEGIN
    BEGIN TRAN
	UPDATE  cheque SET
	        idBanco =@idBanco,
	        numero =@numero,
	        fechaEmision =@fechaEmision,
	        fechaVencimiento =@fechaVencimiento,
	        importe =@importe,
	        idOrigenCheque =@idOrigenCheque,
	        enCartera =@enCartera
	        WHERE idCheque=@idCheque
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cheque
	WHERE  idCheque = @idCheque
	-- End Return Select <- do not remove
	COMMIT

END
GO
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ChequeInsert] (
	@idBanco int = NULL,
	@numero varchar(50),
	@fechaEmision datetime,
	@fechaVencimiento datetime,
	@importe float,
	@idOrigenCheque int,
	@enCartera bit
)
AS
BEGIN
    BEGIN TRAN
    DECLARE @idCheque INT
	SELECT @idCheque = ISNULL(MAX(idCheque),0)+1 FROM dbo.cheque
	
	INSERT INTO cheque (idCheque,idBanco,numero,fechaEmision,fechaVencimiento,importe
	,idOrigenCheque,enCartera)
	SELECT @idCheque,@idBanco,@numero,@fechaEmision,@fechaVencimiento,
	@importe,@idOrigenCheque,@enCartera
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cheque
	WHERE  idCheque = @idCheque
	-- End Return Select <- do not remove
	COMMIT

END
GO
CREATE PROCEDURE [dbo].[PagoCompraInsert] (
   @idPago int,
   @idCompra int
)
AS 
	BEGIN TRAN

	INSERT INTO pagoCompra(idPago,idCompra)
	VALUES (@idPago,@idCompra)
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   pagoCompra
	WHERE  idPago = @idPago AND idCompra = @idCompra
	-- End Return Select <- do not remove
               
	COMMIT
GO
GO
CREATE PROCEDURE [dbo].[PagoChequeInsert] (
   @idPago int,
   @idCheque int
)
AS 
	BEGIN TRAN

	INSERT INTO pagoCheque(idPago,idCheque)
	VALUES (@idPago,@idCheque)
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   pagoCheque
	WHERE  idPago = @idPago AND idCheque = @idCheque
	-- End Return Select <- do not remove
               
	COMMIT
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[MontoCompraSSaldarVista] (@idCompra int)
AS
BEGIN
	SELECT 
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = c.idCompraCabe ),0)) 
	-
	(ISNULL((SELECT SUM (p.importe) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = c.idCompraCabe),0))
	as saldo
	FROM compraCabe c 
	WHERE 
	c.idCompraCabe = @idCompra
END
GO
