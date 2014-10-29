Imports AccesoDatos

Public Class DMOrigenCheque
    Public Shared Function ObtenerOrigenCheque(ByVal idOrigenCheque As Integer) As OrigenCheque
        Dim cmd As New comando("dbo.OrigenChequeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idOrigenCheque", idOrigenCheque)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New OrigenCheque
                o.IdOrigenCheque = CType(.Rows(0).Item("idOrigenCheque"), Integer)
                o.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return o
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaOrigenCheque() As DataTable
        Dim cmd As New comando("dbo.OrigenChequeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idOrigenCheque")
        Return cmd.ejecutar()
    End Function
End Class
