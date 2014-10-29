Imports Negocio

Public Class ReporteValoresCedidos
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
    Private _cheque As Cheque
    Public Property Cheque() As Cheque
        Get
            Return _cheque
        End Get
        Set(ByVal value As Cheque)
            _cheque = value
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
        Dim msgError As String = ""
        Dim esValido As Boolean = True

        If Not Me.txtFechaDesde.Text = "" Then
            If Not IsDate(Me.txtFechaDesde.Text) Then
                msgError += "Error en la fecha desde.<br />"
                esValido = False
            End If
        End If
        If Not Me.txtFechaHasta.Text = "" Then
            If Not IsDate(Me.txtFechaHasta.Text) Then
                msgError += "Error en la fecha hasta.<br />"
                esValido = False
            End If
        End If
        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = msgError
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = ""
        End If

        Return esValido
    End Function

    Private Sub cmdVerValores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerValores.Click
        divErrorCheque.Visible = False
        divExito.Visible = False
        If ValidarForm() Then
            Me.Tabla = Sistema.VistaValoresCedidos(Me.txtFechaDesde.Text, Me.txtFechaHasta.Text, Me.cmbEstadoCheque.SelectedValue)
            Me.ViewState("Tabla") = Me.Tabla
            Me.grilla.DataSource = Me.Tabla
            Me.grilla.DataBind()
        End If
    End Sub

    Protected Sub lnkExpoPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExpoPDF.Click
        Response.Redirect("frmViewer.aspx?tipo=VACE&desde=" & txtFechaDesde.Text & "&hasta=" & txtFechaHasta.Text)
    End Sub
    Private Sub lnkExpoXLS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkExpoXLS.Click
        Response.Redirect("frmViewer.aspx?tipo=VACEEX&desde=" & txtFechaDesde.Text & "&hasta=" & txtFechaHasta.Text)
    End Sub

    Protected Sub btnMarcarCobrado_Click(sender As Object, e As EventArgs) Handles btnMarcarCobrado.Click
        divExito.Visible = False
        If ValidarCheque() Then
            Me.Cheque.Cobrado = True
            Sistema.ActualizarCheque(Me.Cheque)
            txtCheque.Text = ""
            divExito.Visible = True
        End If
    End Sub
    Private Function ValidarCheque() As Boolean
        Dim msgError As String = ""
        Dim esValido As Boolean = True
        Dim strarr As String() = txtCheque.Text.Split("-")
        Dim i As Integer
        If Not Integer.TryParse(strarr(0), i) Then
            msgError += "Error. Seleccione un cheque para marcar como cobrado.<br />"
            esValido = False
        Else
            Me.Cheque = Sistema.ObtenerCheque(CInt(strarr(0)))
            If Me.Cheque Is Nothing Then
                msgError += "Error. Seleccione un cheque para marcar como cobrado.<br />"
                esValido = False
            End If
        End If
        If Not esValido Then
            Me.divErrorCheque.Visible = True
            Me.lblErrorFormCheque.Text = msgError
        Else
            Me.divErrorCheque.Visible = False
            Me.lblErrorFormCheque.Text = ""
        End If
        Return esValido
    End Function
End Class