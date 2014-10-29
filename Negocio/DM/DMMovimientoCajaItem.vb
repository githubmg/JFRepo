Imports AccesoDatos
Public Class DMMovimientoCajaItem
    Public Shared Function ObtenerMovimientoCajaItem(ByVal idMovimientoCajaItem As Integer) As MovimientoCajaItem
        Dim cmd As New comando("dbo.MovimientoCajaItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoCajaItem", idMovimientoCajaItem)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim m As New MovimientoCajaItem
                m.idMovimientoCajaItem = CType(.Rows(0).Item("idMovimientoCajaItem"), Integer)
                m.idMovimientoCaja = CType(.Rows(0).Item("idMovimientoCaja"), Integer)
                m.FormaPago = Sistema.ObtenerFormaPago(CType(.Rows(0).Item("idFormaPago"), Integer))
                m.Importe = CType(.Rows(0).Item("importe"), Double)
                m.Moneda = Sistema.ObtenerMoneda(CType(.Rows(0).Item("idMoneda"), Integer))
                m.cotizacionPesos = CType(.Rows(0).Item("cotizacionPesos"), Double)

                If m.FormaPago.EsCheque Or m.FormaPago.EsInterdeposito Then m.Banco = Sistema.ObtenerBanco(CType(.Rows(0).Item("idBanco"), Integer))

                If m.FormaPago.EsCheque Then m.ChequeSucursal = CType(.Rows(0).Item("chequeSucursal"), String)
                If m.FormaPago.EsCheque Then m.ChequeNumero = CType(.Rows(0).Item("chequeNumero"), String)
                If m.FormaPago.EsCheque Then m.ChequeFechaCobro = CType(.Rows(0).Item("chequeFechaCobro"), Date)

                If m.FormaPago.EsInterdeposito Then m.TipoInterdeposito = Sistema.ObtenerTipoInterdeposito(CType(.Rows(0).Item("idTipoInterdeposito"), Integer))
                If m.FormaPago.EsInterdeposito Then m.InterdepositoBoleta = CType(.Rows(0).Item("interdepositoBoleta"), String)
                If m.FormaPago.EsInterdeposito Then m.InterdepositoFecha = CType(.Rows(0).Item("interdepositoFecha"), Date)
                If m.FormaPago.EsInterdeposito Then m.InterdepositoTerminalBancaria = CType(.Rows(0).Item("interdepositoTerminalBancaria"), String)

                If m.FormaPago.EsTarjeta Then m.TarjetaNumero = CType(.Rows(0).Item("tarjetaNumero"), String)
                If m.FormaPago.EsTarjeta Then m.TarjetaCupon = CType(.Rows(0).Item("tarjetaCupon"), String)
                If m.FormaPago.EsTarjeta Then m.TarjetaAutorizacion = CType(.Rows(0).Item("tarjetaAutorizacion"), String)
                If m.FormaPago.EsTarjeta Then m.TarjetaCuotas = CType(.Rows(0).Item("tarjetaCuotas"), Integer)
                Return m
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarMovimientoCajaItem(ByVal m As MovimientoCajaItem) As Integer
        Dim cmd As New comando("dbo.MovimientoCajaItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoCaja", m.idMovimientoCaja)
        cmd.agregarParametro(ParameterDirection.Input, "@idFormaPago", m.FormaPago.IdFormaPago)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", m.importe)
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", m.Moneda.IdMoneda)
        cmd.agregarParametro(ParameterDirection.Input, "@cotizacionPesos", m.CotizacionPesos)

        If m.FormaPago.EsCheque Or m.FormaPago.EsInterdeposito Then cmd.agregarParametro(ParameterDirection.Input, "@idBanco", m.Banco.IdBanco)
        If m.FormaPago.EsCheque Then cmd.agregarParametro(ParameterDirection.Input, "@chequeSucursal", m.ChequeSucursal)
        If m.FormaPago.EsCheque Then cmd.agregarParametro(ParameterDirection.Input, "@chequeNumero", m.ChequeNumero)
        If m.FormaPago.EsCheque Then cmd.agregarParametro(ParameterDirection.Input, "@chequeFechaCobro", m.ChequeFechaCobro)

        If m.FormaPago.EsInterdeposito Then cmd.agregarParametro(ParameterDirection.Input, "@idTipoInterdeposito", m.TipoInterdeposito.IdTipoInterdeposito)
        If m.FormaPago.EsInterdeposito Then cmd.agregarParametro(ParameterDirection.Input, "@interdepositoBoleta", m.InterdepositoBoleta)
        If m.FormaPago.EsInterdeposito Then cmd.agregarParametro(ParameterDirection.Input, "@interdepositoFecha", m.InterdepositoFecha)
        If m.FormaPago.EsInterdeposito Then cmd.agregarParametro(ParameterDirection.Input, "@interdepositoTerminalBancaria", m.InterdepositoTerminalBancaria)

        If m.FormaPago.EsTarjeta Then cmd.agregarParametro(ParameterDirection.Input, "@tarjetaNumero", m.TarjetaNumero)
        If m.FormaPago.EsTarjeta Then cmd.agregarParametro(ParameterDirection.Input, "@tarjetaCupon", m.TarjetaCupon)
        If m.FormaPago.EsTarjeta Then cmd.agregarParametro(ParameterDirection.Input, "@tarjetaAutorizacion", m.TarjetaAutorizacion)
        If m.FormaPago.EsTarjeta Then cmd.agregarParametro(ParameterDirection.Input, "@tarjetaCuotas", m.TarjetaCuotas)
        Return CType(cmd.ejecutar().Rows(0).Item("idMovimientoCajaItem"), Integer)
    End Function


    Public Shared Function VistaMovimientoCajaItem() As DataTable
        Dim cmd As New comando("dbo.MovimientoCajaItemVista")
        Return cmd.ejecutar()
    End Function

End Class
