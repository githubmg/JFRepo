Imports Negocio

Public Class ReporteStock
    Inherits System.Web.UI.Page
    Private _tabla As DataTable
    Public Property Tabla() As DataTable
        Get
            Return _tabla
        End Get
        Set(ByVal value As DataTable)
            _tabla = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            'Me.txtFechaDesde.Text = Today.AddMonths(-1).ToShortDateString()
            'Me.txtFechaHasta.Text = Today.ToShortDateString()
        Else
            If Not Me.ViewState("Tabla") Is Nothing Then
                Me.Tabla = CType(Me.ViewState("Tabla"), DataTable)
                Me.divExportacion.Visible = True
            Else
                Me.divExportacion.Visible = True
            End If
        End If
    End Sub
    Private Function ValidarForm() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        Dim inte As Integer
        Dim strarr() As String
        strarr = txtProducto.Text.Split(" ")
        If Not strarr(0) Is Nothing AndAlso strarr(0) <> "" Then
            If Not Integer.TryParse(strarr(0), inte) Then
                esValido = False
                msg += "Debe seleccionar un producto.<br />"
            Else
                Dim prod = Sistema.ObtenerProducto(CType(strarr(0), Integer))
                If prod Is Nothing Then
                    esValido = False
                    msg += "Debe seleccionar un producto válido.<br />"
                End If
            End If
        End If
        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = msg
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If
        Return esValido
    End Function

    Private Sub cmdVerValores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerValores.Click
        If ValidarForm() Then
            Dim strarr() As String
            strarr = txtProducto.Text.Split(" ")
            If strarr(0) = "" Then
                strarr(0) = "0"
            End If
            Me.Tabla = Sistema.ReporteProductoStock(CType(strarr(0), Integer))
            Me.ViewState("Tabla") = Me.Tabla
            Me.grilla.DataSource = Me.Tabla
            Me.grilla.DataBind()
        End If
    End Sub

    Protected Sub lnkExpoPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExpoPDF.Click
        Dim strarr() As String
        strarr = txtProducto.Text.Split(" ")
        Response.Redirect("frmViewer.aspx?tipo=ST&id=" & strarr(0))
    End Sub
    Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
        Dim strarr() As String
        strarr = txtProducto.Text.Split(" ")
        Response.Redirect("frmViewer.aspx?tipo=STEX&id=" & strarr(0))
    End Sub


End Class