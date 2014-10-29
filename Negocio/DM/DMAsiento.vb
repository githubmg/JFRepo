Imports AccesoDatos
Public Class DMAsiento
    Public Shared Function VistaAsiento() As DataTable
        Dim cmd As New comando("asientoCabeVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerAsiento(ByVal idAsiento As Integer) As Asiento
        Dim cmd As New comando("asientoCabeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsiento", idAsiento)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim a As New Asiento
                a.IdAsiento = idAsiento
                a.Concepto = .Rows(0).Item("concepto").ToString()
                a.NumeroComprobante = .Rows(0).Item("numeroComprobante").ToString()
                a.Observaciones = .Rows(0).Item("observaciones").ToString()
                a.Fecha = CType(.Rows(0).Item("fecha"), Date)
                a.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(.Rows(0).Item("idTipoComprobante"), Integer))
                a.Items = Sistema.obtenerAsientoItems(idAsiento)
                Return a
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarAsiento(ByVal a As Asiento) As Integer
        Dim cmd As New comando("dbo.asientoCabeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", a.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", a.TipoComprobante.IdTipoComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@numeroComprobante", a.NumeroComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@concepto", a.Concepto)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", a.Observaciones)
        a.IdAsiento = CType(cmd.ejecutar().Rows(0).Item("idAsiento"), Integer)
        For Each ai As AsientoItem In a.Items
            Sistema.AgregarAsientoItem(ai, a.IdAsiento)
        Next
        Return a.IdAsiento
    End Function
    Public Shared Function ActualizarAsiento(ByVal a As Asiento) As Integer
        Dim cmd As New comando("asientoCabeUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsiento", a.IdAsiento)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", a.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", a.TipoComprobante.IdTipoComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@numeroComprobante", a.NumeroComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@concepto", a.Concepto)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", a.Observaciones)
        a.IdAsiento = CType(cmd.ejecutar().Rows(0).Item("idAsiento"), Integer)
        Sistema.BorrarAsientoItem(a.IdAsiento)
        For Each ai As AsientoItem In a.Items
            Sistema.AgregarAsientoItem(ai, a.IdAsiento)
        Next
        Return a.IdAsiento

    End Function
End Class
