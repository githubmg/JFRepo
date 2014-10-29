<Serializable()> _
Public Class ComprobanteCabe
    Private _tipoComprobante As TipoComprobante
    Private _puntoVenta As Integer
    Private _condicionPago As Integer
    Private _idComprobante As Integer
    Private _numeroComprobante As Integer
    Private _fechaEmision As Date
    Private _fechaVencimiento As Date
    Private _fechaServDesde As Date
    Private _fechaServHasta As Date
    Private _ObservacionesComprobante As String
    Private _socio As Socio
    Private _club As Club
    Private _federacion As Federacion


    Private _items As List(Of ComprobanteItem)

    Public Property PuntoVenta() As Integer
        Get
            Return Me._puntoVenta
        End Get
        Set(ByVal value As Integer)
            Me._puntoVenta = value
        End Set
    End Property
    Public Property CondicionPago() As Integer
        Get
            Return Me._condicionPago
        End Get
        Set(ByVal value As Integer)
            Me._condicionPago = value
        End Set
    End Property
    Public Property IdComprobante() As Integer
        Get
            Return Me._idComprobante
        End Get
        Set(ByVal value As Integer)
            Me._idComprobante = value
        End Set
    End Property
    Public Property NumeroComprobante() As Integer
        Get
            Return Me._numeroComprobante
        End Get
        Set(ByVal value As Integer)
            Me._numeroComprobante = value
        End Set
    End Property
    Public Property FechaEmision() As Date
        Get
            Return Me._fechaEmision
        End Get
        Set(ByVal value As Date)
            Me._fechaEmision = value
        End Set
    End Property
    Public Property FechaVencimiento() As Date
        Get
            Return Me._fechaVencimiento
        End Get
        Set(ByVal value As Date)
            Me._fechaVencimiento = value
        End Set
    End Property
    Public Property FechaServDesde() As Date
        Get
            Return Me._fechaServDesde
        End Get
        Set(ByVal value As Date)
            Me._fechaServDesde = value
        End Set
    End Property
    Public Property FechaServHasta() As Date
        Get
            Return Me._fechaServHasta
        End Get
        Set(ByVal value As Date)
            Me._fechaServHasta = value
        End Set
    End Property
    Public Property ObservacionesComprobante() As String
        Get
            Return Me._ObservacionesComprobante
        End Get
        Set(ByVal value As String)
            Me._ObservacionesComprobante = value
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

    Public Property Socio() As Socio
        Get
            Return _socio
        End Get
        Set(ByVal value As Socio)
            _socio = value
        End Set
    End Property
    Public Property Club() As Club
        Get
            Return _club
        End Get
        Set(ByVal value As Club)
            _club = value
        End Set
    End Property
    Public Property Federacion() As Federacion
        Get
            Return _federacion
        End Get
        Set(ByVal value As Federacion)
            _federacion = value
        End Set
    End Property

    Public Property Items() As List(Of ComprobanteItem)
        Get
            Return _items
        End Get
        Set(ByVal value As List(Of ComprobanteItem))
            _items = value
        End Set
    End Property

    Public Shared Sub GenerarPorMultaSocio(ByVal mc As MultaSocioCabe)
        For Each mi As MultaSocioItem In mc.Items
            Dim cc As New ComprobanteCabe

            cc.FechaEmision = mc.FechaRegistro
            cc.FechaVencimiento = mc.FechaRegistro
            cc.FechaServDesde = mc.FechaRegistro
            cc.FechaServHasta = mc.FechaRegistro
            cc.CondicionPago = 0
            cc.ObservacionesComprobante = "Multa socio: " + mi.Socio.Nombre
            cc.TipoComprobante = Sistema.ObtenerTipoComprobante(7) 'NOTA DE DEBITO B
            cc.PuntoVenta = Configuracion.ObtenerInstancia().PuntoVenta
            cc.Socio = mi.Socio

            Dim ci As New ComprobanteItem

            ci.Cantidad = 1
            ci.PrecioUnitario = mi.Monto
            ci.Iva = 0
            ci.Descuento = 0
            ci.MotivoDescuento = ""
            ci.Comentario = ""
            ci.Descripcion = "Multa por torneo " + mc.NombreTorneo
            ci.Origen_idMultaSocioItem = mi.IdMultaSocioItem

            cc.Items = New List(Of ComprobanteItem)
            cc.Items.Add(ci)

            Sistema.AgregarComprobanteCabe(cc)

        Next
    End Sub

    Public Shared Sub GenerarPorPagosSocio(ByVal s As Socio, ByVal pagos As List(Of PagoSocio), ByVal valores As List(Of MovimientoCajaItem))
        'GENERO UNA NOTA DE DÉBITO POR CADA CUOTA PAGADA
        'GENERO UN ÚNICO RECIBO CON UN ITEM POR CADA CONCEPTO

        'INICIALIZO EL RECIBO
        Dim reciboCabe As New ComprobanteCabe
        reciboCabe.Items = New List(Of ComprobanteItem)


        'GENERACION RECIBO DE SOCIO ----------------------------------------------------------------------------------------------------------------
        reciboCabe.FechaEmision = Today.Date
        reciboCabe.FechaVencimiento = Today.Date
        reciboCabe.FechaServDesde = Today.Date
        reciboCabe.FechaServHasta = Today.Date

        reciboCabe.CondicionPago = 0
        reciboCabe.ObservacionesComprobante = "Recibo de socio: " + s.Nombre
        reciboCabe.TipoComprobante = Sistema.ObtenerTipoComprobante(9) 'RECIBO B
        reciboCabe.PuntoVenta = Configuracion.ObtenerInstancia().PuntoVenta
        reciboCabe.Socio = s

        For Each ps As PagoSocio In pagos
            Dim reciboItem = New ComprobanteItem
            reciboItem.Cantidad = 1
            reciboItem.PrecioUnitario = ps.Monto
            reciboItem.Iva = 0
            reciboItem.Descuento = 0
            reciboItem.MotivoDescuento = ""
            reciboItem.Comentario = ""
            reciboItem.Descripcion = ps.Descripcion
            If Not ps.MultaSocioItem Is Nothing Then
                reciboItem.Origen_idMultaSocioItemPago = ps.MultaSocioItem.IdMultaSocioItem
                ComprobanteCabe.GenerarPorPagoMultaSocio(ps.MultaSocioItem.IdMultaSocioItem) ' GENERO LA NOTA DE CRÉDITO PARA EL CLUB Y EL ORGANIZADOR
            End If

            If Not ps.PagoCuotaSocio Is Nothing Then
                reciboItem.Origen_idPagoCuotaSocio = ps.PagoCuotaSocio.IdPagoCuotaSocio
                ComprobanteCabe.GenerarPorPagoCuota(ps.PagoCuotaSocio) 'GENERO LA NOTA DE DEBITO
            End If
            reciboCabe.Items.Add(reciboItem)
        Next
        reciboCabe.IdComprobante = Sistema.AgregarComprobanteCabe(reciboCabe)
        'FIN GENERACION RECIBO DE SOCIO ----------------------------------------------------------------------------------------------------------------


        'GENERO LOS MOVIMIENTOS DE CAJA CORRESPONDIENTES AL RECIBO
        Dim mc As New MovimientoCajaCabe
        mc.Fecha = Today()
        mc.IdComprobante = reciboCabe.IdComprobante
        mc.IdPago = -1
        mc.Items = valores
        mc.IdMovimientoCaja = Sistema.AgregarMovimientoCajaCabe(mc)


        'FIN GENERACION MOVIMIENTOS CAJA ----------------------------------------------------------------------------------------------------------------



    End Sub

    Private Shared Sub GenerarPorPagoMultaSocio(ByVal idMultaSocioItem As Integer)

        Dim mi As MultaSocioItem = Sistema.ObtenerMultaSocioItem(idMultaSocioItem)
        Dim mc As MultaSocioCabe = Sistema.ObtenerMultaSocioCabe(mi.IdMultaSocio)

        Dim porcentajeClub As Double = 0
        Dim porcentajeSocioOrganizador As Double = 0

        If mc.SocioOrganizador Is Nothing Then
            porcentajeClub = 0.75
            porcentajeSocioOrganizador = 0
        Else
            porcentajeClub = 0.75 * 0.25
            porcentajeSocioOrganizador = 0.75 * 0.75
        End If


        'GENERO NOTA CREDITO CLUB
        Dim cc As New ComprobanteCabe

        cc.FechaEmision = Today.Date
        cc.FechaVencimiento = Today.Date
        cc.FechaServDesde = Today.Date
        cc.FechaServHasta = Today.Date

        cc.CondicionPago = 0
        cc.ObservacionesComprobante = "Pago Multa a Socio: " + mi.Socio.Nombre + ". Comisión Club " + mc.Club.Descripcion
        cc.TipoComprobante = Sistema.ObtenerTipoComprobante(8) 'NOTA CREDITO B
        cc.PuntoVenta = Configuracion.ObtenerInstancia().PuntoVenta
        cc.Club = mc.Club

        Dim ci As New ComprobanteItem

        ci.Cantidad = 1
        ci.PrecioUnitario = mi.Monto * porcentajeClub
        ci.Iva = 0
        ci.Descuento = 0
        ci.MotivoDescuento = ""
        ci.Comentario = ""
        ci.Descripcion = "Pago de Multa por torneo " + mc.NombreTorneo
        ci.Origen_idMultaSocioItemPago = mi.IdMultaSocioItem

        cc.Items = New List(Of ComprobanteItem)
        cc.Items.Add(ci)

        Sistema.AgregarComprobanteCabe(cc)

        'GENERO NOTA CREDITO SOCIO ORGANIZADOR
        If Not mc.SocioOrganizador Is Nothing Then
            cc = New ComprobanteCabe

            cc.FechaEmision = Today.Date
            cc.FechaVencimiento = Today.Date
            cc.FechaServDesde = Today.Date
            cc.FechaServHasta = Today.Date

            cc.CondicionPago = 0
            cc.ObservacionesComprobante = "Pago Multa a Socio: " + mi.Socio.Nombre + ". Comisión Organizador " + mc.SocioOrganizador.Nombre
            cc.TipoComprobante = Sistema.ObtenerTipoComprobante(8) 'NOTA CREDITO B
            cc.PuntoVenta = Configuracion.ObtenerInstancia().PuntoVenta

            cc.Socio = mc.SocioOrganizador

            ci = New ComprobanteItem

            ci.Cantidad = 1
            ci.PrecioUnitario = mi.Monto * porcentajeSocioOrganizador
            ci.Iva = 0
            ci.Descuento = 0
            ci.MotivoDescuento = ""
            ci.Comentario = ""
            ci.Descripcion = "Pago de Multa por torneo " + mc.NombreTorneo
            ci.Origen_idMultaSocioItemPago = mi.IdMultaSocioItem

            cc.Items = New List(Of ComprobanteItem)
            cc.Items.Add(ci)

            Sistema.AgregarComprobanteCabe(cc)

        End If



    End Sub

    Private Shared Sub GenerarPorPagoCuota(ByVal p As PagoCuotaSocio)

        'GENERO NOTA DE DEBITO DE SOCIO
        Dim cc As New ComprobanteCabe

        cc.FechaEmision = Today.Date
        cc.FechaVencimiento = Today.Date
        cc.FechaServDesde = Today.Date
        cc.FechaServHasta = Today.Date

        cc.CondicionPago = 0
        cc.ObservacionesComprobante = p.ConceptoCuota.IdConcepto + " AÑO: " + p.Año.ToString() + " - Pago Cuota Socio: " + p.Socio.Nombre
        cc.TipoComprobante = Sistema.ObtenerTipoComprobante(7) 'NOTA DEBITO B
        cc.PuntoVenta = Configuracion.ObtenerInstancia().PuntoVenta
        cc.Socio = p.Socio

        Dim ci As New ComprobanteItem

        ci.Cantidad = 1
        ci.PrecioUnitario = p.Importe
        ci.Iva = 0
        ci.Descuento = 0
        ci.MotivoDescuento = ""
        ci.Comentario = ""
        ci.Descripcion = "Pago cuota concepto " + p.ConceptoCuota.Descripcion
        ci.Origen_idPagoCuotaSocio = p.IdPagoCuotaSocio

        cc.Items = New List(Of ComprobanteItem)
        cc.Items.Add(ci)

        Sistema.AgregarComprobanteCabe(cc)
    End Sub


End Class
