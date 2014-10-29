Imports Negocio
Partial Public Class frmPagoSocio
    Inherits System.Web.UI.Page

    Private _socio As Socio
    Private _PagosSocio As List(Of PagoSocio)
    Private _valores As List(Of MovimientoCajaItem)

    Public Property Socio() As Socio
        Get
            Return _socio
        End Get
        Set(ByVal value As Socio)
            _socio = value
        End Set
    End Property
    Public Property PagosSocio() As List(Of PagoSocio)
        Get
            Return _PagosSocio
        End Get
        Set(ByVal value As List(Of PagoSocio))
            _PagosSocio = value
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





    Private Sub SeleccionarTab(ByVal tab As String)
        Dim accion As String = ""
        accion += "<script type=""text/javascript"" language='javascript'>"
        accion += "jQuery(function($) {"
        accion += "$(""#tabs"").tabs(""select"", """ + tab + """);"
        accion += "});"
        accion += "</script>"
        Me.codigo.InnerHtml = accion

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Socio = Sistema.ObtenerSocio(id)
            Me.lblSocio.Text = Me.Socio.IdSocio.ToString() + " - " + Me.Socio.Nombre
        End If

        If Not Me.ViewState("PagosSocio") Is Nothing Then
            Me.PagosSocio = CType(Me.ViewState("PagosSocio"), List(Of PagoSocio))
        Else
            Me.PagosSocio = New List(Of PagoSocio)
            Me.ViewState("PagosSocio") = Me.PagosSocio
        End If
        Me.grilla.DataSource = Me.PagosSocio
        Me.grilla.DataBind()


        If Not Me.ViewState("Valores") Is Nothing Then
            Me.Valores = CType(Me.ViewState("Valores"), List(Of MovimientoCajaItem))
        Else
            Me.Valores = New List(Of MovimientoCajaItem)
            Me.ViewState("Valores") = Me.Valores
        End If

        Me.grillaValores.DataSource = Me.Valores
        Me.grillaValores.DataBind()


        If Not Me.Page.IsPostBack Then
            If Not Me.Socio Is Nothing Then
                Me.txtAño.Text = Today.Year.ToString()

                Me.cmbConceptoCuota.DataSource = Sistema.VistaConceptoCuota(Me.Socio.CategoriaSocio.IdcategoriaSocio, Me.Socio.EsProfesional)
                Me.cmbConceptoCuota.DataTextField = "Descripcion"
                Me.cmbConceptoCuota.DataValueField = "idConcepto"
                Me.cmbConceptoCuota.DataBind()

                Me.cmbMulta.DataSource = Sistema.VistaMultaSocioImpaga(Me.Socio.IdSocio)
                Me.cmbMulta.DataTextField = "Descripcion"
                Me.cmbMulta.DataValueField = "idMultaSocioItem"
                Me.cmbMulta.DataBind()

                Me.cmbFormaPago.DataSource = Sistema.VistaFormaPago()
                Me.cmbFormaPago.DataTextField = "Descripcion"
                Me.cmbFormaPago.DataValueField = "idFormaPago"
                Me.cmbFormaPago.DataBind()

                Me.cmbTipoInterdeposito.DataSource = Sistema.VistaTipoInterdeposito()
                Me.cmbTipoInterdeposito.DataTextField = "Descripcion"
                Me.cmbTipoInterdeposito.DataValueField = "idTipoInterdeposito"
                Me.cmbTipoInterdeposito.DataBind()

                Me.cmbBanco.DataSource = Sistema.VistaBanco()
                Me.cmbBanco.DataTextField = "Descripcion"
                Me.cmbBanco.DataValueField = "idBanco"
                Me.cmbBanco.DataBind()

                cmbCategoria_SelectedIndexChanged(Nothing, Nothing)
                cmbFormaPago_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If



    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbConceptoCuota.SelectedIndexChanged
        Me.txtMonto.Text = Sistema.ObtenerConceptoCota(Me.cmbConceptoCuota.SelectedValue.ToString()).Importe
    End Sub

    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim mensaje As String = ""

        If Not IsNumeric(Me.txtAño.Text) Then
            esValido = False
            mensaje += "El año debe ser un valor numérico. <br />"
        Else
            If CType(Me.txtAño.Text, Integer) < Today.Year - 10 Or CType(Me.txtAño.Text, Integer) > Today.Year = 10 Then
                esValido = False
                mensaje += "El año debe estar entre el" + (Today.Year - 10).ToString() + "y el " + (Today.Year + 10).ToString() + ". <br />"
            End If
        End If

        If Not IsNumeric(Me.txtMonto.Text) Then
            esValido = False
            mensaje += "El monto debe ser un valor numérico. <br />"
        End If

        If Me.Socio Is Nothing Then
            esValido = False
            mensaje += "Debe seleccionar un socio. <br />"
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = mensaje
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If
        Return esValido
    End Function

    Private Function ValidarFormularioMulta() As Boolean
        Dim esValido As Boolean = True
        Dim mensaje As String = ""


        If Me.cmbMulta.SelectedIndex < 0 Then
            esValido = False
            mensaje += "Debe seleccionar una multa. <br />"
        End If

        If Me.Socio Is Nothing Then
            esValido = False
            mensaje += "Debe seleccionar un socio. Acceda a esta página desde el menú ""Socio"" <br />"
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = mensaje
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If
        Return esValido
    End Function

    Private Function ValidarTotales() As Boolean
        Dim esValido As Boolean = True
        Dim mensaje As String = ""



        Dim total As Double = 0
        For Each p As PagoSocio In Me.PagosSocio
            total += p.Monto
        Next
        For Each m As MovimientoCajaItem In Me.Valores
            total -= m.ImportePesos
        Next
        If total <> 0 Then
            esValido = False
            mensaje += "El total de los valores debe coincidir con el total a pagar <br />"
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = mensaje
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If
        Return esValido
    End Function






    Private Sub cmdAgregarPagoMulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregarPagoMulta.Click
        Try
            SeleccionarTab("tabs-2")

            If Me.ValidarFormularioMulta Then
                Dim ps As New PagoSocio
                ps.MultaSocioItem = Sistema.ObtenerMultaSocioItem(CType(Me.cmbMulta.SelectedValue, Integer))

                Me.PagosSocio.Add(ps)
                Me.ViewState("PagosSocio") = Me.PagosSocio
                Me.grilla.DataSource = Me.PagosSocio
                Me.grilla.DataBind()

            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub
    Private Sub cmdAgregarPagoCuota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregarPagoCuota.Click

        SeleccionarTab("tabs-1")

        If Me.ValidarFormulario Then
            Try
                Dim ps As New PagoSocio
                ps.PagoCuotaSocio = New PagoCuotaSocio
                ps.PagoCuotaSocio.ConceptoCuota = Sistema.ObtenerConceptoCota(CType(Me.cmbConceptoCuota.SelectedValue, String))
                ps.PagoCuotaSocio.Socio = Me.Socio
                ps.PagoCuotaSocio.Año = CType(Me.txtAño.Text, Integer)
                ps.PagoCuotaSocio.Importe = CType(Me.txtMonto.Text, Double)
                Me.PagosSocio.Add(ps)
                Me.ViewState("PagosSocio") = Me.PagosSocio
                Me.grilla.DataSource = Me.PagosSocio
                Me.grilla.DataBind()

            Catch ex As Exception
                Me.divErrorForm.Visible = True
                Me.lblErrorForm.Text = ex.Message
            End Try
        End If
    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.PagosSocio.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), PagoSocio))
            Me.ViewState("PagosSocio") = Me.PagosSocio
            Me.grilla.DataSource = Me.PagosSocio
            Me.grilla.DataBind()
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmSocio.aspx")
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If ValidarTotales() Then

            If Me.PagosSocio.Count > 0 Then

                For Each ps As PagoSocio In Me.PagosSocio
                    'PAGO DE UNA MULTA
                    If Not ps.MultaSocioItem Is Nothing Then
                        Sistema.AgregarMultaSocioPago(CType(ps.MultaSocioItem.IdMultaSocioItem, Integer))
                    End If

                    'PAGO DE UNA CUOTA
                    If Not ps.PagoCuotaSocio Is Nothing Then
                        ps.PagoCuotaSocio.IdPagoCuotaSocio = Sistema.AgregarPagoCuotaSocio(ps.PagoCuotaSocio)
                    End If

                Next
                ComprobanteCabe.GenerarPorPagosSocio(Me.Socio, Me.PagosSocio, Me.Valores) 'GENERO EL COMPROBANTE AUTOMATIZADO PARA El PAGO DE LAS CUOTAS Y LAS MULTAS
            End If
            Response.Redirect("frmSocio.aspx")
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

            Me.Valores.Add(m)
            Me.ViewState("Valores") = Me.Valores

            Me.grillaValores.DataSource = Me.Valores
            Me.grillaValores.DataBind()

        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub
    Private Sub cmdQuitarValor(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grillaValores.ItemCommand
        If e.CommandName = "Quitar" Then

            Dim mi As MovimientoCajaItem = CType(Me.grillaValores.DataSource(e.Item.ItemIndex), MovimientoCajaItem)
            Me.Valores.Remove(mi)
            Me.ViewState("Valores") = Valores

            Me.grillaValores.DataSource = Me.Valores
            Me.grillaValores.DataBind()

            Me.SeleccionarTab("tabs-3")
        End If
    End Sub
End Class