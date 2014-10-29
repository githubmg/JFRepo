GO

CREATE TABLE [dbo].[remito](
	[idRemito] [int] NOT NULL,
	[idPedido] [int] NULL,
	[idFactura] [int] NULL,
 CONSTRAINT [PK_remito] PRIMARY KEY CLUSTERED 
(
	[idRemito] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[remito]  WITH CHECK ADD  CONSTRAINT [FK_remito_pedidoCabe] FOREIGN KEY([idPedido])
REFERENCES [dbo].[pedidoCabe] ([idPedidoCabe])
GO