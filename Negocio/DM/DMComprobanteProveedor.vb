Imports AccesoDatos
Public Class DMComprobanteProveedor

    Public Shared Function ObtenerComprobantesPendientes(ByVal p As Proveedor) As List(Of ComprobanteProveedor)
        Dim l As New List(Of ComprobanteProveedor)
        Dim cmd As New comando("dbo.comprobanteProveedorPendientePagoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idProveedor", 1)
        For Each r As DataRow In cmd.ejecutar().Rows
            l.Add(Sistema.ObtenerComprobanteProveedor(CType(r.Item("idComprobante"), Integer)))
        Next
        Return l
    End Function

    Public Shared Function ObtenerAdelantosNoUtilizados(ByVal p As Proveedor) As List(Of ComprobanteProveedor)
        Dim l As New List(Of ComprobanteProveedor)
        Dim cmd As New comando("dbo.adelantosProveedorNoUtilizados")
        cmd.agregarParametro(ParameterDirection.Input, "@idProveedor", 1)
        For Each r As DataRow In cmd.ejecutar().Rows
            l.Add(Sistema.ObtenerComprobanteProveedor(CType(r.Item("idComprobante"), Integer)))
        Next
        Return l
    End Function

    Public Shared Function ObtenerComprobanteProveedor(ByVal idComprobante As Integer) As ComprobanteProveedor
        Dim cmd As New comando("dbo.comprobanteProveedorSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", idComprobante)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New ComprobanteProveedor
                c.IdComprobante = idComprobante
                c.Detalle = .Rows(0).Item("Detalle").ToString()
                c.Fecha = CType(.Rows(0).Item("Fecha"), Date)
                c.Numero = .Rows(0).Item("Numero").ToString()
                c.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(.Rows(0).Item("idTipoComprobante"), Integer))
                c.Proveedor = Sistema.ObtenerProveedor(CType(.Rows(0).Item("idProveedor"), Integer))
                c.Items = Sistema.ObtenerComprobanteProveedorItems(c)
                Return c
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarComprobanteProveedor(ByVal c As ComprobanteProveedor) As Integer
        Dim cmd As New comando("dbo.comprobanteProveedorInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", c.TipoComprobante.IdTipoComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@idProveedor", 1)
        cmd.agregarParametro(ParameterDirection.Input, "@numero", c.Numero)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", c.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@detalle", c.Detalle)
        c.IdComprobante = CType(cmd.ejecutar().Rows(0).Item("idComprobante"), Integer)
        For Each ci As ComprobanteProveedorItem In c.Items
            Sistema.AgregarComprobanteProveedorItem(ci, c)
        Next
        Return c.IdComprobante()
    End Function
    Public Shared Function ActualizarComprobanteProveedor(ByVal c As ComprobanteProveedor) As Integer
        Dim cmd As New comando("dbo.comprobanteProveedorUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", c.IdComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", c.TipoComprobante.IdTipoComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@idProveedor", 1)
        cmd.agregarParametro(ParameterDirection.Input, "@numero", c.Numero)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", c.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@detalle", c.Detalle)
        Sistema.BorrarComprobanteProveedorItem(c)
        For Each ci As ComprobanteProveedorItem In c.Items
            Sistema.AgregarComprobanteProveedorItem(ci, c)
        Next
        Return CType(cmd.ejecutar().Rows(0).Item("idComprobante"), Integer)
    End Function

End Class
