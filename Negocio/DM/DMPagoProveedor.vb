Imports AccesoDatos
Public Class DMPagoProveedor
    Public Shared Function AgregarPagoProveedor(ByVal p As PagoProveedor) As Integer
        Dim cmd As New comando("dbo.pagoProveedorInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idProveedor", 1)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaPago", p.FechaPago)
        p.IdPago = CType(cmd.ejecutar().Rows(0).Item("idPago"), Integer)

        'COMPROBANTES
        For Each c As ComprobanteProveedor In p.Comprobantes
            Sistema.AgregarComprobantePagoProveedor(p, c)
        Next

        'ADELANTOS
        For Each a As ComprobanteProveedor In p.Adelantos
            Sistema.AgregarAdelantoPagoProveedor(p, a)
        Next

        'RETENCIONES
        For Each r As RetencionPago In p.Retenciones
            Sistema.AgregarRetencionPago(p, r)
        Next

        'MOVIMIENTO CAJA
        Dim mc As New MovimientoCajaCabe(p)
        Sistema.AgregarMovimientoCajaCabe(mc)

        Return p.IdPago

    End Function

    Public Shared Sub AgregarComprobantePagoProveedor(ByVal p As PagoProveedor, ByVal c As ComprobanteProveedor)
        Dim cmd As New comando("dbo.pagoProveedorComprobanteProveedorInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", p.IdPago)
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", c.IdComprobante)
        cmd.ejecutar()
    End Sub

    Public Shared Sub AgregarAdelantoPagoProveedor(ByVal p As PagoProveedor, ByVal a As ComprobanteProveedor)
        Dim cmd As New comando("dbo.pagoProveedorAdelantoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", p.IdPago)
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", a.IdComprobante)
        cmd.ejecutar()
    End Sub
End Class
