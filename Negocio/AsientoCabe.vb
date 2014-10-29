Public Class Asiento
    Private _idAsiento As Integer
    Private _tipoComprobante As TipoComprobante
    Private _fecha As Date
    Private _numeroComprobante As String
    Private _concepto As String
    Private _observaciones As String
    Private _items As List(Of AsientoItem)


    Public Property IdAsiento() As Integer
        Get
            Return Me._idAsiento
        End Get
        Set(ByVal value As Integer)
            Me._idAsiento = value
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
    Public Property NumeroComprobante() As String
        Get
            Return Me._numeroComprobante
        End Get
        Set(ByVal value As String)
            Me._numeroComprobante = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return Me._concepto
        End Get
        Set(ByVal value As String)
            Me._concepto = value
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
    Public Property TipoComprobante() As TipoComprobante
        Get
            Return _tipoComprobante
        End Get
        Set(ByVal value As TipoComprobante)
            _tipoComprobante = value
        End Set
    End Property
    Public Property Items() As List(Of AsientoItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of AsientoItem))
            _items = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal cmp As ComprobanteProveedor)
        Me.TipoComprobante = cmp.TipoComprobante
        Me.Fecha = cmp.Fecha
        Me.NumeroComprobante = cmp.Numero
        Me.Concepto = Left(cmp.Detalle, 50)
        Me.Observaciones = cmp.Detalle

        Me.Items = New List(Of AsientoItem)
        Select Case Me.TipoComprobante.Sigla
            Case "ADEL"
                Dim aiDebe As New AsientoItem
                aiDebe.Cuenta = Sistema.ObtenerParametro().CuentaAdelantoProveedor
                aiDebe.Debe = cmp.Total
                aiDebe.Haber = 0
                Me.Items.Add(aiDebe)

                Dim aiHaber As New AsientoItem
                'aiHaber.Cuenta = cmp.Proveedor.CuentaPatrimonial
                aiHaber.Debe = 0
                aiHaber.Haber = cmp.Total
                Me.Items.Add(aiHaber)

            Case "RINT"
                Dim aiDebe As New AsientoItem
                aiDebe.Cuenta = Sistema.ObtenerParametro().CuentaReintegroProveedor
                aiDebe.Debe = cmp.Total
                aiDebe.Haber = 0
                Me.Items.Add(aiDebe)

                Dim aiHaber As New AsientoItem
                ''aiHaber.Cuenta = cmp.Proveedor.CuentaPatrimonial
                aiHaber.Debe = 0
                aiHaber.Haber = cmp.Total
                Me.Items.Add(aiHaber)

            Case Else
                Dim aiDebe As New AsientoItem
                'aiDebe.Cuenta = cmp.Proveedor.CuentaResultados
                aiDebe.Debe = cmp.Total
                aiDebe.Haber = 0
                Me.Items.Add(aiDebe)

                Dim aiHaber As New AsientoItem
                'aiHaber.Cuenta = cmp.Proveedor.CuentaPatrimonial
                aiHaber.Debe = 0
                aiHaber.Haber = cmp.Total
                Me.Items.Add(aiHaber)

        End Select

    End Sub
    Public Sub New(ByVal pago As PagoProveedor)

        Me.TipoComprobante = Sistema.ObtenerTipoComprobante("OP") 'ORDEN DE PAGO
        Me.Fecha = pago.FechaPago
        Me.NumeroComprobante = "0000-" + Right("00000000" + pago.IdPago.ToString(), 8)
        Me.Concepto = "Asiento automático por OP Nro " + pago.IdPago.ToString()

        Dim sb As New Text.StringBuilder()

        For Each c As ComprobanteProveedor In pago.Comprobantes
            sb.Append(c.TipoComprobante.Sigla + "-" + c.Numero + " ")
        Next
        Me.Observaciones = sb.ToString()

        Me.Items = New List(Of AsientoItem)

        Dim aiDebe As New AsientoItem
        'aiDebe.Cuenta = pago.Proveedor.CuentaPatrimonial
        aiDebe.Debe = pago.TotalComprobantes
        aiDebe.Haber = 0
        Me.Items.Add(aiDebe)

        For Each r As RetencionPago In pago.Retenciones
            Dim aiHaber As New AsientoItem
            aiHaber.Cuenta = r.Retencion.Cuenta
            aiHaber.Debe = 0
            aiHaber.Haber = r.Importe
            Me.Items.Add(aiHaber)
        Next

        For Each mci As MovimientoCajaItem In pago.Valores
            Dim aiHaber As New AsientoItem
            aiHaber.Cuenta = mci.FormaPago.Cuenta
            aiHaber.Debe = 0
            aiHaber.Haber = mci.Importe
            Me.Items.Add(aiHaber)
        Next

        For Each c As ComprobanteProveedor In pago.Adelantos
            Dim aiHaber As New AsientoItem
            aiHaber.Cuenta = Sistema.ObtenerParametro().CuentaAdelantoProveedor
            aiHaber.Debe = 0
            aiHaber.Haber = c.Total
            Me.Items.Add(aiHaber)
        Next


    End Sub

    Public Sub New(ByVal ff As FondoFijo)

        Me.TipoComprobante = Sistema.ObtenerTipoComprobante("FOFI") 'FONDO FIJO
        Me.Fecha = ff.Fecha
        Me.NumeroComprobante = "0000-" + Right("00000000" + ff.IdFondoFijo.ToString(), 8)
        Me.Concepto = "Asiento automático por Fondo Fijo Nro " + ff.IdFondoFijo.ToString()
        Me.Observaciones = ff.Observaciones

        Me.Items = New List(Of AsientoItem)


        For Each fi As FondoFijoItem In ff.Items
            Dim aiDebe As New AsientoItem
            aiDebe.Cuenta = fi.Cuenta
            aiDebe.Debe = fi.Monto * ff.FormaPago.Moneda.cotizacionActual()
            aiDebe.Haber = 0
            Me.Items.Add(aiDebe)
        Next

        Dim aiHaber As New AsientoItem
        aiHaber.Cuenta = ff.FormaPago.Cuenta
        aiHaber.Debe = 0
        aiHaber.Haber = ff.Total * ff.FormaPago.Moneda.cotizacionActual()
        Me.Items.Add(aiHaber)

    End Sub
End Class
