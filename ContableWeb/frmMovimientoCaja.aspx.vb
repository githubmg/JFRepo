Imports Negocio

Public Class frmMovimientoCaja
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            Me.grilla.DataSource = Sistema.VistaMovimientoCaja
            Me.grilla.DataBind()
        End If
    End Sub
    Private Sub cmdNuevaCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Response.Redirect("frmMovimientoCajaEdit.aspx")
    End Sub
End Class