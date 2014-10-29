<Serializable()> _
Public Class MovimientoCajaItem
    Private _idMovimientoCajaItem As Integer
    Private _idMovimientoCaja As Integer
    Private _formaPago As FormaPago
    Private _importe As Double
    Private _moneda As Moneda
    Private _cotizacionPesos As Double
    Private _banco As Banco
    Private _chequeSucursal As String
    Private _chequeNumero As String
    Private _chequeFechaCobro As Date
    Private _tipoInterdeposito As TipoInterdeposito
    Private _interdepositoBoleta As String
    Private _interdepositoFecha As Date
    Private _interdepositoTerminalBancaria As String
    Private _tarjetaNumero As String
    Private _tarjetaCupon As String
    Private _tarjetaAutorizacion As String
    Private _tarjetaCuotas As Integer
    Public Property IdMovimientoCajaItem() As Integer
        Get
            Return Me._idMovimientoCajaItem
        End Get
        Set(ByVal value As Integer)
            Me._idMovimientoCajaItem = value
        End Set
    End Property
    Public Property IdMovimientoCaja() As Integer
        Get
            Return Me._idMovimientoCaja
        End Get
        Set(ByVal value As Integer)
            Me._idMovimientoCaja = value
        End Set
    End Property
    Public Property Importe() As Double
        Get
            Return Me._importe
        End Get
        Set(ByVal value As Double)
            Me._importe = value
        End Set
    End Property

    Public ReadOnly Property ImportePesos() As Double
        Get
            Return Me.Importe * Me.CotizacionPesos
        End Get
    End Property


    Public Property CotizacionPesos() As Double
        Get
            Return Me._cotizacionPesos
        End Get
        Set(ByVal value As Double)
            Me._cotizacionPesos = value
        End Set
    End Property
    Public Property ChequeSucursal() As String
        Get
            Return Me._chequeSucursal
        End Get
        Set(ByVal value As String)
            Me._chequeSucursal = value
        End Set
    End Property
    Public Property ChequeNumero() As String
        Get
            Return Me._chequeNumero
        End Get
        Set(ByVal value As String)
            Me._chequeNumero = value
        End Set
    End Property
    Public Property ChequeFechaCobro() As Date
        Get
            Return Me._chequeFechaCobro
        End Get
        Set(ByVal value As Date)
            Me._chequeFechaCobro = value
        End Set
    End Property
    Public Property InterdepositoBoleta() As String
        Get
            Return Me._interdepositoBoleta
        End Get
        Set(ByVal value As String)
            Me._interdepositoBoleta = value
        End Set
    End Property
    Public Property InterdepositoFecha() As Date
        Get
            Return Me._interdepositoFecha
        End Get
        Set(ByVal value As Date)
            Me._interdepositoFecha = value
        End Set
    End Property
    Public Property InterdepositoTerminalBancaria() As String
        Get
            Return Me._interdepositoTerminalBancaria
        End Get
        Set(ByVal value As String)
            Me._interdepositoTerminalBancaria = value
        End Set
    End Property
    Public Property TarjetaNumero() As String
        Get
            Return Me._tarjetaNumero
        End Get
        Set(ByVal value As String)
            Me._tarjetaNumero = value
        End Set
    End Property
    Public Property TarjetaCupon() As String
        Get
            Return Me._tarjetaCupon
        End Get
        Set(ByVal value As String)
            Me._tarjetaCupon = value
        End Set
    End Property
    Public Property TarjetaAutorizacion() As String
        Get
            Return Me._tarjetaAutorizacion
        End Get
        Set(ByVal value As String)
            Me._tarjetaAutorizacion = value
        End Set
    End Property
    Public Property TarjetaCuotas() As Integer
        Get
            Return Me._tarjetaCuotas
        End Get
        Set(ByVal value As Integer)
            Me._tarjetaCuotas = value
        End Set
    End Property
    Public Property FormaPago() As FormaPago
        Get
            Return _formaPago
        End Get
        Set(ByVal value As FormaPago)
            _formaPago = value
        End Set
    End Property
    Public Property Moneda() As Moneda
        Get
            Return _moneda
        End Get
        Set(ByVal value As Moneda)
            _moneda = value
        End Set
    End Property
    Public Property Banco() As Banco
        Get
            Return _banco
        End Get
        Set(ByVal value As Banco)
            _banco = value
        End Set
    End Property
    Public Property TipoInterdeposito() As TipoInterdeposito
        Get
            Return _tipoInterdeposito
        End Get
        Set(ByVal value As TipoInterdeposito)
            _tipoInterdeposito = value
        End Set
    End Property
End Class
