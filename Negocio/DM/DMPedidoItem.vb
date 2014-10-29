Imports AccesoDatos

Public Class DMPedidoItem
    Public Shared Function ObtenerPedidoItem(ByVal idPedidoItem As Integer) As PedidoItem
        Dim cmd As New comando("dbo.PedidoItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedidoItem", idPedidoItem)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim p As New PedidoItem
                p.IdPedidoItem = CType(.Rows(0).Item("idPedidoItem"), Integer)
                p.Producto = Sistema.ObtenerProducto(CType(.Rows(0).Item("idProducto"), Integer))
                p.Cantidad = CType(.Rows(0).Item("cantidad"), Integer)
                p.Vendedor = Sistema.ObtenerVendedor(CType(.Rows(0).Item("idVendedor"), Integer))
                p.PrecioUnitario = CType(.Rows(0).Item("precioUnitario"), Double)
                p.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                Return p
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarPedidoItem(ByVal p As PedidoItem, idPedido As Integer) As Integer
        Dim cmd As New comando("dbo.PedidoItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedido", idPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", p.Producto.IdProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", p.Cantidad)
        cmd.agregarParametro(ParameterDirection.Input, "@idVendedor", p.Vendedor.IdVendedor)
        cmd.agregarParametro(ParameterDirection.Input, "@precioUnitario", p.PrecioUnitario)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.Observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idPedidoItem"), Integer)
    End Function
    Public Shared Function ActualizarPedidoItem(ByVal p As PedidoItem) As Integer
        Dim cmd As New comando("dbo.PedidoItemUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedidoItem", p.idPedidoItem)
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", p.Producto.IdProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", p.cantidad)
        cmd.agregarParametro(ParameterDirection.Input, "@idVendedor", p.Vendedor.IdVendedor)
        cmd.agregarParametro(ParameterDirection.Input, "@precioUnitario", p.precioUnitario)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idPedidoItem"), Integer)
    End Function
    Public Shared Function VistaPedidoItem() As DataTable
        Dim cmd As New comando("dbo.PedidoItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedidoItem")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerPedidoItems(ByVal idPedido As Integer) As List(Of PedidoItem)
        Dim cmd As New comando("PedidoItemsSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedido", idPedido)
        Dim l As New List(Of PedidoItem)
        For Each r As DataRow In cmd.ejecutar.Rows()
            l.Add(Sistema.ObtenerPedidoItem(CType(r.Item("idPedidoItem"), Integer)))
        Next
        Return l
    End Function
    Public Shared Function EliminarPedidoItems(ByVal idPedido As Integer) As Integer
        Dim cmd As New comando("PedidoItemDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedidoCabe", idPedido)
        cmd.ejecutar()
        Return 0
    End Function
End Class
