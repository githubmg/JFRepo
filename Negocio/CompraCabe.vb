<Serializable()> _
Public Class CompraCabe
    Private _idCompraCabe As Integer
    Private _proveedor As Proveedor
    Private _fechaCompra As Date
    Private _estadoPedido As EstadoPedido
    Private _observaciones As String
    Private _items As List(Of CompraItem)
    Private _tipoOrden As TipoOrden
    Private _ubicacionStock As UbicacionStock
    Private _percepcionIva As Double
    Private _percepcionGanancias As Double
    Private _percepcionIIBB As Double
    Public Property PercepcionIIBB() As Double
        Get
            Return _percepcionIIBB
        End Get
        Set(ByVal value As Double)
            _percepcionIIBB = value
        End Set
    End Property

    Public Property PercepcionGanancias() As Double
        Get
            Return _percepcionGanancias
        End Get
        Set(ByVal value As Double)
            _percepcionGanancias = value
        End Set
    End Property

    Public Property PercepcionIva() As Double
        Get
            Return _percepcionIva
        End Get
        Set(ByVal value As Double)
            _percepcionIva = value
        End Set
    End Property

    Public Property UbicacionStock() As UbicacionStock
        Get
            Return _ubicacionStock
        End Get
        Set(ByVal value As UbicacionStock)
            _ubicacionStock = value
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
    Public Property Items() As List(Of CompraItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of CompraItem))
            _items = value
        End Set
    End Property

    Public Property IdCompraCabe() As Integer
        Get
            Return Me._idCompraCabe
        End Get
        Set(ByVal value As Integer)
            Me._idCompraCabe = value
        End Set
    End Property
    Public Property Proveedor() As Proveedor
        Get
            Return Me._proveedor
        End Get
        Set(ByVal value As Proveedor)
            Me._proveedor = value
        End Set
    End Property
    Public Property FechaCompra() As Date
        Get
            Return Me._fechaCompra
        End Get
        Set(ByVal value As Date)
            Me._fechaCompra = value
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
    Public ReadOnly Property Total() As Double
        Get
            Dim tot As Double = 0
            For Each it In _items
                tot += (it.Cantidad * it.PrecioUnitario + it.Producto.AlicuotaIva.Valor / 100 * it.Cantidad * it.PrecioUnitario)
            Next
            Return tot
        End Get
    End Property

End Class

