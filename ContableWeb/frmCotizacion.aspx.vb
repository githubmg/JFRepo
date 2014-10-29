Imports Negocio
Partial Public Class frmCotizacion
    Inherits System.Web.UI.Page
    Private _moneda As Moneda
    Public Property Moneda() As Moneda
        Get
            Return _moneda
        End Get
        Set(ByVal value As Moneda)
            _moneda = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Request.QueryString("idMoneda") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("idMoneda"), Integer)
            Me.Moneda = Sistema.ObtenerMoneda(id)
            Me.grilla.DataSource = Sistema.VistaCotizacion(Me.Moneda.IdMoneda)
            Me.grilla.DataBind()
        End If




    End Sub
    Private Function Validar() As Boolean
        Dim esValido As Boolean = True
        Dim mensaje As String = ""
        If Me.Moneda Is Nothing Then
            esValido = False
            mensaje += "Debe acceder a este menú a través del administrador de monedas.<br />"
        End If
        If Not IsNumeric(Me.txtCotizacion.Text) Then
            esValido = False
            mensaje += "La cotización debe ser un valor numérico.<br />"
        End If


        If Not esValido Then
            Me.lblErrorForm.Text = mensaje
            Me.divErrorForm.Visible = True
        Else
            Me.lblErrorForm.Text = ""
            Me.divErrorForm.Visible = False
        End If

        Return esValido
    End Function

    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.Validar() Then
            Dim c As New Cotizacion
            c.Moneda = Me.Moneda
            c.Fecha = Now
            c.Cotizacion = CType(Utiles.NormalizarNumero(Me.txtCotizacion.Text), Double)
            c.IdCotizacion = Sistema.AgregarCotizacion(c)

            Me.grilla.DataSource = Sistema.VistaCotizacion(Me.Moneda.IdMoneda)
            Me.grilla.DataBind()

        End If
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmMoneda.aspx")
    End Sub
End Class