Public Class Pago
    Private _idPago As Integer
    Private _fecha As Date
    Private _medioPago As MedioPago
    Private _importe As Double
    Private _observaciones As String
    Private _compras As List(Of CompraCabePagoItem)
    Private _cheque As Cheque
    Public Property Cheque() As Cheque
        Get
            Return _cheque
        End Get
        Set(ByVal value As Cheque)
            _cheque = value
        End Set
    End Property

    Public Property IdPago() As Integer
        Get
            Return Me._idPago
        End Get
        Set(ByVal value As Integer)
            Me._idPago = value
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
    Public Property MedioPago() As MedioPago
        Get
            Return Me._medioPago
        End Get
        Set(ByVal value As MedioPago)
            Me._medioPago = value
        End Set
    End Property
    Public Property Importe() As Double
        Get
            Return Me._importe
        End Get
        Set(ByVal value As Double)
            Me._importe = value
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
    Public Property Compras() As List(Of CompraCabePagoItem)
        Get
            Return Me._compras
        End Get
        Set(ByVal value As List(Of CompraCabePagoItem))
            Me._compras = value
        End Set
    End Property
End Class
