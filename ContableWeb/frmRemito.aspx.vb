Imports Negocio
Imports Microsoft.Reporting.WebForms

Public Class frmRemito
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Me.grilla.DataSource = Sistema.VistaRemitoObj
            Me.grilla.DataBind()
    End Sub


    Protected Sub cmdGenerarFactura_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGenerarFactura.Click
        Response.Redirect("frmFacturarRemitos.aspx")
    End Sub
    Protected Function ValidarFactura(ByVal factura As Factura) As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True
        Dim cuitCliente As Long = factura.Remitos(0).Pedido.Cliente.Cuit
        For Each r As Remito In factura.Remitos
            If r.Pedido.Cliente.Cuit <> cuitCliente Then
                esValido = False
            End If
        Next
        If Not esValido Then
            strError += "Error: todos los remitos seleccionados deben pertenecer al mismo cliente.<br />"
        End If
        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = strError
        End If
        Return esValido
    End Function
   
    Protected Sub Check_Changed(ByVal sender As Object, ByVal e As EventArgs)
        Dim id = CType(sender, CheckBox).InputAttributes("value")

    End Sub
End Class