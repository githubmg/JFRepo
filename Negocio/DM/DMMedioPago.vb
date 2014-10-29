Imports AccesoDatos

Public Class DMMedioPago
    Public Shared Function ObtenerMedioPago(ByVal idMedioPago As Integer) As MedioPago
        Dim cmd As New comando("dbo.MedioPagoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago", idMedioPago)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim m As New MedioPago
                m.IdMedioPago = CType(.Rows(0).Item("idMedioPago"), Integer)
                m.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return m
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaMedioPago() As DataTable
        Dim cmd As New comando("dbo.MedioPagoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago")
        Return cmd.ejecutar()
    End Function
End Class
