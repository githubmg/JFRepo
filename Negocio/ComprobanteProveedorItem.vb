<Serializable()> _
Public Class ComprobanteProveedorItem
    Private _idComprobanteItem As Integer
    Private _descripcion As String
    Private _observaciones As String
    Private _precioUnitario As Double
    Private _cantidad As Double
    Private _iva As Double

    Public Property IdComprobanteItem() As Integer
        Get
            Return _idComprobanteItem
        End Get
        Set(ByVal value As Integer)
            _idComprobanteItem = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property
    Public Property PrecioUnitario() As Double
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As Double)
            _precioUnitario = value
        End Set
    End Property
    Public Property Cantidad() As Double
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Double)
            _cantidad = value
        End Set
    End Property
    Public Property Iva() As Double
        Get
            Return _iva
        End Get
        Set(ByVal value As Double)
            _iva = value
        End Set
    End Property
    Public ReadOnly Property Subtotal() As Double
        Get
            Return Me.Cantidad * Me.PrecioUnitario
        End Get
    End Property
    Public ReadOnly Property MontoIva() As Double
        Get
            Return Me.Subtotal * Me.Iva / 100
        End Get
    End Property
    Public ReadOnly Property Total() As Double
        Get
            Return Me.Subtotal + Me.MontoIva
        End Get
    End Property
End Class
