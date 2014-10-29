<Serializable()> _
Public Class ComprobanteItem
    Private _idComprobanteItem As Integer
    Private _cantidad As Double
    Private _precioUnitario As Double
    Private _descuento As Double
    Private _iva As Double
    Private _descripcion As String
    Private _comentario As String
    Private _motivoDescuento As String

    Private _origen_idMultaSocioItem As Integer
    Private _origen_idMultaSocioItemPago As Integer
    Private _origen_idPagoCuotaSocio As Integer


    Public Property IdComprobanteItem() As Integer
        Get
            Return Me._idComprobanteItem
        End Get
        Set(ByVal value As Integer)
            Me._idComprobanteItem = value
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
    Public Property PrecioUnitario() As Double
        Get
            Return Me._precioUnitario
        End Get
        Set(ByVal value As Double)
            Me._precioUnitario = value
        End Set
    End Property
    Public Property Descuento() As Double
        Get
            Return Me._descuento
        End Get
        Set(ByVal value As Double)
            Me._descuento = value
        End Set
    End Property
    Public Property Iva() As Double
        Get
            Return Me._iva
        End Get
        Set(ByVal value As Double)
            Me._iva = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return Me._descripcion
        End Get
        Set(ByVal value As String)
            Me._descripcion = value
        End Set
    End Property
    Public Property Comentario() As String
        Get
            Return Me._comentario
        End Get
        Set(ByVal value As String)
            Me._comentario = value
        End Set
    End Property
    Public Property MotivoDescuento() As String
        Get
            Return Me._motivoDescuento
        End Get
        Set(ByVal value As String)
            Me._motivoDescuento = value
        End Set
    End Property

    Public ReadOnly Property Subtotal() As Double
        Get
            Return Me.Cantidad * Me.PrecioUnitario * (100 - Me.Descuento) / 100
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


    Public Property Origen_idMultaSocioItem() As Integer
        Get
            Return _origen_idMultaSocioItem
        End Get
        Set(ByVal value As Integer)
            _origen_idMultaSocioItem = value
        End Set
    End Property
    Public Property Origen_idMultaSocioItemPago() As Integer
        Get
            Return _origen_idMultaSocioItemPago
        End Get
        Set(ByVal value As Integer)
            _origen_idMultaSocioItemPago = value
        End Set
    End Property
    Public Property Origen_idPagoCuotaSocio() As Integer
        Get
            Return _origen_idPagoCuotaSocio
        End Get
        Set(ByVal value As Integer)
            _origen_idPagoCuotaSocio = value
        End Set
    End Property
End Class
