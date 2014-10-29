Public Class Cotizacion
    Private _idCotizacion As Integer
    Private _moneda As Moneda
    Private _fecha As Date
    Private _cotizacion As Double
    Public Property IdCotizacion() As Integer
        Get
            Return Me._idCotizacion
        End Get
        Set(ByVal value As Integer)
            Me._idCotizacion = value
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
    Public Property Cotizacion() As Double
        Get
            Return Me._cotizacion
        End Get
        Set(ByVal value As Double)
            Me._cotizacion = value
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


End Class
