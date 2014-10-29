Imports AccesoDatos

Public Class DMCompraItem
    Public Shared Function ObtenerCompraItem(ByVal idCompraItem As Integer) As CompraItem
        Dim cmd As New comando("dbo.CompraItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompraItem", idCompraItem)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New CompraItem
                c.idCompraItem = CType(.Rows(0).Item("idCompraItem"), Integer)
                c.Producto = Sistema.ObtenerProducto(CType(.Rows(0).Item("idProducto"), Integer))
                c.cantidad = CType(.Rows(0).Item("cantidad"), Integer)
                c.PrecioUnitario = CType(.Rows(0).Item("precioUnitario"), Double)
                c.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                Return c
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarCompraItem(ByVal c As CompraItem, idCompra As Integer) As Integer
        Dim cmd As New comando("dbo.CompraItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompra", idCompra)
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", c.Producto.IdProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", c.Cantidad)
        cmd.agregarParametro(ParameterDirection.Input, "@precioUnitario", c.PrecioUnitario)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.Observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idCompraItem"), Integer)
    End Function
    Public Shared Function ActualizarCompraItem(ByVal c As CompraItem) As Integer
        Dim cmd As New comando("dbo.CompraItemUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompraItem", c.idCompraItem)
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", c.Producto.IdProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", c.cantidad)
        cmd.agregarParametro(ParameterDirection.Input, "@precioUnitario", c.precioUnitario)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idCompraItem"), Integer)
    End Function
    Public Shared Function VistaCompraItem() As DataTable
        Dim cmd As New comando("dbo.CompraItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompraItem")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerCompraItems(ByVal idCompra As Integer) As List(Of CompraItem)
        Dim cmd As New comando("CompraItemsSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompra", idCompra)
        Dim l As New List(Of CompraItem)
        For Each r As DataRow In cmd.ejecutar.Rows()
            l.Add(Sistema.ObtenerCompraItem(CType(r.Item("idCompraItem"), Integer)))
        Next
        Return l
    End Function
    Public Shared Function EliminarCompraItems(ByVal idCompra As Integer) As Integer
        Dim cmd As New comando("CompraItemDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompraCabe", idCompra)
        cmd.ejecutar()
        Return 0
    End Function
End Class
