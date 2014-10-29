Imports AccesoDatos
Public Class DMTipoComprobante
    Public Shared Function VistaTipoComprobante() As DataTable
        Dim cmd As New comando("TipoComprobanteVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerTipoComprobante(ByVal idTipoComprobante As Integer) As TipoComprobante
        Dim cmd As New comando("TipoComprobanteSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", idTipoComprobante)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Return mapear(.Rows(0))
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function ObtenerTipoComprobante(ByVal sigla As String) As TipoComprobante
        Dim cmd As New comando("TipoComprobanteSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@sigla", sigla)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Return mapear(.Rows(0))
            Else
                Return Nothing
            End If
        End With
    End Function

    Public Shared Function mapear(ByVal r As DataRow) As TipoComprobante
        Dim o As New TipoComprobante
        o.IdTipoComprobante = CType(r.Item("idTipoComprobante"), Integer)
        o.Descripcion = r.Item("descripcion").ToString()
        o.Letra = r.Item("letra").ToString()
        o.Orden = CType(r.Item("orden"), Integer)
        o.Sigla = r.Item("sigla").ToString()
        Return o
    End Function
End Class
