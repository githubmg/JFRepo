INSERT INTO pantalla VALUES (6,'frmCompra.aspx','Compras','Proceso')
INSERT INTO usuarioPantalla VALUES (1,6,0)

GO

CREATE TABLE [dbo].[compraCabe](
	[idCompraCabe] [int] NOT NULL,
	[cuitProveedor] [bigint] NULL,
	[fechaCompra] [datetime] NULL,
	[idEstado] [int] NULL,
	[observaciones] [varchar](250) NULL,
 CONSTRAINT [PK_compraCabe] PRIMARY KEY CLUSTERED 
(
	[idCompraCabe] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[compraCabe]  WITH CHECK ADD  CONSTRAINT [FK_compraCabe_estadoPedido] FOREIGN KEY([idEstado])
REFERENCES [dbo].[estadoPedido] ([idEstadoPedido])
GO

ALTER TABLE [dbo].[compraCabe] CHECK CONSTRAINT [FK_compraCabe_estadoPedido]
GO

ALTER TABLE [dbo].[compraCabe]  WITH CHECK ADD  CONSTRAINT [FK_compraCabe_proveedor] FOREIGN KEY([cuitProveedor])
REFERENCES [dbo].[proveedor] ([cuit])
GO

ALTER TABLE [dbo].[compraCabe] CHECK CONSTRAINT [FK_compraCabe_proveedor]
GO

GO

CREATE TABLE [dbo].[compraItem](
	[idCompraItem] [int] NOT NULL,
	[idCompra] [int] NULL,
	[idProducto] [int] NULL,
	[cantidad] [int] NULL,
	[precioUnitario] [float] NULL,
	[observaciones] [varchar](250) NULL,
 CONSTRAINT [PK_compraItem] PRIMARY KEY CLUSTERED 
(
	[idCompraItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[compraItem]  WITH CHECK ADD  CONSTRAINT [FK_compraItem_compraCabe] FOREIGN KEY([idCompra])
REFERENCES [dbo].[compraCabe] ([idCompraCabe])
GO

ALTER TABLE [dbo].[compraItem] CHECK CONSTRAINT [FK_compraItem_compraCabe]
GO

ALTER TABLE [dbo].[compraItem]  WITH CHECK ADD  CONSTRAINT [FK_compraItem_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO

ALTER TABLE [dbo].[compraItem] CHECK CONSTRAINT [FK_compraItem_producto]
GO



