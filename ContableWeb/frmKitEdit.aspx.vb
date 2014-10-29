Imports Negocio

Public Class frmKitEdit
    Inherits System.Web.UI.Page

    Private _kit As Kit
    Private _productos As List(Of ProductoKit)

    Public Property Kit() As Kit
        Get
            Return _kit
        End Get
        Set(ByVal value As Kit)
            _kit = value
        End Set
    End Property

    Public Property Productos() As List(Of ProductoKit)
        Get
            Return _productos
        End Get
        Set(ByVal value As List(Of ProductoKit))
            _productos = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Me.Request.QueryString("id") Is Nothing) And IsNumeric(Me.Request.QueryString("id")) Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Kit = Sistema.ObtenerKit(id)
        End If
        If Not Me.Page.IsPostBack Then
            CargarComboFamilia()
            ActualizarComboProducto()
            CargarComboFamiliaPrincipal()
            ActualizarComboProductoPrincipal()
            If Not Me.Kit Is Nothing Then
                Me.txtDescripcion.Text = Me.Kit.Descripcion
                Me.cmbFamiliaPrincipal.SelectedValue = Me.Kit.ProductoPrincipal.Familia.IdFamilia.ToString
                Me.cmbProductoPrincipal.SelectedValue = Me.Kit.ProductoPrincipal.IdProducto.ToString
                Me.Productos = Sistema.ObtenerKitPtoductos(Me.Kit.IdKit)

                Me.ViewState("Productos") = Me.Productos
                Me.grilla.DataSource = Me.Productos
                Me.grilla.DataBind()
            End If
        Else 'PAGE IS POSTBACK
            If Not Me.ViewState("Productos") Is Nothing Then
                Me.Productos = CType(Me.ViewState("Productos"), List(Of ProductoKit))
                Me.grilla.DataSource = Me.Productos
                Me.grilla.DataBind()
            End If
        End If

    End Sub
    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.Productos Is Nothing Then
                Me.Productos = New List(Of ProductoKit)
            End If

            Dim k As New ProductoKit
            k.Cantidad = txtCantidad.Text
            k.Producto = Sistema.ObtenerProducto(CType(cmbProducto.SelectedValue, Integer))
            Me.Productos.Add(k)
            Me.ViewState("Productos") = Me.Productos
            Me.grilla.DataSource = Me.Productos
            Me.grilla.DataBind()

            Me.txtCantidad.Text = ""
            CargarComboFamilia()
            ActualizarComboProducto()
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario() Then
            If Me.Kit Is Nothing Then
                Me.Kit = New Kit
                Me.Kit.Descripcion = txtDescripcion.Text
                Me.Kit.ProductoPrincipal = Sistema.ObtenerProducto(CType(cmbProductoPrincipal.SelectedValue, Integer))
                Me.Kit.Productos = Me.Productos
                Sistema.AgregarKit(Me.Kit)
            Else
               Me.Kit.Descripcion = txtDescripcion.Text
                Me.Kit.ProductoPrincipal = Sistema.ObtenerProducto(CType(cmbProductoPrincipal.SelectedValue, Integer))
                Me.Kit.Productos = Me.Productos
                Sistema.ActualizarKit(Me.Kit)
            End If
            Response.Redirect("frmKit.aspx")
        End If
    End Sub

    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.Productos.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), ProductoKit))
            Me.ViewState("Productos") = Me.Productos
            Me.grilla.DataSource = Me.Productos
            Me.grilla.DataBind()

        ElseIf e.CommandName = "Editar" Then
            Dim pi As ProductoKit = CType(Me.grilla.DataSource(e.Item.ItemIndex), ProductoKit)
            Me.cmbFamilia.SelectedValue = CType(pi.Producto.Familia.IdFamilia, String)
            Me.cmbProducto.SelectedValue = CType(pi.Producto.IdProducto, String)
            txtCantidad.Text = pi.Cantidad
            Me.Productos.Remove(pi)
            Me.ViewState("CompraItems") = Me.Productos
            Me.grilla.DataSource = Me.Productos
            Me.grilla.DataBind()
        End If
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmKit.aspx")
    End Sub
    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""

        If Me.Productos Is Nothing Then
            esValido = False
            msg += "Debe ingresar al menos un producto anexo para el kit.<br />"
        Else
            If Me.Productos.Count = 0 Then
                esValido = False
                msg += "Debe ingresar al menos un producto anexo para el kit.<br />"
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
        If cmbProducto.SelectedValue = cmbProductoPrincipal.SelectedValue Then
            esValido = False
            msg += "Error. El kit no puede contener al producto principal.<br />"
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
    
    Private Sub CargarComboFamilia()
        Me.cmbFamilia.DataSource = Sistema.VistaFamilia
        Me.cmbFamilia.DataValueField = "idFamilia"
        Me.cmbFamilia.DataTextField = "descripcion"
        Me.cmbFamilia.DataBind()
    End Sub
    Private Sub CargarComboFamiliaPrincipal()
        Me.cmbFamiliaPrincipal.DataSource = Sistema.VistaFamilia
        Me.cmbFamiliaPrincipal.DataValueField = "idFamilia"
        Me.cmbFamiliaPrincipal.DataTextField = "descripcion"
        Me.cmbFamiliaPrincipal.DataBind()
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
    Private Sub ActualizarComboProductoPrincipal()
        Me.cmbProductoPrincipal.DataSource = Sistema.VistaProductoByFamlia(CType(Me.cmbFamiliaPrincipal.SelectedValue, Integer))
        Me.cmbProductoPrincipal.DataTextField = "descripcion"
        Me.cmbProductoPrincipal.DataValueField = "idProducto"
        Me.cmbProductoPrincipal.DataBind()
    End Sub



    Private Sub cmbFamiliaPrincipal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFamiliaPrincipal.SelectedIndexChanged
        ActualizarComboProductoPrincipal()
    End Sub

    Private Sub cmbProductoPrincipal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProductoPrincipal.SelectedIndexChanged
        txtDescripcion.Text = cmbProductoPrincipal.SelectedItem.Text
    End Sub
End Class