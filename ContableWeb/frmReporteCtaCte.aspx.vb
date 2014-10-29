Imports Negocio
Imports Microsoft.Reporting.WebForms
Partial Public Class frmReporteCtaCte
    Inherits System.Web.UI.Page

    Private _socio As Socio
    Private _club As Club
    Private _federacion As Federacion

    Private _tabla As DataTable

    Public Property Club() As Club
        Get
            Return _club
        End Get
        Set(ByVal value As Club)
            _club = value
        End Set
    End Property
    Public Property Federacion() As Federacion
        Get
            Return _federacion
        End Get
        Set(ByVal value As Federacion)
            _federacion = value
        End Set
    End Property
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

        Me.lblTitulo.Text = "Comprobantes Emitidos"

        If Not Me.Request.QueryString("idSocio") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("idSocio"), Integer)
            Me.Socio = Sistema.ObtenerSocio(id)
            Me.lblTitulo.Text = Me.Socio.IdSocio.ToString() + " - " + Me.Socio.Nombre
        End If
        If Not Me.Request.QueryString("idClub") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("idClub"), Integer)
            Me.Club = Sistema.ObtenerClub(id)
            Me.lblTitulo.Text = Me.Club.IdClub.ToString() + " - " + Me.Club.Descripcion
        End If
        If Not Me.Request.QueryString("idFederacion") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("idFederacion"), Integer)
            Me.Federacion = Sistema.ObtenerFederacion(id)
            Me.lblTitulo.Text = Me.Federacion.IdFederacion.ToString() + " - " + Me.Federacion.Descripcion
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

        'If Me.Socio Is Nothing Then
        '    msgError += "Debe acceder a esta función desde el menú Socio.<br />"
        '    esValido = False
        'End If

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
            If Me.Socio Is Nothing And Me.Club Is Nothing And Me.Federacion Is Nothing Then Me.Tabla = Sistema.VistaCtaCte(CType(Me.txtFechaDesde.Text, Date), CType(Me.txtFechaHasta.Text, Date))
            If Not Me.Socio Is Nothing Then Me.Tabla = Sistema.VistaCtaCte(Me.Socio, CType(Me.txtFechaDesde.Text, Date), CType(Me.txtFechaHasta.Text, Date))
            If Not Me.Club Is Nothing Then Me.Tabla = Sistema.VistaCtaCte(Me.Club, CType(Me.txtFechaDesde.Text, Date), CType(Me.txtFechaHasta.Text, Date))
            If Not Me.Federacion Is Nothing Then Me.Tabla = Sistema.VistaCtaCte(Me.Federacion, CType(Me.txtFechaDesde.Text, Date), CType(Me.txtFechaHasta.Text, Date))
            Me.ViewState("Tabla") = Me.Tabla

            Me.grilla.DataSource = Me.Tabla
            Me.grilla.DataBind()
        End If

    End Sub

    Private Sub cmdVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        If Me.Socio Is Nothing And Me.Club Is Nothing And Me.Federacion Is Nothing Then Response.Redirect("Default.aspx")
        If Not Me.Socio Is Nothing Then Response.Redirect("frmSocio.aspx")
        If Not Me.Club Is Nothing Then Response.Redirect("frmClub.aspx")
        If Not Me.Federacion Is Nothing Then Response.Redirect("frmFederacion.aspx")
    End Sub

    'Private Sub lnkExpoPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoPDF.Click
    '    If Me.Socio Is Nothing And Me.Club Is Nothing And Me.Federacion Is Nothing Then Utiles.ReportviewerToPdf(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "Comprobantes_Emitidos_AAT")
    '    If Not Me.Socio Is Nothing Then Utiles.ReportviewerToPdf(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "CtaCte_" + Me.Socio.Nombre)
    '    If Not Me.Club Is Nothing Then Utiles.ReportviewerToPdf(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "CtaCte_" + Me.Club.Descripcion)
    '    If Not Me.Federacion Is Nothing Then Utiles.ReportviewerToPdf(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "CtaCte_" + Me.Federacion.Descripcion)
    'End Sub

    'Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
    '    If Me.Socio Is Nothing And Me.Club Is Nothing And Me.Federacion Is Nothing Then Utiles.ReportviewerToExcel(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "Comprobantes_Emitidos_AAT")
    '    If Not Me.Socio Is Nothing Then Utiles.ReportviewerToExcel(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "CtaCte_" + Me.Socio.Nombre)
    '    If Not Me.Club Is Nothing Then Utiles.ReportviewerToExcel(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "CtaCte_" + Me.Club.Descripcion)
    '    If Not Me.Federacion Is Nothing Then Utiles.ReportviewerToExcel(Me.Tabla, Server.MapPath("reportes\reporteCtaCte.rdlc"), "CtaCte_" + Me.Federacion.Descripcion)
    'End Sub

End Class