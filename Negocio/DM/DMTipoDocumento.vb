Imports AccesoDatos
Public Class DMTipoDocumento
    Public Shared Function ObtenerTipoDocumento(ByVal idTipoDocumento As Integer) As TipoDocumento
        Dim cmd As New comando("dbo.TipoDocumentoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoDocumento", idTipoDocumento)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New TipoDocumento
                o.IdTipoDocumento = idTipoDocumento
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaTipoDocumento() As DataTable
        Return New comando("dbo.TipoDocumentoSelect").ejecutar()
    End Function
End Class
