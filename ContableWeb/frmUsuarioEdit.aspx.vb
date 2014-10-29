Imports Negocio

Public Class frmUsuarioEdit
    Inherits System.Web.UI.Page


    Private _usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            _usuario = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Usuario = Sistema.ObtenerUsuario(id)
        End If

        If Not Me.Page.IsPostBack Then

            If Not Me.Usuario Is Nothing Then
                Me.txtNombre.Text = Me.Usuario.Nombre
                Me.txtEmail.Text = Me.Usuario.Email
                Me.txtContrasenia.Text = Me.Usuario.Clave
                Me.txtContrasenia2.Text = Me.Usuario.Clave
                Me.txtNombreUsuario.Text = Me.Usuario.NombreUsuario

            End If
        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True

        If Me.txtNombreUsuario.Text = "" Then
            strError += "Error: debe completar el campo Nombre de Usuario <br />"
            esValido = False
        End If
        If Me.txtContrasenia.Text = "" Then
            strError += "Error: debe completar el campo Constraseña <br />"
            esValido = False
        End If
        If Me.txtContrasenia.Text <> Me.txtContrasenia2.Text Then
            strError += "Error: debe repetir la contraseña ingresada <br />"
            esValido = False
        End If
        If Me.Usuario Is Nothing Then
            Dim uExistente As Usuario = Sistema.ObtenerUsuario(txtNombreUsuario.Text)
            If Not uExistente Is Nothing Then
                strError += "Error: el nombre de usuario ya se encuentra utilizado <br />"
                esValido = False
            End If
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
                If Me.Usuario Is Nothing Then
                    Me.Usuario = New Usuario
                    Me.Usuario.Clave = Me.txtContrasenia.Text
                    Me.Usuario.Email = Me.txtEmail.Text
                    Me.Usuario.Nombre = Me.txtNombre.Text
                    Me.Usuario.NombreUsuario = Me.txtNombreUsuario.Text

                    Sistema.AgregarUsuario(Me.Usuario)
                    Response.Redirect("frmUsuario.aspx")
                Else

                    Me.Usuario.Email = Me.txtEmail.Text
                    Me.Usuario.Nombre = Me.txtNombre.Text
                    Me.Usuario.NombreUsuario = Me.txtNombreUsuario.Text
                    Me.Usuario.Clave = Me.txtContrasenia.Text
                    Sistema.ActualizarUsuario(Me.Usuario)
                    Response.Redirect("frmUsuario.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmUsuario.aspx")
    End Sub
    'Private Sub CargarComboPantalla()
    '    Me.cmbpantalla.DataSource = Sistema.vistapantalla
    '    Me.cmbPantalla.DataValueField = "idPantalla"
    '    Me.cmbPantalla.DataTextField = "descripcion"
    '    Me.cmbPantalla.DataBind()
    'End Sub
End Class