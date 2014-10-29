CREATE PROCEDURE ProductoVistaByFamilia(
@idFamilia int
)

AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia', a.descripcion as 'alicuotaIva',p.descripcion
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	JOIN dbo.alicuotaIva a ON a.idAlicuotaIva = p.idAlicuotaIva
	WHERE f.idFamilia = @idFamilia 
	ORDER BY p.descripcion
END

GO

----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[PedidoCabeInsert] (
	@cuitCliente Bigint,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
	@descuento FLOAT ,
	@observaciones Varchar(250)
)
AS
BEGIN
	DECLARE @idCabe INT
	SELECT @idCabe = ISNULL(MAX(idPedidoCabe),0)+1 FROM dbo.pedidoCabe
	INSERT INTO dbo.pedidoCabe
	        ( idPedidoCabe, 
	         cuitCliente,
	         fechaPedido,
	         orden,
	         idEstadoPedido,
	         descuento,
	         observaciones
			  
	        )
	VALUES  ( @idCabe,
			  @cuitCliente ,
	          @fechaPedido ,
	          @orden , 
	          @idEstadoPedido ,
	          @descuento ,
	          @observaciones 
	        )
	SELECT @idCabe AS idCabe
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoCabeUpdate] (
	@idPedidoCabe int,
	@cuitCliente bigint,
	@fechaPedido DATETIME ,
	@orden Varchar(50) ,
	@idEstadoPedido INT ,
	@descuento FLOAT ,
	@observaciones Varchar(250)
)
AS
BEGIN
    BEGIN TRAN
	UPDATE   pedidoCabe SET
	         cuitCliente=@cuitCliente,
	         fechaPedido=@fechaPedido,
	         orden=@orden,
	         idEstadoPedido=@idEstadoPedido,
	         descuento=@descuento,
	         observaciones=@observaciones
	WHERE idPedidoCabe=@idPedidoCabe 
	        
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   pedidoCabe
	WHERE  idPedidoCabe = @idPedidoCabe
	-- End Return Select <- do not remove
	COMMIT

END
GO

--------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ClienteVistaPorCuitORazon] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT c.cuit + ' - ' +  c.razonSocial AS descripcion
	FROM dbo.cliente c
	WHERE c.razonSocial LIKE '%'+@descripcion+'%' 
	OR c.cuit LIKE '%'+@descripcion+'%'
	ORDER BY c.cuit
END
GO
----------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[ClienteVistaPorCuitORazon] (@descripcion VARCHAR(100))
AS
BEGIN
	SELECT CAST(c.cuit as varchar(20)) + ' - ' +  c.razonSocial AS descripcion
	FROM dbo.cliente c
	WHERE c.razonSocial LIKE '%'+@descripcion+'%' 
	OR CAST(c.cuit as varchar(20)) LIKE '%'+@descripcion+'%'
	ORDER BY c.cuit
END
GO