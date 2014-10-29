Imports AccesoDatos

Public Class DMTipoOrden
    Public Shared Function ObtenerTipoOrden(ByVal idTipoOrden As Integer) As TipoOrden
        Dim cmd As New comando("dbo.TipoOrdenSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoOrden", idTipoOrden)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim t As New TipoOrden
                t.IdTipoOrden = CType(.Rows(0).Item("idTipoOrden"), Integer)
                t.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return t
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaTipoOrden() As DataTable
        Dim cmd As New comando("dbo.TipoOrdenSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoOrden")
        Return cmd.ejecutar()
    End Function
End Class
