Imports AccesoDatos
Public Class DMReporte
    Public Shared Function ReporteTotalesMulta(ByVal idMultaSocio As Integer) As DataTable
        Dim cmd As New comando("dbo.rptTotalesMulta")
        cmd.agregarParametro(ParameterDirection.Input, "@idMultaSocio", idMultaSocio)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ReporteDetalleMulta(ByVal idMultaSocio As Integer) As DataTable
        Dim cmd As New comando("dbo.rptDetalleMulta")
        cmd.agregarParametro(ParameterDirection.Input, "@idMultaSocio", idMultaSocio)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaAcreedores(ByVal desde As String, ByVal hasta As String) As DataTable
        Dim cmd As New comando("dbo.rptAcreedores")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaDeudores(ByVal desde As String, ByVal hasta As String) As DataTable
        Dim cmd As New comando("dbo.rptDeudores")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaMovCaja(ByVal desde As String, ByVal hasta As String) As DataTable
        Dim cmd As New comando("dbo.rptMovCaja")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaValoresCartera(ByVal desde As String, ByVal hasta As String) As DataTable
        Dim cmd As New comando("dbo.rptChequesCartera")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaValoresCedidos(ByVal desde As String, ByVal hasta As String, ByVal cobrado As String) As DataTable
        Dim cmd As New comando("dbo.rptChequesCedidos")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        Select Case cobrado
            Case "1"
                cmd.agregarParametro(ParameterDirection.Input, "@cobrado", 1)
            Case "2"
                cmd.agregarParametro(ParameterDirection.Input, "@cobrado", 0)
        End Select
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaVentasVendedor(ByVal desde As String, ByVal hasta As String, ByVal idVendedor As String) As DataTable
        Dim cmd As New comando("dbo.rptVentasVendedor")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        If idVendedor <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@idVendedor", CType(idVendedor, Integer))
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function ReporteComprobantesEmitidos(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.rptComprobantesEmitidos")
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaCtaCteProveedor(ByVal p As Proveedor, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.CtaCteProveedorVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idProveedor", 1)
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function

    Public Shared Function VistaCtaCte(ByVal s As Socio, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.CtaCteVista")
        cmd.agregarParametro(ParameterDirection.Input, "@IdSocio", s.IdSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ReporteProductoStock(ByVal idProducto As Integer) As DataTable
        Dim cmd As New comando("dbo.rptProductoStock")
        If idProducto <> 0 Then
            cmd.agregarParametro(ParameterDirection.Input, "@idProducto", idProducto)
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function ReporteCosto(ByVal idProducto As Integer) As DataTable
        Dim cmd As New comando("dbo.rptProductoCosto")
        If idProducto <> 0 Then
            cmd.agregarParametro(ParameterDirection.Input, "@idProducto", idProducto)
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaCtaCte(ByVal c As Club, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.CtaCteVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idClub", c.IdClub)
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaCtaCte(ByVal f As Federacion, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.CtaCteVista")
        cmd.agregarParametro(ParameterDirection.Input, "@IdFederacion", f.IdFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaCtaCte(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.CtaCteVista")
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function

    Public Shared Function VistaOrdenPagoProveedor(ByVal p As Proveedor, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.rptOrdenPago")
        cmd.agregarParametro(ParameterDirection.Input, "@idProveedor", 1)
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function


    Public Shared Function VistaComprobanteOrdenPago_comprobantes(ByVal idPago As Integer) As DataTable
        Dim cmd As New comando("dbo.rptComprobanteOrdenPago_comprobantes")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", idPago)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaComprobanteOrdenPago_retenciones(ByVal idPago As Integer) As DataTable
        Dim cmd As New comando("dbo.rptComprobanteOrdenPago_retenciones")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", idPago)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaComprobanteOrdenPago_Valores(ByVal idPago As Integer) As DataTable
        Dim cmd As New comando("dbo.rptComprobanteOrdenPago_valores")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", idPago)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaComprobanteRetencion(ByVal idPago As Integer) As DataTable
        Dim cmd As New comando("dbo.rptComprobanteRetencion")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", idPago)
        Return cmd.ejecutar()
    End Function

    Public Shared Function ReporteLibroDiario(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.rptLibroDiario")
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ReporteSumasSaldos(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Dim cmd As New comando("dbo.rptSumasSaldos")
        cmd.agregarParametro(ParameterDirection.Input, "@desde", desde)
        cmd.agregarParametro(ParameterDirection.Input, "@hasta", hasta)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ReportePlanDeCuentas(ByVal cuentaDesde As String, ByVal cuentaHasta As String) As DataTable
        Dim cmd As New comando("dbo.rptPlanDeCuentas")
        cmd.agregarParametro(ParameterDirection.Input, "@cuentaDesde", cuentaDesde)
        cmd.agregarParametro(ParameterDirection.Input, "@cuentaHasta", cuentaHasta)
        Return cmd.ejecutar()
    End Function
End Class
