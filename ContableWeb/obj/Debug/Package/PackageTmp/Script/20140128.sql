GO

CREATE TABLE [dbo].[tipoMovimiento](
	[idTipoMovimiento] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[idTipoMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GO
CREATE TABLE dbo.movimientoCaja
	(
	idMovimientoCaja int NOT NULL,
	idTipoMovimiento int NULL,
	fecha datetime NULL,
	idMedioPago int NULL,
	monto float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.movimientoCaja ADD CONSTRAINT
	PK_movimientoCaja PRIMARY KEY CLUSTERED 
	(
	idMovimientoCaja
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.movimientoCaja ADD CONSTRAINT
	FK_movimientoCaja_medioPago FOREIGN KEY
	(
	idMedioPago
	) REFERENCES dbo.medioPago
	(
	idMedioPago
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.movimientoCaja ADD CONSTRAINT
	FK_movimientoCaja_tipoMovimiento FOREIGN KEY
	(
	idTipoMovimiento
	) REFERENCES dbo.tipoMovimiento
	(
	idTipoMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

CREATE TABLE [dbo].[movimientoCajaCheque](
	[idMovimientoCaja] [int] NOT NULL,
	[idCheque] [int] NOT NULL,
 CONSTRAINT [PK_movimientoCajaCheque] PRIMARY KEY CLUSTERED 
(
	[idMovimientoCaja] ASC,
	[idCheque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.movimientoCajaCheque ADD CONSTRAINT
	FK_movimientoCajaCheque_movimientoCaja FOREIGN KEY
	(
	idMovimientoCaja
	) REFERENCES dbo.movimientoCaja
	(
	idMovimientoCaja
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.movimientoCajaCheque ADD CONSTRAINT
	FK_movimientoCajaCheque_cheque FOREIGN KEY
	(
	idCheque
	) REFERENCES dbo.cheque
	(
	idCheque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
INSERT INTO pantalla VALUES ('10','frmMovimientoCaja.aspx','Movimientos de Caja','Proceso')
INSERT INTO usuarioPantalla VALUES (1,10,0)
update pantalla set descripcion = 'Pedidos' where descripcion = 'Pedido'
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[movimientoCajaVista] 
AS
BEGIN
	SELECT m.idMovimientoCaja,m.fecha,mp.descripcion as 'medioPago',
			m.monto, tp.descripcion as 'tipoMovimiento'
	FROM movimientoCaja m 
	 INNER JOIN medioPago mp on mp.idMedioPago = m.idMedioPago
	 INNER JOIN tipoMovimiento tp on tp.idTipoMovimiento = m.idTipoMovimiento
END
GO
GO
CREATE PROCEDURE [dbo].[TipoMovimientoSelect] 
    @idTipoMovimiento INT = NULL
AS 
	SELECT *
	FROM   [dbo].[tipoMovimiento] 
	WHERE  (idTipoMovimiento = @idTipoMovimiento OR @idTipoMovimiento IS NULL) 

GO	
INSERT INTO dbo.tipoMovimiento VALUES (1,'Ingreso')
INSERT INTO dbo.tipoMovimiento VALUES (2,'Egreso')
GO
CREATE PROCEDURE [dbo].[MovimientoCajaChequeInsert] (
   @idMovimientoCaja int,
   @idCheque int
)
AS 
	BEGIN TRAN

	INSERT INTO dbo.movimientoCajaCheque(idMovimientoCaja,idCheque)
	VALUES (@idMovimientoCaja,@idCheque)
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   movimientoCajaCheque
	WHERE  idMovimientoCaja = @idMovimientoCaja AND idCheque = @idCheque
	-- End Return Select <- do not remove
               
	COMMIT
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[MovimientoCajaUpdate] (
	@idMovimientoCaja INT,
	@idTipoMovimiento int,
	@fecha datetime,
	@idMedioPago int,
	@monto float
	
)
AS
BEGIN
	UPDATE dbo.movimientoCaja SET 
	idTipoMovimiento=@idTipoMovimiento,
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
CREATE PROCEDURE [dbo].[MovimientoCajaInsert] (
	@idTipoMovimiento int,
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
	        idTipoMovimiento,
	        fecha,
	        idMedioPago,
	        monto
	        )
	VALUES  ( 
			@idMovimientoCaja,
	        @idTipoMovimiento,
	        @fecha,
	        @idMedioPago,
	        @monto		
	        )
	SELECT @idMovimientoCaja AS 'idMovimientoCaja'
END
GO
GO
CREATE PROCEDURE [dbo].[MovimientoCajaChequeDelete] (@idMovimientoCaja INT)
AS
BEGIN
	DELETE
	FROM dbo.movimientoCajaCheque
	WHERE (idMovimientoCaja = @idMovimientoCaja)
END
GO