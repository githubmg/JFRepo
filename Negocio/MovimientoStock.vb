Public Class MovimientoStock
    Private _idMovimientoStock As Integer
    Private _fecha As Date
    Private _tipoMovimiento As TipoMovimiento
    Private _producto As Producto
    Private _ubicacionStock As UbicacionStock
    Private _cantidad As Double
    Private _ubicacionStockOrigen As UbicacionStock
    Private _ubicacionStockDestino As UbicacionStock
    Public Property UbicacionStock() As UbicacionStock
        Get
            Return _ubicacionStock
        End Get
        Set(ByVal value As UbicacionStock)
            _ubicacionStock = value
        End Set
    End Property

    Public Property UbicacionStockOrigen() As UbicacionStock
        Get
            Return _ubicacionStockOrigen
        End Get
        Set(ByVal value As UbicacionStock)
            _ubicacionStockOrigen = value
        End Set
    End Property

    Public Property UbicacionStockDestino() As UbicacionStock
        Get
            Return _ubicacionStockDestino
        End Get
        Set(ByVal value As UbicacionStock)
            _ubicacionStockDestino = value
        End Set
    End Property
    Public Property IdMovimientoStock() As Integer
        Get
            Return Me._idMovimientoStock
        End Get
        Set(ByVal value As Integer)
            Me._idMovimientoStock = value
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
    Public Property TipoMovimiento() As TipoMovimiento
        Get
            Return Me._tipoMovimiento
        End Get
        Set(ByVal value As TipoMovimiento)
            Me._tipoMovimiento = value
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
    Public Property Cantidad() As Double
        Get
            Return Me._cantidad
        End Get
        Set(ByVal value As Double)
            Me._cantidad = value
        End Set
    End Property
End Class
