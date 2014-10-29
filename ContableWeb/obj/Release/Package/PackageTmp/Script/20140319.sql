
GO
CREATE PROCEDURE [dbo].[rptChequesCartera] (
	@desde DATE = null,
	@hasta DATE = null
)
AS
BEGIN
select ch.idCheque,
Convert(varchar(10),CONVERT(date,ch.fechaVencimiento,106),103) as fechaVencimiento,
Convert(varchar(10),CONVERT(date,ch.fechaEmision,106),103) as fechaEmision,
ch.enCartera,
ch.idCheque,
ch.idOrigenCheque,ch.importe,ch.numero,
b.descripcion as banco, cp.idPedido, cp.idCobro, cli.cuit, cli.razonSocial  from 
cheque ch inner join banco b
on b.idBanco = ch.idBanco
JOIN cobroCheque cc ON cc.idCheque = ch.idCheque
JOIN cobroPedido cp ON cp.idCobro = cc.idCobro
JOIN pedidoCabe pc on cp.idPedido = pc.idPedidoCabe
JOIN cliente cli on pc.cuitCliente = cli.cuit
WHERE enCartera = 1
AND (pc.fechaPedido >= @desde or @desde is NULL) AND
			(pc.fechaPedido<= @hasta or @hasta is NULL)
	ORDER BY  pc.fechaPedido DESC
END
GO
INSERT INTO pantalla VALUES (16,'ReporteValoresEnCartera.aspx','Valores en Cartera','Reporte')
INSERT INTO usuarioPantalla VALUES (1,16,0)
update pantalla set descripcion = 'Acreedores por Compras'
where idPantalla = 15

GO
CREATE PROCEDURE chequeSelect
    @idCheque INT = NULL
AS 
	SELECT *
	FROM   cheque 
	WHERE  (idCheque = @idCheque OR @idCheque IS NULL) 

GO
