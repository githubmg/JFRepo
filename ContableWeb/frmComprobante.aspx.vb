Imports Negocio
Partial Public Class frmComprobante
    Inherits System.Web.UI.Page

    Private _comprobanteItems As List(Of ComprobanteItem)
    Private _comprobante As ComprobanteCabe


    Public Property ComprobanteItems() As List(Of ComprobanteItem)
        Get
            Return _comprobanteItems
        End Get
        Set(ByVal value As List(Of ComprobanteItem))
            _comprobanteItems = value
        End Set
    End Property

    Public Property Comprobante() As ComprobanteCabe
        Get
            Return _comprobante
        End Get
        Set(ByVal value As ComprobanteCabe)
            _comprobante = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack Then

            Me.cmbTipoComprobante.DataSource = Sistema.VistaTipoComprobante
            Me.cmbTipoComprobante.DataTextField = "descripcion"
            Me.cmbTipoComprobante.DataValueField = "idTipoComprobante"
            Me.cmbTipoComprobante.DataBind()

            Me.txtFechaComprobante.Text = Today.ToShortDateString()
            Me.txtFechaVencimiento.Text = Today.ToShortDateString()
            Me.txtFechaserviciosDesde.Text = Today.ToShortDateString()
            Me.txtFechaserviciosHasta.Text = Today.ToShortDateString()

            Me.txtPuntoVenta.Text = Right("0000" + Configuracion.ObtenerInstancia().PuntoVenta.ToString, 4)
            Me.cmbTipoComprobante_SelectedIndexChanged(Nothing, Nothing)

        Else
            If Not Me.ViewState("ComprobanteItems") Is Nothing Then
                Me.ComprobanteItems = CType(Me.ViewState("ComprobanteItems"), List(Of ComprobanteItem))
                Me.grilla.DataSource = Me.ComprobanteItems
                Me.grilla.DataBind()
            End If
        End If
    End Sub

    Private Function ValidarForm() As Boolean
        Dim esValido As Boolean = True
        Dim strError As String = ""

        If Me.txtPuntoVenta.Text.Length <> 4 Then
            strError += "El punto de venta debe tener cuatro dígitos. <br />"
            esValido = False
        End If
        If Not IsNumeric(Me.txtPuntoVenta.Text) Then
            strError += "El punto de venta debe ser un número válido. <br />"
            esValido = False
        End If
        If Me.txtNumeroFactura.Text.Length <> 8 Then
            strError += "El número de comprobante debe tener ocho dígitos. <br />"
            esValido = False
        End If
        If Not IsNumeric(Me.txtNumeroFactura.Text) Then
            strError += "El numero de comprobante debe ser un número válido. <br />"
            esValido = False
        End If
        If Not IsDate(Me.txtFechaComprobante.Text) Then
            strError += "La fecha de emisión debe ser una fecha válida. <br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaVencimiento.Text) Then
            strError += "La fecha de vencimiento debe ser una fecha válida. <br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaserviciosDesde.Text) Then
            strError += "La fecha de Servicios desde debe ser una fecha válida. <br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaserviciosHasta.Text) Then
            strError += "La fecha de Servicios hasta debe ser una fecha válida. <br />"
            esValido = False
        End If

        If Not IsNumeric(Me.txtCondicionPago.Text) Then
            strError += "La condición de pago debe debe ser un número válido. <br />"
            esValido = False
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = strError
        End If
        Return esValido
    End Function

    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim strError As String = ""

        If Me.txtDescripcionItem.Text = "" Then
            strError += "La descripción no puede estar vacía. <br />"
            esValido = False
        End If
        If Not IsNumeric(Me.txtCantidadItem.Text) Then
            strError += "La cantidad debe ser un número válido. <br />"
            esValido = False
        End If
        If Not IsNumeric(Me.txtPrecioUnitarioItem.Text) Then
            strError += "El valor unitario debe debe ser un número válido. <br />"
            esValido = False
        End If

        If Not IsNumeric(Me.txtIVA.Text) Then
            strError += "El IVA debe debe ser un número válido. <br />"
            esValido = False
        End If

        If Not IsNumeric(Me.txtDescuento.Text) Then
            strError += "El descuento debe debe ser un número válido. <br />"
            esValido = False
        End If

        If Not esValido Then
            Me.divErrorItem.Visible = True
            Me.lblErrorItem.Text = strError
        End If
        Return esValido
    End Function

    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        Try

            If ValidarItem() Then
                If Me.ComprobanteItems Is Nothing Then
                    Me.ComprobanteItems = New List(Of ComprobanteItem)
                End If

                Dim i As New ComprobanteItem
                i.Descripcion = Me.txtDescripcionItem.Text
                i.Comentario = Me.txtComentarioItem.Text
                i.Cantidad = CType(Me.txtCantidadItem.Text, Double)
                i.PrecioUnitario = CType(Me.txtPrecioUnitarioItem.Text, Double)
                i.Iva = CType(Me.txtIVA.Text, Double)
                i.MotivoDescuento = Me.txtMotivoDescuento.Text
                i.Descuento = CType(Me.txtDescuento.Text, Double)

                Me.ComprobanteItems.Add(i)
                Me.ViewState("ComprobanteItems") = Me.ComprobanteItems
                Me.grilla.DataSource = Me.ComprobanteItems
                Me.grilla.DataBind()

                Me.txtDescripcionItem.Text = ""
                Me.txtComentarioItem.Text = ""
                Me.txtCantidadItem.Text = ""
                Me.txtPrecioUnitarioItem.Text = ""
                Me.txtMotivoDescuento.Text = ""
                Me.txtDescuento.Text = ""

                Me.divErrorItem.Visible = False
                Me.lblErrorItem.Text = ""

            End If

        Catch ex As Exception
            Me.divErrorItem.Visible = True
            Me.lblErrorItem.Text = ex.Message
        End Try
    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.ComprobanteItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), ComprobanteItem))
            Me.ViewState("ComprobanteItems") = Me.ComprobanteItems
            Me.grilla.DataSource = Me.ComprobanteItems
            Me.grilla.DataBind()
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try
            If Me.ValidarForm Then
                If Me.Comprobante Is Nothing Then
                    Me.Comprobante = New ComprobanteCabe
                    Me.Comprobante.PuntoVenta = Me.txtPuntoVenta.Text
                    Me.Comprobante.NumeroComprobante = Me.txtNumeroFactura.Text
                    Me.Comprobante.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
                    Me.Comprobante.FechaEmision = CType(Me.txtFechaComprobante.Text, Date)
                    Me.Comprobante.FechaVencimiento = CType(Me.txtFechaVencimiento.Text, Date)
                    Me.Comprobante.FechaServDesde = CType(Me.txtFechaserviciosDesde.Text, Date)
                    Me.Comprobante.FechaServHasta = CType(Me.txtFechaserviciosHasta.Text, Date)
                    Me.Comprobante.CondicionPago = CType(Me.txtCondicionPago.Text, Double)
                    Me.Comprobante.ObservacionesComprobante = Me.txtDetalle.Text

                    Me.Comprobante.Items = Me.ComprobanteItems
                    Me.Comprobante.IdComprobante = Sistema.AgregarComprobanteCabe(Me.Comprobante)
                Else
                    Me.Comprobante.PuntoVenta = Me.txtPuntoVenta.Text
                    Me.Comprobante.NumeroComprobante = Me.txtNumeroFactura.Text
                    Me.Comprobante.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
                    Me.Comprobante.FechaEmision = CType(Me.txtFechaComprobante.Text, Date)
                    Me.Comprobante.FechaVencimiento = CType(Me.txtFechaVencimiento.Text, Date)
                    Me.Comprobante.FechaServDesde = CType(Me.txtFechaserviciosDesde.Text, Date)
                    Me.Comprobante.FechaServHasta = CType(Me.txtFechaserviciosHasta.Text, Date)
                    Me.Comprobante.CondicionPago = CType(Me.txtCondicionPago.Text, Double)
                    Me.Comprobante.ObservacionesComprobante = Me.txtDetalle.Text

                    Me.Comprobante.Items = Me.ComprobanteItems
                    Me.Comprobante.IdComprobante = Sistema.ActualizarComprobanteCabe(Me.Comprobante)
                End If
                Response.Redirect("Default.aspx")
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmbTipoComprobante_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoComprobante.SelectedIndexChanged
        Try
            Dim proximoNumero As Integer
            proximoNumero = Sistema.ObtenerProximoNumeroComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer), CType(Me.txtPuntoVenta.Text, Integer))
            Me.txtNumeroFactura.Text = Right("00000000" + proximoNumero.ToString(), 8)
        Catch ex As Exception

        End Try
    End Sub
End Class