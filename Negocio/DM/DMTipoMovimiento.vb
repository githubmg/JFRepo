Imports AccesoDatos

Public Class DMTipoMovimiento
    Public Shared Function ObtenerTipoMovimiento(ByVal idTipoMovimiento As Integer) As TipoMovimiento
        Dim cmd As New comando("dbo.TipoMovimientoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoMovimiento", idTipoMovimiento)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim t As New TipoMovimiento
                t.IdTipoMovimiento = CType(.Rows(0).Item("idTipoMovimiento"), Integer)
                t.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return t
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaTipoMovimiento() As DataTable
        Dim cmd As New comando("dbo.TipoMovimientoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoMovimiento")
        Return cmd.ejecutar()
    End Function
End Class
