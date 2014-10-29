<Serializable()> _
Public Class FondoFijoItem
    Private _idFondoFijoItem As Integer
    Private _cuenta As Cuenta
    Private _observaciones As String
    Private _monto As Double
    Public Property IdFondoFijoItem() As Integer
        Get
            Return Me._idFondoFijoItem
        End Get
        Set(ByVal value As Integer)
            Me._idFondoFijoItem = value
        End Set
    End Property
    Public Property Cuenta() As Cuenta
        Get
            Return _cuenta
        End Get
        Set(ByVal value As Cuenta)
            _cuenta = value
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
    Public Property Monto() As Double
        Get
            Return Me._monto
        End Get
        Set(ByVal value As Double)
            Me._monto = value
        End Set
    End Property

End Class
