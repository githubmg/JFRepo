Imports AccesoDatos
Public Class DMEstadoSocio
    Public Shared Function ObtenerEstadoSocio(ByVal idEstadoSocio As Integer) As EstadoSocio
        Dim cmd As New comando("dbo.EstadoSocioSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoSocio", idEstadoSocio)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New EstadoSocio
                o.IdestadoSocio = idEstadoSocio
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaEstadoSocio() As DataTable
        Return New comando("dbo.EstadoSocioSelect").ejecutar()
    End Function
End Class
