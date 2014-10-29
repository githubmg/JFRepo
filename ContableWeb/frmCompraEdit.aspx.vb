Imports Negocio
Public Class frmCompraEdit
    Inherits System.Web.UI.Page

    Private _compraCabe As CompraCabe
    Private _compraItems As List(Of CompraItem)

    Public Property CompraCabe() As CompraCabe
        Get
            Return _compraCabe
        End Get
        Set(ByVal value As CompraCabe)
            _compraCabe = value
        End Set
    End Property

    Public Property CompraItems() As List(Of CompraItem)
        Get
            Return _compraItems
        End Get
        Set(ByVal value As List(Of CompraItem))
            _compraItems = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Me.Request.QueryString("id") Is Nothing) And IsNumeric(Me.Request.QueryString("id")) Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.CompraCabe = Sistema.ObtenerCompraCabe(id)
        End If
        If Not Me.Page.IsPostBack Then
            Me.cmbEstado.DataSource = Sistema.VistaEstadoPedido()
            Me.cmbEstado.DataValueField = "idEstadoPedido"
            Me.cmbEstado.DataTextField = "descripcion"
            Me.cmbEstado.DataBind()
            CargarComboTipoOrden()
            Me.txtFecha.Text = Today.ToShortDateString()
            CargarComboFamilia()
            ActualizarComboProducto()
            CargarComboUbicacionStock()
            Me.txtFecha.Text = Today.ToShortDateString()
            If Not Me.CompraCabe Is Nothing Then
                Me.txtFecha.Text = Me.CompraCabe.FechaCompra.ToShortDateString()
                Me.txtProveedor.Text = Me.CompraCabe.Proveedor.Cuit & " - " & Me.CompraCabe.Proveedor.RazonSocial
                Me.txtObservaciones.Text = Me.CompraCabe.Observaciones
                Me.cmbEstado.SelectedValue = Me.CompraCabe.EstadoPedido.IdEstadoPedido.ToString
                Me.cmbTipoOrden.SelectedValue = Me.CompraCabe.TipoOrden.IdTipoOrden.ToString
                Me.cmbUbicacionStock.SelectedValue = Me.CompraCabe.UbicacionStock.IdUbicacionStock.ToString
                Me.txtGanancias.Text = Me.CompraCabe.PercepcionGanancias.ToString
                Me.txtIIBB.Text = Me.CompraCabe.PercepcionIIBB
                Me.txtIva.Text = Me.CompraCabe.PercepcionIva
                Me.CompraItems = Sistema.ObtenerCompraItems(Me.CompraCabe.IdCompraCabe)

                Me.ViewState("CompraItems") = Me.CompraItems
                Me.grilla.DataSource = Me.CompraItems
                Me.grilla.DataBind()
            End If
        Else 'PAGE IS POSTBACK
            If Not Me.ViewState("CompraItems") Is Nothing Then
                Me.CompraItems = CType(Me.ViewState("CompraItems"), List(Of CompraItem))
                Me.grilla.DataSource = Me.CompraItems
                Me.grilla.DataBind()
            End If
        End If

    End Sub
    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.CompraItems Is Nothing Then
                Me.CompraItems = New List(Of CompraItem)
            End If

            Dim ci As New CompraItem
            ci.Cantidad = CType(txtCantidad.Text, Integer)
            ci.Observaciones = txtObservacionesItem.Text
            ci.PrecioUnitario = txtPrecioUnitario.Text
            ci.Producto = Sistema.ObtenerProducto(CType(cmbProducto.SelectedValue, Integer))
            Me.CompraItems.Add(ci)
            Me.ViewState("CompraItems") = Me.CompraItems
            Me.grilla.DataSource = Me.CompraItems
            Me.grilla.DataBind()

            Me.txtCantidad.Text = ""
            Me.txtObservacionesItem.Text = ""
            Me.txtPrecioUnitario.Text = ""
            CargarComboFamilia()
            ActualizarComboProducto()
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario() Then
            If Me.CompraCabe Is Nothing Then
                Me.CompraCabe = New CompraCabe
                Me.CompraCabe.Proveedor = Sistema.ObtenerProveedor(CType(txtProveedor.Text.Substring(0, 11), Long))
                Me.CompraCabe.EstadoPedido = Sistema.ObtenerEstadoPedido(CType(cmbEstado.SelectedValue, Integer))
                Me.CompraCabe.FechaCompra = CType(Me.txtFecha.Text, Date)
                Me.CompraCabe.Observaciones = txtObservaciones.Text
                Me.CompraCabe.Items = Me.CompraItems
                Me.CompraCabe.TipoOrden = Sistema.ObtenerTipoOrden(CType(cmbTipoOrden.SelectedValue, Integer))
                Me.CompraCabe.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(cmbUbicacionStock.SelectedValue, Integer))
                If txtGanancias.Text <> "" Then
                    Me.CompraCabe.PercepcionGanancias = CType(txtGanancias.Text, Double)
                Else
                    Me.CompraCabe.PercepcionGanancias = 0
                End If
                If txtIIBB.Text <> "" Then
                    Me.CompraCabe.PercepcionIIBB = CType(txtIIBB.Text, Double)
                Else
                    Me.CompraCabe.PercepcionIIBB = 0
                End If
                If txtIva.Text <> "" Then
                    Me.CompraCabe.PercepcionIva = CType(txtIva.Text, Double)
                Else
                    Me.CompraCabe.PercepcionIva = 0
                End If
                Sistema.AgregarCompraCabe(Me.CompraCabe)
            Else
                Me.CompraCabe.Proveedor = Sistema.ObtenerProveedor(CType(txtProveedor.Text.Substring(0, 11), Long))
                Me.CompraCabe.EstadoPedido = Sistema.ObtenerEstadoPedido(CType(cmbEstado.SelectedValue, Integer))
                Me.CompraCabe.FechaCompra = CType(Me.txtFecha.Text, Date)
                Me.CompraCabe.TipoOrden = Sistema.ObtenerTipoOrden(CType(cmbTipoOrden.SelectedValue, Integer))
                Me.CompraCabe.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(cmbUbicacionStock.SelectedValue, Integer))
                Me.CompraCabe.Observaciones = txtObservaciones.Text
                Me.CompraCabe.Items = Me.CompraItems
                If txtGanancias.Text <> "" Then
                    Me.CompraCabe.PercepcionGanancias = CType(txtGanancias.Text, Double)
                Else
                    Me.CompraCabe.PercepcionGanancias = 0
                End If
                If txtIIBB.Text <> "" Then
                    Me.CompraCabe.PercepcionIIBB = CType(txtIIBB.Text, Double)
                Else
                    Me.CompraCabe.PercepcionIIBB = 0
                End If
                If txtIva.Text <> "" Then
                    Me.CompraCabe.PercepcionIva = CType(txtIva.Text, Double)
                Else
                    Me.CompraCabe.PercepcionIva = 0
                End If
                Sistema.ActualizarCompraCabe(Me.CompraCabe)
            End If
            Response.Redirect("frmCompra.aspx")
        End If
    End Sub

    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.CompraItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), CompraItem))
            Me.ViewState("CompraItems") = Me.CompraItems
            Me.grilla.DataSource = Me.CompraItems
            Me.grilla.DataBind()

        ElseIf e.CommandName = "Editar" Then
            Dim pi As CompraItem = CType(Me.grilla.DataSource(e.Item.ItemIndex), CompraItem)
            Me.cmbFamilia.SelectedValue = CType(pi.Producto.Familia.IdFamilia, String)
            ActualizarComboProducto()
            Me.cmbProducto.SelectedValue = CType(pi.Producto.IdProducto, String)
            txtObservacionesItem.Text = pi.Observaciones
            txtPrecioUnitario.Text = pi.PrecioUnitario
            txtCantidad.Text = pi.Cantidad.ToString
            Me.CompraItems.Remove(pi)
            Me.ViewState("CompraItems") = Me.CompraItems
            Me.grilla.DataSource = Me.CompraItems
            Me.grilla.DataBind()
        End If
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmCompra.aspx")
    End Sub
    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""

        If Not IsDate(Me.txtFecha.Text) Then
            esValido = False
            msg += "La fecha no es válida.<br />"
        End If
        If txtProveedor.Text.Length < 11 Then
            esValido = False
            msg += "Debe seleccionar un proveedor de la lista.<br />"
        Else
            Dim lng As Long
            If Not Long.TryParse(txtProveedor.Text.Substring(0, 11), lng) Then
                esValido = False
                msg += "El CUIT del proveedor ingresado no es válido.<br />"
            Else
                Dim pv = Sistema.ObtenerProveedor(CType(txtProveedor.Text.Substring(0, 11), Long))
                If pv Is Nothing Then
                    esValido = False
                    msg += "El CUIT ingresado no pertenece a un proveedor. Seleccione un proveedor de la lista.<br />"
                End If
            End If
        End If
        If Me.CompraItems Is Nothing Then
            esValido = False
            msg += "Debe ingresar al menos un item para la compra.<br />"
        Else
            If Me.CompraItems.Count = 0 Then
                esValido = False
                msg += "Debe ingresar al menos un item para la compra.<br />"
            End If
        End If
        Dim a As Double
        If txtGanancias.Text <> "" Then
            If Not Double.TryParse(Me.txtGanancias.Text, a) Then
                esValido = False
                msg += "Debe ingresar un monto de percepción de ganancias válido.<br />"
            End If
        End If
        If txtIIBB.Text <> "" Then
            If Not Double.TryParse(Me.txtIIBB.Text, a) Then
                esValido = False
                msg += "Debe ingresar un monto de percepción de ingresos brutos válido.<br />"
            End If
        End If
        If txtIva.Text <> "" Then
            If Not Double.TryParse(Me.txtIva.Text, a) Then
                esValido = False
                msg += "Debe ingresar un monto de percepción de IVA válido.<br />"
            End If
        End If
        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = msg
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If
        Return esValido

    End Function
    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        Dim inte As Integer
        If Not Integer.TryParse(txtCantidad.Text, inte) Then
            esValido = False
            msg += "Error. La cantidad debe ser un valor numérico.<br />"
        Else
            If CType(txtCantidad.Text, Integer) <= 0 Then
                esValido = False
                msg += "Error. La cantidad debe ser mayor que 0.<br />"
            End If
        End If
        Dim db As Double
        If Not Double.TryParse(txtPrecioUnitario.Text, db) Then
            esValido = False
            msg += "Error. El precio debe tener el formato 00,00.<br />"
        Else
            If CType(txtPrecioUnitario.Text, Double) <= 0 Then
                esValido = False
                msg += "Error. El precio debe ser mayor que $0.<br />"
            End If
        End If

        If Not esValido Then
            Me.divErrorItem.Visible = True
            Me.lblErrorItem.Text = msg
        Else
            Me.divErrorItem.Visible = False
            Me.lblErrorItem.Text = ""
        End If
        Return esValido

    End Function
    Private Sub CargarComboTipoOrden()
        Me.cmbTipoOrden.DataSource = Sistema.VistaTipoOrden
        Me.cmbTipoOrden.DataValueField = "idTipoOrden"
        Me.cmbTipoOrden.DataTextField = "descripcion"
        Me.cmbTipoOrden.DataBind()
    End Sub
    Private Sub CargarComboFamilia()
        Me.cmbFamilia.DataSource = Sistema.VistaFamilia
        Me.cmbFamilia.DataValueField = "idFamilia"
        Me.cmbFamilia.DataTextField = "descripcion"
        Me.cmbFamilia.DataBind()
    End Sub
    Private Sub CargarComboUbicacionStock()
        Me.cmbUbicacionStock.DataSource = Sistema.VistaUbicacionStock
        Me.cmbUbicacionStock.DataValueField = "idUbicacionStock"
        Me.cmbUbicacionStock.DataTextField = "descripcion"
        Me.cmbUbicacionStock.DataBind()
    End Sub
    Private Sub cmbFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFamilia.SelectedIndexChanged
        ActualizarComboProducto()
    End Sub
    Private Sub ActualizarComboProducto()
        Me.cmbProducto.DataSource = Sistema.VistaProductoByFamlia(CType(Me.cmbFamilia.SelectedValue, Integer))
        Me.cmbProducto.DataTextField = "descripcion"
        Me.cmbProducto.DataValueField = "idProducto"
        Me.cmbProducto.DataBind()
    End Sub


End Class