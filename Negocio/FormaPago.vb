<Serializable()> _
Public Class FormaPago
    Private _idFormaPago As Integer
    Private _descripcion As String
    Private _cuenta As Cuenta
    Private _esCheque As Boolean
    Private _esTarjeta As Boolean
    Private _esInterdeposito As Boolean
    Private _usadoParaFondoFijo As Boolean
    Private _moneda As Moneda


    Public Property IdFormaPago() As Integer
        Get
            Return Me._idFormaPago
        End Get
        Set(ByVal value As Integer)
            Me._idFormaPago = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return Me._descripcion
        End Get
        Set(ByVal value As String)
            Me._descripcion = value
        End Set
    End Property
    Public Property Cuenta() As Cuenta
        Get
            Return Me._cuenta
        End Get
        Set(ByVal value As Cuenta)
            Me._cuenta = value
        End Set
    End Property
    Public Property EsCheque() As Boolean
        Get
            Return Me._esCheque
        End Get
        Set(ByVal value As Boolean)
            Me._esCheque = value
        End Set
    End Property
    Public Property EsTarjeta() As Boolean
        Get
            Return _esTarjeta
        End Get
        Set(ByVal value As Boolean)
            _esTarjeta = value
        End Set
    End Property
    Public Property EsInterdeposito() As Boolean
        Get
            Return _esInterdeposito
        End Get
        Set(ByVal value As Boolean)
            _esInterdeposito = value
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
    Public Property UsadoParaFondoFijo() As Boolean
        Get
            Return _usadoParaFondoFijo
        End Get
        Set(ByVal value As Boolean)
            _usadoParaFondoFijo = value
        End Set
    End Property
End Class

