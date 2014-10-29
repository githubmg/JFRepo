Imports AccesoDatos
Public Class DMComprobanteItem
    Public Shared Function ObtenerComprobanteItem(ByVal idComprobanteItem As Integer) As ComprobanteItem
        Dim cmd As New comando("dbo.comprobanteItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobanteItem", idComprobanteItem)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New ComprobanteItem
                c.IdComprobanteItem = idComprobanteItem
                c.Descripcion = CType(.Rows(0).Item("Descripcion"), String)
                c.Comentario = CType(.Rows(0).Item("Comentario"), String)
                c.Cantidad = CType(.Rows(0).Item("Cantidad"), Double)
                c.PrecioUnitario = CType(.Rows(0).Item("PrecioUnitario"), Double)
                c.MotivoDescuento = CType(.Rows(0).Item("MotivoDescuento"), String)
                c.Iva = CType(.Rows(0).Item("Iva"), Double)

                If Not .Rows(0).IsNull("Origen_idMultaSocioItem") Then c.Origen_idMultaSocioItem = CType(.Rows(0).Item("Origen_idMultaSocioItem"), Integer)
                If Not .Rows(0).IsNull("Origen_idMultaSocioItemPago") Then c.Origen_idMultaSocioItemPago = CType(.Rows(0).Item("Origen_idMultaSocioItemPago"), Integer)
                If Not .Rows(0).IsNull("Origen_idPagoCuotaSocio") Then c.Origen_idPagoCuotaSocio = CType(.Rows(0).Item("Origen_idPagoCuotaSocio"), Integer)

                Return c
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function ObtenerComprobanteItemPorComprobante(ByVal idComprobante As Integer) As List(Of ComprobanteItem)
        Dim l As New List(Of ComprobanteItem)
        Dim cmd As New comando("dbo.comprobanteItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", idComprobante)
        For Each r As DataRow In cmd.ejecutar.Rows
            l.Add(Sistema.ObtenerComprobanteItem(CType(r.Item("idComprobanteItem"), Integer)))
        Next
        Return l
    End Function
    Public Shared Function AgregarComprobanteItem(ByVal c As ComprobanteItem, ByVal idComprobante As Integer) As Integer
        Dim cmd As New comando("dbo.comprobanteItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", idComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", c.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@comentario", c.Comentario)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", c.Cantidad)
        cmd.agregarParametro(ParameterDirection.Input, "@precioUnitario", c.PrecioUnitario)
        cmd.agregarParametro(ParameterDirection.Input, "@motivoDescuento", c.MotivoDescuento)
        cmd.agregarParametro(ParameterDirection.Input, "@descuento", c.Descuento)
        cmd.agregarParametro(ParameterDirection.Input, "@iva", c.Iva)
        If c.Origen_idMultaSocioItem > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@Origen_idMultaSocioItem", c.Origen_idMultaSocioItem)
        If c.Origen_idMultaSocioItemPago > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@Origen_idMultaSocioItemPago", c.Origen_idMultaSocioItemPago)
        If c.Origen_idPagoCuotaSocio > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@Origen_idPagoCuotaSocio", c.Origen_idPagoCuotaSocio)

        Return CType(cmd.ejecutar().Rows(0).Item("IdComprobanteItem"), Integer)
    End Function
    Public Shared Function ActualizarComprobanteItem(ByVal c As ComprobanteItem, ByVal idComprobante As Integer) As Integer
        Dim cmd As New comando("dbo.comprobanteItemUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobanteItem ", c.IdComprobanteItem)
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", idComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", c.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@comentario", c.Comentario)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", c.Cantidad)
        cmd.agregarParametro(ParameterDirection.Input, "@precioUnitario", c.PrecioUnitario)
        cmd.agregarParametro(ParameterDirection.Input, "@motivoDescuento", c.MotivoDescuento)
        cmd.agregarParametro(ParameterDirection.Input, "@descuento", c.Descuento)
        cmd.agregarParametro(ParameterDirection.Input, "@iva", c.Iva)
        If c.Origen_idMultaSocioItem > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@Origen_idMultaSocioItem", c.Origen_idMultaSocioItem)
        If c.Origen_idMultaSocioItemPago > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@Origen_idMultaSocioItemPago", c.Origen_idMultaSocioItemPago)
        If c.Origen_idPagoCuotaSocio > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@Origen_idPagoCuotaSocio", c.Origen_idPagoCuotaSocio)

        Return CType(cmd.ejecutar().Rows(0).Item("IdComprobanteItem"), Integer)
    End Function
    Public Shared Sub BorrarComprobanteItem(ByVal idComprobante As Integer)
        Dim cmd As New comando("dbo.comprobanteItemDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", idComprobante)
        cmd.ejecutar()
    End Sub

End Class
