GO
ALTER PROCEDURE [dbo].[FacturaInsert] 
    @fecha date,
    @observaciones varchar(100)
AS 
    DECLARE @idFactura INT
	SELECT @idFactura = ISNULL(MAX(idFactura),0)+1 FROM dbo.factura

	INSERT INTO [dbo].factura (idFactura, fecha, observaciones)
	SELECT @idFactura, @fecha, @observaciones
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   factura
	WHERE  idFactura = @idFactura
	-- End Return Select <- do not remove
GO
GO
ALTER TABLE dbo.movimientoCaja ADD
	idDescripcionMovCaja int NULL
GO
GO
CREATE TABLE dbo.descripcionMovCaja
	(
	idDescripcionMovCaja int NOT NULL,
	descripcion varchar(100) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.descripcionMovCaja ADD CONSTRAINT
	PK_descripcionMovCaja PRIMARY KEY CLUSTERED 
	(
	idDescripcionMovCaja
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.movimientoCaja ADD CONSTRAINT
	FK_movimientoCaja_descripcionMovCaja FOREIGN KEY
	(
	idDescripcionMovCaja
	) REFERENCES dbo.descripcionMovCaja
	(
	idDescripcionMovCaja
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
USE [jfservicios]
GO
/****** Object:  StoredProcedure [dbo].[MovimientoCajaInsert]    Script Date: 07/17/2014 14:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[MovimientoCajaInsert] (
	@idTipoMovimiento int,
	@idDescripcionMovCaja int,
	@fecha datetime,
	@idMedioPago int,
	@monto float
	
)
AS
BEGIN
	DECLARE @idMovimientoCaja INT
	SELECT @idMovimientoCaja = ISNULL(MAX(idMovimientoCaja),0)+1 FROM dbo.movimientoCaja
	INSERT INTO dbo.movimientoCaja
	        ( 
	        idMovimientoCaja,
	        idDescripcionMovCaja,
	        idTipoMovimiento,
	        fecha,
	        idMedioPago,
	        monto
	        )
	VALUES  ( 
			@idMovimientoCaja,
			@idDescripcionMovCaja,
	        @idTipoMovimiento,
	        @fecha,
	        @idMedioPago,
	        @monto		
	        )
	SELECT @idMovimientoCaja AS 'idMovimientoCaja'
END
GO

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[MovimientoCajaUpdate] (
	@idMovimientoCaja INT,
	@idDescripcionMovCaja INT,
	@idTipoMovimiento int,
	@fecha datetime,
	@idMedioPago int,
	@monto float
	
)
AS
BEGIN
	UPDATE dbo.movimientoCaja SET 
	idTipoMovimiento=@idTipoMovimiento,
	idDescripcionMovCaja=@idDescripcionMovCaja,
	fecha=@fecha,
	idMedioPago=@idMedioPago,
	monto=@monto
	WHERE
	idMovimientoCaja = @idMovimientoCaja
	SELECT @idMovimientoCaja AS 'idMovimientoCaja'
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[movimientoCajaVista] 
AS
BEGIN
	SELECT m.idMovimientoCaja,m.fecha,mp.descripcion as 'medioPago',
			m.monto, tp.descripcion as 'tipoMovimiento', 
			dm.descripcion as 'descripcionMovCaja'
	FROM movimientoCaja m 
	 INNER JOIN medioPago mp on mp.idMedioPago = m.idMedioPago
	 INNER JOIN tipoMovimiento tp on tp.idTipoMovimiento = m.idTipoMovimiento
	 LEFT JOIN descripcionMovCaja dm on dm.idDescripcionMovCaja = m.idDescripcionMovCaja
END
GO
INSERT INTO pantalla values (23,'ReporteMovCaja.aspx','Movimiento de Caja','Reporte')
INSERT INTO usuarioPantalla VALUES (1,23,0)
GO

CREATE PROCEDURE [dbo].[rptMovCaja] (
	@desde DATE = null,
	@hasta DATE = null
)
AS
BEGIN
	SELECT m.idMovimientoCaja,Convert(varchar(10),CONVERT(date,m.fecha,106),103) as fecha,mp.descripcion as 'medioPago',
			m.monto, tp.descripcion as 'tipoMovimiento', 
			dm.descripcion as 'descripcionMovCaja'
	FROM movimientoCaja m 
	 INNER JOIN medioPago mp on mp.idMedioPago = m.idMedioPago
	 INNER JOIN tipoMovimiento tp on tp.idTipoMovimiento = m.idTipoMovimiento
	 LEFT JOIN descripcionMovCaja dm on dm.idDescripcionMovCaja = m.idDescripcionMovCaja
	WHERE (m.fecha >= @desde or @desde is NULL) AND
			(m.fecha<= @hasta or @hasta is NULL)
	ORDER BY m.fecha DESC
END
GO