Imports Negocio
Partial Public Class frmCuenta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.grilla.DataSource = Sistema.VistaCuenta
        Me.grilla.DataBind()
    End Sub

    Private Sub cmdNuevaCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevaCuenta.Click
        Response.Redirect("frmCuentaEdit.aspx")
    End Sub
End Class