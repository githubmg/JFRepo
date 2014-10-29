Imports AccesoDatos

Public Class DMKitProducto
    Public Shared Function AgregarKitProducto(ByVal kp As ProductoKit, ByVal idKit As Integer) As Integer
        Dim cmd As New comando("dbo.KitProductoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idKit", idKit)
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", kp.Producto.IdProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", kp.Cantidad)
        Return CType(cmd.ejecutar().Rows(0).Item("idKit"), Integer)
    End Function
    Public Shared Function EliminarProductosKit(ByVal idKit As Integer) As Integer
        Dim cmd As New comando("dbo.KitProductoDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idKit", idKit)
        Return CType(cmd.ejecutar().Rows(0).Item("idKit"), Integer)
    End Function
End Class
