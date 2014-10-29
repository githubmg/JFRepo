update pedidoCabe set idTipoOrden = 1

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeUpdate] (
	@idPedidoCabe int,
	@cuitCliente bigint,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
	@idTipoOrden INT ,
	@observaciones Varchar(250)
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   pedidoCabe SET
	         cuitCliente=@cuitCliente,
	         fechaPedido=@fechaPedido,
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
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[pedidoCabeVista] 
AS
BEGIN
	SELECT pc.idPedidoCabe,
	pc.fechaPedido, 
	pc.orden,
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
	 INNER JOIN cliente c ON pc.cuitCliente = c.cuit
	 INNER JOIN estadoPedido ep ON pc.idEstadoPedido = ep.idEstadoPedido
	 INNER JOIN tipoOrden tor ON tor.idTipoOrden = pc.idTipoOrden
END
GO

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[compraCabeVista] 
AS
BEGIN
	SELECT cc.idCompraCabe,
	p.razonSocial as 'proveedor',
	cc.fechaCompra, 
	ep.descripcion as 'estado',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = cc.idCompraCabe ),0)) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario)  
	from CompraItem ci where ci.idCompra = cc.idCompraCabe ),0)) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idpago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'saldado',
	tor.descripcion as 'tipoOrden'
	 FROM compraCabe cc 
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON cc.idEstado = ep.idEstadoPedido
	 INNER JOIN tipoOrden tor ON cc.idTipoOrden = tor.idTipoOrden
END
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
ALTER TABLE dbo.producto
	DROP CONSTRAINT FK_producto_alicuotaIva
GO
ALTER TABLE dbo.alicuotaIva SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.producto
	DROP CONSTRAINT FK_producto_familia
GO
ALTER TABLE dbo.familia SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_producto
	(
	idProducto int NOT NULL,
	idFamilia int NULL,
	idAlicuotaIva int NULL,
	descripcion varchar(150) NULL,
	codProducto char(20) NULL,
	activo bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_producto SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.producto)
	 EXEC('INSERT INTO dbo.Tmp_producto (idProducto, idFamilia, idAlicuotaIva, descripcion, codProducto)
		SELECT idProducto, idFamilia, idAlicuotaIva, descripcion, codProducto FROM dbo.producto WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.movimientoStock
	DROP CONSTRAINT FK_movimientoStock_producto
GO
ALTER TABLE dbo.pedidoItem
	DROP CONSTRAINT FK_pedidoItem_producto
GO
ALTER TABLE dbo.compraItem
	DROP CONSTRAINT FK_compraItem_producto
GO
DROP TABLE dbo.producto
GO
EXECUTE sp_rename N'dbo.Tmp_producto', N'producto', 'OBJECT' 
GO
ALTER TABLE dbo.producto ADD CONSTRAINT
	PK_producto PRIMARY KEY CLUSTERED 
	(
	idProducto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.producto ADD CONSTRAINT
	FK_producto_familia FOREIGN KEY
	(
	idFamilia
	) REFERENCES dbo.familia
	(
	idFamilia
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.producto ADD CONSTRAINT
	FK_producto_alicuotaIva FOREIGN KEY
	(
	idAlicuotaIva
	) REFERENCES dbo.alicuotaIva
	(
	idAlicuotaIva
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.compraItem ADD CONSTRAINT
	FK_compraItem_producto FOREIGN KEY
	(
	idProducto
	) REFERENCES dbo.producto
	(
	idProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.compraItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.pedidoItem ADD CONSTRAINT
	FK_pedidoItem_producto FOREIGN KEY
	(
	idProducto
	) REFERENCES dbo.producto
	(
	idProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.pedidoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
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
ALTER TABLE dbo.movimientoStock SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO
GO
CREATE PROCEDURE [dbo].[productoDelete] (
    @idProducto int
)
AS 
	UPDATE producto set activo = 0 
	WHERE  idProducto = @idProducto
GO	
GO
ALTER PROCEDURE [dbo].[productoVista]
AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia', a.descripcion as 'alicuotaIva',p.descripcion,
	p.codProducto
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	JOIN dbo.alicuotaIva a ON a.idAlicuotaIva = p.idAlicuotaIva
	WHERE p.activo = 1
	ORDER BY p.descripcion
END
GO
update producto set activo = 1

GO
ALTER PROCEDURE [dbo].[productoInsert] (
   @descripcion varchar(150),
   @idFamilia int,
   @idAlicuotaIva int,
   @activo bit,
   @codProducto char(20)
)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
    DECLARE @idProducto INT
	SELECT @idProducto = ISNULL(MAX(idProducto),0)+1 FROM dbo.producto

	INSERT INTO producto (idProducto,idFamilia,idAlicuotaIva,descripcion,codProducto,activo)
	SELECT   @idProducto,@idFamilia,@idAlicuotaIva,@descripcion,@codProducto,@activo
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   producto
	WHERE  idProducto = @idProducto
	-- End Return Select <- do not remove
               
	COMMIT

GO

GO
ALTER PROCEDURE [dbo].[ProductoVistaByFamilia](
@idFamilia int
)

AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia', a.descripcion as 'alicuotaIva',p.descripcion,
	p.codProducto
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	JOIN dbo.alicuotaIva a ON a.idAlicuotaIva = p.idAlicuotaIva
	WHERE f.idFamilia = @idFamilia 
	AND p.activo = 1
	ORDER BY p.descripcion
END
GO
INSERT INTO cliente(cuit,razonSocial) VALUES (27000000006,'CUIT desconocido')
INSERT INTO proveedor(cuit,razonSocial) VALUES (27000000006,'CUIT desconocido')