Imports Negocio

Public Class frmFamiliaEdit
    Inherits System.Web.UI.Page

    Private _familia As Familia
    Public Property Familia() As Familia
        Get
            Return _familia
        End Get
        Set(ByVal value As Familia)
            _familia = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Familia = Sistema.ObtenerFamilia(id)
        End If

        If Not Me.Page.IsPostBack Then
            If Not Me.Familia Is Nothing Then
                Me.txtDescripcion.Text = Me.Familia.Descripcion
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
                If Me.Familia Is Nothing Then
                    Me.Familia = New Familia
                    Me.Familia.Descripcion = Me.txtDescripcion.Text
                    Sistema.AgregarFamilia(Me.Familia)
                    Response.Redirect("frmFamilia.aspx")
                Else
                    Me.Familia.Descripcion = Me.txtDescripcion.Text
                    Sistema.ActualizarFamilia(Me.Familia)
                    Response.Redirect("frmFamilia.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmFamilia.aspx")
    End Sub

End Class