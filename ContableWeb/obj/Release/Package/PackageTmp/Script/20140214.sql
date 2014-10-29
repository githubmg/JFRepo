INSERT INTO pantalla VALUES (13,'frmMovimientoStock.aspx','Movimientos de Stock','Proceso')
INSERT INTO usuarioPantalla VALUES (1,13,0)
GO
CREATE TABLE dbo.movimientoStock
	(
	idMovimientoStock int NOT NULL,
	fecha datetime NULL,
	idTipoMovimiento int NULL,
	idProducto int NULL,
	cantidad float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.movimientoStock ADD CONSTRAINT
	PK_movimientoStock PRIMARY KEY CLUSTERED 
	(
	idMovimientoStock
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.movimientoStock ADD CONSTRAINT
	FK_movimientoStock_producto FOREIGN KEY
	(
	idProducto
	) REFERENCES dbo.producto
	(
	idProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.movimientoStock ADD CONSTRAINT
	FK_movimientoStock_tipoMovimiento FOREIGN KEY
	(
	idTipoMovimiento
	) REFERENCES dbo.tipoMovimiento
	(
	idTipoMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
GO
CREATE PROCEDURE MovimientoStockVista
AS
BEGIN
	SELECT	idMovimientoStock,
	fecha,
	tipoMovimiento.descripcion as tipoMovimiento,
	familia.descripcion as familia,
	producto.descripcion as producto,
	cantidad
	from movimientoStock
	JOIN tipoMovimiento on movimientoStock.idTipoMovimiento = tipoMovimiento.idTipoMovimiento
	JOIN producto on movimientoStock.idProducto = producto.idProducto
	JOIN familia on producto.idFamilia = familia.idFamilia
END
GO

GO
CREATE PROCEDURE MovimientoStockSelect
    @idMovimientoStock INT = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT * 
	FROM   movimientoStock
	WHERE  (idMovimientoStock = @idMovimientoStock or @idMovimientoStock IS NULL) 

	COMMIT

GO

GO
CREATE PROCEDURE [dbo].[MovimientoStockUpdate] 
    @idMovimientoStock int,
    @fecha datetime,
    @idTipoMovimiento int,
    @idProducto int,
    @cantidad float
   
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE movimientoStock
	SET 
	fecha= @fecha,
	idTipoMovimiento= @idTipoMovimiento,
	idProducto= @idProducto,
	cantidad= @cantidad
	WHERE @idMovimientoStock = idMovimientoStock
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   movimientoStock
	WHERE @idMovimientoStock = idMovimientoStock
	-- End Return Select <- do not remove

	COMMIT
GO

GO
CREATE PROCEDURE [dbo].[MovimientoStockInsert] 
    @fecha datetime,
    @idTipoMovimiento int,
    @idProducto int,
    @cantidad float
   
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	DECLARE @idMovimientoStock INT
	SELECT @idMovimientoStock = ISNULL(MAX(idMovimientoStock),0)+1 FROM dbo.movimientoStock
	
	INSERT INTO movimientoStock (idMovimientoStock,fecha,idTipoMovimiento,idProducto,cantidad)
	VALUES  (@idMovimientoStock,@fecha,@idTipoMovimiento,@idProducto,@cantidad)
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   movimientoStock
	WHERE @idMovimientoStock = idMovimientoStock
	-- End Return Select <- do not remove

	COMMIT
GO