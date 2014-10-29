Imports AccesoDatos
Public Class DMRetencion
    Public Shared Function VistaRetencion() As DataTable
        Dim cmd As New comando("dbo.retencionSelect")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerRetencion(ByVal idRetencion As Integer) As Retencion
        Dim cmd As New comando("dbo.retencionSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idRetencion", idRetencion)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim r As New Retencion
                r.IdRetencion = idRetencion
                r.Descripcion = .Rows(0).Item("descripcion").ToString()
                r.Cuenta = Sistema.ObtenerCuenta(.Rows(0).Item("codigoCuenta").ToString())
                Return r
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
