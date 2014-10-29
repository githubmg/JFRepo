GO
----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[compraCabeVista] 
AS
BEGIN
	SELECT cc.idCompraCabe,
	p.razonSocial,
	cc.fechaCompra, 
	ep.descripcion as 'estado'
	FROM compraCabe cc 
	 INNER JOIN proveedor p ON cc.cuitProveedor = p.cuit
	 INNER JOIN estadoPedido ep ON cc.idEstado = ep.idEstadoPedido
END
