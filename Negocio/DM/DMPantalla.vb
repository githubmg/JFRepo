Imports AccesoDatos

Public Class DMPantalla
    Public Shared Function ObtenerPantalla(ByVal idPantalla As Integer) As Pantalla
        Dim cmd As New comando("dbo.PantallaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idPantalla", idPantalla)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Pantalla
                o.IdPantalla = idPantalla
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                o.Tipo = .Rows(0).Item("tipo").ToString()
                o.Url = .Rows(0).Item("url").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaPantalla() As DataTable
        Return New comando("dbo.PantallaSelect").ejecutar()
    End Function
End Class
