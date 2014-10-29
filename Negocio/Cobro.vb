Public Class Cobro
    Private _idCobro As Integer
    Private _fecha As Date
    Private _medioPago As MedioPago
    Private _importe As Double
    Private _observaciones As String
    Private _pedidos As List(Of PedidoCabeCobroItem)
    Private _cheque As Cheque
    Public Property Pedidos() As List(Of PedidoCabeCobroItem)
        Get
            Return Me._pedidos
        End Get
        Set(ByVal value As List(Of PedidoCabeCobroItem))
            Me._pedidos = value
        End Set
    End Property
    Public Property IdCobro() As Integer
        Get
            Return Me._idCobro
        End Get
        Set(ByVal value As Integer)
            Me._idCobro = value
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
    Public Property Cheque() As Cheque
        Get
            Return Me._cheque
        End Get
        Set(ByVal value As Cheque)
            Me._cheque = value
        End Set
    End Property
    Public Property MedioPago() As MedioPago
        Get
            Return Me._medioPago
        End Get
        Set(ByVal value As MedioPago)
            Me._medioPago = value
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
    Public Property Observaciones() As String
        Get
            Return Me._observaciones
        End Get
        Set(ByVal value As String)
            Me._observaciones = value
        End Set
    End Property
End Class
