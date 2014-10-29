GO

ALTER PROCEDURE [dbo].[depositoInsert] (
  @idCheque  INT,
  @idBanco INT,
  @numeroTransaccion varchar(20),
  @fecha date
)
AS 
begin
	declare @idDeposito INT
	SELECT @idDeposito = ISNULL(MAX(idDeposito),0)+1 FROM deposito
	INSERT INTO deposito (idDeposito,idCheque,idBanco,numeroTransaccion,fecha)
    VALUES (@idDeposito,@idCheque,@idBanco,@numeroTransaccion,@fecha)
    select * from deposito where idDeposito = @idDeposito
end
GO