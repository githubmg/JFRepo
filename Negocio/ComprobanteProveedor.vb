<Serializable()> _
Public Class ComprobanteProveedor
    Private _idComprobante As Integer
    Private _proveedor As Proveedor
    Private _tipoComprobante As TipoComprobante
    Private _fecha As Date
    Private _numero As String
    Private _detalle As String
    Private _items As List(Of ComprobanteProveedorItem)

    Public Property IdComprobante() As Integer
        Get
            Return Me._idComprobante
        End Get
        Set(ByVal value As Integer)
            Me._idComprobante = value
        End Set
    End Property
    Public Property TipoComprobante() As TipoComprobante
        Get
            Return Me._tipoComprobante
        End Get
        Set(ByVal value As TipoComprobante)
            Me._tipoComprobante = value
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
    Public Property Numero() As String
        Get
            Return Me._numero
        End Get
        Set(ByVal value As String)
            Me._numero = value
        End Set
    End Property
    Public Property Detalle() As String
        Get
            Return Me._detalle
        End Get
        Set(ByVal value As String)
            Me._detalle = value
        End Set
    End Property
    Public Property Items() As List(Of ComprobanteProveedorItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of ComprobanteProveedorItem))
            _items = value
        End Set
    End Property
    Public Property Proveedor() As Proveedor
        Get
            Return _proveedor
        End Get
        Set(ByVal value As Proveedor)
            _proveedor = value
        End Set
    End Property

    Public ReadOnly Property Subtotal() As Double
        Get
            Dim s As Double = 0
            For Each i As ComprobanteProveedorItem In Me.Items
                s += i.Subtotal
            Next
            Return s
        End Get
    End Property
    Public ReadOnly Property MontoIva() As Double
        Get
            Dim s As Double = 0
            For Each i As ComprobanteProveedorItem In Me.Items
                s += i.MontoIva
            Next
            Return s
        End Get
    End Property
    Public ReadOnly Property Total() As Double
        Get
            Dim s As Double = 0
            For Each i As ComprobanteProveedorItem In Me.Items
                s += i.Total
            Next
            Return s
        End Get
    End Property

End Class
