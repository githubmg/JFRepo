Imports Negocio
Partial Public Class frmAsiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            Me.grilla.DataSource = Sistema.VistaAsiento
            Me.grilla.DataBind()

            Me.cmbAsientoTipo.DataSource = Sistema.VistaAsientoTipo()
            Me.cmbAsientoTipo.DataTextField = "concepto"
            Me.cmbAsientoTipo.DataValueField = "idAsientoTipo"
            Me.cmbAsientoTipo.DataBind()
        End If

    End Sub

    Private Sub cmdNuevaCuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If Me.cmbAsientoTipo.SelectedValue > 0 Then
            Response.Redirect("frmAsientoEdit.aspx?idAsientoTipo=" + Me.cmbAsientoTipo.SelectedValue.ToString())
        Else
            Response.Redirect("frmAsientoEdit.aspx")
        End If

    End Sub

End Class