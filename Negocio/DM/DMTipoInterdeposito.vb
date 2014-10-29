Imports AccesoDatos
Public Class DMTipoInterdeposito
    Public Shared Function ObtenerTipoInterdeposito(ByVal idTipoInterdeposito As Integer) As TipoInterdeposito
        Dim cmd As New comando("dbo.TipoInterdepositoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoInterdeposito", idTipoInterdeposito)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim t As New TipoInterdeposito
                t.IdTipoInterdeposito = CType(.Rows(0).Item("idTipoInterdeposito"), Integer)
                t.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return t
            Else : Return Nothing
            End If
        End With
    End Function

    Public Shared Function AgregarTipoInterdeposito(ByVal t As TipoInterdeposito) As Integer
        Dim cmd As New comando("dbo.TipoInterdepositoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", t.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idTipoInterdeposito"), Integer)
    End Function

    Public Shared Function ActualizarTipoInterdeposito(ByVal t As TipoInterdeposito) As Integer
        Dim cmd As New comando("dbo.TipoInterdepositoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoInterdeposito", t.idTipoInterdeposito)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", t.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idTipoInterdeposito"), Integer)
    End Function

    Public Shared Function VistaTipoInterdeposito() As DataTable
        Dim cmd As New comando("dbo.TipoInterdepositoSelect")
        Return cmd.ejecutar()
    End Function

End Class
