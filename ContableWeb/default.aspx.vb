Imports Negocio
Public Class _default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Function ValidarUsuario(ByVal usuario As String, ByVal password As String)
        Dim u As Usuario = Sistema.ObtenerUsuario(Me.username.Text)
        If Not u Is Nothing AndAlso Me.password.Text = u.Clave Then
            Me.Session("usuario") = u
            Return True
        End If
        Return False
    End Function


    Private Sub cmdIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIngresar.Click
        Try
            Me.divError.Visible = False

            If Me.ValidarUsuario(Me.username.Text, Me.password.Text) Then
                If Not Request.QueryString("ReturnUrl") Is Nothing Then
                    FormsAuthentication.SetAuthCookie(Me.username.Text, False)
                    Response.Redirect(Request.QueryString("ReturnUrl"))
                Else
                    FormsAuthentication.SetAuthCookie(Me.username.Text, False)
                    Response.Redirect(CType(Me.Session("usuario"), Usuario).PantallaDefault)
                End If
            Else
                Me.divError.Visible = True
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

End Class