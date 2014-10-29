<Serializable()> _
Public Class CompraCabePagoItem
    Private _compraCabe As CompraCabe
    Public Property CompraCabe() As CompraCabe
        Get
            Return _compraCabe
        End Get
        Set(ByVal value As CompraCabe)
            _compraCabe = value
        End Set
    End Property
    Private _montoCancelado As Double
    Public Property MontoCancelado() As Double
        Get
            Return _montoCancelado
        End Get
        Set(ByVal value As Double)
            _montoCancelado = value
        End Set
    End Property



End Class

