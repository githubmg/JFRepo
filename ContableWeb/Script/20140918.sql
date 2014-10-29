GO
ALTER TABLE dbo.cheque ADD
	cobrado bit NULL
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[VistaChequeNoCobrado] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(c.idCheque as varchar(11)) + ' - nro: ' + c.numero + ' - ' +  b.descripcion + ' - $' + CAST(c.importe as varchar(20)) AS descripcion
	FROM cheque c
		INNER JOIN banco b ON c.idBanco = b.idBanco
	WHERE 
	(c.numero LIKE '%'+@descripcion+'%' OR
	CAST(c.importe as varchar(20)) LIKE '%'+@descripcion+'%' OR
	b.descripcion LIKE '%'+@descripcion+'%') 
	AND 
	c.idOrigenCheque = 1
	AND
	(c.cobrado <> 1 OR c.cobrado is null)
	ORDER BY c.numero
END

GO
update cheque set cobrado = 0
GO

GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[ChequeUpdate] (
	@idCheque int,
	@idBanco int,
	@numero varchar(50),
	@fechaEmision datetime,
	@fechaVencimiento datetime,
	@importe float,
	@idOrigenCheque int,
	@enCartera bit,
	@cobrado bit
)
AS
BEGIN
    BEGIN TRAN
	UPDATE  cheque SET
	        idBanco =@idBanco,
	        numero =@numero,
	        fechaEmision =@fechaEmision,
	        fechaVencimiento =@fechaVencimiento,
	        importe =@importe,
	        idOrigenCheque =@idOrigenCheque,
	        enCartera =@enCartera,
	        cobrado=@cobrado
	        WHERE idCheque=@idCheque
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cheque
	WHERE  idCheque = @idCheque
	-- End Return Select <- do not remove
	COMMIT

END
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[ChequeInsert] (
	@idBanco int = NULL,
	@numero varchar(50),
	@fechaEmision datetime,
	@fechaVencimiento datetime,
	@importe float,
	@idOrigenCheque int,
	@enCartera bit,
	@cobrado bit
)
AS
BEGIN
    BEGIN TRAN
    DECLARE @idCheque INT
	SELECT @idCheque = ISNULL(MAX(idCheque),0)+1 FROM dbo.cheque
	
	INSERT INTO cheque (idCheque,idBanco,numero,fechaEmision,fechaVencimiento,importe
	,idOrigenCheque,enCartera, cobrado)
	SELECT @idCheque,@idBanco,@numero,@fechaEmision,@fechaVencimiento,
	@importe,@idOrigenCheque,@enCartera, @cobrado
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   cheque
	WHERE  idCheque = @idCheque
	-- End Return Select <- do not remove
	COMMIT

END
GO
ALTER PROCEDURE [dbo].[rptChequesCedidos] (
	@desde DATE = null,
	@hasta DATE = null,
	@cobrado BIT = null
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
			(cc.fechaCompra<= @hasta or @hasta is NULL) AND
			(ch.cobrado = @cobrado or @cobrado is NULL)
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
