<Serializable()> _
Public Class RemitoVistaClass

    Private _idRemito As Integer
    Public Property IdRemito() As Integer
        Get
            Return _idRemito
        End Get
        Set(ByVal value As Integer)
            _idRemito = value
        End Set
    End Property

    Private _chasis As String
    Public Property Chasis() As String
        Get
            Return _chasis
        End Get
        Set(ByVal value As String)
            _chasis = value
        End Set
    End Property

    Private _cliente As String
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property

    Private _fechaPedido As Date
    Public Property FechaPedido() As Date
        Get
            Return _fechaPedido
        End Get
        Set(ByVal value As Date)
            _fechaPedido = value
        End Set
    End Property


    Private _orden As String
    Public Property Orden() As String
        Get
            Return _orden
        End Get
        Set(ByVal value As String)
            _orden = value
        End Set
    End Property


    Private _estado As String
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property


    Private _pendiente As String
    Public Property Pendiente() As String
        Get
            Return _pendiente
        End Get
        Set(ByVal value As String)
            _pendiente = value
        End Set
    End Property


    Private _total As String
    Public Property Total() As String
        Get
            Return _total
        End Get
        Set(ByVal value As String)
            _total = value
        End Set
    End Property

    Private _factura As String
    Public Property Factura() As String
        Get
            Return _factura
        End Get
        Set(ByVal value As String)
            _factura = value
        End Set
    End Property


End Class
