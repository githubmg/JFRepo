GO
CREATE PROCEDURE [dbo].[eventoInsert] 
    @fecha as date,
    @trabajo as varchar,
    @datosContacto as varchar,
    @estado as varchar,
    @domicilio as varchar,
    @idCliente as varchar
    
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
CREATE PROCEDURE [dbo].[eventoInsert] 
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
CREATE PROCEDURE [dbo].[eventoUpdate] 
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
GO
CREATE PROCEDURE [dbo].[rptEventoSelect] 
    @desde date = null,
    @hasta date = null
AS 
	SELECT REPLACE(cast(e.datosContacto as varchar(350)) ,'<br />',' ') as datosContacto,e.domicilio,e.estado,Convert(varchar(10),CONVERT(date,e.fecha,106),103) as fecha,e.idCliente,e.idEvento,REPLACE(CAST(e.trabajo as varchar(350)),'<br />',' ')  as trabajo,c.razonSocial
	FROM   evento e INNER JOIN cliente c ON e.idCliente = c.idCliente
	WHERE  
	(e.fecha <= @hasta OR @hasta IS NULL) AND
	(e.fecha >= @desde OR @desde IS NULL)
GO