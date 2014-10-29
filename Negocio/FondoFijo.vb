Public Class FondoFijo
    Private _idFondoFijo As Integer
    Private _formaPago As FormaPago
    Private _observaciones As String
    Private _fecha As Date
    Private _items As List(Of FondoFijoItem)

    Public Property IdFondoFijo() As Integer
        Get
            Return Me._idFondoFijo
        End Get
        Set(ByVal value As Integer)
            Me._idFondoFijo = value
        End Set
    End Property
    Public Property FormaPago() As FormaPago
        Get
            Return Me._formaPago
        End Get
        Set(ByVal value As FormaPago)
            Me._formaPago = value
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
    Public Property Fecha() As Date
        Get
            Return Me._fecha
        End Get
        Set(ByVal value As Date)
            Me._fecha = value
        End Set
    End Property
    Public Property Items() As List(Of FondoFijoItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of FondoFijoItem))
            _items = value
        End Set
    End Property
    Public ReadOnly Property Total() As Double
        Get
            Dim t As Double = 0
            For Each fi As FondoFijoItem In Me.Items
                t += fi.Monto
            Next
            Return t
        End Get
    End Property

End Class
