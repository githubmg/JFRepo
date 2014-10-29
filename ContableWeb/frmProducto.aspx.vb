Imports Negocio

Public Class frmProducto
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.grilla.DataSource = Sistema.VistaProducto()
        Me.grilla.DataBind()
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Response.Redirect("frmProductoEdit.aspx")
    End Sub
    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Sistema.BorrarUsuario(CType(e.CommandArgument.ToString, Integer))
            Me.grilla.DataSource = Sistema.VistaProducto()
            Me.grilla.DataBind()
        End If
    End Sub
End Class