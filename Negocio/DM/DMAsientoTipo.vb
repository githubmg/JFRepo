Imports AccesoDatos
Public Class DMAsientoTipo
    Public Shared Function VistaAsientoTipo() As DataTable
        Dim cmd As New comando("AsientoTipoVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerAsientoTipo(ByVal idAsientoTipo As Integer) As Asiento
        Dim cmd As New comando("AsientoTipoCabeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsientoTipo", idAsientoTipo)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim a As New Asiento
                a.IdAsiento = idAsientoTipo
                a.Concepto = .Rows(0).Item("concepto").ToString()
                a.NumeroComprobante = .Rows(0).Item("numeroComprobante").ToString()
                a.Observaciones = .Rows(0).Item("observaciones").ToString()
                a.Fecha = CType(.Rows(0).Item("fecha"), Date)
                a.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(.Rows(0).Item("idTipoComprobante"), Integer))
                a.Items = Sistema.ObtenerAsientoTipoItems(idAsientoTipo)
                Return a
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarAsientoTipo(ByVal a As Asiento) As Integer
        Dim cmd As New comando("dbo.AsientoTipoCabeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", a.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", a.TipoComprobante.IdTipoComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@numeroComprobante", a.NumeroComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@concepto", a.Concepto)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", a.Observaciones)
        a.IdAsiento = CType(cmd.ejecutar().Rows(0).Item("idAsientoTipo"), Integer)
        For Each ai As AsientoItem In a.Items
            Sistema.AgregarAsientoTipoItem(ai, a.IdAsiento)
        Next
        Return a.IdAsiento
    End Function
    'Public Shared Function ActualizarAsientoTipo(ByVal a As Asiento) As Integer
    '    Dim cmd As New comando("AsientoTipoCabeUpdate")
    '    cmd.agregarParametro(ParameterDirection.Input, "@idAsientoTipo", a.IdAsiento)
    '    cmd.agregarParametro(ParameterDirection.Input, "@fecha", a.Fecha)
    '    cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", a.TipoComprobante.IdTipoComprobante)
    '    cmd.agregarParametro(ParameterDirection.Input, "@numeroComprobante", a.NumeroComprobante)
    '    cmd.agregarParametro(ParameterDirection.Input, "@concepto", a.Concepto)
    '    cmd.agregarParametro(ParameterDirection.Input, "@observaciones", a.Observaciones)
    '    a.IdAsiento = CType(cmd.ejecutar().Rows(0).Item("idAsientoTipo"), Integer)
    '    Sistema.BorrarAsientoTipoItem(a.IdAsiento)
    '    For Each ai As AsientoItem In a.Items
    '        Sistema.AgregarAsientoItem(ai, a.IdAsiento)
    '    Next
    '    Return a.IdAsiento

    'End Function
End Class
