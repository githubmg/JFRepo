GO
ALTER TABLE dbo.cliente ADD
	idCliente int NULL
GO
UPDATE t1 
SET t1.idCliente = s.idCliente  
FROM  cliente t1
INNER JOIN
(
     SELECT cuit,ROW_NUMBER() OVER( ORDER BY cuit DESC) idCliente
     FROM cliente
) s ON t1.cuit = s.cuit
GO
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_cliente
	(
	cuit bigint NOT NULL,
	razonSocial varchar(100) NULL,
	idLocalidad int NULL,
	domicilio varchar(100) NULL,
	codigoPostal char(10) NULL,
	idCondicionIva int NULL,
	telefono varchar(20) NULL,
	email varchar(100) NULL,
	observaciones varchar(250) NULL,
	idCliente int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_cliente SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.cliente)
	 EXEC('INSERT INTO dbo.Tmp_cliente (cuit, razonSocial, idLocalidad, domicilio, codigoPostal, idCondicionIva, telefono, email, observaciones, idCliente)
		SELECT cuit, razonSocial, idLocalidad, domicilio, codigoPostal, idCondicionIva, telefono, email, observaciones, idCliente FROM dbo.cliente WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.pedidoCabe
	DROP CONSTRAINT FK_pedidoCabe_cliente
GO
DROP TABLE dbo.cliente
GO
EXECUTE sp_rename N'dbo.Tmp_cliente', N'cliente', 'OBJECT' 
GO
ALTER TABLE dbo.cliente ADD CONSTRAINT
	PK_cliente_1 PRIMARY KEY CLUSTERED 
	(
	idCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.pedidoCabe SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'CONTROL') as Contr_Per 
GO
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.pedidoCabe.cuitCliente', N'Tmp_idCliente', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.pedidoCabe.Tmp_idCliente', N'idCliente', 'COLUMN' 
GO
ALTER TABLE dbo.pedidoCabe SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'CONTROL') as Contr_Per 
GO
UPDATE pedidoCabe 
set idCliente = (SELECT idCliente from cliente where cuit=idCliente)
GO
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_pedidoCabe
	(
	idPedidoCabe int NOT NULL,
	idCliente int NULL,
	fechaPedido datetime NULL,
	orden varchar(50) NULL,
	idEstadoPedido int NULL,
	observaciones varchar(250) NULL,
	controlado bit NULL,
	idTipoOrden int NULL,
	chasis varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_pedidoCabe SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.pedidoCabe)
	 EXEC('INSERT INTO dbo.Tmp_pedidoCabe (idPedidoCabe, idCliente, fechaPedido, orden, idEstadoPedido, observaciones, controlado, idTipoOrden, chasis)
		SELECT idPedidoCabe, CONVERT(int, idCliente), fechaPedido, orden, idEstadoPedido, observaciones, controlado, idTipoOrden, chasis FROM dbo.pedidoCabe WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.cobroPedido
	DROP CONSTRAINT FK_cobroPedido_pedidoCabe
GO
ALTER TABLE dbo.remito
	DROP CONSTRAINT FK_remito_pedidoCabe
GO
ALTER TABLE dbo.pedidoItem
	DROP CONSTRAINT FK_pedidoItem_pedidoCabe
GO
DROP TABLE dbo.pedidoCabe
GO
EXECUTE sp_rename N'dbo.Tmp_pedidoCabe', N'pedidoCabe', 'OBJECT' 
GO
ALTER TABLE dbo.pedidoCabe ADD CONSTRAINT
	PK_pedidoCabe PRIMARY KEY CLUSTERED 
	(
	idPedidoCabe
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.pedidoCabe', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.pedidoItem ADD CONSTRAINT
	FK_pedidoItem_pedidoCabe FOREIGN KEY
	(
	idPedido
	) REFERENCES dbo.pedidoCabe
	(
	idPedidoCabe
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.pedidoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.pedidoItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.pedidoItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.pedidoItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.remito ADD CONSTRAINT
	FK_remito_pedidoCabe FOREIGN KEY
	(
	idPedido
	) REFERENCES dbo.pedidoCabe
	(
	idPedidoCabe
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.remito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.remito', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.remito', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.remito', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.cobroPedido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.cobroPedido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.cobroPedido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.cobroPedido', 'Object', 'CONTROL') as Contr_Per 
GO
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_cliente
	(
	cuit bigint NULL,
	razonSocial varchar(100) NULL,
	idLocalidad int NULL,
	domicilio varchar(100) NULL,
	codigoPostal char(10) NULL,
	idCondicionIva int NULL,
	telefono varchar(20) NULL,
	email varchar(100) NULL,
	observaciones varchar(250) NULL,
	idCliente int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_cliente SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.cliente)
	 EXEC('INSERT INTO dbo.Tmp_cliente (cuit, razonSocial, idLocalidad, domicilio, codigoPostal, idCondicionIva, telefono, email, observaciones, idCliente)
		SELECT cuit, razonSocial, idLocalidad, domicilio, codigoPostal, idCondicionIva, telefono, email, observaciones, idCliente FROM dbo.cliente WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.cliente
GO
EXECUTE sp_rename N'dbo.Tmp_cliente', N'cliente', 'OBJECT' 
GO
ALTER TABLE dbo.cliente ADD CONSTRAINT
	PK_cliente_1 PRIMARY KEY CLUSTERED 
	(
	idCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.cliente ADD CONSTRAINT
	FK_cliente_cliente FOREIGN KEY
	(
	idCliente
	) REFERENCES dbo.cliente
	(
	idCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.cliente', 'Object', 'CONTROL') as Contr_Per 
GO
GO
ALTER TABLE dbo.pedidoCabe ADD CONSTRAINT
	FK_pedidoCabe_cliente FOREIGN KEY
	(
	idCliente
	) REFERENCES dbo.cliente
	(
	idCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
GO
ALTER PROCEDURE [dbo].[clienteInsert] (
    @cuit bigint,@razonSocial varchar(100),@idLocalidad int,@domicilio varchar(100),
    @codigoPostal char(10),@idCondicionIva int,@telefono varchar(20),@email varchar(100),
    @observaciones varchar(250)
)
AS 
	BEGIN TRAN
	DECLARE @idCliente INT
	SELECT @idCliente = ISNULL(MAX(idCliente),0)+1 FROM dbo.cliente
	
	INSERT INTO cliente (idCliente, cuit,razonSocial,idLocalidad,domicilio,codigoPostal,idCondicionIva,telefono,email,observaciones)
	SELECT   @idCliente,@cuit,@razonSocial,@idLocalidad,@domicilio,@codigoPostal,@idCondicionIva,@telefono,@email,@observaciones
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cliente
	WHERE  idCliente = @idCliente
	-- End Return Select <- do not remove
               
	COMMIT
GO

GO
CREATE PROCEDURE clientePorCuit (
    @cuit bigint
)
AS 
	SELECT *
	FROM   dbo.cliente 
	WHERE  (cuit = @cuit)

GO

ALTER PROCEDURE [dbo].[clienteSelect] (
    @idCliente int = NULL
)
AS 
	BEGIN TRAN
	SELECT *
	FROM   dbo.cliente 
	WHERE  (idCliente = @idCliente OR @idCliente IS NULL)
	COMMIT
GO
ALTER PROCEDURE [dbo].[clienteUpdate] (
	@idCliente int,
   @cuit bigint,
   @razonSocial varchar(100),
   @idLocalidad int,
   @domicilio varchar(100),
   @codigoPostal char(10),
   @idCondicionIva int,
   @telefono varchar(20),
   @email varchar(100),
   @observaciones varchar(250)
)
AS 
	BEGIN TRAN
	UPDATE dbo.cliente
	SET      cuit = @cuit,razonSocial = @razonSocial,idLocalidad= @idLocalidad,domicilio = @domicilio,
	codigoPostal=@codigoPostal,idCondicionIva=@idCondicionIva,telefono=@telefono,
	email=@email,observaciones=@observaciones
	WHERE  idCliente=@idCliente
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cliente
	WHERE  idCliente=@idCliente
	-- End Return Select <- do not remove
	COMMIT

GO
ALTER PROCEDURE [dbo].[pedidoCabeVista] 
AS
BEGIN
	SELECT pc.idPedidoCabe,
	pc.fechaPedido, 
	pc.orden,
	pc.chasis,
	c.razonSocial as 'razonSocial',
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
	tor.descripcion as 'tipoOrden'
	FROM pedidoCabe pc 
	 INNER JOIN cliente c ON pc.idCliente = c.idCliente
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	 INNER JOIN tipoOrden tor ON tor.idTipoOrden = pc.idTipoOrden
END

GO


----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeInsert] (
	@idCliente INT,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@chasis Varchar(50) ,
	@idEstadoPedido INT ,
	@idTipoOrden INT ,
	@observaciones Varchar(250)
)
AS
BEGIN
	DECLARE @idCabe INT
	SELECT @idCabe = ISNULL(MAX(idPedidoCabe),0)+1 FROM dbo.pedidoCabe
	INSERT INTO dbo.pedidoCabe
	        ( idPedidoCabe, 
	         idCliente,
	         fechaPedido,
	         chasis,
	         orden,
	         idEstadoPedido,
	         idTipoOrden,
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @idCliente ,
	          @fechaPedido ,
	          @chasis ,
	          @orden , 
	          @idEstadoPedido ,
	          @idTipoOrden ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeUpdate] (
	@idPedidoCabe int,
	@idCliente bigint,
	@fechaPedido DATETIME ,
	@chasis varchar(50),
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
	@idTipoOrden INT ,
	@observaciones Varchar(250)
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   pedidoCabe SET
	         idCliente=@idCliente,
	         fechaPedido=@fechaPedido,
	         chasis=@chasis,
	         orden=@orden,
	         idEstadoPedido=@idEstadoPedido,
	         idTipoOrden=@idTipoOrden,
	         observaciones=@observaciones
	WHERE idPedidoCabe=@idPedidoCabe 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   pedidoCabe
	WHERE  idPedidoCabe = @idPedidoCabe
	-- End Return Select <- do not remove
	COMMIT

END
GO

GO
ALTER PROCEDURE [dbo].[clienteVista]
AS
BEGIN
	SELECT	c.idCliente,c.cuit,c.razonSocial,l.descripcion as 'localidad',
	c.domicilio,c.codigoPostal,
	ci.descripcion as 'condicionIva',
	c.telefono,c.email,c.observaciones
	FROM dbo.cliente c
	JOIN dbo.localidad l ON c.idLocalidad = l.idLocalidad
	JOIN dbo.condicionIva ci ON c.idCondicionIva = ci.idCondicionIva
	ORDER BY c.razonSocial
END
GO
UPDATE pedidoCabe set idCliente = (select top 1 idCliente from cliente)
UPDATE pedidoCabe set controlado = 0 WHERE controlado is null
UPDATE pedidoCabe set chasis = '' where chasis is null

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[ClienteVistaPorCuitORazon] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(c.idCliente as varchar(20)) + '- ' + CAST(c.cuit as varchar(20)) + ' - ' +  c.razonSocial AS descripcion
	FROM dbo.cliente c
	WHERE c.razonSocial LIKE '%'+@descripcion+'%' 
	OR CAST(c.cuit as varchar(20)) LIKE '%'+@descripcion+'%'
	ORDER BY c.cuit
END
GO
GO
CREATE TABLE dbo.vendedor
	(
	idVendedor int NOT NULL,
	descripcion varchar(100) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.vendedor ADD CONSTRAINT
	PK_vendedor PRIMARY KEY CLUSTERED 
	(
	idVendedor
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO
ALTER TABLE dbo.pedidoItem ADD
	idVendedor int NULL
GO
GO
ALTER TABLE dbo.pedidoItem ADD CONSTRAINT
	FK_pedidoItem_vendedor FOREIGN KEY
	(
	idVendedor
	) REFERENCES dbo.vendedor
	(
	idVendedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
GO
CREATE PROCEDURE [dbo].[VendedorSelect]
    @idVendedor INT = NULL
AS 
	SELECT *
	FROM   vendedor 
	WHERE  (idVendedor = @idVendedor OR @idVendedor IS NULL) 

GO
ALTER PROCEDURE [dbo].[PedidoItemInsert] (
	@idPedido INT,
	@idProducto INT ,
	@cantidad INT ,
	@idVendedor INT,
	@precioUnitario float,
	@observaciones varchar(100)
)
AS
BEGIN
	DECLARE @idPedidoItem INT
	SELECT @idPedidoItem = ISNULL(MAX(idPedidoItem),0)+1 FROM dbo.pedidoItem
	INSERT INTO dbo.pedidoItem
	        ( idPedidoItem, 
			  idPedido ,
	          idProducto ,
	          cantidad ,
			  idVendedor,		
	          precioUnitario ,
	          observaciones
	        )
	VALUES  ( @idPedidoItem,
			  @idPedido ,
	          @idProducto ,
	          @cantidad , 
			  @idVendedor,
	          @precioUnitario,
	          @observaciones
	        )
	SELECT @idPedidoItem AS idPedidoItem
END

GO
INSERT INTO vendedor VALUES (1,'Sin vendedor')
UPDATE pedidoItem set idVendedor = 1
GO
----------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoSSaldarVista] (@descripcion VARCHAR(100))
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
	) as varchar(20)),'0')+ ' - ' +
	ISNULL(CAST(re.idFactura as varchar(20)),'Sin facturar') 
	
	FROM pedidoCabe p 
	 INNER JOIN cliente c ON p.idCliente = c.idCliente
	 INNER JOIN estadoPedido ep ON p.idEstadoPedido = ep.idEstadoPedido
	 LEFT JOIN remito re ON re.idPedido = p.idPedidoCabe
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