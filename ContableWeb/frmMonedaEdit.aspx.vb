Imports Negocio


Partial Public Class frmMonedaEdit
    Inherits System.Web.UI.Page

    Private _Moneda As Moneda
    Public Property Moneda() As Moneda
        Get
            Return Me._Moneda
        End Get
        Set(ByVal value As Moneda)
            Me._Moneda = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Moneda = Sistema.ObtenerMoneda(id)
        End If

        If Not Me.Page.IsPostBack Then
            If Not Me.Moneda Is Nothing Then
                Me.txtDescripcion.Text = Me.Moneda.Descripcion
                Me.txtSimbolo.Text = Me.Moneda.Simbolo
                Me.txtAbreviatura.Text = Me.Moneda.Abreviatura
            End If
        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True

        If Me.txtDescripcion.Text = "" Then
            strError += "La descripcion no puede estar vacía.<br />"
            esValido = False
        End If
        If Me.txtSimbolo.Text = "" Then
            strError += "El símbolo no puede estar vacío.<br />"
            esValido = False
        End If
        If Me.txtAbreviatura.Text = "" Then
            strError += "La abreviatura no puede estar vacía.<br />"
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
                If Me.Moneda Is Nothing Then
                    Me.Moneda = New Moneda
                    Me.Moneda.Descripcion = Me.txtDescripcion.Text
                    Me.Moneda.Abreviatura = Me.txtAbreviatura.Text
                    Me.Moneda.Simbolo = Me.txtSimbolo.Text
                    Sistema.AgregarMoneda(Me.Moneda)
                    Response.Redirect("frmMoneda.aspx")
                Else
                    Me.Moneda.Descripcion = Me.txtDescripcion.Text
                    Me.Moneda.Abreviatura = Me.txtAbreviatura.Text
                    Me.Moneda.Simbolo = Me.txtSimbolo.Text
                    Sistema.ActualizarMoneda(Me.Moneda)
                    Response.Redirect("frmMoneda.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmMoneda.aspx")
    End Sub
End Class
