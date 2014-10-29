Imports Negocio

Public Class frmFactura
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            Me.grilla.DataSource = Sistema.VistaFactura
            Me.grilla.DataBind()
        End If
    End Sub

End Class