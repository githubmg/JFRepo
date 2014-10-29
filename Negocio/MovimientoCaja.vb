Public Class MovimientoCaja
    Private _idMovimientoCaja As Integer
    Private _tipoMovimiento As TipoMovimiento
    Private _fecha As Date
    Private _medioPago As MedioPago
    Private _monto As Double
    Private _cheque As Cheque
    Private _descripcionMovCaja As DescripcionMovCaja

    Public Property IdMovimientoCaja() As Integer
        Get
            Return Me._idMovimientoCaja
        End Get
        Set(ByVal value As Integer)
            Me._idMovimientoCaja = value
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
    Public Property Monto() As Double
        Get
            Return Me._monto
        End Get
        Set(ByVal value As Double)
            Me._monto = value
        End Set
    End Property
    Public Property DescripcionMovCaja() As DescripcionMovCaja
        Get
            Return Me._descripcionMovCaja
        End Get
        Set(ByVal value As DescripcionMovCaja)
            Me._descripcionMovCaja = value
        End Set
    End Property
    Public Property Cheque() As Cheque
        Get
            Return Me._Cheque
        End Get
        Set(ByVal value As Cheque)
            Me._Cheque = value
        End Set
    End Property
End Class
