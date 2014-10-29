GO
CREATE PROCEDURE [dbo].[rptChequesCedidos] (
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
b.descripcion as banco, paco.idCompra, paco.idPago, pro.cuit, pro.razonSocial  from 
cheque ch inner join banco b
on b.idBanco = ch.idBanco
JOIN pagoCheque pc ON pc.idCheque = ch.idCheque
JOIN pagoCompra paco ON pc.idPago = paco.idCompra
JOIN compraCabe cc on cc.idCompraCabe = paco.idCompra
JOIN proveedor pro on pro.cuit = cc.cuitProveedor
WHERE enCartera = 0
AND (cc.fechaCompra >= @desde or @desde is NULL) AND
			(cc.fechaCompra<= @hasta or @hasta is NULL)
	ORDER BY  cc.fechaCompra DESC
END
GO