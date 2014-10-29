Imports Negocio
Imports Microsoft.Reporting.WebForms
Partial Public Class frmReportePlanDeCuentas
    Inherits System.Web.UI.Page
    Private _tabla As DataTable
    Public Property Tabla() As DataTable
        Get
            Return _tabla
        End Get
        Set(ByVal value As DataTable)
            _tabla = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblTitulo.Text = "Plan de Cuentas"

        'If Not Me.Request.QueryString("idSocio") Is Nothing Then
        '    Dim id As Integer = CType(Me.Request.QueryString("idSocio"), Integer)
        '    Me.Socio = Sistema.ObtenerSocio(id)
        '    Me.lblTitulo.Text = Me.Socio.IdSocio.ToString() + " - " + Me.Socio.Nombre
        'End If


        If Not Me.Page.IsPostBack Then
            Me.txtCuentaDesde.Text = ""
            Me.txtCuentaHasta.Text = ""
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

        'If Me.Socio Is Nothing Then
        '    msgError += "Debe acceder a esta función desde el menú Socio.<br />"
        '    esValido = False
        'End If

        'If Not IsDate(Me.txtFechaDesde.Text) Then
        '    msgError += "Error en la fecha desde.<br />"
        '    esValido = False
        'End If

        'If Not IsDate(Me.txtFechaHasta.Text) Then
        '    msgError += "Error en la fecha hasta.<br />"
        '    esValido = False
        'End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = msgError
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If

        Return esValido
    End Function

    Private Sub cmdVerCtaCte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerReporte.Click
        If ValidarForm() Then
            Me.Tabla = Sistema.ReportePlanDeCuentas(Me.txtCuentaDesde.Text, Me.txtCuentaHasta.Text)
            Me.ViewState("Tabla") = Me.Tabla

            Me.grilla.DataSource = Me.Tabla
            Me.grilla.DataBind()
        End If

    End Sub

    Private Sub cmdVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Response.Redirect("Default.aspx")
    End Sub

    'Private Sub lnkExpoPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoPDF.Click
    '    Utiles.ReportviewerToPdf(Me.Tabla, Server.MapPath("reportes\reportePlanDeCuentas.rdlc"), "PlanDeCuentas")
    'End Sub

    'Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
    '    Utiles.ReportviewerToExcel(Me.Tabla, Server.MapPath("reportes\reportePlanDeCuentas.rdlc"), "PlanDeCuentas")
    'End Sub

End Class