Imports AccesoDatos
Public Class DMPais
    Public Shared Function VistaPais() As DataTable
        Dim cmd As New comando("PaisSelect")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerPais(ByVal idPais As Integer) As Pais
        Dim cmd As New comando("PaisSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idPais", idPais)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim o As New Pais
                o.IdPais = idPais
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
