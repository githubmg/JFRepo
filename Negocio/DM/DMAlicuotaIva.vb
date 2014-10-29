Imports AccesoDatos

Public Class DMAlicuotaIva
    Public Shared Function ObtenerAlicuotaIva(ByVal idAlicuotaIva As Integer) As AlicuotaIva
        Dim cmd As New comando("dbo.AlicuotaIvaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAlicuotaIva", idAlicuotaIva)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim a As New AlicuotaIva
                a.IdAlicuotaIva = CType(.Rows(0).Item("idAlicuotaIva"), Integer)
                a.Valor = CType(.Rows(0).Item("valor"), Double)
                a.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return a
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaAlicuotaIva() As DataTable
        Dim cmd As New comando("dbo.AlicuotaIvaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAlicuotaIva")
        Return cmd.ejecutar()
    End Function
End Class
