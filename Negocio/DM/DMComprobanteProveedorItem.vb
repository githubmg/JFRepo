Imports AccesoDatos
Public Class DMComprobanteProveedorItem

    Public Shared Function ObtenerComprobanteProveedorItem(ByVal idComprobanteItem As Integer) As ComprobanteProveedorItem
        Dim cmd As New comando("dbo.comprobanteProveedorItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobanteItem", idComprobanteItem)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim ci As New ComprobanteProveedorItem
                ci.IdComprobanteItem = idComprobanteItem
                ci.Descripcion = .Rows(0).Item("descripcion").ToString()
                ci.Observaciones = .Rows(0).Item("Observaciones").ToString()
                ci.Cantidad = CType(.Rows(0).Item("cantidad"), Double)
                ci.PrecioUnitario = CType(.Rows(0).Item("PrecioUnitario"), Double)
                ci.Iva = CType(.Rows(0).Item("Iva"), Double)
                Return ci
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function ObtenerComprobanteProveedorItems(ByVal c As ComprobanteProveedor) As List(Of ComprobanteProveedorItem)
        Dim cmd As New comando("dbo.comprobanteProveedorItemSelect")
        Dim l As New List(Of ComprobanteProveedorItem)
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", c.IdComprobante)
        For Each r As DataRow In cmd.ejecutar().Rows
            l.Add(Sistema.ObtenerComprobanteProveedorItem(CType(r.Item("idComprobanteItem"), Integer)))
        Next
        Return l
    End Function
    Public Shared Function AgregarComprobanteProveedorItem(ByVal ci As ComprobanteProveedorItem, ByVal c As ComprobanteProveedor) As Integer
        Dim cmd As New comando("dbo.comprobanteProveedorItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", c.IdComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", ci.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", ci.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@precioUnitario", ci.PrecioUnitario)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", ci.Cantidad)
        cmd.agregarParametro(ParameterDirection.Input, "@iva", ci.Iva)
        Return CType(cmd.ejecutar().Rows(0).Item("idComprobanteItem"), Integer)
    End Function
    Public Shared Sub BorrarComprobanteProveedorItem(ByVal c As ComprobanteProveedor)
        Dim cmd As New comando("dbo.comprobanteProveedorItemDelete")
        cmd.agregarParametro(ParameterDirection.Input, "idComprobante", c.IdComprobante)
        cmd.ejecutar()
    End Sub
End Class
