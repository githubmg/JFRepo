<Serializable()> _
Public Class PedidoItem
    Private _idPedidoItem As Integer
    Private _producto As Producto
    Private _cantidad As Integer
    Private _vendedor As Vendedor
    Private _precioUnitario As Double
    Private _observaciones As String
    Public Property IdPedidoItem() As Integer
        Get
            Return Me._idPedidoItem
        End Get
        Set(ByVal value As Integer)
            Me._idPedidoItem = value
        End Set
    End Property
    Public Property Vendedor() As Vendedor
        Get
            Return Me._vendedor
        End Get
        Set(ByVal value As Vendedor)
            Me._vendedor = value
        End Set
    End Property
    Public Property Producto() As Producto
        Get
            Return Me._producto
        End Get
        Set(ByVal value As Producto)
            Me._producto = value
        End Set
    End Property
    Public Property Cantidad() As Integer
        Get
            Return Me._cantidad
        End Get
        Set(ByVal value As Integer)
            Me._cantidad = value
        End Set
    End Property
   
    Public Property PrecioUnitario() As Double
        Get
            Return Me._precioUnitario
        End Get
        Set(ByVal value As Double)
            Me._precioUnitario = value
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
End Class
