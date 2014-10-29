<Serializable()> _
Public Class PedidoCabe
    Private _idPedidoCabe As Integer
    Private _cliente As Cliente
    Private _fechaPedido As Date
    Private _orden As String
    Private _estadoPedido As EstadoPedido
    Private _observaciones As String
    Private _items As List(Of PedidoItem)
    Private _tipoOrden As TipoOrden
    Private _chasis As String
    Private _ubicacionStock As UbicacionStock
    Public Property UbicacionStock() As UbicacionStock
        Get
            Return _ubicacionStock
        End Get
        Set(ByVal value As UbicacionStock)
            _ubicacionStock = value
        End Set
    End Property
    Public Property Chasis() As String
        Get
            Return Me._chasis
        End Get
        Set(ByVal value As String)
            Me._chasis = value
        End Set
    End Property
    Public Property TipoOrden() As TipoOrden
        Get
            Return _tipoOrden
        End Get
        Set(ByVal value As TipoOrden)
            _tipoOrden = value
        End Set
    End Property

    Public Property IdPedidoCabe() As Integer
        Get
            Return Me._idPedidoCabe
        End Get
        Set(ByVal value As Integer)
            Me._idPedidoCabe = value
        End Set
    End Property

    Public Property Cliente() As Cliente
        Get
            Return Me._cliente
        End Get
        Set(ByVal value As Cliente)
            Me._cliente = value
        End Set
    End Property
    Public Property FechaPedido() As Date
        Get
            Return Me._fechaPedido
        End Get
        Set(ByVal value As Date)
            Me._fechaPedido = value
        End Set
    End Property
    Public Property Orden() As String
        Get
            Return Me._orden
        End Get
        Set(ByVal value As String)
            Me._orden = value
        End Set
    End Property
    Public Property EstadoPedido() As EstadoPedido
        Get
            Return Me._estadoPedido
        End Get
        Set(ByVal value As EstadoPedido)
            Me._estadoPedido = value
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
    Public Property Items() As List(Of PedidoItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of PedidoItem))
            _items = value
        End Set
    End Property
    Public ReadOnly Property Total() As Double
        Get
            Dim tot As Double = 0
            For Each it In _items
                tot += (it.Cantidad * it.PrecioUnitario)
            Next
            Return tot
        End Get
    End Property
End Class
