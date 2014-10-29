Imports AccesoDatos

Public Class DMPedidoCabe
    Public Shared Function ObtenerPedidoCabe(ByVal idPedidoCabe As Integer) As PedidoCabe
        Dim cmd As New comando("dbo.PedidoCabeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedidoCabe", idPedidoCabe)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim p As New PedidoCabe
                p.idPedidoCabe = CType(.Rows(0).Item("idPedidoCabe"), Integer)
                p.Cliente = Sistema.Obtenercliente(CType(.Rows(0).Item("idCliente"), Integer))
                p.fechaPedido = CType(.Rows(0).Item("fechaPedido"), Date)
                p.Orden = CType(.Rows(0).Item("orden"), String)
                p.Chasis = CType(.Rows(0).Item("chasis"), String)
                p.EstadoPedido = Sistema.ObtenerEstadoPedido(CType(.Rows(0).Item("idEstadoPedido"), Integer))
                p.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(.Rows(0).Item("idUbicacionStock"), Integer))
                p.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                p.TipoOrden = Sistema.ObtenerTipoOrden(CType(.Rows(0).Item("idTipoOrden"), Integer))
                p.Items = Sistema.ObtenerPedidoItems(p.IdPedidoCabe)

                Return p
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarPedidoCabe(ByVal p As PedidoCabe) As Integer
        Dim cmd As New comando("dbo.PedidoCabeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idCliente", p.Cliente.IdCliente)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaPedido", p.fechaPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@orden", p.Orden)
        cmd.agregarParametro(ParameterDirection.Input, "@chasis", p.Chasis)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoPedido", p.EstadoPedido.IdEstadoPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoOrden", p.TipoOrden.IdTipoOrden)
        cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStock", p.UbicacionStock.IdUbicacionStock)
        p.IdPedidoCabe = CType(cmd.ejecutar().Rows(0).Item("idCabe"), Integer)
        For Each pi As PedidoItem In p.Items
            Sistema.AgregarPedidoItem(pi, p.IdPedidoCabe)
        Next
        'Agrego tambien el remito siempre y cuando sea registrado
        If p.TipoOrden.IdTipoOrden = 1 Then
            Sistema.AgregarRemito(p)
        End If
        Return p.IdPedidoCabe
    End Function
    Public Shared Function ActualizarPedidoCabe(ByVal p As PedidoCabe) As Integer
        Dim cmd As New comando("dbo.PedidoCabeUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedidoCabe", p.idPedidoCabe)
        cmd.agregarParametro(ParameterDirection.Input, "@idCliente", p.Cliente.IdCliente)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaPedido", p.fechaPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@orden", p.Orden)
        cmd.agregarParametro(ParameterDirection.Input, "@chasis", p.Chasis)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoPedido", p.EstadoPedido.IdEstadoPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoOrden", p.TipoOrden.IdTipoOrden)
        cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStock", p.UbicacionStock.IdUbicacionStock)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.Observaciones)
        p.IdPedidoCabe = CType(cmd.ejecutar().Rows(0).Item("idPedidoCabe"), Integer)
        Sistema.EliminarItems(p.IdPedidoCabe)
        For Each pi As PedidoItem In p.Items
            Sistema.AgregarPedidoItem(pi, p.IdPedidoCabe)
        Next
        Return p.IdPedidoCabe
    End Function
    Public Shared Function VistaPedidoCabe() As DataTable
        Dim cmd As New comando("dbo.PedidoCabeVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaPedidoSinSaldar(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.PedidoSSaldarVista")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function
    Public Shared Function MontoCompraSinSaldar(ByVal p As PedidoCabe) As Double
        Dim cmd As New comando("dbo.MontoPedidoSSaldarVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedido", p.IdPedidoCabe)
        Return CType(cmd.ejecutar().Rows(0).Item("saldo"), Double)
    End Function
    Public Shared Function AgregarRemito(ByVal p As PedidoCabe) As Integer
        Dim cmd As New comando("dbo.PedidoRemitoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idPedido", p.IdPedidoCabe)
        Return CType(cmd.ejecutar().Rows(0).Item("idRemito"), Integer)
    End Function

End Class
