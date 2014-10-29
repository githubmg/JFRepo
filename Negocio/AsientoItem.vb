<Serializable()> _
Public Class AsientoItem
    Private _idAsientoItem As Integer
    Private _debe As Double
    Private _haber As Double
    Private _cuenta As Cuenta
    Public Property IdAsientoItem() As Integer
        Get
            Return Me._idAsientoItem
        End Get
        Set(ByVal value As Integer)
            Me._idAsientoItem = value
        End Set
    End Property
    Public Property Debe() As Double
        Get
            Return Me._debe
        End Get
        Set(ByVal value As Double)
            Me._debe = value
        End Set
    End Property
    Public Property Haber() As Double
        Get
            Return Me._haber
        End Get
        Set(ByVal value As Double)
            Me._haber = value
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


End Class
