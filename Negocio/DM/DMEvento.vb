Imports AccesoDatos
Public Class DMEvento
    Public Shared Function ObtenerEvento(ByVal idEvento As Integer) As Evento
        Dim cmd As New comando("dbo.EventoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idEvento", idEvento)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Evento
                o.IdEvento = idEvento
                o.Cliente = Sistema.Obtenercliente(CType(.Rows(0).Item("idCliente"), Integer))
                o.DatosContacto = .Rows(0).Item("datosContacto").ToString()
                o.Domicilio = .Rows(0).Item("domicilio").ToString()
                o.Fecha = CType(.Rows(0).Item("fecha"), DateTime)
                o.Estado = .Rows(0).Item("estado").ToString()
                o.Trabajo = .Rows(0).Item("trabajo").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaEvento() As DataTable
        Return New comando("dbo.EventoSelect").ejecutar()
    End Function
    Public Shared Function VistaEventoPorFechas(desde As String, hasta As String) As DataTable
        Dim cmd = New comando("dbo.EventoSelect")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaReporteEventoPorFecha(desde As String, hasta As String) As DataTable
        Dim cmd = New comando("dbo.rptEventoSelect")
        If desde <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@desde", CType(desde, Date))
        End If
        If hasta <> "" Then
            cmd.agregarParametro(ParameterDirection.Input, "@hasta", CType(hasta, Date))
        End If
        Return cmd.ejecutar()
    End Function
    Public Shared Function AgregarEvento(ByVal e As Evento) As Integer
        Dim cmd As New comando("dbo.EventoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idCliente", e.Cliente.IdCliente)
        cmd.agregarParametro(ParameterDirection.Input, "@datosContacto", e.DatosContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@domicilio", e.Domicilio)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", e.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@estado", e.Estado)
        cmd.agregarParametro(ParameterDirection.Input, "@trabajo", e.Trabajo)
        Return CType(cmd.ejecutar().Rows(0).Item("idEvento"), Integer)
    End Function
    Public Shared Function ActualizarEvento(ByVal e As Evento) As Integer
        Dim cmd As New comando("dbo.EventoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idEvento", e.IdEvento)
        cmd.agregarParametro(ParameterDirection.Input, "@idCliente", e.Cliente.IdCliente)
        cmd.agregarParametro(ParameterDirection.Input, "@datosContacto", e.DatosContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@domicilio", e.Domicilio)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", e.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@estado", e.Estado)
        cmd.agregarParametro(ParameterDirection.Input, "@trabajo", e.Trabajo)
        Return CType(cmd.ejecutar().Rows(0).Item("idEvento"), Integer)
    End Function
End Class
