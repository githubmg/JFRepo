GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[compraCabeVista] 
AS
BEGIN
	SELECT cc.idCompraCabe,
	p.razonSocial as 'proveedor',
	cc.fechaCompra, 
	ep.descripcion as 'estado'
	FROM compraCabe cc 
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON cc.idEstado = ep.idEstadoPedido
END
GO
GO

CREATE TABLE [dbo].[banco](
	[idBanco] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_banco] PRIMARY KEY CLUSTERED 
(
	[idBanco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

GO

CREATE TABLE [dbo].[cheque](
	[idCheque] [int] NOT NULL,
	[idBanco] [int] NULL,
	[numero] [varchar](50) NULL,
	[fechaEmision] [datetime] NULL,
	[fechaVencimiento] [datetime] NULL,
	[importe] [float] NULL,
	[idOrigenCheque] [int] NULL,
	[enCartera] [bit] NULL,
 CONSTRAINT [PK_cheque] PRIMARY KEY CLUSTERED 
(
	[idCheque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cheque]  WITH CHECK ADD  CONSTRAINT [FK_cheque_banco] FOREIGN KEY([idBanco])
REFERENCES [dbo].[banco] ([idBanco])
GO

ALTER TABLE [dbo].[cheque] CHECK CONSTRAINT [FK_cheque_banco]

GO

CREATE TABLE [dbo].[medioPago](
	[idMedioPago] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_medioPago] PRIMARY KEY CLUSTERED 
(
	[idMedioPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GO

CREATE TABLE [dbo].[cobro](
	[idCobro] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[idMedioPago] [int] NULL,
	[importe] [float] NULL,
	[observaciones] [varchar](150) NULL,
 CONSTRAINT [PK_cobro] PRIMARY KEY CLUSTERED 
(
	[idCobro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cobro]  WITH CHECK ADD  CONSTRAINT [FK_cobro_medioPago] FOREIGN KEY([idMedioPago])
REFERENCES [dbo].[medioPago] ([idMedioPago])
GO

ALTER TABLE [dbo].[cobro] CHECK CONSTRAINT [FK_cobro_medioPago]
GO



GO

CREATE TABLE [dbo].[pago](
	[idPago] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[idMedioPago] [int] NULL,
	[importe] [float] NULL,
	[observaciones] [varchar](150) NULL,
 CONSTRAINT [PK_pago] PRIMARY KEY CLUSTERED 
(
	[idPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[pago]  WITH CHECK ADD  CONSTRAINT [FK_pago_medioPago] FOREIGN KEY([idMedioPago])
REFERENCES [dbo].[medioPago] ([idMedioPago])
GO

ALTER TABLE [dbo].[pago] CHECK CONSTRAINT [FK_pago_medioPago]
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[pagoVista] 
AS
BEGIN
	SELECT p.idPago,p.fecha,mp.descripcion as 'medioPago',
			p.importe,p.observaciones
	FROM pago p 
	 INNER JOIN medioPago mp on mp.idMedioPago = p.idMedioPago
END
GO
INSERT INTO pantalla VALUES (7,'frmPago.aspx','Pagos','Proceso')
INSERT INTO usuarioPantalla VALUES (1,7,0)


