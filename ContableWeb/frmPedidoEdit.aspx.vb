Imports Negocio

Public Class frmPedidoEdit
    Inherits System.Web.UI.Page

    Private _pedidoCabe As PedidoCabe
    Private _pedidoItems As List(Of PedidoItem)

    Public Property PedidoCabe() As PedidoCabe
        Get
            Return _pedidoCabe
        End Get
        Set(ByVal value As PedidoCabe)
            _pedidoCabe = value
        End Set
    End Property

    Public Property PedidoItems() As List(Of PedidoItem)
        Get
            Return _pedidoItems
        End Get
        Set(ByVal value As List(Of PedidoItem))
            _pedidoItems = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Me.Request.QueryString("id") Is Nothing) And IsNumeric(Me.Request.QueryString("id")) Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.PedidoCabe = Sistema.ObtenerPedidoCabe(id)
        End If
        If Not Me.Page.IsPostBack Then
            Me.cmbEstado.DataSource = Sistema.VistaEstadoPedido()
            Me.cmbEstado.DataValueField = "idEstadoPedido"
            Me.cmbEstado.DataTextField = "descripcion"
            Me.cmbEstado.DataBind()
            CargarComboTipoOrden()
            CargarComboUbicacionStock()
            Me.txtFecha.Text = Today.ToShortDateString()
            CargarComboFamilia()
            ActualizarComboProducto()
            CargarComboVendedor()

            Me.txtFecha.Text = Today.ToShortDateString()

            If Not Me.PedidoCabe Is Nothing Then
                Me.txtFecha.Text = Me.PedidoCabe.FechaPedido.ToShortDateString()
                Me.txtCliente.Text = Me.PedidoCabe.Cliente.IdCliente & "- " & Me.PedidoCabe.Cliente.Cuit & " - " & Me.PedidoCabe.Cliente.RazonSocial
                Me.txtOrden.Text = Me.PedidoCabe.Orden
                Me.txtObservaciones.Text = Me.PedidoCabe.Observaciones
                Me.txtChasis.Text = Me.PedidoCabe.Chasis
                Me.cmbEstado.SelectedValue = Me.PedidoCabe.EstadoPedido.IdEstadoPedido.ToString
                Me.cmbTipoOrden.SelectedValue = Me.PedidoCabe.TipoOrden.IdTipoOrden.ToString
                Me.cmbUbicacionStock.SelectedValue = Me.PedidoCabe.UbicacionStock.IdUbicacionStock.ToString
                Me.PedidoItems = Sistema.ObtenerPedidoItems(Me.PedidoCabe.IdPedidoCabe)

                Me.ViewState("pedidoItems") = Me.PedidoItems
                Me.grilla.DataSource = Me.PedidoItems
                Me.grilla.DataBind()
            End If
        Else 'PAGE IS POSTBACK
            If Not Me.ViewState("pedidoItems") Is Nothing Then
                Me.PedidoItems = CType(Me.ViewState("pedidoItems"), List(Of PedidoItem))
                Me.grilla.DataSource = Me.PedidoItems
                Me.grilla.DataBind()
            End If
        End If

    End Sub
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

    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.PedidoItems Is Nothing Then
                Me.PedidoItems = New List(Of PedidoItem)
            End If

            Dim pi As New PedidoItem
            pi.Cantidad = CType(txtCantidad.Text, Integer)

            pi.Observaciones = txtObservacionesItem.Text
            pi.PrecioUnitario = txtPrecioUnitario.Text
            pi.Producto = Sistema.ObtenerProducto(CType(cmbProducto.SelectedValue, Integer))
            pi.Vendedor = Sistema.ObtenerVendedor(CType(cmbVendedor.SelectedValue, Integer))
            Me.PedidoItems.Add(pi)
            Me.ViewState("pedidoItems") = Me.PedidoItems
            Me.grilla.DataSource = Me.PedidoItems
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
            Dim idCliente As Integer = ObtenerId()
            If Me.PedidoCabe Is Nothing Then
                Me.PedidoCabe = New PedidoCabe
                Me.PedidoCabe.Cliente = Sistema.Obtenercliente(idCliente)
                Me.PedidoCabe.EstadoPedido = Sistema.ObtenerEstadoPedido(CType(cmbEstado.SelectedValue, Integer))
                Me.PedidoCabe.TipoOrden = Sistema.ObtenerTipoOrden(CType(cmbTipoOrden.SelectedValue, Integer))
                Me.PedidoCabe.FechaPedido = CType(Me.txtFecha.Text, Date)
                Me.PedidoCabe.Observaciones = txtObservaciones.Text
                Me.PedidoCabe.Orden = txtOrden.Text
                Me.PedidoCabe.Chasis = txtChasis.Text
                Me.PedidoCabe.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(cmbUbicacionStock.SelectedValue, Integer))
                Me.PedidoCabe.Items = Me.PedidoItems
                Sistema.AgregarPedidoCabe(Me.PedidoCabe)
            Else
                Me.PedidoCabe.Cliente = Sistema.Obtenercliente(idCliente)
                Me.PedidoCabe.EstadoPedido = Sistema.ObtenerEstadoPedido(CType(cmbEstado.SelectedValue, Integer))
                Me.PedidoCabe.TipoOrden = Sistema.ObtenerTipoOrden(CType(cmbTipoOrden.SelectedValue, Integer))
                Me.PedidoCabe.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(cmbUbicacionStock.SelectedValue, Integer))
                Me.PedidoCabe.FechaPedido = CType(Me.txtFecha.Text, Date)
                Me.PedidoCabe.Observaciones = txtObservaciones.Text
                Me.PedidoCabe.Orden = txtOrden.Text
                Me.PedidoCabe.Chasis = txtChasis.Text
                Me.PedidoCabe.Items = Me.PedidoItems
                Sistema.ActualizarPedidoCabe(Me.PedidoCabe)
            End If
            Response.Redirect("frmPedido.aspx")
        End If
    End Sub
    Private Function ObtenerId()
        Dim partes As String() = Me.txtCliente.Text.Split(New Char() {"-"c})
        Return partes(0)
    End Function
    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.PedidoItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), PedidoItem))
            Me.ViewState("pedidoItems") = Me.PedidoItems
            Me.grilla.DataSource = Me.PedidoItems
            Me.grilla.DataBind()

        ElseIf e.CommandName = "Editar" Then
            Dim pi As PedidoItem = CType(Me.grilla.DataSource(e.Item.ItemIndex), PedidoItem)
            Me.cmbFamilia.SelectedValue = CType(pi.Producto.Familia.IdFamilia, String)
            ActualizarComboProducto()
            Me.cmbProducto.SelectedValue = CType(pi.Producto.IdProducto, String)
            Me.cmbVendedor.SelectedValue = CType(pi.Vendedor.IdVendedor, String)
            txtObservacionesItem.Text = pi.Observaciones
            txtPrecioUnitario.Text = pi.PrecioUnitario
            txtCantidad.Text = pi.Cantidad.ToString
            Me.PedidoItems.Remove(pi)
            Me.ViewState("pedidoItems") = Me.PedidoItems
            Me.grilla.DataSource = Me.PedidoItems
            Me.grilla.DataBind()
        End If
    End Sub

    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        If Me.txtCantidad.Text = "" Then
            esValido = False
            msg += "Error. Debe ingresar una cantidad.<br />"
        End If
        Dim inte As Integer
        If Not Integer.TryParse(txtCantidad.Text, inte) Then
            esValido = False
            msg += "Error. La cantidad debe ser un número entero.<br />"
        End If
        If txtPrecioUnitario.Text = "" Then
            esValido = False
            msg += "Debe ingresar un precio unitario.<br />"
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

    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""

        If Not IsDate(Me.txtFecha.Text) Then
            esValido = False
            msg += "La fecha no es válida.<br />"
        End If
        If Not (Me.txtOrden.Text.Length <= 13) Then
            esValido = False
            msg += "El campo Orden no debe exceder los 13 caracteres.<br />"
        End If
        If Me.PedidoItems Is Nothing Then
            esValido = False
            msg += "Debe ingresar al menos un item para el pedido.<br />"
        Else
            If Me.PedidoItems.Count = 0 Then
                esValido = False
                msg += "Debe ingresar al menos un item para el pedido.<br />"
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

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmPedido.aspx")
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
    Private Sub CargarComboVendedor()
        Me.cmbVendedor.DataSource = Sistema.VistaVendedor()
        Me.cmbVendedor.DataTextField = "descripcion"
        Me.cmbVendedor.DataValueField = "idVendedor"
        Me.cmbVendedor.DataBind()
    End Sub
    Private Sub CargarComboUbicacionStock()
        Me.cmbUbicacionStock.DataSource = Sistema.VistaUbicacionStock
        Me.cmbUbicacionStock.DataValueField = "idUbicacionStock"
        Me.cmbUbicacionStock.DataTextField = "descripcion"
        Me.cmbUbicacionStock.DataBind()
    End Sub
End Class