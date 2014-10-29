Imports Negocio
Imports Microsoft.Reporting.WebForms
Partial Public Class frmCtaCteSocio
    Inherits System.Web.UI.Page

    Private _socio As Socio
    Private _tabla As DataTable

    Public Property Socio() As Socio
        Get
            Return _socio
        End Get
        Set(ByVal value As Socio)
            _socio = value
        End Set
    End Property
    Public Property Tabla() As DataTable
        Get
            Return _tabla
        End Get
        Set(ByVal value As DataTable)
            _tabla = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Socio = Sistema.ObtenerSocio(id)
            Me.lblSocio.Text = Me.Socio.IdSocio.ToString() + " - " + Me.Socio.Nombre
        End If

        If Not Me.Page.IsPostBack Then
            Me.txtFechaDesde.Text = Today.AddMonths(-1).ToShortDateString()
            Me.txtFechaHasta.Text = Today.ToShortDateString()
        Else
            If Not Me.ViewState("Tabla") Is Nothing Then
                Me.Tabla = CType(Me.ViewState("Tabla"), DataTable)
                Me.divExportacion.Visible = True
            Else
                Me.divExportacion.Visible = True
            End If
        End If

    End Sub
    Private Function ValidarForm() As Boolean
        Dim msgError As String = ""
        Dim esValido As Boolean = True

        If Me.Socio Is Nothing Then
            msgError += "Debe acceder a esta función desde el menú Socio.<br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaDesde.Text) Then
            msgError += "Error en la fecha desde.<br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaHasta.Text) Then
            msgError += "Error en la fecha hasta.<br />"
            esValido = False
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = msgError
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If

        Return esValido
    End Function

    Private Sub cmdVerCtaCte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerCtaCte.Click
        If ValidarForm() Then
            'Me.Tabla = Sistema.VistaCtaCteSocio(Me.Socio, CType(Me.txtFechaDesde.Text, Date), CType(Me.txtFechaHasta.Text, Date))
            'Me.ViewState("Tabla") = Me.Tabla

            'Me.grilla.DataSource = Me.Tabla
            'Me.grilla.DataBind()
        End If

    End Sub

    Private Sub cmdVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Response.Redirect("frmSocio.aspx")
    End Sub

    'Private Sub lnkExpoPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoPDF.Click
    '    Utiles.ReportviewerToPdf(Me.Tabla, Server.MapPath("reportes\reporteCtaCteSocio.rdlc"), "CtaCte_" + Me.Socio.Nombre)
    'End Sub

    'Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
    '    Utiles.ReportviewerToExcel(Me.Tabla, Server.MapPath("reportes\reporteCtaCteSocio.rdlc"), "CtaCte_" + Me.Socio.Nombre)
    'End Sub

End Class