Imports AccesoDatos
Public Class DMGanancias
    Public Shared Function ObtenerGanancias(ByVal idGanancias As Integer) As Ganancias
        Dim cmd As New comando("dbo.GananciasSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idGanancias", idGanancias)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Ganancias
                o.IdGanancias = idGanancias
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaGanancias() As DataTable
        Return New comando("dbo.GananciasSelect").ejecutar()
    End Function

End Class
