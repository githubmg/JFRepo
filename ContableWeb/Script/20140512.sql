INSERT INTO pantalla VALUES (19,'ReporteValoresCedidos.aspx','Valores Cedidos','Reporte')
INSERT INTO usuarioPantalla VALUES (1,19,0)
GO
CREATE PROCEDURE [dbo].[rptProductoStock]
AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia',p.descripcion,
	p.codProducto,
	CAST(ISNULL(SUM(ci.cantidad),0) - ISNULL(SUM(pit.cantidad),0) 
	+ ISNULL(SUM(msi.cantidad),0) - ISNULL(SUM(mse.cantidad),0)
	AS varchar) AS stock
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	LEFT JOIN compraItem ci ON p.idProducto = ci.idProducto
	LEFT JOIN pedidoItem pit ON p.idProducto = pit.idProducto
	LEFT JOIN (SELECT * FROM movimientoStock where idMovimientoStock = 1) as msi
	ON p.idProducto = msi.idProducto
	LEFT JOIN (SELECT * FROM movimientoStock where idMovimientoStock = 2) as mse
	ON p.idProducto = mse.idProducto
	WHERE p.activo = 1
	GROUP BY 
	p.idProducto,f.descripcion,p.descripcion,
	p.codProducto
	ORDER BY p.descripcion
END
GO
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
b.descripcion as banco, 
max(ISNULL(cli.razonSocial,'Sin cliente')) as cliente
from 
cheque ch inner join banco b
on b.idBanco = ch.idBanco
JOIN pagoCheque pc ON pc.idCheque = ch.idCheque
JOIN pagoCompra paco ON pc.idPago = paco.idCompra
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
go