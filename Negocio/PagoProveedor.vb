<Serializable()> _
Public Class PagoProveedor

    Private _idPago As Integer
    Private _proveedor As Proveedor
    Private _fechaPago As Date
    Private _comprobantes As List(Of ComprobanteProveedor)
    Private _retenciones As List(Of RetencionPago)
    Private _valores As List(Of MovimientoCajaItem)
    Private _adelantos As List(Of ComprobanteProveedor)

    Public Property IdPago() As Integer
        Get
            Return _idPago
        End Get
        Set(ByVal value As Integer)
            _idPago = value
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
    Public Property FechaPago() As Date
        Get
            Return _fechaPago
        End Get
        Set(ByVal value As Date)
            _fechaPago = value
        End Set
    End Property
    Public Property Comprobantes() As List(Of ComprobanteProveedor)
        Get
            Return _comprobantes
        End Get
        Set(ByVal value As List(Of ComprobanteProveedor))
            _comprobantes = value
        End Set
    End Property
    Public Property Retenciones() As List(Of RetencionPago)
        Get
            Return _retenciones
        End Get
        Set(ByVal value As List(Of RetencionPago))
            _retenciones = value
        End Set
    End Property
    Public Property Valores() As List(Of MovimientoCajaItem)
        Get
            Return _valores
        End Get
        Set(ByVal value As List(Of MovimientoCajaItem))
            _valores = value
        End Set
    End Property

    Public Property Adelantos() As List(Of ComprobanteProveedor)
        Get
            Return _adelantos
        End Get
        Set(ByVal value As List(Of ComprobanteProveedor))
            _adelantos = value
        End Set
    End Property
    Public ReadOnly Property TotalComprobantes() As Double
        Get
            Dim total As Double = 0
            For Each c As ComprobanteProveedor In Me.Comprobantes
                total += c.Total
            Next
            Return Math.Round(total, 2)
        End Get
    End Property

    Public ReadOnly Property TotalAdelantos() As Double
        Get
            Dim total As Double = 0
            For Each c As ComprobanteProveedor In Me.Adelantos
                total += c.Total
            Next
            Return Math.Round(total, 2)
        End Get
    End Property

    Public ReadOnly Property TotalRetenciones() As Double
        Get
            Dim total As Double = 0
            For Each r As RetencionPago In Me.Retenciones
                total += r.Importe
            Next
            Return Math.Round(total, 2)
        End Get
    End Property

    Public ReadOnly Property TotalValores() As Double
        Get
            Dim total As Double = 0
            For Each v As MovimientoCajaItem In Me.Valores
                total += v.ImportePesos
            Next
            Return Math.Round(total, 2)
        End Get
    End Property
    Public ReadOnly Property TotalFaltante() As Double
        Get
            Return Math.Round((Me.TotalComprobantes - Me.TotalRetenciones - Me.TotalValores - Me.TotalAdelantos), 2)
        End Get
    End Property
End Class
