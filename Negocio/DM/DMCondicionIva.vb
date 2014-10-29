Imports AccesoDatos
Public Class DMCondicionIva
    Public Shared Function ObtenerCondicionIva(ByVal idCondicionIva As Integer) As CondicionIva
        Dim cmd As New comando("dbo.CondicionIvaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionIva", idCondicionIva)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New CondicionIva
                o.IdCondicionIva = idCondicionIva
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaCondicionIva() As DataTable
        Return New comando("dbo.CondicionIvaSelect").ejecutar()
    End Function
End Class
