GO
CREATE TABLE [dbo].[ubicacionStock](
	[idUbicacionStock] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_ubicacionStock] PRIMARY KEY CLUSTERED 
(
	[idUbicacionStock] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT INTO ubicacionStock VALUES (1,'Irigoyen')
INSERT INTO ubicacionStock VALUES (2,'San Isidro')
GO
ALTER TABLE dbo.pedidoCabe ADD
	idUbicacionStock int NULL
GO
GO
ALTER TABLE dbo.pedidoCabe ADD CONSTRAINT
	FK_pedidoCabe_ubicacionStock FOREIGN KEY
	(
	idUbicacionStock
	) REFERENCES dbo.ubicacionStock
	(
	idUbicacionStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.compraCabe ADD
	idUbicacionStock int NULL
GO
ALTER TABLE dbo.compraCabe ADD CONSTRAINT
	FK_compraCabe_ubicacionStock FOREIGN KEY
	(
	idUbicacionStock
	) REFERENCES dbo.ubicacionStock
	(
	idUbicacionStock
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
