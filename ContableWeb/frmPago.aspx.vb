Imports Negocio

Public Class frmPagos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            Me.grilla.DataSource = Sistema.VistaPago
            Me.grilla.DataBind()
        End If
    End Sub
    Private Sub cmdNuevaCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Response.Redirect("frmPagoEdit.aspx")
    End Sub
    Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
        Response.Redirect("frmViewer.aspx?tipo=PAGEX")
    End Sub
End Class