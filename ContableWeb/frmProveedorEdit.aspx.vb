Imports Negocio
Partial Public Class frmProveedorEdit
    Inherits System.Web.UI.Page

    Private _proveedor As proveedor
    Public Property Proveedor() As Proveedor
        Get
            Return _proveedor
        End Get
        Set(ByVal value As Proveedor)
            _proveedor = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Long = CType(Me.Request.QueryString("id"), Long)
            Me.Proveedor = Sistema.ObtenerProveedor(id)
        End If

        If Not Me.Page.IsPostBack Then

            Me.cmbProvincia.DataSource = Sistema.VistaProvincia()
            Me.cmbProvincia.DataTextField = "descripcion"
            Me.cmbProvincia.DataValueField = "idProvincia"
            Me.cmbProvincia.DataBind()

            Me.cmbLocalidad.DataSource = Sistema.VistaLocalidad(cmbProvincia.SelectedValue)
            Me.cmbLocalidad.DataTextField = "descripcion"
            Me.cmbLocalidad.DataValueField = "idLocalidad"
            Me.cmbLocalidad.DataBind()

            If Not Me.Proveedor Is Nothing Then
                Me.txtCuit.Text = Me.Proveedor.Cuit
                Me.txtCuit.ReadOnly = True
                Me.txtRazonSocial.Text = Me.Proveedor.RazonSocial
                Me.txtDomicilio.Text = Me.Proveedor.Domicilio
                Me.txtCodigoPostal.Text = Me.Proveedor.CodigoPostal
                Me.txtTelefono.Text = Me.Proveedor.Telefono
                Me.txtEmail.Text = Me.Proveedor.Email
                Me.txtObservaciones.Text = Me.Proveedor.Observaciones
                Me.cmbProvincia.SelectedValue = Me.Proveedor.Localidad.Provincia.IdProvincia.ToString()
                Me.cmbLocalidad.SelectedValue = Me.Proveedor.Localidad.IdLocalidad.ToString()

            End If
        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True
        If Me.txtCuit.Text = "" Then
            strError += "Error: debe completar el campo CUIT.<br />"
            esValido = False
        End If
        If Not IsNumeric(Me.txtCuit.Text) Or Not Me.txtCuit.Text.Length = 11 Then
            strError += "Error: el valor ingresado en el campo CUIT debe ser numérico y tener 11 caracteres.<br />"
            esValido = False
        Else
            If Not Utiles.validarCuit(Me.txtCuit.Text) Then
                strError += "Error: ingrese un número de CUIT válido.<br />"
                esValido = False
            End If
        End If
        If Me.Proveedor Is Nothing Then
            'Estoy dando de Alta
            Dim c As Proveedor = Sistema.ObtenerProveedor(txtCuit.Text)
            If Not c Is Nothing Then
                strError += "Error: El CUIT ingresado corresponde a un Proveedor existente en el sistema.<br />"
                esValido = False
            End If
        End If
        If Me.txtRazonSocial.Text = "" Then
            strError += "Error: debe completar el campo 'Razón Social'<br />"
            esValido = False
        End If
        Dim expression As String = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        Dim match As Match = Regex.Match(txtEmail.Text, expression, RegexOptions.IgnoreCase)
        If Not match.Success Then
            strError += "Error: debe ingresar una dirección de correo válida.<br />"
            esValido = False
        End If
        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = strError
        End If
        Return esValido
    End Function
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try

            If Me.validarForm() Then
                If Me.Proveedor Is Nothing Then
                    Me.Proveedor = New Proveedor
                    Me.Proveedor.CodigoPostal = txtCodigoPostal.Text
                    Me.Proveedor.Localidad = Sistema.ObtenerLocalidad(CType(cmbLocalidad.SelectedValue, Integer))
                    Me.Proveedor.Cuit = txtCuit.Text
                    Me.Proveedor.Domicilio = txtDomicilio.Text
                    Me.Proveedor.Email = txtEmail.Text
                    Me.Proveedor.Observaciones = txtObservaciones.Text
                    Me.Proveedor.RazonSocial = txtRazonSocial.Text
                    Me.Proveedor.Telefono = txtTelefono.Text
                    Sistema.AgregarProveedor(Me.Proveedor)
                    Response.Redirect("frmProveedor.aspx")
                Else
                    Me.Proveedor.CodigoPostal = txtCodigoPostal.Text
                    Me.Proveedor.Localidad = Sistema.ObtenerLocalidad(CType(cmbLocalidad.SelectedValue, Integer))
                    Me.Proveedor.Cuit = txtCuit.Text
                    Me.Proveedor.Domicilio = txtDomicilio.Text
                    Me.Proveedor.Email = txtEmail.Text
                    Me.Proveedor.Observaciones = txtObservaciones.Text
                    Me.Proveedor.RazonSocial = txtRazonSocial.Text
                    Me.Proveedor.Telefono = txtTelefono.Text
                    Sistema.ActualizarProveedor(Me.Proveedor)
                    Response.Redirect("frmProveedor.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmProveedor.aspx")
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        Me.cmbLocalidad.DataSource = Sistema.VistaLocalidad(cmbProvincia.SelectedValue)
        Me.cmbLocalidad.DataTextField = "descripcion"
        Me.cmbLocalidad.DataValueField = "idLocalidad"
        Me.cmbLocalidad.DataBind()
    End Sub
  

End Class