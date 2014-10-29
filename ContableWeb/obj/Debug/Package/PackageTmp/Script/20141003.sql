GO

ALTER PROCEDURE [dbo].[rptChequesCedidos] (
	@desde DATE = null,
	@hasta DATE = null,
	@cobrado BIT = null
)
AS
BEGIN
select ch.idCheque,
Convert(varchar(10),CONVERT(date,ch.fechaVencimiento,106),103) as fechaVencimiento,
Convert(varchar(10),CONVERT(date,ch.fechaEmision,106),103) as fechaEmision,
Convert(varchar(10),datediff(d,GETDATE(),ch.fechaVencimiento)) as diasRestantes,
ch.idCheque,
orch.descripcion as origenCheque,
ch.importe,
ch.numero,
ISNULL(b.descripcion,'') as banco, 
max(ISNULL(pro.razonSocial,'Sin proveedor')) as proveedor
from 
cheque ch 
LEFT JOIN banco b on b.idBanco = ch.idBanco
JOIN pagoCheque pc ON pc.idCheque = ch.idCheque
JOIN pagoCompra paco ON pc.idPago = paco.idPago
JOIN compraCabe cc on cc.idCompraCabe = paco.idCompra
JOIN origenCheque orch ON ch.idOrigenCheque = orch.idOrigenCheque
JOIN proveedor pro ON pro.cuit = cc.cuitProveedor
WHERE enCartera = 0
AND (cc.fechaCompra >= @desde or @desde is NULL) AND
			(cc.fechaCompra<= @hasta or @hasta is NULL) AND
			(ch.cobrado = @cobrado or @cobrado is NULL)
group by 	
ch.idCheque,
orch.descripcion,
ch.importe,
ch.numero,
b.descripcion,
ch.fechaVencimiento,
ch.fechaEmision,
cc.fechaCompra		
	ORDER BY  cc.fechaCompra DESC
END
GO
GO
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
	c.razonSocial LIKE '%'+@descripcion+'%' OR
	re.idFactura LIKE '%'+@descripcion+'%'
	) 
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
GO

CREATE TABLE [dbo].[evento](
	[idEvento] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[trabajo] [text] NULL,
	[datosContacto] [text] NULL,
	[estado] [varchar](50) NULL,
	[domicilio] [varchar](250) NULL,
	[idCliente] [int] NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[idEvento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[evento]  WITH CHECK ADD  CONSTRAINT [FK_Evento_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([idCliente])
GO

ALTER TABLE [dbo].[evento] CHECK CONSTRAINT [FK_Evento_cliente]
GO


