Imports Negocio
Imports Microsoft.Reporting.WebForms
Partial Public Class frmReporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim proveedor As New Proveedor
        proveedor.IdProveedor = 1

        Dim dt As DataTable = Sistema.VistaCtaCteProveedor(proveedor, #12/1/2012#, #12/31/2012#)
        ReportViewer1.Visible = True
        Dim rds As ReportDataSource = New ReportDataSource("Datos", dt)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class