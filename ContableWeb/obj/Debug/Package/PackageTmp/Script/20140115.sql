GO
ALTER PROCEDURE [dbo].[ChequeCarteraPorNroBancoImporte] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT c.numero + ' - ' +  b.descripcion + ' - $' + CAST(c.importe as varchar(20)) AS descripcion
	FROM cheque c
		INNER JOIN banco b ON c.idBanco = b.idBanco
	WHERE 
	(c.numero LIKE '%'+@descripcion+'%' OR
	CAST(c.importe as varchar(20)) LIKE '%'+@descripcion+'%' OR
	b.descripcion LIKE '%'+@descripcion+'%') 
	AND 
	c.enCartera = 1
	ORDER BY c.numero
END
GO
GO
CREATE PROCEDURE AgregarCompraPago (
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
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[PagoInsert] (
	@fecha datetime,
	@idMedioPago int,
	@importe float,
	@observaciones varchar(150)
	
)
AS
BEGIN
	DECLARE @idPago INT
	SELECT @idPago = ISNULL(MAX(idPago),0)+1 FROM dbo.pago
	INSERT INTO dbo.pago
	        ( 
	        idPago,
	        fecha,
	        idMedioPago,
	        importe,
	        observaciones
	        )
	VALUES  ( 
			@idPago,
			@fecha,
			@idMedioPago,
			@importe,
			@observaciones				
	        )
	SELECT @idPago AS idPago
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[ChequeCarteraPorNroBancoImporte] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(c.idCheque as varchar(11)) + ' - nro: ' + c.numero + ' - ' +  b.descripcion + ' - $' + CAST(c.importe as varchar(20)) AS descripcion
	FROM cheque c
		INNER JOIN banco b ON c.idBanco = b.idBanco
	WHERE 
	(c.numero LIKE '%'+@descripcion+'%' OR
	CAST(c.importe as varchar(20)) LIKE '%'+@descripcion+'%' OR
	b.descripcion LIKE '%'+@descripcion+'%') 
	AND 
	c.enCartera = 1
	ORDER BY c.numero
END
GO
GO
CREATE PROCEDURE AgregarPagoCheque (
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