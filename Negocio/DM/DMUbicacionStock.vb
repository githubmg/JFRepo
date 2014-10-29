Imports AccesoDatos
Public Class DMUbicacionStock
    Public Shared Function ObtenerUbicacionStock(ByVal idUbicacionStock As Integer) As UbicacionStock
        Dim cmd As New comando("dbo.UbicacionStockSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStock", idUbicacionStock)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New UbicacionStock
                o.IdUbicacionStock = idUbicacionStock
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaUbicacionStock() As DataTable
        Return New comando("dbo.UbicacionStockSelect").ejecutar()
    End Function
   
End Class
