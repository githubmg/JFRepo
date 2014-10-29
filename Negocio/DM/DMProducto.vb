Imports AccesoDatos

Public Class DMProducto
    Public Shared Function ObtenerProducto(ByVal idProducto As Integer) As Producto
        Dim cmd As New comando("dbo.ProductoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", idProducto)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim p As New Producto
                p.idProducto = CType(.Rows(0).Item("idProducto"), Integer)
                p.Familia = Sistema.ObtenerFamilia(CType(.Rows(0).Item("idFamilia"), Integer))
                p.AlicuotaIva = Sistema.ObtenerAlicuotaIva(CType(.Rows(0).Item("idAlicuotaIva"), Integer))
                p.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                p.CodProducto = CType(.Rows(0).Item("codProducto"), String)
                Return p
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarProducto(ByVal p As Producto) As Integer
        Dim cmd As New comando("dbo.ProductoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idFamilia", p.Familia.IdFamilia)
        cmd.agregarParametro(ParameterDirection.Input, "@idAlicuotaIva", p.AlicuotaIva.IdAlicuotaIva)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", p.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@codProducto", p.CodProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@activo", 1)
        Return CType(cmd.ejecutar().Rows(0).Item("idProducto"), Integer)
    End Function
    Public Shared Function ActualizarProducto(ByVal p As Producto) As Integer
        Dim cmd As New comando("dbo.ProductoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", p.idProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@idFamilia", p.Familia.IdFamilia)
        cmd.agregarParametro(ParameterDirection.Input, "@idAlicuotaIva", p.AlicuotaIva.IdAlicuotaIva)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", p.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@codProducto", p.CodProducto)
        Return CType(cmd.ejecutar().Rows(0).Item("idProducto"), Integer)
    End Function
    Public Shared Function VistaProducto() As DataTable
        Dim cmd As New comando("dbo.ProductoVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaProductoByFamlia(ByVal idFamilia As Integer) As DataTable
        Dim cmd As New comando("dbo.ProductoVistaByFamilia")
        cmd.agregarParametro(ParameterDirection.Input, "@idFamilia", idFamilia)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaProductoStockByDecripcion(ByVal desc As String) As DataTable
        Dim cmd As New comando("dbo.VistaProductoStockByDecripcion")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", desc)
        Return cmd.ejecutar()
    End Function
    Public Shared Function BorrarProducto(ByVal idProducto As Integer) As Integer
        Dim cmd As New comando("dbo.ProductoDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", idProducto)
        cmd.ejecutar()
        Return idProducto
    End Function
End Class
