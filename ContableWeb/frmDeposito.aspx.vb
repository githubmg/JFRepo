Imports Negocio

Public Class frmDeposito
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.grilla.DataSource = Sistema.VistaDeposito()
        Me.grilla.DataBind()
    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Response.Redirect("frmDepositoEdit.aspx")
    End Sub

End Class