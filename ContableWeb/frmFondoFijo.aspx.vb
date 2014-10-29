Imports Negocio
Partial Public Class frmFondoFijo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.grilla.DataSource = Sistema.VistaFondoFijo()
        Me.grilla.DataBind()
    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Response.Redirect("frmFondoFijoEdit.aspx")
    End Sub

End Class