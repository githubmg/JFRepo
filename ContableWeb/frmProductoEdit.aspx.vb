Imports Negocio

Public Class frmProductoEdit
    Inherits System.Web.UI.Page

    Private _producto As Producto
    Public Property Producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("idProducto") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("idProducto"), Integer)
            Me.Producto = Sistema.ObtenerProducto(id)
        End If

        If Not Me.Page.IsPostBack Then

            Me.cmbFamilia.DataSource = Sistema.VistaFamilia()
            Me.cmbFamilia.DataTextField = "descripcion"
            Me.cmbFamilia.DataValueField = "idFamilia"
            Me.cmbFamilia.DataBind()

            Me.cmbAlicuotaIva.DataSource = Sistema.VistaAlicuotaIva()
            Me.cmbAlicuotaIva.DataTextField = "descripcion"
            Me.cmbAlicuotaIva.DataValueField = "idAlicuotaIva"
            Me.cmbAlicuotaIva.DataBind()

            If Not Me.Producto Is Nothing Then
                Me.txtCodProducto.Text = Me.Producto.CodProducto
                Me.txtDescripcion.Text = Me.Producto.Descripcion
                Me.cmbAlicuotaIva.SelectedValue = Me.Producto.AlicuotaIva.IdAlicuotaIva
                Me.cmbFamilia.SelectedValue = Me.Producto.Familia.IdFamilia
            End If
        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True
        If Me.txtDescripcion.Text = "" Then
            strError += "Error: debe completar el campo Descripción<br />"
            esValido = False
        End If
        If Me.txtCodProducto.Text = "" Then
            strError += "Error: debe completar el campo Código de Producto<br />"
            esValido = False
        End If

        If Me.cmbFamilia.SelectedValue Is Nothing Then
            strError += "Error: debe seleccionar una familia<br />"
            esValido = False
        End If
        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = strError
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If
        Return esValido
    End Function
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try

            If Me.validarForm() Then
                If Me.Producto Is Nothing Then
                    Me.Producto = New Producto
                    Me.Producto.CodProducto = txtCodProducto.Text
                    Me.Producto.Descripcion = txtDescripcion.Text
                    Me.Producto.Familia = Sistema.ObtenerFamilia(CType(cmbFamilia.SelectedValue, Integer))
                    Me.Producto.AlicuotaIva = Sistema.ObtenerAlicuotaIva(CType(cmbAlicuotaIva.SelectedValue, Integer))
                    Sistema.AgregarProducto(Me.Producto)
                    Response.Redirect("frmProducto.aspx")
                Else
                    Me.Producto.CodProducto = txtCodProducto.Text
                    Me.Producto.Descripcion = txtDescripcion.Text
                    Me.Producto.Familia = Sistema.ObtenerFamilia(CType(cmbFamilia.SelectedValue, Integer))
                    Me.Producto.AlicuotaIva = Sistema.ObtenerAlicuotaIva(CType(cmbAlicuotaIva.SelectedValue, Integer))
                    Sistema.ActualizarProducto(Me.Producto)
                    Response.Redirect("frmProducto.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmProducto.aspx")
    End Sub
End Class