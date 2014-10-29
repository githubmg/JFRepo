INSERT INTO estadoPedido VALUES (4,'Facturado')
GO
GO

CREATE TABLE [dbo].[deposito](
	[idDeposito] [int] NOT NULL,
	[idCheque] [int] NULL,
	[idBanco] [int] NULL,
	[numeroTransaccion] [varchar](20) NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_deposito] PRIMARY KEY CLUSTERED 
(
	[idDeposito] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[deposito]  WITH CHECK ADD  CONSTRAINT [FK_deposito_banco] FOREIGN KEY([idBanco])
REFERENCES [dbo].[banco] ([idBanco])
GO
ALTER TABLE [dbo].[deposito]  WITH CHECK ADD  CONSTRAINT [FK_deposito_cheque] FOREIGN KEY([idCheque])
REFERENCES [dbo].[cheque] ([idCheque])
GO
delete from usuarioPantalla where idPantalla = 25
delete from pantalla where idPantalla = 25

INSERT INTO pantalla VALUES (25,'frmDeposito.aspx','Depósito de cheques','Proceso')
INSERT INTO usuarioPantalla VALUES (1,25,0)
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[depositoVista] 
AS
BEGIN
	SELECT d.*,b.descripcion as banco, ch.numero as cheque
	FROM deposito d 
	 INNER JOIN banco b on d.idBanco = b.idBanco
	 INNER JOIN cheque ch on d.idCheque = ch.idCheque
END
GO

CREATE PROCEDURE [dbo].[depositoSelect] (
    @id int = NULL
)
AS 
	
	SELECT *
	FROM   dbo.deposito 
	WHERE  (idDeposito = @id OR @id IS NULL)
GO

CREATE PROCEDURE [dbo].[depositoInsert] (
  @idCheque  INT,
  @idBanco INT,
  @numeroTransaccion varchar(20),
  @fecha date
)
AS 
begin
	declare @idDeposito INT
	SELECT @idDeposito = ISNULL(MAX(idDeposito),0)+1 FROM deposito
	INSERT INTO deposito (idDeposito,idCheque,idBanco,numeroTransaccion,fecha)
    VALUES (@idDeposito,@idCheque,@idBanco,@numeroTransaccion,@fecha)
end
GO