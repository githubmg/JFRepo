<Serializable()> _
Public Class MultaSocioItem
    Private _idMultaSocioItem As Integer
    Private _socio As Socio
    Private _monto As Double
    Private _idMultaSocio As Integer

    Public Property IdMultaSocioItem() As Integer
        Get
            Return Me._idMultaSocioItem
        End Get
        Set(ByVal value As Integer)
            Me._idMultaSocioItem = value
        End Set
    End Property
    Public Property Socio() As Socio
        Get
            Return Me._socio
        End Get
        Set(ByVal value As Socio)
            Me._socio = value
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
    Public Property IdMultaSocio() As Integer
        Get
            Return _idMultaSocio
        End Get
        Set(ByVal value As Integer)
            _idMultaSocio = value
        End Set
    End Property


End Class
