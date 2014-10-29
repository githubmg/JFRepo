Imports Negocio
Partial Public Class frmComprobanteProveedor
    Inherits System.Web.UI.Page

    Private _proveedor As Proveedor
    Private _comprobanteProveedorItems As List(Of ComprobanteProveedorItem)
    Private _comprobanteProveedor As ComprobanteProveedor

    Public Property Proveedor() As Proveedor
        Get
            Return _proveedor
        End Get
        Set(ByVal value As Proveedor)
            _proveedor = value
        End Set
    End Property

    Public Property ComprobanteProveedorItems() As List(Of ComprobanteProveedorItem)
        Get
            Return _comprobanteProveedorItems
        End Get
        Set(ByVal value As List(Of ComprobanteProveedorItem))
            _comprobanteProveedorItems = value
        End Set
    End Property

    Public Property ComprobanteProveedor() As ComprobanteProveedor
        Get
            Return _comprobanteProveedor
        End Get
        Set(ByVal value As ComprobanteProveedor)
            _comprobanteProveedor = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Proveedor = Sistema.ObtenerProveedor(id)
            Me.lblProveedor.Text = Me.Proveedor.IdProveedor.ToString() + " - " + Me.Proveedor.RazonSocial
        End If



        If Not Me.Page.IsPostBack Then

            Me.cmbCondicionVenta.DataSource = Sistema.VistaCondicionVenta
            Me.cmbCondicionVenta.DataTextField = "descripcion"
            Me.cmbCondicionVenta.DataValueField = "idCondicionVenta"
            Me.cmbCondicionVenta.DataBind()

            Me.cmbTipoComprobante.DataSource = Sistema.VistaTipoComprobante
            Me.cmbTipoComprobante.DataTextField = "descripcion"
            Me.cmbTipoComprobante.DataValueField = "idTipoComprobante"
            Me.cmbTipoComprobante.DataBind()

            Me.txtFechaComprobante.Text = Today.ToShortDateString()

            If Not Me.Request.QueryString("accion") Is Nothing AndAlso Me.Request.QueryString("accion").Equals("RINT") Then
                Dim t As TipoComprobante = Sistema.ObtenerTipoComprobante("RINT")
                Me.cmbTipoComprobante.SelectedValue = t.IdTipoComprobante
                Me.lblProveedor.Text += " - Carga de reintegros"
                Me.cmbTipoComprobante_SelectedIndexChanged(Nothing, Nothing)
            End If
            If Not Me.Request.QueryString("accion") Is Nothing AndAlso Me.Request.QueryString("accion").Equals("ADEL") Then
                Dim t As TipoComprobante = Sistema.ObtenerTipoComprobante("ADEL")
                Me.cmbTipoComprobante.SelectedValue = t.IdTipoComprobante
                Me.lblProveedor.Text += " - Carga de adelantos"
                Me.cmbTipoComprobante_SelectedIndexChanged(Nothing, Nothing)
            End If



        Else
            If Not Me.ViewState("ComprobanteProveedorItems") Is Nothing Then
                Me.ComprobanteProveedorItems = CType(Me.ViewState("ComprobanteProveedorItems"), List(Of ComprobanteProveedorItem))
                Me.grilla.DataSource = Me.ComprobanteProveedorItems
                Me.grilla.DataBind()
            End If
        End If
    End Sub

    Private Function ValidarForm() As Boolean
        Dim esValido As Boolean = True
        Dim strError As String = ""

        If Me.Proveedor Is Nothing Then
            strError += "Se debe acceder a esta pantalla por medio del menú Proveedor. <br />"
            esValido = False
        End If

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
            strError += "La fecha del comprobante no es válida. <br />"
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

        If Not esValido Then
            Me.divErrorItem.Visible = True
            Me.lblErrorItem.Text = strError
        End If
        Return esValido
    End Function

    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        Try

            If ValidarItem() Then
                If Me.ComprobanteProveedorItems Is Nothing Then
                    Me.ComprobanteProveedorItems = New List(Of ComprobanteProveedorItem)
                End If

                Dim i As New ComprobanteProveedorItem
                i.Descripcion = Me.txtDescripcionItem.Text
                i.Observaciones = Me.txtObservacionesItem.Text
                i.Cantidad = CType(Me.txtCantidadItem.Text, Double)
                i.PrecioUnitario = CType(Me.txtPrecioUnitarioItem.Text, Double)
                i.Iva = CType(Me.txtIVA.Text, Double)

                Me.ComprobanteProveedorItems.Add(i)
                Me.ViewState("ComprobanteProveedorItems") = Me.ComprobanteProveedorItems
                Me.grilla.DataSource = Me.ComprobanteProveedorItems
                Me.grilla.DataBind()

                Me.txtDescripcionItem.Text = ""
                Me.txtObservacionesItem.Text = ""
                Me.txtCantidadItem.Text = ""
                Me.txtPrecioUnitarioItem.Text = ""

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
            Me.ComprobanteProveedorItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), ComprobanteProveedorItem))
            Me.ViewState("ComprobanteProveedorItems") = Me.ComprobanteProveedorItems
            Me.grilla.DataSource = Me.ComprobanteProveedorItems
            Me.grilla.DataBind()
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmProveedor.aspx")
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try
            If Me.ValidarForm Then
                If Me.ComprobanteProveedor Is Nothing Then
                    Me.ComprobanteProveedor = New ComprobanteProveedor
                    Me.ComprobanteProveedor.Detalle = Me.txtDetalle.Text
                    Me.ComprobanteProveedor.Fecha = CType(Me.txtFechaComprobante.Text, Date)
                    Me.ComprobanteProveedor.Numero = Me.txtPuntoVenta.Text + "-" + Me.txtNumeroFactura.Text
                    Me.ComprobanteProveedor.Proveedor = Me.Proveedor
                    Me.ComprobanteProveedor.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
                    Me.ComprobanteProveedor.Items = Me.ComprobanteProveedorItems

                    If Me.ComprobanteProveedor.TipoComprobante.Sigla = "RINT" Then
                        Dim p As Parametro = Sistema.ObtenerParametro()
                        p.NumeracionReintegros = p.NumeracionReintegros + 1
                        Sistema.ActualizarParametro(p)
                        Me.ComprobanteProveedor.Numero = "0000-" + Right("00000000" + p.NumeracionReintegros.ToString(), 8)
                    End If

                    If Me.ComprobanteProveedor.TipoComprobante.Sigla = "ADEL" Then
                        Dim p As Parametro = Sistema.ObtenerParametro()
                        p.NumeracionAdelantos = p.NumeracionAdelantos + 1
                        Sistema.ActualizarParametro(p)
                        Me.ComprobanteProveedor.Numero = "0000-" + Right("00000000" + p.NumeracionAdelantos.ToString(), 8)
                    End If

                    Me.ComprobanteProveedor.IdComprobante = Sistema.AgregarComprobanteProveedor(Me.ComprobanteProveedor)
                Else
                    Me.ComprobanteProveedor.Detalle = Me.txtDetalle.Text
                    Me.ComprobanteProveedor.Fecha = CType(Me.txtFechaComprobante.Text, Date)
                    Me.ComprobanteProveedor.Numero = Me.txtPuntoVenta.Text + "-" + Me.txtNumeroFactura.Text
                    Me.ComprobanteProveedor.Proveedor = Me.Proveedor
                    Me.ComprobanteProveedor.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
                    Me.ComprobanteProveedor.Items = Me.ComprobanteProveedorItems

                    If Me.ComprobanteProveedor.TipoComprobante.Sigla = "RINT" Then
                        Dim p As Parametro = Sistema.ObtenerParametro()
                        p.NumeracionReintegros = p.NumeracionReintegros + 1
                        Sistema.ActualizarParametro(p)
                        Me.ComprobanteProveedor.Numero = "0000-" + Right("00000000" + p.NumeracionReintegros.ToString(), 8)
                    End If
                    If Me.ComprobanteProveedor.TipoComprobante.Sigla = "ADEL" Then
                        Dim p As Parametro = Sistema.ObtenerParametro()
                        p.NumeracionAdelantos = p.NumeracionAdelantos + 1
                        Sistema.ActualizarParametro(p)
                        Me.ComprobanteProveedor.Numero = "0000-" + Right("00000000" + p.NumeracionAdelantos.ToString(), 8)
                    End If

                    Me.ComprobanteProveedor.IdComprobante = Sistema.ActualizarComprobanteProveedor(Me.ComprobanteProveedor)
                End If

                Dim a As New Asiento(Me.ComprobanteProveedor)
                Sistema.AgregarAsiento(a)

                Response.Redirect("frmProveedor.aspx")
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmbTipoComprobante_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoComprobante.SelectedIndexChanged

        Me.divDatosComprobante.Visible = True

        Dim t As TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
        If t.Sigla.ToUpper().Equals("RINT") Or _
           t.Sigla.ToUpper().Equals("ADEL") Then
            Me.divDatosComprobante.Visible = False
            Me.txtPuntoVenta.Text = "0000"
            Me.txtNumeroFactura.Text = "00000000"
        End If

    End Sub
End Class