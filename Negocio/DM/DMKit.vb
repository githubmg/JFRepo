Imports AccesoDatos

Public Class DMKit
    Public Shared Function ObtenerKitPtoductos(ByVal idKit As Integer) As List(Of ProductoKit)
        Dim cmd As New comando("KitProductosSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idKit", idKit)
        Dim l As New List(Of ProductoKit)
        For Each r As DataRow In cmd.ejecutar.Rows()
            Dim pk As New ProductoKit
            pk.Producto = Sistema.ObtenerProducto(CType(r.Item("idProducto"), Integer))
            pk.Cantidad = CType(r.Item("cantdad"), Integer)
            l.Add(pk)
        Next
        Return l
    End Function
    Public Shared Function ObtenerKit(ByVal idKit As Integer) As Kit
        Dim cmd As New comando("dbo.KitSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idKit", idKit)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim k As New Kit
                k.IdKit = CType(.Rows(0).Item("idKit"), Integer)
                k.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                k.ProductoPrincipal = Sistema.ObtenerProducto(CType(.Rows(0).Item("idProductoPrincipal"), Integer))
                k.Productos = Sistema.ObtenerKitPtoductos(k.IdKit)
                Return k
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarKit(ByVal k As Kit) As Integer
        Dim cmd As New comando("dbo.KitInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", k.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProductoPrincipal", k.ProductoPrincipal.IdProducto)
        k.IdKit = CType(cmd.ejecutar().Rows(0).Item("idKit"), Integer)
        For Each kp In k.Productos
            Sistema.AgregarKitProducto(kp, k.IdKit)
        Next
    End Function
    
    Public Shared Function ActualizarKit(ByVal k As Kit) As Integer
        Dim cmd As New comando("dbo.KitUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idKit", k.IdKit)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", k.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProductoPrincipal", k.ProductoPrincipal.IdProducto)
        k.IdKit = (CType(cmd.ejecutar().Rows(0).Item("idKit"), Integer))
        Sistema.EliminarProductosKit(k.IdKit)
        For Each kp In k.Productos
            Sistema.AgregarKitProducto(kp, k.IdKit)
        Next
    End Function
    Public Shared Function VistaKit() As DataTable
        Dim cmd As New comando("dbo.KitVista")
        Return cmd.ejecutar()
    End Function


End Class
