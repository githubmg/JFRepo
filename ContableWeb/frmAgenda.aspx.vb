Imports Negocio

Public Class frmAgenda
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
        Me.Tabla = Sistema.VistaEventoPorFecha(Me.txtFechaDesde.Text, Me.txtFechaHasta.Text)
        Me.ViewState("Tabla") = Me.Tabla
        Me.grilla.DataSource = Me.Tabla
        Me.grilla.DataBind()
    End Sub
    Protected Sub lnkExpoPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExpoPDF.Click
        Response.Redirect("frmViewer.aspx?tipo=AGENDA&desde=" & txtFechaDesde.Text & "&hasta=" & txtFechaHasta.Text)
    End Sub
    Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
        Response.Redirect("frmViewer.aspx?tipo=AGENDAEX&desde=" & txtFechaDesde.Text & "&hasta=" & txtFechaHasta.Text)
    End Sub

    Protected Sub btnNuevoEvento_Click(sender As Object, e As EventArgs) Handles btnNuevoEvento.Click
        Response.Redirect("frmAgendaEdit.aspx")
    End Sub
End Class