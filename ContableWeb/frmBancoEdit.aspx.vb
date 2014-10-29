Imports Negocio

Public Class frmBancoEdit
    Inherits System.Web.UI.Page

    Private _banco As Banco
    Public Property Banco() As Banco
        Get
            Return _banco
        End Get
        Set(ByVal value As Banco)
            _banco = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Banco = Sistema.ObtenerBanco(id)
        End If

        If Not Me.Page.IsPostBack Then
            If Not Me.Banco Is Nothing Then
                Me.txtDescripcion.Text = Me.Banco.Descripcion
            End If
        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True

        If Me.txtDescripcion.Text = "" Then
            strError += "Error: debe completar el campo Descripción.<br />"
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
                If Me.Banco Is Nothing Then
                    Me.Banco = New Banco
                    Me.Banco.Descripcion = Me.txtDescripcion.Text
                    Sistema.AgregarBanco(Me.Banco)
                    Response.Redirect("frmBanco.aspx")
                Else
                    Me.Banco.Descripcion = Me.txtDescripcion.Text
                    Sistema.ActualizarBanco(Me.Banco)
                    Response.Redirect("frmBanco.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmBanco.aspx")
    End Sub

End Class