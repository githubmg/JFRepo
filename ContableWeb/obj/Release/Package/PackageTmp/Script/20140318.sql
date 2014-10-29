GO
CREATE PROCEDURE [dbo].[rptAcreedores] (
	@desde DATE = null,
	@hasta DATE = null
)
AS
BEGIN
	SELECT 	
	cc.idCompraCabe,
	Convert(varchar(10),CONVERT(date,cc.fechaCompra,106),103) as fecha,
	CAST(p.cuit as varchar) as cuit,
	p.razonSocial, 
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1 + aliva.valor/100 ))  
	from compraItem ci 
	JOIN producto pro on ci.idProducto = pro.idProducto
	JOIN alicuotaIva aliva ON pro.idAlicuotaIva = aliva.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe ),0)) 
	-
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p	INNER JOIN pagoCompra pc ON p.idPago = pc.idPago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'pendiente',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario )  
	from compraItem ci 
	where ci.idCompra = cc.idCompraCabe
	),0)) 
	)
	as varchar(20)),'0') as 'subtotal',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario * (1 + aliva.valor/100 ))  
	from compraItem ci 
	JOIN producto pro on ci.idProducto = pro.idProducto
	JOIN alicuotaIva aliva ON pro.idAlicuotaIva = aliva.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe
	),0)) 
	)
	as varchar(20)),'0') as 'total',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (ci.cantidad * ci.precioUnitario *  aliva.valor/100 )  
	from compraCabe cc 
	JOIN compraItem ci ON ci.idCompra=cc.idCompraCabe
	JOIN producto pro on ci.idProducto = pro.idProducto
	JOIN alicuotaIva aliva ON pro.idAlicuotaIva = aliva.idAlicuotaIva
	where ci.idCompra = cc.idCompraCabe
	),0)) 
	)
	as varchar(20)),'0') as 'iva',
	ISNULL(
	CAST(
	(
	(ISNULL((SELECT SUM (pc.montoCancelado) 
	from pago p INNER JOIN pagoCompra pc ON p.idPago = pc.idPago
	WHERE pc.idCompra = cc.idCompraCabe),0))) 
	as varchar(20)),'0') as 'saldado'
	FROM compraCabe cc   
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	WHERE (cc.fechaCompra >= @desde or @desde is NULL) AND
			(cc.fechaCompra<= @hasta or @hasta is NULL)
	ORDER BY  cc.fechaCompra DESC
END
GO
INSERT INTO pantalla VALUES (15,'ReporteAcreedores.aspx','Acreedores por compras','Reporte')
INSERT INTO usuarioPantalla VALUES (1,15,0)