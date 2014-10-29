<Serializable()> _
Public Class PagoCuotaSocio
    Private _año As Integer
    Private _idPagoCuotaSocio As Integer
    Private _socio As Socio
    Private _conceptoCuota As ConceptoCuota
    Private _importe As Double
    Public Property Año() As Integer
        Get
            Return Me._año
        End Get
        Set(ByVal value As Integer)
            Me._año = value
        End Set
    End Property
    Public Property IdPagoCuotaSocio() As Integer
        Get
            Return Me._idPagoCuotaSocio
        End Get
        Set(ByVal value As Integer)
            Me._idPagoCuotaSocio = value
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
    Public Property Importe() As Double
        Get
            Return Me._importe
        End Get
        Set(ByVal value As Double)
            Me._importe = value
        End Set
    End Property
    Public Property ConceptoCuota() As ConceptoCuota
        Get
            Return _conceptoCuota
        End Get
        Set(ByVal value As ConceptoCuota)
            _conceptoCuota = value
        End Set
    End Property


End Class
