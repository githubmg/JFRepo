Imports AccesoDatos

Public Class DMEstadoPedido
    Public Shared Function ObtenerEstadoPedido(ByVal idEstadoPedido As Integer) As EstadoPedido
        Dim cmd As New comando("dbo.EstadoPedidoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoPedido", idEstadoPedido)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim e As New EstadoPedido
                e.IdEstadoPedido = CType(.Rows(0).Item("idEstadoPedido"), Integer)
                e.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return e
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarEstadoPedido(ByVal e As EstadoPedido) As Integer
        Dim cmd As New comando("dbo.EstadoPedidoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", e.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idEstadoPedido"), Integer)
    End Function
    Public Shared Function ActualizarEstadoPedido(ByVal e As EstadoPedido) As Integer
        Dim cmd As New comando("dbo.EstadoPedidoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoPedido", e.idEstadoPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", e.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idEstadoPedido"), Integer)
    End Function
    Public Shared Function VistaEstadoPedido() As DataTable
        Dim cmd As New comando("dbo.EstadoPedidoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoPedido")
        Return cmd.ejecutar()
    End Function
End Class
