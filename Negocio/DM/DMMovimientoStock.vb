Imports AccesoDatos

Public Class DMMovimientoStock
    Public Shared Function ObtenerMovimientoStock(ByVal idMovimientoStock As Integer) As MovimientoStock
        Dim cmd As New comando("dbo.MovimientoStockSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoStock", idMovimientoStock)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim m As New MovimientoStock
                m.IdMovimientoStock = CType(.Rows(0).Item("idMovimientoStock"), Integer)
                m.Fecha = CType(.Rows(0).Item("fecha"), Date)
                m.TipoMovimiento = Sistema.ObtenerTipoMovimiento(CType(.Rows(0).Item("idTipoMovimiento"), Integer))
                m.Producto = Sistema.ObtenerProducto(CType(.Rows(0).Item("idProducto"), Integer))
                m.Cantidad = CType(.Rows(0).Item("cantidad"), Double)
                If Not IsDBNull(.Rows(0).Item("idUbicacionStock")) Then
                    m.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(.Rows(0).Item("idUbicacionStock"), Integer))
                End If
                If Not IsDBNull(.Rows(0).Item("idUbicacionStockOrigen")) Then
                    m.UbicacionStockOrigen = Sistema.ObtenerUbicacionStock(CType(.Rows(0).Item("idUbicacionStockOrigen"), Integer))
                End If
                If Not IsDBNull(.Rows(0).Item("idUbicacionStockDestino")) Then
                    m.UbicacionStockDestino = Sistema.ObtenerUbicacionStock(CType(.Rows(0).Item("idUbicacionStockDestino"), Integer))
                End If
                Return m
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarMovimientoStock(ByVal m As MovimientoStock) As Integer
        Dim cmd As New comando("dbo.MovimientoStockInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", m.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoMovimiento", m.TipoMovimiento.IdTipoMovimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", m.Producto.IdProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", m.Cantidad)
        If m.TipoMovimiento.IdTipoMovimiento = 3 Then
            cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStockOrigen", m.UbicacionStockOrigen.IdUbicacionStock)
            cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStockDestino", m.UbicacionStockDestino.IdUbicacionStock)
        Else
            cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStock", m.UbicacionStock.IdUbicacionStock)
        End If
        Return CType(cmd.ejecutar().Rows(0).Item("idMovimientoStock"), Integer)
    End Function
    Public Shared Function ActualizarMovimientoStock(ByVal m As MovimientoStock) As Integer
        Dim cmd As New comando("dbo.MovimientoStockUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoStock", m.idMovimientoStock)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", m.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoMovimiento", m.TipoMovimiento.IdTipoMovimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@idProducto", m.Producto.IdProducto)
        cmd.agregarParametro(ParameterDirection.Input, "@cantidad", m.Cantidad)
        If m.TipoMovimiento.IdTipoMovimiento = 3 Then
            cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStockOrigen", m.UbicacionStockOrigen.IdUbicacionStock)
            cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStockDestino", m.UbicacionStockDestino.IdUbicacionStock)
        Else
            cmd.agregarParametro(ParameterDirection.Input, "@idUbicacionStock", m.UbicacionStock.IdUbicacionStock)
        End If
        Return CType(cmd.ejecutar().Rows(0).Item("idMovimientoStock"), Integer)
    End Function
    Public Shared Function VistaMovimientoStock() As DataTable
        Dim cmd As New comando("dbo.MovimientoStockVista")
        Return cmd.ejecutar()
    End Function
End Class
