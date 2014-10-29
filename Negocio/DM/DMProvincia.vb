Imports AccesoDatos
Public Class DMProvincia
    Public Shared Function ObtenerProvincia(ByVal idProvincia As Integer) As Provincia
        Dim cmd As New comando("dbo.ProvinciaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idProvincia", idProvincia)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Provincia
                o.IdProvincia = idProvincia
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaProvincia() As DataTable
        Return New comando("dbo.ProvinciaSelect").ejecutar()
    End Function
End Class
