Imports Microsoft.Reporting.WebForms
Public Class MiReporte
    Inherits ReportViewer

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        MyBase.Render(writer)
        Using sw As New System.IO.StringWriter
            Dim tmpWriter As New System.Web.UI.HtmlTextWriter(sw)
            Dim val As String = sw.ToString()
            val = val.Replace("!= 'javascript:\'\''", "!= 'javascript:\'\'' && false")
            writer.Write(val)
            MyBase.Render(tmpWriter)
        End Using

    End Sub

End Class
