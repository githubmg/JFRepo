GO
ALTER TABLE dbo.movimientoStock ADD
	idUbicacionStock int NULL
GO
ALTER TABLE dbo.movimientoStock ADD CONSTRAINT
	FK_movimientoStock_ubicacionStock FOREIGN KEY
	(
	idUbicacionStock
	) REFERENCES dbo.ubicacionStock
	(
	idUbicacionStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
GO
ALTER TABLE dbo.movimientoStock ADD
	idUbicacionStockOrigen int NULL,
	idUbicacionStockDestino int NULL
GO
GO
ALTER TABLE dbo.movimientoStock ADD CONSTRAINT
	FK_movimientoStock_ubicacionStock1 FOREIGN KEY
	(
	idUbicacionStockDestino
	) REFERENCES dbo.ubicacionStock
	(
	idUbicacionStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.movimientoStock ADD CONSTRAINT
	FK_movimientoStock_ubicacionStock2 FOREIGN KEY
	(
	idUbicacionStockOrigen
	) REFERENCES dbo.ubicacionStock
	(
	idUbicacionStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

GO
ALTER PROCEDURE [dbo].[MovimientoStockInsert] 
    @fecha datetime,
    @idTipoMovimiento int,
    @idProducto int,
    @cantidad float,
    @idUbicacionStock INT = NULL,
    @idUbicacionStockOrigen INT = NULL,
    @idUbicacionStockDestino INT = NULL
   
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	DECLARE @idMovimientoStock INT
	SELECT @idMovimientoStock = ISNULL(MAX(idMovimientoStock),0)+1 FROM dbo.movimientoStock
	
	INSERT INTO movimientoStock (idMovimientoStock,fecha,idTipoMovimiento,idProducto,cantidad,idUbicacionStock,idUbicacionStockOrigen,idUbicacionStockDestino)
	VALUES  (@idMovimientoStock,@fecha,@idTipoMovimiento,@idProducto,@cantidad,@idUbicacionStock,@idUbicacionStockOrigen,@idUbicacionStockDestino)
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   movimientoStock
	WHERE @idMovimientoStock = idMovimientoStock
	-- End Return Select <- do not remove

	COMMIT
GO

GO
ALTER PROCEDURE [dbo].[MovimientoStockUpdate] 
    @idMovimientoStock int,
    @fecha datetime,
    @idTipoMovimiento int,
    @idProducto int,
    @cantidad float,
    @idUbicacionStock INT = NULL,
    @idUbicacionStockOrigen INT = NULL,
    @idUbicacionStockDestino INT = NULL
   
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE movimientoStock
	SET 
	fecha= @fecha,
	idTipoMovimiento= @idTipoMovimiento,
	idProducto= @idProducto,
	cantidad= @cantidad,
	idUbicacionStock=@idUbicacionStock,
	idUbicacionStockOrigen=@idUbicacionStockOrigen,
	idUbicacionStockDestino=@idUbicacionStockDestino
	WHERE @idMovimientoStock = idMovimientoStock
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   movimientoStock
	WHERE @idMovimientoStock = idMovimientoStock
	-- End Return Select <- do not remove

	COMMIT
GO
ALTER PROCEDURE [dbo].[MovimientoStockVista]
AS
BEGIN
	SELECT	idMovimientoStock,
	fecha,
	tipoMovimiento.descripcion as tipoMovimiento,
	familia.descripcion as familia,
	producto.descripcion as producto,
	cantidad,
	us.descripcion as ubicacionStock,
	uso.descripcion as ubicacionStockOrigen,
	usd.descripcion as ubicacionStockDestino
	from movimientoStock
	JOIN tipoMovimiento on movimientoStock.idTipoMovimiento = tipoMovimiento.idTipoMovimiento
	JOIN producto on movimientoStock.idProducto = producto.idProducto
	JOIN familia on producto.idFamilia = familia.idFamilia
	LEFT JOIN ubicacionStock us ON us.idUbicacionStock = movimientoStock.idUbicacionStock
	LEFT JOIN ubicacionStock uso ON uso.idUbicacionStock = movimientoStock.idUbicacionStockOrigen
	LEFT JOIN ubicacionStock usd ON usd.idUbicacionStock = movimientoStock.idUbicacionStockDestino
END
GO
UPDATE movimientoStock SET idUbicacionStock = 1