<Serializable()> _
Public Class PedidoCabeCobroItem

    Private _pedidoCabe As PedidoCabe
    Public Property PedidoCabe() As PedidoCabe
        Get
            Return _pedidoCabe
        End Get
        Set(ByVal value As PedidoCabe)
            _pedidoCabe = value
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
