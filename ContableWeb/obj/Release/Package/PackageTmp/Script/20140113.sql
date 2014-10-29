GO
CREATE TABLE dbo.origenCheque
	(
	idOrigenCheque int NOT NULL,
	descripcion varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.origenCheque ADD CONSTRAINT
	PK_origenCheque PRIMARY KEY CLUSTERED 
	(
	idOrigenCheque
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.cheque ADD CONSTRAINT
	FK_cheque_origenCheque FOREIGN KEY
	(
	idOrigenCheque
	) REFERENCES dbo.origenCheque
	(
	idOrigenCheque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
INSERT INTO dbo.origenCheque values (1,'Propio')
INSERT INTO dbo.origenCheque values (2,'De terceros')
GO
------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[OrigenChequeSelect] (
	@idOrigenCheque INT = NULL
)
AS
BEGIN
	SELECT	*
	FROM dbo.origenCheque
	WHERE idOrigenCheque = ISNULL(@idOrigenCheque,idOrigenCheque)
	ORDER BY idOrigenCheque
END
GO
CREATE PROCEDURE [dbo].[MedioPagoSelect] (
	@idMedioPago INT = NULL
)
AS
BEGIN
	SELECT	*
	FROM dbo.medioPago
	WHERE idMedioPago = ISNULL(@idMedioPago,idMedioPago)
	ORDER BY idMedioPago
END
GO
insert into MedioPago values (1,'Efectivo')
insert into MedioPago values (2,'Cheque')
insert into MedioPago values (3,'Transferencia')
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE ChequeCarteraPorNroBancoImporte (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT c.numero + ' - ' +  b.descripcion + ' - ' + CAST(c.importe as varchar(20)) AS descripcion
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

CREATE PROCEDURE bancoInsert 
    @descripcion varchar(100)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
    DECLARE @idBanco INT
	SELECT @idBanco = ISNULL(MAX(idBanco),0)+1 FROM dbo.banco

	INSERT INTO [dbo].banco ([idBanco], [descripcion])
	SELECT @idBanco, @descripcion
	
	-- Begin Return Select <- do not remove
	SELECT [idBanco], [descripcion]
	FROM   [dbo].[banco]
	WHERE  [idBanco] = @idBanco
	-- End Return Select <- do not remove
               
	COMMIT
GO
INSERT INTO pantalla VALUES (8,'frmBanco.aspx','Bancos','Tabla')
INSERT INTO usuarioPantalla VALUES (1,8,0)
GO
CREATE PROCEDURE [dbo].[bancoUpdate] 
    @idBanco int,
    @descripcion varchar(100)
   
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[banco]
	SET    [idBanco] = @idBanco, [descripcion] = @descripcion
	WHERE  [idBanco] = @idBanco
	
	-- Begin Return Select <- do not remove
	SELECT [idBanco], [descripcion]
	FROM   [dbo].[banco]
	WHERE  [idBanco] = @idBanco	
	-- End Return Select <- do not remove

	COMMIT

GO
CREATE PROCEDURE [dbo].[bancoSelect] 
    @idBanco INT = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [idBanco], [descripcion]  
	FROM   [dbo].[banco] 
	WHERE  ([idBanco] = @idBanco OR @idBanco IS NULL) 

	COMMIT
GO
GO
CREATE TABLE dbo.pagoCompra
	(
	idPago int NOT NULL,
	idCompra int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.pagoCompra ADD CONSTRAINT
	PK_pagoCompra PRIMARY KEY CLUSTERED 
	(
	idPago,
	idCompra
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.pagoCompra ADD CONSTRAINT
	FK_pagoCompra_pago FOREIGN KEY
	(
	idPago
	) REFERENCES dbo.pago
	(
	idPago
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.pagoCompra ADD CONSTRAINT
	FK_pagoCompra_compraCabe FOREIGN KEY
	(
	idCompra
	) REFERENCES dbo.compraCabe
	(
	idCompraCabe
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
GO
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[CompraSSaldarVista] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(c.idCompraCabe as varchar(20)) + ' - ' +  
	p.razonSocial + ' - ' + 
	CONVERT(VARCHAR(10), c.fechaCompra, 103)  + ' - ' + 
	ep.descripcion + ' - ' 
	+ '$' +
	ISNULL(
	CAST((SELECT SUM (cantidad * precioUnitario) as descripcion
	
	from CompraItem ci where ci.idCompra = c.idCompraCabe ) as varchar(20)),'0')
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
CREATE PROCEDURE [dbo].[CompraItemInsert] (
	@idCompra INT,
	@idProducto INT ,
	@cantidad INT ,
	@precioUnitario float,
	@observaciones varchar(100)
)
AS
BEGIN
	DECLARE @idCompraItem INT
	SELECT @idCompraItem = ISNULL(MAX(idCompraItem),0)+1 FROM dbo.compraItem
	INSERT INTO dbo.compraItem
	        ( idCompraItem, 
			  idCompra ,
	          idProducto ,
	          cantidad ,
	          precioUnitario ,
	          observaciones
	        )
	VALUES  ( @idCompraItem,
			  @idCompra ,
	          @idProducto ,
	          @cantidad , 
	          @precioUnitario,
	          @observaciones
	        )
	SELECT @idCompraItem AS idCompraItem
END
GO
GO
----------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[CompraItemSelect] (@idCompraItem INT = Null)
AS
BEGIN
	SELECT	*
	FROM dbo.compraItem
	WHERE (idCompraItem = @idCompraItem OR @idCompraItem is NULL)
END
GO