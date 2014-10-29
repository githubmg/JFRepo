Imports Negocio
Partial Public Class frmPagoProveedor
    Inherits System.Web.UI.Page

    Private _comprobantes As List(Of ComprobanteProveedor)
    Private _adelantos As List(Of ComprobanteProveedor)
    Private _proveedor As Proveedor
    Private _pago As PagoProveedor

    Public Property Comprobantes() As List(Of ComprobanteProveedor)
        Get
            Return _comprobantes
        End Get
        Set(ByVal value As List(Of ComprobanteProveedor))
            _comprobantes = value
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
    Public Property Proveedor() As Proveedor
        Get
            Return _proveedor
        End Get
        Set(ByVal value As Proveedor)
            _proveedor = value
        End Set
    End Property
    Public Property Pago() As PagoProveedor
        Get
            Return _pago
        End Get
        Set(ByVal value As PagoProveedor)
            _pago = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Proveedor = Sistema.ObtenerProveedor(id)
            Me.lblProveedor.Text = Me.Proveedor.IdProveedor.ToString() + " - " + Me.Proveedor.RazonSocial
        End If

        If Not Me.Page.IsPostBack Then

            Me.Pago = New PagoProveedor()
            Me.Pago.Comprobantes = New List(Of ComprobanteProveedor)
            Me.Pago.Adelantos = New List(Of ComprobanteProveedor)
            Me.Pago.Retenciones = New List(Of RetencionPago)
            Me.Pago.Valores = New List(Of MovimientoCajaItem)
            Me.ViewState("Pago") = Me.Pago

            Me.cmbFormaPago.DataSource = Sistema.VistaFormaPago()
            Me.cmbFormaPago.DataTextField = "descripcion"
            Me.cmbFormaPago.DataValueField = "idFormaPago"
            Me.cmbFormaPago.DataBind()

            Me.cmbBanco.DataSource = Sistema.VistaBanco()
            Me.cmbBanco.DataTextField = "descripcion"
            Me.cmbBanco.DataValueField = "idBanco"
            Me.cmbBanco.DataBind()

            Me.cmbRetencion.DataSource = Sistema.VistaRetencion()
            Me.cmbRetencion.DataTextField = "descripcion"
            Me.cmbRetencion.DataValueField = "idRetencion"
            Me.cmbRetencion.DataBind()

            Me.cmbRetencion_SelectedIndexChanged(Nothing, Nothing)

            Me.SeleccionarTab("tabs-1")

            If Not Me.Proveedor Is Nothing Then
                Me.Comprobantes = Sistema.ObtenerComprobantesPendientes(Me.Proveedor)
                Me.ViewState("Comprobantes") = Me.Comprobantes
                Me.grillaComprobantes.DataSource = Me.Comprobantes
                Me.grillaComprobantes.DataBind()

                Me.Adelantos = Sistema.ObtenerAdelantosNoUtilizados(Me.Proveedor)
                Me.ViewState("Adelantos") = Me.Comprobantes
                Me.GrillaAdelantos.DataSource = Me.Adelantos
                Me.GrillaAdelantos.DataBind()

            End If
        Else
            If Not Me.ViewState("Comprobantes") Is Nothing Then
                Me.Comprobantes = CType(Me.ViewState("Comprobantes"), List(Of ComprobanteProveedor))
                Me.grillaComprobantes.DataSource = Me.Comprobantes
                Me.grillaComprobantes.DataBind()
            End If

            If Not Me.ViewState("Adelantos") Is Nothing Then
                Me.Adelantos = CType(Me.ViewState("Adelantos"), List(Of ComprobanteProveedor))
                Me.GrillaAdelantos.DataSource = Me.Adelantos
                Me.GrillaAdelantos.DataBind()
            End If



            If Not Me.ViewState("Pago") Is Nothing Then

                Me.Pago = CType(Me.ViewState("Pago"), PagoProveedor)
                Me.grillaComprobantesSeleccionados.DataSource = Me.Pago.Comprobantes
                Me.grillaComprobantesSeleccionados.DataBind()

                Me.grillaValores.DataSource = Me.Pago.Valores
                Me.grillaValores.DataBind()

                Me.GrillaRetenciones.DataSource = Me.Pago.Retenciones
                Me.GrillaRetenciones.DataBind()

                Me.GrillaAdelantosSeleccionados.DataSource = Me.Pago.Adelantos
                Me.GrillaAdelantosSeleccionados.DataBind()

            End If
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim id As Integer
        Try
            id = Me.Proveedor.IdProveedor
        Catch ex As Exception
            id = -1
        End Try
        Response.Redirect("frmOrdenesDePago.aspx?id=" + id.ToString())
    End Sub

    Private Sub calcularValores()
        Me.lblTotalComprobantes.Text = Me.Pago.TotalComprobantes.ToString()
        Me.lblTotalRetenciones.Text = Me.Pago.TotalRetenciones.ToString()
        Me.lblTotalValores.Text = Me.Pago.TotalValores.ToString()
        Me.lblTotalAdelantos.Text = Me.Pago.TotalAdelantos.ToString()
        Me.lblFaltante.Text = Me.Pago.TotalFaltante.ToString()
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try
            If Me.ValidarForm Then
                Me.Pago.Proveedor = Me.Proveedor
                Me.Pago.FechaPago = Today.Date
                Me.Pago.IdPago = Sistema.AgregarPagoProveedor(Me.Pago)

                Dim a As Asiento = New Asiento(Me.Pago)
                Sistema.AgregarAsiento(a)

                Response.Redirect("frmProveedor.aspx")
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Function ValidarForm() As Boolean
        Dim esValido As Boolean = True
        Dim strError As String = ""

        If Me.Proveedor Is Nothing Then
            strError += "Se debe acceder a esta pantalla por medio del menú Proveedor. <br />"
            esValido = False
        End If
        If Math.Abs(Me.Pago.TotalFaltante) > 0.1 Then
            strError += "La suma de los comprobantes debe ser igual a las retenciones más los valores. <br />"
            esValido = False
        End If
        If Me.Pago.TotalComprobantes = 0 Then
            strError += "Debe seleccionar por lo menos un comprobante para pagar. <br />"
            esValido = False
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = strError
        End If
        Return esValido
    End Function

    Private Function ValidarValor() As Boolean
        Dim msgError As String = ""
        Dim esValido As Boolean = True
        If Not IsNumeric(Me.txtImporteValor.Text) Then
            esValido = False
            msgError = "El importe del valor debe ser un número válido. <br />"
        End If

        If Not esValido Then
            Me.divErrorValores.Visible = True
            Me.lblErrorValores.Text = msgError
        Else
            Me.divErrorValores.Visible = False
            Me.lblErrorValores.Text = ""
        End If
        Return esValido
    End Function

    Private Function ValidarRetencion() As Boolean
        Dim msgError As String = ""
        Dim esValido As Boolean = True
        If Not IsNumeric(Me.txtImpoteRetencion.Text) Then
            esValido = False
            msgError = "El importe de retención debe ser un número válido. <br />"
        End If

        If Not esValido Then
            Me.divErrorRetenciones.Visible = True
            Me.lblErrorRetenciones.Text = msgError
        Else
            Me.divErrorRetenciones.Visible = False
            Me.lblErrorRetenciones.Text = ""
        End If
        Return esValido
    End Function

    Private Sub cmdAgregarComprobante(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grillaComprobantes.ItemCommand
        If e.CommandName = "Seleccionar" Then
            Try

                Dim c As ComprobanteProveedor = CType(Me.grillaComprobantes.DataSource(e.Item.ItemIndex), ComprobanteProveedor)
                Dim existe As Boolean = False
                For Each cp As ComprobanteProveedor In Me.Pago.Comprobantes
                    If cp.IdComprobante = c.IdComprobante Then existe = True
                Next

                If Not existe Then
                    Me.Pago.Comprobantes.Add(c)
                    Me.ViewState("Pago") = Pago

                    Me.grillaComprobantesSeleccionados.DataSource = Me.Pago.Comprobantes
                    Me.grillaComprobantesSeleccionados.DataBind()

                    Me.divErrorComprobantes.Visible = False
                    Me.lblErrorComprobantes.Text = ""
                Else
                    Me.divErrorComprobantes.Visible = True
                    Me.lblErrorComprobantes.Text = "El comprobante ya fue seleccionado"
                End If


                Me.calcularValores()
                Me.SeleccionarTab("tabs-1")
            Catch ex As Exception
                Me.divErrorComprobantes.Visible = True
                Me.lblErrorComprobantes.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub cmdAgregarAdelanto(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles GrillaAdelantos.ItemCommand
        If e.CommandName = "Seleccionar" Then
            Try

                Dim c As ComprobanteProveedor = CType(Me.GrillaAdelantos.DataSource(e.Item.ItemIndex), ComprobanteProveedor)
                Dim existe As Boolean = False
                For Each cp As ComprobanteProveedor In Me.Pago.Adelantos
                    If cp.IdComprobante = c.IdComprobante Then existe = True
                Next

                If Not existe Then
                    Me.Pago.Adelantos.Add(c)
                    Me.ViewState("Pago") = Pago

                    Me.GrillaAdelantosSeleccionados.DataSource = Me.Pago.Adelantos
                    Me.GrillaAdelantosSeleccionados.DataBind()

                    Me.divErrorAdelantos.Visible = False
                    Me.lblErrorAdelantos.Text = ""
                Else
                    Me.divErrorAdelantos.Visible = True
                    Me.lblErrorAdelantos.Text = "El adelanto ya fue seleccionado"
                End If

                Me.calcularValores()
                Me.SeleccionarTab("tabs-4")

            Catch ex As Exception
                Me.divErrorAdelantos.Visible = True
                Me.lblErrorAdelantos.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub cmdQuitarComprobante(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grillaComprobantesSeleccionados.ItemCommand
        If e.CommandName = "Quitar" Then

            Dim c As ComprobanteProveedor = CType(Me.grillaComprobantesSeleccionados.DataSource(e.Item.ItemIndex), ComprobanteProveedor)
            Me.Pago.Comprobantes.Remove(c)
            Me.ViewState("Pago") = Pago

            Me.grillaComprobantesSeleccionados.DataSource = Me.Pago.Comprobantes
            Me.grillaComprobantesSeleccionados.DataBind()

            Me.calcularValores()
            Me.SeleccionarTab("tabs-1")
        End If
    End Sub

    Private Sub cmdQuitarAdelanto(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles GrillaAdelantosSeleccionados.ItemCommand
        If e.CommandName = "Quitar" Then

            Dim c As ComprobanteProveedor = CType(Me.GrillaAdelantosSeleccionados.DataSource(e.Item.ItemIndex), ComprobanteProveedor)
            Me.Pago.Adelantos.Remove(c)
            Me.ViewState("Pago") = Pago

            Me.GrillaAdelantosSeleccionados.DataSource = Me.Pago.Adelantos
            Me.GrillaAdelantosSeleccionados.DataBind()

            Me.calcularValores()
            Me.SeleccionarTab("tabs-4")
        End If
    End Sub

    Private Sub cmdAgregarValor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregarValor.Click
        Try

            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""

            Dim m As New MovimientoCajaItem
            m.FormaPago = Sistema.ObtenerFormaPago(CType(Me.cmbFormaPago.SelectedValue, Integer))
            m.Importe = CType(Me.txtImporteValor.Text, Double)
            m.Moneda = m.FormaPago.Moneda
            m.CotizacionPesos = m.FormaPago.Moneda.cotizacionActual

            If m.FormaPago.EsCheque Or m.FormaPago.EsInterdeposito Then
                m.Banco = Sistema.ObtenerBanco(CType(Me.cmbBanco.SelectedValue, Integer))
            Else
                m.Banco = Nothing
            End If

            If m.FormaPago.EsCheque Then
                m.ChequeSucursal = Me.txtChequeSucursal.Text
                m.ChequeNumero = Me.txtChequeNumero.Text
                m.ChequeFechaCobro = CType(Me.txtChequeFechaCobro.Text, Date)
            Else
                m.ChequeSucursal = ""
                m.ChequeNumero = ""
                m.ChequeFechaCobro = #1/1/1900#

            End If

            If m.FormaPago.EsInterdeposito Then
                m.TipoInterdeposito = Sistema.ObtenerTipoInterdeposito(CType(Me.cmbTipoInterdeposito.SelectedValue, Integer))
                m.InterdepositoBoleta = Me.txtInterdepositoBoleta.Text
                m.InterdepositoFecha = CType(Me.txtInterdepositoFecha.Text, Date)
                m.InterdepositoTerminalBancaria = Me.txtInterdepositoTerminalBancaria.Text
            Else
                m.TipoInterdeposito = Nothing
                m.InterdepositoBoleta = ""
                m.InterdepositoFecha = #1/1/1900#
                m.InterdepositoTerminalBancaria = ""
            End If

            If m.FormaPago.EsTarjeta Then
                m.TarjetaNumero = Me.txtTarjetaNumero.Text
                m.TarjetaCupon = Me.txtTarjetaCupon.Text
                m.TarjetaAutorizacion = Me.txtTarjetaAutorizacion.Text
                m.TarjetaCuotas = CType(Me.txtTarjetaCuotas.Text, Integer)
            Else
                m.TarjetaNumero = ""
                m.TarjetaCupon = ""
                m.TarjetaAutorizacion = ""
                m.TarjetaCuotas = 0
            End If

            Me.Pago.Valores.Add(m)
            Me.ViewState("Valores") = Me.Pago.Valores

            Me.grillaValores.DataSource = Me.Pago.Valores
            Me.grillaValores.DataBind()

            Me.calcularValores()

        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdQuitarValor(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grillaValores.ItemCommand
        If e.CommandName = "Quitar" Then

            Dim v As MovimientoCajaItem = CType(Me.grillaValores.DataSource(e.Item.ItemIndex), MovimientoCajaItem)
            Me.Pago.Valores.Remove(v)
            Me.ViewState("Pago") = Pago

            Me.grillaValores.DataSource = Me.Pago.Valores
            Me.grillaValores.DataBind()

            Me.calcularValores()
            Me.SeleccionarTab("tabs-3")
        End If
    End Sub

    Private Sub cmdAgregarRetencion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregarRetencion.Click
        Try
            If Me.ValidarRetencion Then
                Dim r As New RetencionPago
                r.Retencion = Sistema.ObtenerRetencion(CType(Me.cmbRetencion.SelectedValue, Integer))
                r.ConceptoRetencion = Sistema.ObtenerConceptoRetencion(CType(Me.cmbConceptoRetencion.SelectedValue, Integer))
                r.Importe = CType(Me.txtImpoteRetencion.Text, Double)
                Me.Pago.Retenciones.Add(r)
                Me.ViewState("Pago") = Pago
                Me.GrillaRetenciones.DataSource = Me.Pago.Retenciones
                Me.GrillaRetenciones.DataBind()
                Me.calcularValores()
            End If

        Catch ex As Exception
            Me.divErrorRetenciones.Visible = True
            Me.lblErrorRetenciones.Text = ex.Message
        End Try
        Me.SeleccionarTab("tabs-2")
    End Sub

    Private Sub cmdQuitarRetencion(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles GrillaRetenciones.ItemCommand
        If e.CommandName = "Quitar" Then

            Dim r As RetencionPago = CType(Me.GrillaRetenciones.DataSource(e.Item.ItemIndex), RetencionPago)
            Me.Pago.Retenciones.Remove(r)
            Me.ViewState("Pago") = Pago

            Me.GrillaRetenciones.DataSource = Me.Pago.Retenciones
            Me.GrillaRetenciones.DataBind()

            Me.calcularValores()
            Me.SeleccionarTab("tabs-2")
        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        Dim f As FormaPago = Sistema.ObtenerFormaPago(CType(Me.cmbFormaPago.SelectedValue, Integer))


        Me.divBanco.Visible = False
        Me.divCheque.Visible = False
        Me.divInterdeposito.Visible = False
        Me.divTarjeta.Visible = False

        If f.EsCheque Then
            Me.divBanco.Visible = True
            Me.divCheque.Visible = True
        End If
        If f.EsInterdeposito Then
            Me.divBanco.Visible = True
            Me.divInterdeposito.Visible = True
        End If
        If f.EsTarjeta Then
            Me.divTarjeta.Visible = True
        End If


        Me.divBanco.Visible = f.EsCheque
        Me.SeleccionarTab("tabs-3")
    End Sub

    Private Sub cmbRetencion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRetencion.SelectedIndexChanged
        Try
            Me.SeleccionarTab("tabs-2")
            Me.cmbConceptoRetencion.DataSource = Sistema.VistaConceptoRetencion(CType(Me.cmbRetencion.SelectedValue, Integer))
            Me.cmbConceptoRetencion.DataTextField = "descripcion"
            Me.cmbConceptoRetencion.DataValueField = "idConcepto"
            Me.cmbConceptoRetencion.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SeleccionarTab(ByVal tab As String)
        Dim accion As String = ""
        accion += "<script type=""text/javascript"" language='javascript'>"
        accion += "jQuery(function($) {"
        accion += "$(""#tabs"").tabs(""select"", """ + tab + """);"
        accion += "});"
        accion += "</script>"
        Me.codigo.InnerHtml = accion

    End Sub

End Class