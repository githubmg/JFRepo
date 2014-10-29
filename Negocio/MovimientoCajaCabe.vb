Public Class MovimientoCajaCabe
    Private _idMovimientoCaja As Integer
    Private _fecha As Date
    Private _idComprobante As Integer
    Private _idPago As Integer
    Private _idFondoFijo As Integer

    Private _items As List(Of MovimientoCajaItem)


    Public Property IdMovimientoCaja() As Integer
        Get
            Return Me._idMovimientoCaja
        End Get
        Set(ByVal value As Integer)
            Me._idMovimientoCaja = value
        End Set
    End Property
    Public Property Fecha() As Date
        Get
            Return Me._fecha
        End Get
        Set(ByVal value As Date)
            Me._fecha = value
        End Set
    End Property
    Public Property IdComprobante() As Integer
        Get
            Return Me._idComprobante
        End Get
        Set(ByVal value As Integer)
            Me._idComprobante = value
        End Set
    End Property
    Public Property IdPago() As Integer
        Get
            Return Me._idPago
        End Get
        Set(ByVal value As Integer)
            Me._idPago = value
        End Set
    End Property
    Public Property IdFondoFijo() As Integer
        Get
            Return _idFondoFijo
        End Get
        Set(ByVal value As Integer)
            _idFondoFijo = value
        End Set
    End Property
    Public Property Items() As List(Of MovimientoCajaItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of MovimientoCajaItem))
            _items = value
        End Set
    End Property



    Public Sub New()

    End Sub

    Public Sub New(ByVal ff As FondoFijo)
        Me.IdFondoFijo = ff.IdFondoFijo
        Me.Fecha = ff.Fecha
        Me.Items = New List(Of MovimientoCajaItem)

        Dim m As New MovimientoCajaItem
        m.FormaPago = ff.FormaPago
        m.Importe = ff.Total
        m.Moneda = m.FormaPago.Moneda
        m.CotizacionPesos = m.FormaPago.Moneda.cotizacionActual

        m.Banco = Nothing

        m.ChequeSucursal = ""
        m.ChequeNumero = ""
        m.ChequeFechaCobro = #1/1/1900#

        m.TipoInterdeposito = Nothing
        m.InterdepositoBoleta = ""
        m.InterdepositoFecha = #1/1/1900#
        m.InterdepositoTerminalBancaria = ""

        m.TarjetaNumero = ""
        m.TarjetaCupon = ""
        m.TarjetaAutorizacion = ""
        m.TarjetaCuotas = 0

        Me.Items.Add(m)

    End Sub

    Public Sub New(ByVal p As PagoProveedor)
        Me.IdPago = p.IdPago
        Me.Fecha = p.FechaPago
        Me.Items = p.Valores

    End Sub

End Class
