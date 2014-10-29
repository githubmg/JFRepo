GO
ALTER TABLE dbo.pedidoCabe ADD
	idTipoOrden int NULL
GO
GO
ALTER TABLE dbo.compraCabe ADD
	idTipoOrden int NULL
GO
GO

CREATE TABLE [dbo].[tipoOrden](
	[idTipoOrden] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tipoOrden] PRIMARY KEY CLUSTERED 
(
	[idTipoOrden] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[compraCabe]  WITH CHECK ADD  CONSTRAINT [FK_compraCabe_tipoOrden] FOREIGN KEY([idTipoOrden])
REFERENCES [dbo].[tipoOrden] ([idTipoOrden])
GO

ALTER TABLE [dbo].[compraCabe] CHECK CONSTRAINT [FK_compraCabe_tipoOrden]
GO
GO
ALTER TABLE dbo.pedidoCabe ADD CONSTRAINT
	FK_pedidoCabe_tipoOrden FOREIGN KEY
	(
	idTipoOrden
	) REFERENCES dbo.tipoOrden
	(
	idTipoOrden
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
CREATE PROCEDURE TipoOrdenSelect
    @idTipoOrden INT = NULL
AS 
	SELECT *
	FROM   tipoOrden 
	WHERE  (idTipoOrden = @idTipoOrden OR @idTipoOrden IS NULL) 

GO

GO
INSERT INTO tipoOrden VALUES(1,'Controlado')
INSERT INTO tipoOrden VALUES(2,' No Controlado')
