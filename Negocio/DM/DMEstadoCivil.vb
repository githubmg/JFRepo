Imports AccesoDatos
Public Class DMEstadoCivil
    Public Shared Function ObtenerEstadoCivil(ByVal idEstadoCivil As Integer) As EstadoCivil
        Dim cmd As New comando("dbo.EstadoCivilSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoCivil", idEstadoCivil)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New EstadoCivil
                o.IdEstadoCivil = idEstadoCivil
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaEstadoCivil() As DataTable
        Return New comando("dbo.EstadoCivilSelect").ejecutar()
    End Function
End Class

