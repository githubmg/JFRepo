GO
CREATE PROCEDURE [dbo].[productoVista]
AS
BEGIN
	SELECT	p.idProducto,f.descripcion as 'familia', a.descripcion as 'alicuotaIva',p.descripcion
	FROM dbo.producto p
	JOIN dbo.familia f ON p.idFamilia = f.idFamilia
	JOIN dbo.alicuotaIva a ON a.idAlicuotaIva = p.idAlicuotaIva
	ORDER BY p.descripcion
END
GO
GO

CREATE PROCEDURE [dbo].[productoUpdate] (
   @idProducto int,
   @descripcion varchar(150),
   @idFamilia int,
   @idAlicuotaIva int
)
AS 
	BEGIN TRAN
	UPDATE dbo.producto
	SET    idFamilia=@idFamilia,idAlicuotaIva=@idAlicuotaIva,descripcion=@descripcion
	WHERE  idProducto = @idProducto
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   producto
	WHERE  idProducto = @idProducto
	-- End Return Select <- do not remove
	COMMIT

GO
GO
CREATE PROCEDURE [dbo].[productoInsert] (
   @descripcion varchar(150),
   @idFamilia int,
   @idAlicuotaIva int
)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
    DECLARE @idProducto INT
	SELECT @idProducto = ISNULL(MAX(idProducto),0)+1 FROM dbo.producto

	INSERT INTO producto (idProducto,idFamilia,idAlicuotaIva,descripcion)
	SELECT   @idProducto,@idFamilia,@idAlicuotaIva,@descripcion
	
	-- Begin Return Select <- do not remove
	SELECT *
	FROM   producto
	WHERE  idProducto = @idProducto
	-- End Return Select <- do not remove
               
	COMMIT
GO
GO
CREATE PROCEDURE [dbo].[productoSelect] (
    @idProducto int = NULL
)
AS 
	BEGIN TRAN
	SELECT *
	FROM   dbo.producto 
	WHERE  (idProducto = @idProducto OR @idProducto IS NULL)
	COMMIT
GO
GO
ALTER PROCEDURE [dbo].[alicuotaIvaSelect] 
    @idAlicuotaIva INT = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT idAlicuotaIva,valor,descripcion
	FROM   dbo.alicuotaIva
	WHERE  (idAlicuotaIva = @idAlicuotaIva OR @idAlicuotaIva IS NULL) 

	COMMIT
GO
INSERT INTO alicuotaIva values (1,0,'0%')
INSERT INTO alicuotaIva values (2,10.5,'10,5%')
INSERT INTO alicuotaIva values (3,21,'21%')
INSERT INTO alicuotaIva values (4,27,'27%')
