GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[cobroVista] 
AS
BEGIN
	SELECT c.idCobro,c.fecha,mp.descripcion as 'medioPago',
			c.importe,c.observaciones
	FROM cobro c 
	 INNER JOIN medioPago mp on mp.idMedioPago = c.idMedioPago
END
GO
INSERT INTO pantalla VALUES (9,'frmCobro.aspx','Cobros','Proceso')
INSERT INTO usuarioPantalla VALUES (1,9,0)
GO
CREATE TABLE dbo.cobroPedido
	(
	idCobro int NOT NULL,
	idPedido int NOT NULL,
	montoCancelado float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.cobroPedido ADD CONSTRAINT
	PK_cobroPedido PRIMARY KEY CLUSTERED 
	(
	idCobro,
	idPedido
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
CREATE TABLE dbo.cobroCheque
	(
	idCobro int NOT NULL,
	idCheque int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.cobroCheque ADD CONSTRAINT
	PK_cobroCheque PRIMARY KEY CLUSTERED 
	(
	idCobro,
	idCheque
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.cobroCheque ADD CONSTRAINT
	FK_cobroCheque_cobro FOREIGN KEY
	(
	idCobro
	) REFERENCES dbo.cobro
	(
	idCobro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.cobroCheque ADD CONSTRAINT
	FK_cobroCheque_cheque FOREIGN KEY
	(
	idCheque
	) REFERENCES dbo.cheque
	(
	idCheque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
GO
ALTER TABLE dbo.cobroPedido ADD CONSTRAINT
	FK_cobroPedido_cobro FOREIGN KEY
	(
	idCobro
	) REFERENCES dbo.cobro
	(
	idCobro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.cobroPedido ADD CONSTRAINT
	FK_cobroPedido_pedidoCabe FOREIGN KEY
	(
	idPedido
	) REFERENCES dbo.pedidoCabe
	(
	idPedidoCabe
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoSSaldarVista] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(p.idPedidoCabe as varchar(20)) + ' - ' +  
	c.razonSocial + ' - ' + 
	CONVERT(VARCHAR(10), p.fechaPedido, 103)  + ' - ' + 
	ep.descripcion + ' - ' 
	+ '$' +
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from pedidoItem pit where pit.idPedido = p.idPedidoCabe ),0)) 
	-
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c	INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = p.idPedidoCabe),0))
	) as varchar(20)),'0')
	
	FROM pedidoCabe p 
	 INNER JOIN cliente c ON p.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON p.idEstadoPedido = ep.idEstadoPedido
	WHERE 
	(
	CAST(p.idPedidoCabe as varchar(20)) LIKE '%'+@descripcion+'%' OR
	c.razonSocial LIKE '%'+@descripcion+'%') 
	AND 
	--Condicion de que el pedido esté sin saldar
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from pedidoItem pit where pit.idPedido = p.idPedidoCabe ),0)
	) 
	> 
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c	INNER JOIN cobroPedido cp ON c.idCobro = cp.idcobro
	WHERE cp.idPedido = p.idPedidoCabe),0)
	)	
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[MontoPedidoSSaldarVista] (@idPedido int)
AS
BEGIN
	SELECT 
	(ISNULL((SELECT SUM (pit.cantidad * pit.precioUnitario)  
	from PedidoItem pit where pit.idPedido = p.idPedidoCabe ),0)) 
	-
	(ISNULL((SELECT SUM (cp.montoCancelado) 
	from cobro c	INNER JOIN cobroPedido cp ON c.idCobro = cp.idCobro
	WHERE cp.idPedido = p.idPedidoCabe),0))
	as saldo
	FROM pedidoCabe p 
	WHERE 
	p.idPedidoCabe = @idPedido
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[CobroInsert] (
	@fecha datetime,
	@idMedioPago int,
	@importe float,
	@observaciones varchar(150)
	
)
AS
BEGIN
	DECLARE @idCobro INT
	SELECT @idCobro = ISNULL(MAX(idCobro),0)+1 FROM dbo.cobro
	INSERT INTO dbo.cobro
	        ( 
	        idCobro,
	        fecha,
	        idMedioPago,
	        importe,
	        observaciones
	        )
	VALUES  ( 
			@idCobro,
			@fecha,
			@idMedioPago,
			@importe,
			@observaciones				
	        )
	SELECT @idCobro AS 'idCobro'
END
GO
