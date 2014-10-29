Imports AccesoDatos
Public Class DMCentroCostos
    Public Shared Function VistaCentroCostos() As DataTable
        Dim cmd As New comando("CentroCostosVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerCentroCostos(ByVal idCentroCostos As Integer) As CentroCostos
        Dim cmd As New comando("CentroCostosSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCentroCostos", idCentroCostos)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim o As New CentroCostos
                o.IdCentroCostos = idCentroCostos
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
