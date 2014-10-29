GO
CREATE TABLE dbo.estadoPedido
	(
	idEstadoPedido int NOT NULL,
	descripcion varchar(100) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.estadoPedido ADD CONSTRAINT
	PK_estadoPedido PRIMARY KEY CLUSTERED 
	(
	idEstadoPedido
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
GO

CREATE TABLE [dbo].[pedidoCabe](
	[idPedidoCabe] [int] NOT NULL,
	[cuitCliente] [bigint] NULL,
	[fechaPedido] [datetime] NULL,
	[orden] [varchar](50) NULL,
	[idEstadoPedido] [int] NULL,
	[descuento] [float] NULL,
	[observaciones] [varchar](250) NULL,
 CONSTRAINT [PK_pedidoCabe] PRIMARY KEY CLUSTERED 
(
	[idPedidoCabe] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[pedidoCabe]  WITH CHECK ADD  CONSTRAINT [FK_pedidoCabe_cliente] FOREIGN KEY([cuitCliente])
REFERENCES [dbo].[cliente] ([cuit])
GO

ALTER TABLE [dbo].[pedidoCabe] CHECK CONSTRAINT [FK_pedidoCabe_cliente]
GO

ALTER TABLE [dbo].[pedidoCabe]  WITH CHECK ADD  CONSTRAINT [FK_pedidoCabe_estadoPedido] FOREIGN KEY([idEstadoPedido])
REFERENCES [dbo].[estadoPedido] ([idEstadoPedido])
GO

ALTER TABLE [dbo].[pedidoCabe] CHECK CONSTRAINT [FK_pedidoCabe_estadoPedido]
GO
GO

CREATE TABLE [dbo].[pedidoItem](
	[idPedidoItem] [int] NOT NULL,
	[idPedido] [int] NULL,
	[idProducto] [int] NULL,
	[cantidad] [int] NULL,
	[chasis] [varchar](50) NULL,
	[precioUnitario] [float] NULL,
	[descuentoUnitario] [float] NULL,
	[observaciones] [varchar](100) NULL,
 CONSTRAINT [PK_pedidoItem] PRIMARY KEY CLUSTERED 
(
	[idPedidoItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[pedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_pedidoItem_pedidoCabe] FOREIGN KEY([idPedido])
REFERENCES [dbo].[pedidoCabe] ([idPedidoCabe])
GO

ALTER TABLE [dbo].[pedidoItem] CHECK CONSTRAINT [FK_pedidoItem_pedidoCabe]
GO

ALTER TABLE [dbo].[pedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_pedidoItem_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO

ALTER TABLE [dbo].[pedidoItem] CHECK CONSTRAINT [FK_pedidoItem_producto]
GO
