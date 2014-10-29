
GO
ALTER PROCEDURE [dbo].[eventoInsert] 
    @fecha as date,
    @trabajo as text,
    @datosContacto as text,
    @estado as varchar(50),
    @domicilio as varchar(250),
    @idCliente as int
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
    DECLARE @idEvento INT
	SELECT @idEvento = ISNULL(MAX(idEvento),0)+1 FROM dbo.evento

	INSERT INTO evento (idEvento,fecha,trabajo,datosContacto,estado,domicilio,idCliente)
	SELECT @idEvento,@fecha,@trabajo,@datosContacto,@estado,@domicilio,@idCliente
	
	-- Begin Return Select <- do not remove
	SELECT @idEvento as 'idEvento'
	-- End Return Select <- do not remove
               
	COMMIT
GO
ALTER PROCEDURE [dbo].[eventoUpdate] 
	@idEvento as int,
    @fecha as date,
    @trabajo as text,
    @datosContacto as text,
    @estado as varchar(50),
    @domicilio as varchar(250),
    @idCliente as int
    
AS 
	UPDATE evento SET fecha=@fecha,trabajo=@trabajo,datosContacto=@datosContacto,estado=@estado,domicilio=@domicilio,idCliente=@idCliente
	WHERE idEvento=@idEvento
	
	-- Begin Return Select <- do not remove
	SELECT @idEvento as 'idEvento'
	-- End Return Select <- do not remove

GO
