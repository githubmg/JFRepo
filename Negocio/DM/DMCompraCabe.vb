Imports AccesoDatos

Public Class DMCompraCabe
    Public Shared Function ObtenerCompraCabe(ByVal idCompraCabe As Integer) As CompraCabe
        Dim cmd As New comando("dbo.CompraCabeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompraCabe", idCompraCabe)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New CompraCabe
                c.IdCompraCabe = CType(.Rows(0).Item("idCompraCabe"), Integer)
                c.Proveedor = Sistema.ObtenerProveedor(CType(.Rows(0).Item("cuitProveedor"), Long))
                c.fechaCompra = CType(.Rows(0).Item("fechaCompra"), Date)
                c.EstadoPedido = Sistema.ObtenerEstadoPedido(CType(.Rows(0).Item("idEstado"), Integer))
                c.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                c.TipoOrden = Sistema.ObtenerTipoOrden(CType(.Rows(0).Item("idTipoOrden"), Integer))
                c.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(.Rows(0).Item("idUbicacionStock"), Integer))
                c.PercepcionGanancias = CType(.Rows(0).Item("percepcionGanancias"), Double)
                c.PercepcionIIBB = CType(.Rows(0).Item("percepcionIIBB"), Double)
                c.PercepcionIva = CType(.Rows(0).Item("percepcionIva"), Double)
                c.Items = Sistema.ObtenerCompraItems(idCompraCabe)

                Return c
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarCompraCabe(ByVal c As CompraCabe) As Integer
        Dim cmd As New comando("dbo.CompraCabeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@cuitProveedor", c.Proveedor.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaCompra", c.fechaCompra)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoPedido", c.EstadoPedido.IdEstadoPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoOrden", c.TipoOrden.IdTipoOrden)
        cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStock", c.UbicacionStock.IdUbicacionStock)
        cmd.agregarParametro(ParameterDirection.Input, "@percepcionGanancias", c.PercepcionGanancias)
        cmd.agregarParametro(ParameterDirection.Input, "@percepcionIva", c.PercepcionIva)
        cmd.agregarParametro(ParameterDirection.Input, "@percepcionIIBB", c.PercepcionIIBB)
        c.IdCompraCabe = CType(cmd.ejecutar().Rows(0).Item("idCabe"), Integer)
        For Each ci As CompraItem In c.Items
            Sistema.AgregarCompraItem(ci, c.IdCompraCabe)
        Next
        Return c.IdCompraCabe
    End Function
    Public Shared Function ActualizarCompraCabe(ByVal c As CompraCabe) As Integer
        Dim cmd As New comando("dbo.CompraCabeUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompraCabe", c.idCompraCabe)
        cmd.agregarParametro(ParameterDirection.Input, "@cuitProveedor", c.Proveedor.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaCompra", c.fechaCompra)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoPedido", c.EstadoPedido.IdEstadoPedido)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoOrden", c.TipoOrden.IdTipoOrden)
        cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStock", c.UbicacionStock.IdUbicacionStock)
        cmd.agregarParametro(ParameterDirection.Input, "@percepcionGanancias", c.PercepcionGanancias)
        cmd.agregarParametro(ParameterDirection.Input, "@percepcionIva", c.PercepcionIva)
        cmd.agregarParametro(ParameterDirection.Input, "@percepcionIIBB", c.PercepcionIIBB)

        Sistema.EliminarItemsCompra(c.IdCompraCabe)
        For Each ci As CompraItem In c.Items
            Sistema.AgregarCompraItem(ci, c.IdCompraCabe)
        Next
        Return CType(cmd.ejecutar().Rows(0).Item("idCompraCabe"), Integer)
    End Function
    Public Shared Function VistaCompraCabe() As DataTable
        Dim cmd As New comando("dbo.CompraCabeVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaCompraSinSaldar(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.CompraSSaldarVista")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function
    Public Shared Function MontoCompraSinSaldar(ByVal c As CompraCabe) As Double
        Dim cmd As New comando("dbo.MontoCompraSSaldarVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idCompra", c.IdCompraCabe)
        Return CType(cmd.ejecutar().Rows(0).Item("saldo"), Double)
    End Function
   
End Class
