Imports AccesoDatos
Public Class DMSexo
    Public Shared Function ObtenerSexo(ByVal idSexo As Integer) As Sexo
        Dim cmd As New comando("dbo.SexoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idSexo", idSexo)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Sexo
                o.IdSexo = idSexo
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaSexo() As DataTable
        Return New comando("dbo.SexoSelect").ejecutar()
    End Function
End Class
