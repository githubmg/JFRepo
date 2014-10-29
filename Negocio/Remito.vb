Public Class Remito
    Private _idRemito As Integer
    Public Property IdRemito() As Integer
        Get
            Return _idRemito
        End Get
        Set(ByVal value As Integer)
            _idRemito = value
        End Set
    End Property
    Private _pedido As PedidoCabe
    Public Property Pedido() As PedidoCabe
        Get
            Return _pedido
        End Get
        Set(ByVal value As PedidoCabe)
            _pedido = value
        End Set
    End Property

End Class
