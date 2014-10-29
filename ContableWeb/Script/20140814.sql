GO
ALTER PROCEDURE [dbo].[rptChequesCedidos] (
	@desde DATE = null,
	@hasta DATE = null
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
max(ISNULL(cli.razonSocial,'Sin cliente')) as cliente
from 
cheque ch 
LEFT JOIN banco b on b.idBanco = ch.idBanco
JOIN pagoCheque pc ON pc.idCheque = ch.idCheque
JOIN pagoCompra paco ON pc.idPago = paco.idPago
JOIN compraCabe cc on cc.idCompraCabe = paco.idCompra
JOIN origenCheque orch ON ch.idOrigenCheque = orch.idOrigenCheque
LEFT JOIN cobroCheque ccq ON ch.idCheque = ccq.idCheque
LEFT JOIN cobroPedido cpe ON ccq.idCobro = cpe.idCobro
LEFT JOIN pedidoCabe ped ON ped.idPedidoCabe = cpe.idPedido
LEFT JOIN cliente cli ON cli.idCliente = ped.idCliente
WHERE enCartera = 0
AND (cc.fechaCompra >= @desde or @desde is NULL) AND
			(cc.fechaCompra<= @hasta or @hasta is NULL)
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