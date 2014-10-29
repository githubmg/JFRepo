Imports Negocio
Public Class frmAgendaEdit
    Inherits System.Web.UI.Page
    Private _evento As Evento
    Public Property Evento() As Evento
        Get
            Return _evento
        End Get
        Set(ByVal value As Evento)
            _evento = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Evento = Sistema.ObtenerEvento(id)
        End If
        If Not Me.Page.IsPostBack Then
            If Not Me.Evento Is Nothing Then
                txtCliente.Text = Me.Evento.Cliente.IdCliente & " - " & Me.Evento.Cliente.Cuit & " - " & Me.Evento.Cliente.RazonSocial
                txtDatosContacto.Text = Me.Evento.DatosContacto.Replace("<br />", vbNewLine)
                txtFecha.Text = Me.Evento.Fecha.ToShortDateString
                txtTrabajo.Text = Me.Evento.Trabajo.Replace("<br />", vbNewLine)
                Select Case Me.Evento.Domicilio
                    Case "Irigoyen", "San Isidro", "Otros"
                        cmbDomicilio.SelectedItem.Text = Me.Evento.Domicilio
                    Case Else
                        txtDomicilio.Text = Me.Evento.Domicilio
                        pnlDomicilio.Visible = True
                        cmbDomicilio.SelectedItem.Text = "Domicilio"
                End Select
                cmbEstado.SelectedItem.Text = Me.Evento.Estado
            End If
        End If
    End Sub

    Private Sub cmbDomicilio_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbDomicilio.SelectedIndexChanged
        pnlDomicilio.Visible = (cmbDomicilio.SelectedItem.Text = "Domicilio")
    End Sub
    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        If Sistema.Obtenercliente(Sistema.ObtenerId(txtCliente.Text)) Is Nothing Then
            esValido = False
            msg = "Debe seleccionar un cliente"
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

    Private Sub cmdGuardar_Click(sender As Object, e As System.EventArgs) Handles cmdGuardar.Click
        If ValidarFormulario() Then
            If Me.Evento Is Nothing Then
                Me.Evento = New Evento
            End If
            Me.Evento.Cliente = Sistema.Obtenercliente(Sistema.ObtenerId(txtCliente.Text))
            Me.Evento.DatosContacto = txtDatosContacto.Text.Replace(vbNewLine, "<br />")
            Me.Evento.Fecha = CType(txtFecha.Text, Date)
            Me.Evento.Trabajo = txtTrabajo.Text.Replace(vbNewLine, "<br />")
            Me.Evento.Estado = cmbEstado.SelectedItem.Text
            If cmbDomicilio.SelectedItem.Text = "Domicilio" Then
                Me.Evento.Domicilio = txtDomicilio.Text
            Else
                Me.Evento.Domicilio = cmbDomicilio.SelectedItem.Text
            End If
            If Not Me.Request.QueryString("id") Is Nothing Then
                Sistema.ActualizarEvento(Me.Evento)
            Else
                Sistema.AgregarEvento(Me.Evento)
            End If
            Response.Redirect("frmAgenda.aspx")
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmAgenda.aspx")
    End Sub
End Class