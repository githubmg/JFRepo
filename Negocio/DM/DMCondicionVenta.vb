Imports AccesoDatos
Public Class DMCondicionVenta
    Public Shared Function VistaCondicionVenta() As DataTable
        Dim cmd As New comando("CondicionVentaSelect")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerCondicionVenta(ByVal idCondicionVenta As Integer) As CondicionVenta
        Dim cmd As New comando("CondicionVentaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionVenta", idCondicionVenta)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim o As New CondicionVenta
                o.IdCondicionVenta = idCondicionVenta
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
