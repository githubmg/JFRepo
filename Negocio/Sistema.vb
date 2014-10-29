Public Class Sistema
    'General
    Public Shared Function ObtenerId(texto As String) As Integer
        Try
            Dim partes As String() = texto.Split(New Char() {"-"c})
            Return CType(partes(0), Integer)
        Catch ex As Exception
            Return 0
        End Try
    End Function
    'Evento
    Public Shared Function ObtenerEvento(ByVal idEvento As Integer) As Evento
        Return DMEvento.ObtenerEvento(idEvento)
    End Function
    Public Shared Function AgregarEvento(ByVal e As Evento) As Integer
        Return DMEvento.AgregarEvento(e)
    End Function
    Public Shared Function ActualizarEvento(ByVal e As Evento) As Integer
        Return DMEvento.ActualizarEvento(e)
    End Function
    Public Shared Function VistaEvento() As DataTable
        Return DMEvento.VistaEvento()
    End Function
    Public Shared Function VistaEventoPorFecha(desde As String, hasta As String) As DataTable
        Return DMEvento.VistaEventoPorFechas(desde, hasta)
    End Function
    Public Shared Function VistaReporteEventoPorFecha(desde As String, hasta As String) As DataTable
        Return DMEvento.VistaReporteEventoPorFecha(desde, hasta)
    End Function

    'DEPOSITO
    Public Shared Function ObtenerDeposito(ByVal idDeposito As Integer) As Deposito
        Return DMDeposito.ObtenerDeposito(idDeposito)
    End Function
    Public Shared Function VistaDeposito() As DataTable
        Return DMDeposito.VistaDeposito()
    End Function
    Public Shared Function AgregarDeposito(ByVal d As Deposito) As Integer
        Return DMDeposito.AgregarDeposito(d)
    End Function
    'Pantalla
    Public Shared Function ObtenerPantalla(ByVal idPantalla As Integer) As Pantalla
        Return DMPantalla.ObtenerPantalla(idPantalla)
    End Function
    Public Shared Function VistaPantalla() As DataTable
        Return DMPantalla.VistaPantalla()
    End Function
    ' USUARIO
    Public Shared Sub BorrarUsuario(ByVal idUsuario As Integer)
        DMUsuario.BorrarUsuario(idUsuario)
    End Sub
    Public Shared Sub AgregarPermisosUsuario(ByVal u As Usuario, ByVal p As List(Of PantallaUsuarioItem))
        DMUsuario.AgregarPermisosUsuario(u, p)
    End Sub
    Public Shared Function VistaUsuario() As DataTable
        Return DMUsuario.VistaUsuario()
    End Function
    Public Shared Function VistaUsuarioAjax(ByVal des As String) As DataTable
        Return DMUsuario.VistaUsuarioAjax(des)
    End Function
    Public Shared Function PermisosVistaAjax(ByVal des As String) As DataTable
        Return DMUsuario.PermisosVistaAjax(des)
    End Function
    ' KIT
    Public Shared Function EliminarProductosKit(ByVal idKit As Integer) As Integer
        Return DMKitProducto.EliminarProductosKit(idKit)
    End Function
    Public Shared Function AgregarKitProducto(ByVal kp As ProductoKit, ByVal idKit As Integer) As Integer
        DMKitProducto.AgregarKitProducto(kp, idKit)
    End Function
    Public Shared Function ObtenerKit(ByVal idKit As Integer) As Kit
        Return DMKit.ObtenerKit(idKit)
    End Function
    Public Shared Function AgregarKit(ByVal k As Kit) As Integer
        Return DMKit.AgregarKit(k)
    End Function
    Public Shared Function ActualizarKit(ByVal k As Kit) As Integer
        Return DMKit.ActualizarKit(k)
    End Function
    Public Shared Function VistaKit() As DataTable
        Return DMKit.VistaKit()
    End Function
    Public Shared Function ObtenerKitPtoductos(ByVal idKit As Integer) As List(Of ProductoKit)
        Return DMKit.ObtenerKitPtoductos(idKit)
    End Function
    'VENDEDOR
    Public Shared Function ObtenerVendedor(ByVal idVendedor As Integer) As Vendedor
        Return DMVendedor.ObtenerVendedor(idVendedor)
    End Function
    Public Shared Function VistaVendedor() As DataTable
        Return DMVendedor.VistaVendedor()
    End Function
    ' TIPOORDEN
    Public Shared Function ObtenerTipoOrden(ByVal idTipoOrden As Integer) As TipoOrden
        Return DMTipoOrden.ObtenerTipoOrden(idTipoOrden)
    End Function
    Public Shared Function VistaTipoOrden() As DataTable
        Return DMTipoOrden.VistaTipoOrden()
    End Function
    'REPORTE
    Public Shared Function VistaValoresCedidos(ByVal desde As String, ByVal hasta As String, cobrado As String) As DataTable
        Return DMReporte.VistaValoresCedidos(desde, hasta, cobrado)
    End Function
    Public Shared Function VistaValoresCartera(ByVal desde As String, ByVal hasta As String) As DataTable
        Return DMReporte.VistaValoresCartera(desde, hasta)
    End Function
    Public Shared Function VistaVentasVendedor(ByVal desde As String, ByVal hasta As String, ByVal idVendedor As String) As DataTable
        Return DMReporte.VistaVentasVendedor(desde, hasta, idVendedor)
    End Function
    Public Shared Function VistaAcreedores(ByVal desde As String, ByVal hasta As String) As DataTable
        Return DMReporte.VistaAcreedores(desde, hasta)
    End Function
    Public Shared Function VistaDeudores(ByVal desde As String, ByVal hasta As String) As DataTable
        Return DMReporte.VistaDeudores(desde, hasta)
    End Function
    Public Shared Function ReportePlanDeCuentas(ByVal cuentaDesde As String, ByVal cuentaHasta As String) As DataTable
        Return DMReporte.ReportePlanDeCuentas(cuentaDesde, cuentaHasta)
    End Function
    Public Shared Function ReporteLibroDiario(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.ReporteLibroDiario(desde, hasta)
    End Function
    Public Shared Function ReporteSumasSaldos(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.ReporteSumasSaldos(desde, hasta)
    End Function

    Public Shared Function ReporteTotalesMulta(ByVal idMultaSocio As Integer) As DataTable
        Return DMReporte.ReporteTotalesMulta(idMultaSocio)
    End Function
    Public Shared Function ReporteDetalleMulta(ByVal idMultaSocio As Integer) As DataTable
        Return DMReporte.ReporteDetalleMulta(idMultaSocio)
    End Function
    Public Shared Function ReporteComprobantesEmitidos(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.ReporteComprobantesEmitidos(desde, hasta)
    End Function
    Public Shared Function VistaCtaCte(ByVal s As Socio, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.VistaCtaCte(s, desde, hasta)
    End Function
    Public Shared Function ReporteProductoStock(ByVal idProducto As Integer) As DataTable
        Return DMReporte.ReporteProductoStock(idProducto)
    End Function
    Public Shared Function ReporteCosto(ByVal idProducto As Integer) As DataTable
        Return DMReporte.ReporteCosto(idProducto)
    End Function
    Public Shared Function VistaCtaCte(ByVal c As Club, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.VistaCtaCte(c, desde, hasta)
    End Function
    Public Shared Function VistaCtaCte(ByVal f As Federacion, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.VistaCtaCte(f, desde, hasta)
    End Function
    Public Shared Function VistaCtaCteProveedor(ByVal p As Proveedor, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.VistaCtaCteProveedor(p, desde, hasta)
    End Function
    Public Shared Function VistaCtaCte(ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.VistaCtaCte(desde, hasta)
    End Function
    Public Shared Function VistaOrdenPagoProveedor(ByVal p As Proveedor, ByVal desde As Date, ByVal hasta As Date) As DataTable
        Return DMReporte.VistaOrdenPagoProveedor(p, desde, hasta)
    End Function
    Public Shared Function VistaComprobanteOrdenPago_comprobantes(ByVal idPago As Integer) As DataTable
        Return DMReporte.VistaComprobanteOrdenPago_comprobantes(idPago)
    End Function
    Public Shared Function VistaComprobanteOrdenPago_retenciones(ByVal idPago As Integer) As DataTable
        Return DMReporte.VistaComprobanteOrdenPago_retenciones(idPago)
    End Function
    Public Shared Function VistaComprobanteOrdenPago_valores(ByVal idPago As Integer) As DataTable
        Return DMReporte.VistaComprobanteOrdenPago_Valores(idPago)
    End Function
    Public Shared Function VistaComprobanteRetencion(ByVal idPago As Integer) As DataTable
        Return DMReporte.VistaComprobanteRetencion(idPago)
    End Function

    'MONEDA
    Public Shared Function ObtenerMoneda(ByVal idMoneda As Integer) As Moneda
        Return DMMoneda.ObtenerMoneda(idMoneda)
    End Function
    Public Shared Function AgregarMoneda(ByVal m As Moneda) As Integer
        Return DMMoneda.AgregarMoneda(m)
    End Function
    Public Shared Function ActualizarMoneda(ByVal m As Moneda) As Integer
        Return DMMoneda.ActualizarMoneda(m)
    End Function
    Public Shared Function VistaMoneda() As DataTable
        Return DMMoneda.VistaMoneda()
    End Function

    'TIPO INTERDEPOSITO
    Public Shared Function ObtenerTipoInterdeposito(ByVal idTipoInterdeposito As Integer) As TipoInterdeposito
        Return DMTipoInterdeposito.ObtenerTipoInterdeposito(idTipoInterdeposito)
    End Function
    Public Shared Function AgregarTipoInterdeposito(ByVal t As TipoInterdeposito) As Integer
        Return DMTipoInterdeposito.AgregarTipoInterdeposito(t)
    End Function
    Public Shared Function ActualizarTipoInterdeposito(ByVal t As TipoInterdeposito) As Integer
        Return DMTipoInterdeposito.ActualizarTipoInterdeposito(t)
    End Function
    Public Shared Function VistaTipoInterdeposito() As DataTable
        Return DMTipoInterdeposito.VistaTipoInterdeposito()
    End Function


    'COTIZACION
    Public Shared Function ObtenerCotizacion(ByVal idCotizacion As Integer) As Cotizacion
        Return DMCotizacion.ObtenerCotizacion(idCotizacion)
    End Function
    Public Shared Function AgregarCotizacion(ByVal c As Cotizacion) As Integer
        Return DMCotizacion.AgregarCotizacion(c)
    End Function
    Public Shared Function ActualizarCotizacion(ByVal c As Cotizacion) As Integer
        Return DMCotizacion.ActualizarCotizacion(c)
    End Function
    Public Shared Function VistaCotizacion(ByVal idMoneda As Integer) As DataTable
        Return DMCotizacion.VistaCotizacion(idMoneda)
    End Function
    Public Shared Function ObtenerCotizacionActual(ByVal idMoneda As Integer) As Double
        Return DMCotizacion.ObtenerCotizacionActual(idMoneda)
    End Function


    'USUARIO
    Public Shared Function ObtenerUsuario(ByVal idUsuario As Integer) As Usuario
        Return DMUsuario.ObtenerUsuario(idUsuario)
    End Function
    Public Shared Function ObtenerUsuario(ByVal nombreUsuario As String) As Usuario
        Return DMUsuario.ObtenerUsuario(nombreUsuario)
    End Function
    Public Shared Function AgregarUsuario(ByVal u As Usuario) As Integer
        Return DMUsuario.AgregarUsuario(u)
    End Function
    Public Shared Function ActualizarUsuario(ByVal u As Usuario) As Integer
        DMUsuario.ActualizarUsuario(u)
    End Function
    Public Shared Function GetPantallasUsuarioByTipo(ByVal u As Usuario, ByVal tipo As String) As DataTable
        Return DMUsuario.ObtenerPantallasByTipo(u, tipo)
    End Function
    Public Shared Function PantallasUsuarioVista(ByVal idUsuario As Integer) As List(Of PantallaUsuarioItem)
        Return DMUsuario.PantallasUsuarioVista(idUsuario)
    End Function
    'COMPROBANTE CABE
    Public Shared Function ObtenerProximoNumeroComprobante(ByVal idTipoComprobante As Integer, ByVal puntoVenta As Integer) As Integer
        Return DMComprobanteCabe.ObtenerProximoNumeroComprobante(idTipoComprobante, puntoVenta)
    End Function
    Public Shared Function ObtenerComprobanteCabe(ByVal idComprobante As Integer) As ComprobanteCabe
        Return DMComprobanteCabe.ObtenerComprobanteCabe(idComprobante)
    End Function
    Public Shared Function AgregarComprobanteCabe(ByVal c As ComprobanteCabe) As Integer
        Return DMComprobanteCabe.AgregarComprobanteCabe(c)
    End Function
    Public Shared Function ActualizarComprobanteCabe(ByVal c As ComprobanteCabe) As Integer
        Return DMComprobanteCabe.ActualizarComprobanteCabe(c)
    End Function


    'COMPROBANTE ITEM
    Public Shared Function ObtenerComprobanteItem(ByVal idComprobanteItem As Integer) As ComprobanteItem
        Return DMComprobanteItem.ObtenerComprobanteItem(idComprobanteItem)
    End Function
    Public Shared Function ObtenerComprobanteItemPorComprobante(ByVal idComprobante As Integer) As List(Of ComprobanteItem)
        Return DMComprobanteItem.ObtenerComprobanteItemPorComprobante(idComprobante)
    End Function
    Public Shared Function AgregarComprobanteItem(ByVal c As ComprobanteItem, ByVal idComprobante As Integer) As Integer
        Return DMComprobanteItem.AgregarComprobanteItem(c, idComprobante)
    End Function
    Public Shared Function ActualizarComprobanteItem(ByVal c As ComprobanteItem, ByVal idComprobante As Integer) As Integer
        Return DMComprobanteItem.ActualizarComprobanteItem(c, idComprobante)
    End Function
    Public Shared Sub BorrarComprobanteItem(ByVal idComprobante As Integer)
        DMComprobanteItem.BorrarComprobanteItem(idComprobante)
    End Sub


    'MULTA SOCIO PAGO
    Public Shared Function AgregarMultaSocioPago(ByVal idMultaSocioItem As Integer) As Integer
        DMMultaSocioPago.AgregarMultaSocioPago(idMultaSocioItem)
    End Function


    'MULTA SOCIO CABE
    Public Shared Function AgregarMultaSocioCabe(ByVal m As MultaSocioCabe) As Integer
        Return DMMultaSocioCabe.AgregarMultaSocioCabe(m)
    End Function
    Public Shared Function VistaMultaSocioCabePorClub(ByVal idClub As Integer) As DataTable
        Return DMMultaSocioCabe.VistaMultaSocioCabePorClub(idClub)
    End Function
    Public Shared Function ObtenerMultaSocioCabe(ByVal idMultaSocio As Integer) As MultaSocioCabe
        Return DMMultaSocioCabe.ObtenerMultaSocioCabe(idMultaSocio)
    End Function


    'MULTA SOCIO ITEM
    Public Shared Function ObtenerMultaSocioItem(ByVal idMultaSocioItem As Integer) As MultaSocioItem
        Return DMMultaSocioItem.ObtenerMultaSocioItem(idMultaSocioItem)
    End Function
    Public Shared Function AgregarMultaSocioItem(ByVal m As MultaSocioItem, ByVal idMultaSocio As Integer) As Integer
        Return DMMultaSocioItem.AgregarMultaSocioItem(m, idMultaSocio)
    End Function
    Public Shared Function VistaMultaSocioImpaga(ByVal idSocio As Integer) As DataTable
        Return DMMultaSocioItem.VistaMultaSocioImpaga(idSocio)
    End Function


    'CONCEPTO CUOTA
    Public Shared Function VistaConceptoCuota(ByVal idCategoriaSocio As Integer, ByVal esProfesional As Boolean) As DataTable
        Return DMConceptoCuota.VistaConceptoCuota(idCategoriaSocio, esProfesional)
    End Function
    Public Shared Function ObtenerConceptoCota(ByVal idConcepto As String) As ConceptoCuota
        Return DMConceptoCuota.ObtenerConceptoCota(idConcepto)
    End Function


    'PAGO CUOTA SOCIO
    Public Shared Function AgregarPagoCuotaSocio(ByVal p As PagoCuotaSocio) As Integer
        Return DMPagoCuotaSocio.AgregarPagoCuotaSocio(p)
    End Function


    'CLUB
    Public Shared Function VistaClub() As DataTable
        Return DMClub.VistaClub()
    End Function
    Public Shared Function VistaClub(ByVal descripcion As String) As DataTable
        Return DMClub.VistaClub(descripcion)
    End Function

    Public Shared Function ObtenerClub(ByVal idClub As Integer) As Club
        Return DMClub.ObtenerClub(idClub)
    End Function
    Public Shared Function AgregarClub(ByVal c As Club) As Integer
        Return DMClub.AgregarClub(c)
    End Function
    Public Shared Function ActualizarClub(ByVal c As Club) As Integer
        Return DMClub.ActualizarClub(c)
    End Function


    'Federacion
    Public Shared Function VistaFederacion() As DataTable
        Return DMFederacion.VistaFederacion()
    End Function
    Public Shared Function VistaFederacion(ByVal descripcion As String) As DataTable
        Return DMFederacion.VistaFederacion(descripcion)
    End Function

    Public Shared Function ObtenerFederacion(ByVal idFederacion As Integer) As Federacion
        Return DMFederacion.ObtenerFederacion(idFederacion)
    End Function
    Public Shared Function AgregarFederacion(ByVal c As Federacion) As Integer
        Return DMFederacion.AgregarFederacion(c)
    End Function
    Public Shared Function ActualizarFederacion(ByVal c As Federacion) As Integer
        Return DMFederacion.ActualizarFederacion(c)
    End Function

    'PAGO PROVEEDOR
    Public Shared Function AgregarPagoProveedor(ByVal p As PagoProveedor) As Integer
        Return DMPagoProveedor.AgregarPagoProveedor(p)
    End Function
    Public Shared Sub AgregarComprobantePagoProveedor(ByVal p As PagoProveedor, ByVal c As ComprobanteProveedor)
        DMPagoProveedor.AgregarComprobantePagoProveedor(p, c)
    End Sub
    Public Shared Sub AgregarAdelantoPagoProveedor(ByVal p As PagoProveedor, ByVal a As ComprobanteProveedor)
        DMPagoProveedor.AgregarAdelantoPagoProveedor(p, a)
    End Sub


    'RETENCION PAGO
    Public Shared Function AgregarRetencionPago(ByVal p As PagoProveedor, ByVal r As RetencionPago) As Integer
        Return DMRetencionPago.AgregarRetencionPago(p, r)
    End Function

    'RETENCION
    Public Shared Function VistaRetencion() As DataTable
        Return DMRetencion.VistaRetencion()
    End Function
    Public Shared Function ObtenerRetencion(ByVal idRetencion As Integer) As Retencion
        Return DMRetencion.ObtenerRetencion(idRetencion)
    End Function

    'CONCEPTO RETENCION
    Public Shared Function VistaConceptoRetencion(ByVal idRetencion As Integer) As DataTable
        Return DMConceptoRetencion.VistaConceptoRetencion(idRetencion)
    End Function
    Public Shared Function ObtenerConceptoRetencion(ByVal IdConcepto As Integer) As ConceptoRetencion
        Return DMConceptoRetencion.ObtenerConceptoRetencion(IdConcepto)
    End Function

    'FORMA DE PAGO
    Public Shared Function VistaFormaPago() As DataTable
        Return DMFormaPago.VistaFormaPago()
    End Function
    Public Shared Function VistaFormaPagoFondoFijo() As DataTable
        Return DMFormaPago.VistaFormaPagoFondoFijo()
    End Function
    Public Shared Function ObtenerFormaPago(ByVal idFormaPago As Integer) As FormaPago
        Return DMFormaPago.ObtenerFormaPago(idFormaPago)
    End Function
    Public Shared Function AgregarFormaPago(ByVal f As FormaPago) As Integer
        Return DMFormaPago.AgregarFormaPago(f)
    End Function
    Public Shared Function ActualizarFormaPago(ByVal f As FormaPago) As Integer
        Return DMFormaPago.ActualizarFormaPago(f)
    End Function

    'COMPROBANTE PROVEEDOR ITEM
    Public Shared Function AgregarComprobanteProveedorItem(ByVal ci As ComprobanteProveedorItem, ByVal c As ComprobanteProveedor) As Integer
        Return DMComprobanteProveedorItem.AgregarComprobanteProveedorItem(ci, c)
    End Function
    Public Shared Sub BorrarComprobanteProveedorItem(ByVal c As ComprobanteProveedor)
        DMComprobanteProveedorItem.BorrarComprobanteProveedorItem(c)
    End Sub
    Public Shared Function ObtenerComprobanteProveedorItem(ByVal idComprobanteItem As Integer) As ComprobanteProveedorItem
        Return DMComprobanteProveedorItem.ObtenerComprobanteProveedorItem(idComprobanteItem)
    End Function
    Public Shared Function ObtenerComprobanteProveedorItems(ByVal c As ComprobanteProveedor) As List(Of ComprobanteProveedorItem)
        Return DMComprobanteProveedorItem.ObtenerComprobanteProveedorItems(c)
    End Function

    'COMPROBANTE PROVEEDOR
    Public Shared Function ObtenerComprobantesPendientes(ByVal p As Proveedor) As List(Of ComprobanteProveedor)
        Return DMComprobanteProveedor.ObtenerComprobantesPendientes(p)
    End Function
    Public Shared Function ObtenerAdelantosNoUtilizados(ByVal p As Proveedor) As List(Of ComprobanteProveedor)
        Return DMComprobanteProveedor.ObtenerAdelantosNoUtilizados(p)
    End Function

    Public Shared Function ObtenerComprobanteProveedor(ByVal idComprobante As Integer) As ComprobanteProveedor
        Return DMComprobanteProveedor.ObtenerComprobanteProveedor(idComprobante)
    End Function
    Public Shared Function AgregarComprobanteProveedor(ByVal c As ComprobanteProveedor) As Integer
        Return DMComprobanteProveedor.AgregarComprobanteProveedor(c)
    End Function
    Public Shared Function ActualizarComprobanteProveedor(ByVal c As ComprobanteProveedor) As Integer
        Return DMComprobanteProveedor.ActualizarComprobanteProveedor(c)
    End Function

    'CONDICION VENTA
    Public Shared Function VistaCondicionVenta() As DataTable
        Return DMCondicionVenta.VistaCondicionVenta()
    End Function
    Public Shared Function ObtenerCondicionVenta(ByVal idCondicionVenta As Integer) As CondicionVenta
        Return DMCondicionVenta.ObtenerCondicionVenta(idCondicionVenta)
    End Function

    'SOCIO
    Public Shared Function VistaSocio() As DataTable
        Return DMSocio.VistaSocio()
    End Function
    Public Shared Function VistaSocio(ByVal nombreSocio As String) As DataTable
        Return DMSocio.VistaSocio(nombreSocio)
    End Function
    Public Shared Function ObtenerSocio(ByVal idSocio As Integer) As Socio
        Return DMSocio.ObtenerSocio(idSocio)
    End Function
    Public Shared Function ObtenerSocioPorNumeroDocumento(ByVal NumeroDocumento As Integer) As Socio
        Return DMSocio.ObtenerSocioPorNumeroDocumento(NumeroDocumento)
    End Function
    Public Shared Function AgregarSocio(ByVal s As Socio) As Integer
        Return DMSocio.AgregarSocio(s)
    End Function
    Public Shared Function ActualizarSocio(ByVal s As Socio) As Integer
        Return DMSocio.ActualizarSocio(s)
    End Function

    'SEXO
    Public Shared Function ObtenerSexo(ByVal idSexo As Integer) As Sexo
        Return DMSexo.ObtenerSexo(idSexo)
    End Function
    Public Shared Function VistaSexo() As DataTable
        Return DMSexo.VistaSexo()
    End Function


    'CATEGORIA SOCIO
    Public Shared Function VistaCategoriaSocio() As DataTable
        Return DMCategoriaSocio.VistaCategoriaSocio()
    End Function
    Public Shared Function ObtenerCategoriaSocio(ByVal idCategoriaSocio As Integer) As CategoriaSocio
        Return DMCategoriaSocio.ObtenerCategoriaSocio(idCategoriaSocio)
    End Function
    Public Shared Function ObtenerCategoriaSocioPorEdad(ByVal edad As Integer) As CategoriaSocio
        Return DMCategoriaSocio.ObtenerCategoriaSocioPorEdad(edad)
    End Function

    'ESTADO CIVIL
    Public Shared Function VistaEstadoCivil() As DataTable
        Return DMEstadoCivil.VistaEstadoCivil()
    End Function
    Public Shared Function ObtenerEstadoCivil(ByVal idEstadoCivil As Integer) As EstadoCivil
        Return DMEstadoCivil.ObtenerEstadoCivil(idEstadoCivil)
    End Function

    'ESTADO SOCIO
    Public Shared Function VistaEstadoSocio() As DataTable
        Return DMEstadoSocio.VistaEstadoSocio()
    End Function
    Public Shared Function ObtenerEstadoSocio(ByVal idEstadoSocio As Integer) As EstadoSocio
        Return DMEstadoSocio.ObtenerEstadoSocio(idEstadoSocio)
    End Function

    'PAIS
    Public Shared Function VistaPais() As DataTable
        Return DMPais.VistaPais()
    End Function
    Public Shared Function ObtenerPais(ByVal idPais As Integer) As Pais
        Return DMPais.ObtenerPais(idPais)
    End Function

    'TIPO DOCUMENTO
    Public Shared Function VistaTipoDocumento() As DataTable
        Return DMTipoDocumento.VistaTipoDocumento()
    End Function
    Public Shared Function ObtenerTipoDocumento(ByVal idTipoDocumento As Integer) As TipoDocumento
        Return DMTipoDocumento.ObtenerTipoDocumento(idTipoDocumento)
    End Function

    'PROVEEDOR
    Public Shared Function VistaProveedor() As DataTable
        Return DMProveedor.VistaProveedor()
    End Function
    Public Shared Function AgregarProveedor(ByVal p As Proveedor) As Long
        Return DMProveedor.AgregarProveedor(p)
    End Function
    Public Shared Function ActualizarProveedor(ByVal p As Proveedor) As Long
        Return DMProveedor.ActualizarProveedor(p)
    End Function
    Public Shared Function ObtenerProveedor(ByVal cuit As Long) As Proveedor
        Return DMProveedor.ObtenerProveedor(cuit)
    End Function

    'BANCO
    Public Shared Function ObtenerBanco(ByVal idBanco As Integer) As Banco
        Return DMBanco.ObtenerBanco(idBanco)
    End Function
    Public Shared Function VistaBanco() As DataTable
        Return DMBanco.VistaBanco()
    End Function
    Public Shared Function AgregarBanco(ByVal b As Banco) As Integer
        Return DMBanco.AgregarBanco(b)
    End Function
    Public Shared Function ActualizarBanco(ByVal b As Banco) As Integer
        Return DMBanco.ActualizarBanco(b)
    End Function
    Public Shared Function ObtenerUbicacionStock(ByVal idUbicacionStock As Integer) As UbicacionStock
        Return DMUbicacionStock.ObtenerUbicacionStock(idUbicacionStock)
    End Function
    Public Shared Function VistaUbicacionStock() As DataTable
        Return DMUbicacionStock.VistaUbicacionStock()
    End Function
    'GANANCIAS
    Public Shared Function ObtenerGanancias(ByVal idGanancias As Integer) As Ganancias
        Return DMGanancias.ObtenerGanancias(idGanancias)
    End Function
    Public Shared Function VistaGanancias() As DataTable
        Return DMGanancias.VistaGanancias()
    End Function

    'Resolucion General Seguridad Social
    Public Shared Function ObtenerResolucionGeneralSeguridadSocial(ByVal idResolucionGeneral As Integer) As ResolucionGeneralSeguridadSocial
        Return DMResolucionGeneralSeguridadSocial.ObtenerResolucionGeneralSeguridadSocial(idResolucionGeneral)
    End Function
    Public Shared Function VistaResolucionGeneralSeguridadSocial() As DataTable
        Return DMResolucionGeneralSeguridadSocial.VistaResolucionGeneralSeguridadSocial()
    End Function

    'PROVINCIA
    Public Shared Function ObtenerProvincia(ByVal idProvincia As Integer) As Provincia
        Return DMProvincia.ObtenerProvincia(idProvincia)
    End Function
    Public Shared Function VistaProvincia() As DataTable
        Return DMProvincia.VistaProvincia()
    End Function

    'CONDICION IVA
    Public Shared Function ObtenerCondicionIva(ByVal idCondicionIva As Integer) As CondicionIva
        Return DMCondicionIva.ObtenerCondicionIva(idCondicionIva)
    End Function
    Public Shared Function VistaCondicionIva() As DataTable
        Return DMCondicionIva.VistaCondicionIva()
    End Function

    'RUBRO PROVEEDOR
    Public Shared Function ObtenerRubroProveedor(ByVal idRubroProveedor As Integer) As RubroProveedor
        Return DMRubroProveedor.ObtenerRubroProveedor(idRubroProveedor)
    End Function
    Public Shared Function VistaRubroProveedor() As DataTable
        Return DMRubroProveedor.VistaRubroProveedor()
    End Function

    'CUENTA
    Public Shared Function VistaCuenta() As DataTable
        Return DMCuenta.VistaCuenta()
    End Function
    Public Shared Function VistaCuenta(ByVal param As String) As DataTable
        Return DMCuenta.VistaCuenta(param)
    End Function
    Public Shared Function ObtenerCuenta(ByVal codigo As String) As Cuenta
        Return DMCuenta.ObtenerCuenta(codigo)
    End Function
    Public Shared Function AgregarCuenta(ByVal c As Cuenta) As String
        Return DMCuenta.AgregarCuenta(c)
    End Function
    Public Shared Function ActualizarCuenta(ByVal c As Cuenta) As String
        Return DMCuenta.ActualizarCuenta(c)
    End Function

    'TIPO CUENTA
    Public Shared Function VistaTipoCuenta() As DataTable
        Return DMTipoCuenta.VistaTipoCuenta()
    End Function
    Public Shared Function ObtenerTipoCuenta(ByVal idTipoCuenta As Integer) As TipoCuenta
        Return DMTipoCuenta.ObtenerTipoCuenta(idTipoCuenta)
    End Function

    'TIPO COMPROBANTE
    Public Shared Function VistaTipoComprobante() As DataTable
        Return DMTipoComprobante.VistaTipoComprobante()
    End Function
    Public Shared Function ObtenerTipoComprobante(ByVal idTipoComprobante As Integer) As TipoComprobante
        Return DMTipoComprobante.ObtenerTipoComprobante(idTipoComprobante)
    End Function
    Public Shared Function ObtenerTipoComprobante(ByVal sigla As String) As TipoComprobante
        Return DMTipoComprobante.ObtenerTipoComprobante(sigla)
    End Function

    'CENTRO DE COSTOS
    Public Shared Function VistaCentroCostos() As DataTable
        Return DMCentroCostos.VistaCentroCostos()
    End Function
    Public Shared Function ObtenerCentroCostos(ByVal idCentroCostos As Integer) As CentroCostos
        Return DMCentroCostos.ObtenerCentroCostos(idCentroCostos)
    End Function

    'ASIENTO CABE
    Public Shared Function VistaAsiento() As DataTable
        Return DMAsiento.VistaAsiento()
    End Function
    Public Shared Function ObtenerAsiento(ByVal idAsiento As Integer) As Asiento
        Return DMAsiento.ObtenerAsiento(idAsiento)
    End Function
    Public Shared Function AgregarAsiento(ByVal a As Asiento) As Integer
        Return DMAsiento.AgregarAsiento(a)
    End Function
    Public Shared Function ActualizarAsiento(ByVal a As Asiento) As Integer
        Return DMAsiento.ActualizarAsiento(a)
    End Function

    'ASIENTO ITEM
    Public Shared Function ObtenerAsientoItem(ByVal idAsientoItem As Integer) As AsientoItem
        Return DMAsientoItem.ObtenerAsientoItem(idAsientoItem)
    End Function
    Public Shared Function ObtenerAsientoItems(ByVal idAsiento As Integer) As List(Of AsientoItem)
        Return DMAsientoItem.ObtenerAsientoItems(idAsiento)
    End Function
    Public Shared Function AgregarAsientoItem(ByVal ai As AsientoItem, ByVal idAsiento As Integer) As Integer
        Return DMAsientoItem.AgregarAsientoItem(ai, idAsiento)
    End Function
    Public Shared Sub BorrarAsientoItem(ByVal idAsiento As Integer)
        DMAsientoItem.BorrarAsientoItem(idAsiento)
    End Sub

    'AsientoTipo CABE
    Public Shared Function VistaAsientoTipo() As DataTable
        Return DMAsientoTipo.VistaAsientoTipo()
    End Function
    Public Shared Function ObtenerAsientoTipo(ByVal idAsientoTipo As Integer) As Asiento
        Return DMAsientoTipo.ObtenerAsientoTipo(idAsientoTipo)
    End Function
    Public Shared Function AgregarAsientoTipo(ByVal a As Asiento) As Integer
        Return DMAsientoTipo.AgregarAsientoTipo(a)
    End Function
    'Public Shared Function ActualizarAsientoTipo(ByVal a As Asiento) As Integer
    '    Return DMAsientoTipo.ActualizarAsientoTipo(a)
    'End Function

    'AsientoTipo ITEM
    Public Shared Function ObtenerAsientoTipoItem(ByVal idAsientoTipoItem As Integer) As AsientoItem
        Return DMAsientoTipoItem.ObtenerAsientoTipoItem(idAsientoTipoItem)
    End Function
    Public Shared Function ObtenerAsientoTipoItems(ByVal idAsientoTipo As Integer) As List(Of AsientoItem)
        Return DMAsientoTipoItem.ObtenerAsientoTipoItems(idAsientoTipo)
    End Function
    Public Shared Function AgregarAsientoTipoItem(ByVal ai As AsientoItem, ByVal idAsientoTipo As Integer) As Integer
        Return DMAsientoTipoItem.AgregarAsientoTipoItem(ai, idAsientoTipo)
    End Function
    Public Shared Sub BorrarAsientoTipoItem(ByVal idAsientoTipo As Integer)
        DMAsientoTipoItem.BorrarAsientoTipoItem(idAsientoTipo)
    End Sub

    'MOVIMIENTO CAJA CABE
    Public Shared Function ObtenerMovimientoCajaCabe(ByVal idMovimientoCaja As Integer) As MovimientoCajaCabe
        Return DMMovimientoCajaCabe.ObtenerMovimientoCajaCabe(idMovimientoCaja)
    End Function
    Public Shared Function AgregarMovimientoCajaCabe(ByVal m As MovimientoCajaCabe) As Integer
        Return DMMovimientoCajaCabe.AgregarMovimientoCajaCabe(m)
    End Function
    Public Shared Function VistaMovimientoCajaCabe() As DataTable
        Return DMMovimientoCajaCabe.VistaMovimientoCajaCabe()
    End Function

    'MOVIMIENTO CAJA ITEM
    Public Shared Function ObtenerMovimientoCajaItem(ByVal idMovimientoCajaItem As Integer) As MovimientoCajaItem
        Return DMMovimientoCajaItem.ObtenerMovimientoCajaItem(idMovimientoCajaItem)
    End Function
    Public Shared Function AgregarMovimientoCajaItem(ByVal m As MovimientoCajaItem) As Integer
        Return DMMovimientoCajaItem.AgregarMovimientoCajaItem(m)
    End Function
    Public Shared Function VistaMovimientoCajaItem() As DataTable
        Return DMMovimientoCajaItem.VistaMovimientoCajaItem()
    End Function

    'PARAMETROS
    Public Shared Function ObtenerParametro() As Parametro
        Return DMParametro.ObtenerParametro()
    End Function
    Public Shared Function AgregarParametro(ByVal p As Parametro) As Integer
        DMParametro.AgregarParametro(p)
    End Function

    Public Shared Function ActualizarParametro(ByVal p As Parametro) As Integer
        Return DMParametro.ActualizarParametro(p)
    End Function
    Public Shared Function VistaParametro() As DataTable
        Return DMParametro.VistaParametro()
    End Function

    'EJERCICIO
    Public Shared Function ObtenerEjercicio(ByVal idEjercicio As Integer) As Ejercicio
        Return DMEjercicio.ObtenerEjercicio(idEjercicio)
    End Function
    Public Shared Function AgregarEjercicio(ByVal e As Ejercicio) As Integer
        Return DMEjercicio.AgregarEjercicio(e)
    End Function
    Public Shared Function ActualizarEjercicio(ByVal e As Ejercicio) As Integer
        Return DMEjercicio.ActualizarEjercicio(e)
    End Function
    Public Shared Function VistaEjercicio() As DataTable
        Return DMEjercicio.VistaEjercicio()
    End Function

    ' FONDOFIJO
    Public Shared Function ObtenerFondoFijo(ByVal idFondoFijo As Integer) As FondoFijo
        Return DMFondoFijo.ObtenerFondoFijo(idFondoFijo)
    End Function
    Public Shared Function AgregarFondoFijo(ByVal f As FondoFijo) As Integer
        Return DMFondoFijo.AgregarFondoFijo(f)
    End Function
    Public Shared Function ActualizarFondoFijo(ByVal f As FondoFijo) As Integer
        Return DMFondoFijo.ActualizarFondoFijo(f)
    End Function
    Public Shared Function VistaFondoFijo() As DataTable
        Return DMFondoFijo.VistaFondoFijo()
    End Function

    ' FONDOFIJOITEM
    Public Shared Function ObtenerFondoFijoItem(ByVal idFondoFijoItem As Integer) As FondoFijoItem
        Return DMFondoFijoItem.ObtenerFondoFijoItem(idFondoFijoItem)
    End Function
    Public Shared Function AgregarFondoFijoItem(ByVal fc As FondoFijo, ByVal f As FondoFijoItem) As Integer
        Return DMFondoFijoItem.AgregarFondoFijoItem(fc, f)
    End Function
    Public Shared Function ActualizarFondoFijoItem(ByVal fc As FondoFijo, ByVal f As FondoFijoItem) As Integer
        Return DMFondoFijoItem.ActualizarFondoFijoItem(fc, f)
    End Function
    Public Shared Function VistaFondoFijoItem() As DataTable
        Return DMFondoFijoItem.VistaFondoFijoItem()
    End Function
    Public Shared Sub BorrarFondoFijoItem(ByVal ff As FondoFijo)
        DMFondoFijoItem.BorrarFondoFijoItem(ff)
    End Sub
    ' CLIENTE
    Public Shared Function Obtenercliente(ByVal idCliente As Integer) As Cliente
        Return DMCliente.Obtenercliente(idCliente)
    End Function
    Public Shared Function ObtenerclientePorCuit(ByVal cuit As Long) As Cliente
        Return DMCliente.ObtenerclientePorCuit(cuit)
    End Function
    Public Shared Function Agregarcliente(ByVal c As Cliente) As Integer
        Return DMCliente.Agregarcliente(c)
    End Function
    Public Shared Function Actualizarcliente(ByVal c As Cliente) As Integer
        Return DMCliente.Actualizarcliente(c)
    End Function
    Public Shared Function VistaCliente() As DataTable
        Return DMCliente.Vistacliente()
    End Function
    Public Shared Function VistaCliente(ByVal descripcion As String) As DataTable
        Return DMCliente.Vistacliente(descripcion)
    End Function
    ' LOCALIDAD
    Public Shared Function ObtenerLocalidad(ByVal idLocalidad As Integer) As Localidad
        Return DMLocalidad.ObtenerLocalidad(idLocalidad)
    End Function
    Public Shared Function AgregarLocalidad(ByVal l As Localidad) As Integer
        Return DMLocalidad.AgregarLocalidad(l)
    End Function
    Public Shared Function ActualizarLocalidad(ByVal l As Localidad) As Integer
        Return DMLocalidad.ActualizarLocalidad(l)
    End Function
    Public Shared Function VistaLocalidad() As DataTable
        Return DMLocalidad.VistaLocalidad()
    End Function
    Public Shared Function VistaLocalidad(ByVal idProvincnia As Integer) As DataTable
        Return DMLocalidad.VistaLocalidad(idProvincnia)
    End Function
    ' FAMILIA
    Public Shared Function ObtenerFamilia(ByVal idFamilia As Integer) As Familia
        Return DMFamilia.ObtenerFamilia(idFamilia)
    End Function
    Public Shared Function AgregarFamilia(ByVal f As Familia) As Integer
        Return DMFamilia.AgregarFamilia(f)
    End Function
    Public Shared Function ActualizarFamilia(ByVal f As Familia) As Integer
        Return DMFamilia.ActualizarFamilia(f)
    End Function
    Public Shared Function VistaFamilia() As DataTable
        Return DMFamilia.VistaFamilia()
    End Function
    ' ALICUOTAIVA
    Public Shared Function ObtenerAlicuotaIva(ByVal idAlicuotaIva As Integer) As AlicuotaIva
        Return DMAlicuotaIva.ObtenerAlicuotaIva(idAlicuotaIva)
    End Function
    Public Shared Function VistaAlicuotaIva() As DataTable
        Return DMAlicuotaIva.VistaAlicuotaIva()
    End Function
    ' PRODUCTO
    Public Shared Function ObtenerProducto(ByVal idProducto As Integer) As Producto
        Return DMProducto.ObtenerProducto(idProducto)
    End Function
    Public Shared Function AgregarProducto(ByVal p As Producto) As Integer
        Return DMProducto.AgregarProducto(p)
    End Function
    Public Shared Function ActualizarProducto(ByVal p As Producto) As Integer
        Return DMProducto.ActualizarProducto(p)
    End Function
    Public Shared Function VistaProducto() As DataTable
        Return DMProducto.VistaProducto()
    End Function
    Public Shared Function BorrarProducto(ByVal idProducto As Integer) As Integer
        Return DMProducto.BorrarProducto(idProducto)
    End Function
    Public Shared Function VistaProductoByFamlia(ByVal idFamilia As Integer) As DataTable
        Return DMProducto.VistaProductoByFamlia(idFamilia)
    End Function
    Public Shared Function VistaProductoStockByDecripcion(ByVal desc As String) As DataTable
        Return DMProducto.VistaProductoStockByDecripcion(desc)
    End Function
    ' PEDIDOCABE
    Public Shared Function ObtenerPedidoCabe(ByVal idPedidoCabe As Integer) As PedidoCabe
        Return DMPedidoCabe.ObtenerPedidoCabe(idPedidoCabe)
    End Function
    Public Shared Function AgregarPedidoCabe(ByVal p As PedidoCabe) As Integer
        Return DMPedidoCabe.AgregarPedidoCabe(p)
    End Function
    Public Shared Function ActualizarPedidoCabe(ByVal p As PedidoCabe) As Integer
        Return DMPedidoCabe.ActualizarPedidoCabe(p)
    End Function
    Public Shared Function VistaPedidoCabe() As DataTable
        Return DMPedidoCabe.VistaPedidoCabe()
    End Function
    Public Shared Function VistaPedidoSinSaldar(ByVal descripcion As String) As DataTable
        Return DMPedidoCabe.VistaPedidoSinSaldar(descripcion)
    End Function
    Public Shared Function MontoSSaldarDePedido(ByVal p As PedidoCabe) As Double
        Return DMPedidoCabe.MontoCompraSinSaldar(p)
    End Function
    Public Shared Function AgregarRemito(ByVal p As PedidoCabe) As Integer
        Return DMPedidoCabe.AgregarRemito(p)
    End Function
    ' ESTADOPEDIDO
    Public Shared Function ObtenerEstadoPedido(ByVal idEstadoPedido As Integer) As EstadoPedido
        Return DMEstadoPedido.ObtenerEstadoPedido(idEstadoPedido)
    End Function
    Public Shared Function AgregarEstadoPedido(ByVal e As EstadoPedido) As Integer
        Return DMEstadoPedido.AgregarEstadoPedido(e)
    End Function
    Public Shared Function ActualizarEstadoPedido(ByVal e As EstadoPedido) As Integer
        Return DMEstadoPedido.ActualizarEstadoPedido(e)
    End Function
    Public Shared Function VistaEstadoPedido() As DataTable
        Return DMEstadoPedido.VistaEstadoPedido()
    End Function
    ' PEDIDOITEM
    Public Shared Function ObtenerPedidoItem(ByVal idPedidoItem As Integer) As PedidoItem
        Return DMPedidoItem.ObtenerPedidoItem(idPedidoItem)
    End Function
    Public Shared Function AgregarPedidoItem(ByVal p As PedidoItem, ByVal idPedido As Integer) As Integer
        Return DMPedidoItem.AgregarPedidoItem(p, idPedido)
    End Function
    Public Shared Function ActualizarPedidoItem(ByVal p As PedidoItem) As Integer
        Return DMPedidoItem.ActualizarPedidoItem(p)
    End Function
    Public Shared Function VistaPedidoItem() As DataTable
        Return DMPedidoItem.VistaPedidoItem()
    End Function
    Public Shared Function ObtenerPedidoItems(ByVal idPedidoCabe As Integer) As List(Of PedidoItem)
        Return DMPedidoItem.ObtenerPedidoItems(idPedidoCabe)
    End Function
    Public Shared Function EliminarItems(ByVal idPedidoCabe As Integer) As Integer
        Return DMPedidoItem.EliminarPedidoItems(idPedidoCabe)
    End Function
    ' COMPRACABE
    Public Shared Function ObtenerCompraCabe(ByVal idCompraCabe As Integer) As CompraCabe
        Return DMCompraCabe.ObtenerCompraCabe(idCompraCabe)
    End Function
    Public Shared Function AgregarCompraCabe(ByVal c As CompraCabe) As Integer
        Return DMCompraCabe.AgregarCompraCabe(c)
    End Function
    Public Shared Function ActualizarCompraCabe(ByVal c As CompraCabe) As Integer
        Return DMCompraCabe.ActualizarCompraCabe(c)
    End Function
    Public Shared Function VistaCompraCabe() As DataTable
        Return DMCompraCabe.VistaCompraCabe()
    End Function
    Public Shared Function VistaProveedor(ByVal descripcion As String) As DataTable
        Return DMProveedor.VistaProveedor(descripcion)
    End Function
    Public Shared Function VistaCompraSinSaldar(ByVal descripcion As String) As DataTable
        Return DMCompraCabe.VistaCompraSinSaldar(descripcion)
    End Function
    Public Shared Function MontoSSaldarDeCompra(ByVal c As CompraCabe) As Double
        Return DMCompraCabe.MontoCompraSinSaldar(c)
    End Function
    ' COMPRAITEM
    Public Shared Function ObtenerCompraItem(ByVal idCompraItem As Integer) As CompraItem
        Return DMCompraItem.ObtenerCompraItem(idCompraItem)
    End Function
    Public Shared Function ObtenerCompraItems(ByVal idCompraCabe As Integer) As List(Of CompraItem)
        Return DMCompraItem.ObtenerCompraItems(idCompraCabe)
    End Function
    Public Shared Function EliminarItemsCompra(ByVal idCompraCabe As Integer) As Integer
        Return DMCompraItem.EliminarCompraItems(idCompraCabe)
    End Function
    Public Shared Function AgregarCompraItem(ByVal ci As CompraItem, ByVal idCompra As Integer) As Integer
        Return DMCompraItem.AgregarCompraItem(ci, idCompra)
    End Function
    ' MEDIOPAGO
    Public Shared Function ObtenerMedioPago(ByVal idMedioPago As Integer) As MedioPago
        Return DMMedioPago.ObtenerMedioPago(idMedioPago)
    End Function
    Public Shared Function VistaMedioPago() As DataTable
        Return DMMedioPago.VistaMedioPago()
    End Function
    'DESCRIPCION MOVIMIENTO DE CAJA
    Public Shared Function ObtenerDescripcionMovCaja(ByVal idDescripcionMovCaja As Integer) As DescripcionMovCaja
        Return DMDescripcionMovCaja.ObtenerDescripcionMovCaja(idDescripcionMovCaja)
    End Function
    Public Shared Function VistaDescripcionMovCaja() As DataTable
        Return DMDescripcionMovCaja.VistaDescripcionMovCaja()
    End Function
    Public Shared Function VistaMovCaja(ByVal desde As String, ByVal hasta As String) As DataTable
        Return DMReporte.VistaMovCaja(desde, hasta)
    End Function

    ' PAGO
    Public Shared Function ObtenerPago(ByVal idPago As Integer) As Pago
        Return DMPago.ObtenerPago(idPago)
    End Function
    Public Shared Function AgregarPago(ByVal p As Pago) As Integer
        Return DMPago.AgregarPago(p)
    End Function
    Public Shared Function ActualizarPago(ByVal p As Pago) As Integer
        Return DMPago.ActualizarPago(p)
    End Function
    Public Shared Function VistaPago() As DataTable
        Return DMPago.VistaPago()
    End Function
    Public Shared Function AgregarCompraPago(ByVal c As CompraCabePagoItem, ByVal p As Pago) As DataTable
        Return DMPago.AgregarCompraPago(c, p)
    End Function
    Public Shared Function AgregarPagoCheque(ByVal p As Pago) As Integer
        Return DMPago.AgregarPagoCheque(p)
    End Function
    ' ORIGENCHEQUE
    Public Shared Function ObtenerOrigenCheque(ByVal idOrigenCheque As Integer) As OrigenCheque
        Return DMOrigenCheque.ObtenerOrigenCheque(idOrigenCheque)
    End Function
    Public Shared Function VistaOrigenCheque() As DataTable
        Return DMOrigenCheque.VistaOrigenCheque()
    End Function
    'CHEQUE
    Public Shared Function VistaChequeCartera(ByVal descripcion As String) As DataTable
        Return DMCheque.VistaChequeCartera(descripcion)
    End Function
    Public Shared Function VistaChequeNoCobrado(ByVal descripcion As String) As DataTable
        Return DMCheque.VistaChequeNoCobrado(descripcion)
    End Function
    Public Shared Function ObtenerCheque(ByVal idCheque As Integer) As Cheque
        Return DMCheque.ObtenerCheque(idCheque)
    End Function
    Public Shared Function AgregarCheque(ByVal c As Cheque) As Integer
        Return DMCheque.AgregarCheque(c)
    End Function
    Public Shared Function ActualizarCheque(ByVal c As Cheque) As Integer
        Return DMCheque.ActualizarCheque(c)
    End Function
    ' COBRO
    Public Shared Function ObtenerCobro(ByVal idCobro As Integer) As Cobro
        Return DMCobro.ObtenerCobro(idCobro)
    End Function
    Public Shared Function AgregarCobro(ByVal c As Cobro) As Integer
        Return DMCobro.AgregarCobro(c)
    End Function
    Public Shared Function ActualizarCobro(ByVal c As Cobro) As Integer
        Return DMCobro.ActualizarCobro(c)
    End Function
    Public Shared Function VistaCobro() As DataTable
        Return DMCobro.VistaCobro()
    End Function
    Public Shared Function AgregarPedidoCobro(ByVal p As PedidoCabeCobroItem, ByVal c As Cobro) As DataTable
        Return DMCobro.AgregarPedidoCobro(p, c)
    End Function
    Public Shared Function AgregarCobroCheque(ByVal c As Cobro) As Integer
        Return DMCobro.AgregarCobroCheque(c)
    End Function
    ' MOVIMIENTOCAJA
    Public Shared Function ObtenerMovimientoCaja(ByVal idMovimientoCaja As Integer) As MovimientoCaja
        Return DMMovimientoCaja.ObtenerMovimientoCaja(idMovimientoCaja)
    End Function
    Public Shared Function AgregarMovimientoCaja(ByVal m As MovimientoCaja) As Integer
        Return DMMovimientoCaja.AgregarMovimientoCaja(m)
    End Function
    Public Shared Function ActualizarMovimientoCaja(ByVal m As MovimientoCaja) As Integer
        Return DMMovimientoCaja.ActualizarMovimientoCaja(m)
    End Function
    Public Shared Function VistaMovimientoCaja() As DataTable
        Return DMMovimientoCaja.VistaMovimientoCaja()
    End Function
    Public Shared Function AgregarMovimientoCajaCheque(ByVal m As MovimientoCaja) As Integer
        Return DMMovimientoCaja.AgregarMovimientoCajaCheque(m)
    End Function
    Public Shared Function BorrarMovimientoCajaCheque(ByVal m As MovimientoCaja) As Integer
        Return DMMovimientoCaja.BorrarMovimientoCajaCheque(m)
    End Function

    ' TIPOMOVIMIENTO
    Public Shared Function ObtenerTipoMovimiento(ByVal idTipoMovimiento As Integer) As TipoMovimiento
        Return DMTipoMovimiento.ObtenerTipoMovimiento(idTipoMovimiento)
    End Function
    Public Shared Function VistaTipoMovimiento() As DataTable
        Return DMTipoMovimiento.VistaTipoMovimiento()
    End Function
    'REMITO
    Public Shared Function VistaRemitoObj() As List(Of RemitoVistaClass)
        Return DMRemito.VistaRemitoObj
    End Function
    Public Shared Function VistaRemitoObj(ByVal idRemito As Integer) As RemitoVistaClass
        Return DMRemito.VistaRemitoObj(idRemito)
    End Function
    Public Shared Function VistaRemitoReporte(ByVal idRemito As Integer) As DataTable
        Return DMRemito.VistaRemitoReporte(idRemito)
    End Function
    Public Shared Function ObtenerRemitos(ByVal idFactura As Integer) As List(Of Remito)
        Return DMRemito.ObtenerRemitos(idFactura)
    End Function
    Public Shared Function ObtenerRemito(ByVal idRemito As Integer) As Remito
        Return DMRemito.ObtenerRemito(idRemito)
    End Function
    Public Shared Function VistaRemitoSinFacturar(ByVal prefix As String) As DataTable
        Return DMRemito.VistaRemitosSinFacturar(prefix)
    End Function
    'FACTURA
    Public Shared Function ObtenerFactura(ByVal idFactura As Integer) As Factura
        Return DMFactura.ObtenerFactura(idFactura)
    End Function
    Public Shared Function AgregarFactura(ByVal f As Factura) As Integer
        Return DMFactura.AgregarFactura(f)
    End Function
    Public Shared Function VistaFactura() As DataTable
        Return DMFactura.VistaFactura()
    End Function

    Public Shared Function AgregarFacturaRemito(ByVal r As Remito, ByVal idFactura As Integer) As Integer
        Return DMFactura.AgregarFacturaRemito(r, idFactura)
    End Function
    Public Shared Function VistaFacturaReporte(ByVal idFactura As Integer) As DataTable
        Return DMFactura.VistaFacturaReporte(idFactura)
    End Function
    Public Shared Function VistaFacturaCabe(ByVal idFactura As Integer) As DataTable
        Return DMFactura.VistaFacturaCabe(idFactura)
    End Function
    Public Shared Function VistaFacturaDetalle(ByVal idFactura As Integer) As DataTable
        Return DMFactura.VistaFacturaDetalle(idFactura)
    End Function
    ' MOVIMIENTOSTOCK
    Public Shared Function ObtenerMovimientoStock(ByVal idMovimientoStock As Integer) As MovimientoStock
        Return DMMovimientoStock.ObtenerMovimientoStock(idMovimientoStock)
    End Function
    Public Shared Function AgregarMovimientoStock(ByVal m As MovimientoStock) As Integer
        Return DMMovimientoStock.AgregarMovimientoStock(m)
    End Function
    Public Shared Function ActualizarMovimientoStock(ByVal m As MovimientoStock) As Integer
        Return DMMovimientoStock.ActualizarMovimientoStock(m)
    End Function
    Public Shared Function VistaMovimientoStock() As DataTable
        Return DMMovimientoStock.VistaMovimientoStock()
    End Function
End Class

' PROVEEDOR

