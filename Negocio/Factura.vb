Public Class Factura
    Private _idFactura As Integer
    Private _fecha As Date
    Private _observaciones As String
    Public Property Observaciones() As String
        Get
            Return Me._observaciones
        End Get
        Set(ByVal value As String)
            Me._observaciones = value
        End Set
    End Property
    Public Property IdFactura() As Integer
        Get
            Return Me._idFactura
        End Get
        Set(ByVal value As Integer)
            Me._idFactura = value
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

    Private _remitos As List(Of Remito)
    Public Property Remitos() As List(Of Remito)
        Get
            Return _remitos
        End Get
        Set(ByVal value As List(Of Remito))
            _remitos = value
        End Set
    End Property

End Class
