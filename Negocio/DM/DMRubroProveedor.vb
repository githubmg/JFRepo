Imports AccesoDatos
Public Class DMRubroProveedor
    Public Shared Function ObtenerRubroProveedor(ByVal idRubroProveedor As Integer) As RubroProveedor
        Dim cmd As New comando("dbo.rubroProveedorSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idRubroProveedor", idRubroProveedor)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New RubroProveedor
                o.IdRubroProveedor = idRubroProveedor
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaRubroProveedor() As DataTable
        Return New comando("dbo.rubroProveedorSelect").ejecutar()
    End Function
End Class
