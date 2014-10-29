Imports AccesoDatos

Public Class DMVendedor
    Public Shared Function ObtenerVendedor(ByVal idVendedor As Integer) As Vendedor
        Dim cmd As New comando("dbo.VendedorSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idVendedor", idVendedor)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim v As New Vendedor
                v.IdVendedor = CType(.Rows(0).Item("idVendedor"), Integer)
                v.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return v
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaVendedor() As DataTable
        Dim cmd As New comando("dbo.VendedorSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idVendedor")
        Return cmd.ejecutar()
    End Function
End Class
