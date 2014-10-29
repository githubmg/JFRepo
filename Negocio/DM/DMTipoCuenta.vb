Imports AccesoDatos
Public Class DMTipoCuenta
    Public Shared Function VistaTipoCuenta() As DataTable
        Dim cmd As New comando("tipoCuentaVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerTipoCuenta(ByVal idTipoCuenta As Integer) As TipoCuenta
        Dim cmd As New comando("tipoCuentaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoCuenta", idTipoCuenta)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim o As New TipoCuenta
                o.IdTipoCuenta = idTipoCuenta
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
