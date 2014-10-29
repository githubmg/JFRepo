<Serializable()> _
Public Class RetencionPago
    Private _idRetencionPago As Integer
    Private _retencion As Retencion
    Private _conceptoRetencion As ConceptoRetencion
    Private _importe As Double
    Public Property IdRetencionPago() As Integer
        Get
            Return _idRetencionPago
        End Get
        Set(ByVal value As Integer)
            _idRetencionPago = value
        End Set
    End Property
    Public Property Retencion() As Retencion
        Get
            Return _retencion
        End Get
        Set(ByVal value As Retencion)
            _retencion = value
        End Set
    End Property
    Public Property ConceptoRetencion() As ConceptoRetencion
        Get
            Return _conceptoRetencion
        End Get
        Set(ByVal value As ConceptoRetencion)
            _conceptoRetencion = value
        End Set
    End Property
    Public Property Importe() As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
        End Set
    End Property

End Class
