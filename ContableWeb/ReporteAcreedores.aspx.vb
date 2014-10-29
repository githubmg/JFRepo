Imports Negocio

Public Class ReporteAcreedores
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
        If Not Me.Page.IsPostBack Then
            'Me.txtFechaDesde.Text = Today.AddMonths(-1).ToShortDateString()
            'Me.txtFechaHasta.Text = Today.ToShortDateString()
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
        If Not Me.txtFechaDesde.Text = "" Then
            If Not IsDate(Me.txtFechaDesde.Text) Then
                msgError += "Error en la fecha desde.<br />"
                esValido = False
            End If
        End If
        If Not Me.txtFechaHasta.Text = "" Then
            If Not IsDate(Me.txtFechaHasta.Text) Then
                msgError += "Error en la fecha hasta.<br />"
                esValido = False
            End If
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

    Private Sub cmdVerAcreedores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerAcreedores.Click
        If ValidarForm() Then
            Me.Tabla = Sistema.VistaAcreedores(Me.txtFechaDesde.Text, Me.txtFechaHasta.Text)
            Me.ViewState("Tabla") = Me.Tabla
            Me.grilla.DataSource = Me.Tabla
            Me.grilla.DataBind()
        End If
    End Sub

    Protected Sub lnkExpoPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExpoPDF.Click
        Response.Redirect("frmViewer.aspx?tipo=ACR&desde=" & txtFechaDesde.Text & "&hasta=" & txtFechaHasta.Text)
    End Sub
    Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
        Response.Redirect("frmViewer.aspx?tipo=ACREX&desde=" & txtFechaDesde.Text & "&hasta=" & txtFechaHasta.Text)
    End Sub

    Private Sub cmdVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Response.Redirect("default.aspx")
    End Sub
End Class