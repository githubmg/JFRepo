Imports Negocio

Public Class frmPagoEdit
    Inherits System.Web.UI.Page
    Private _pago As Pago
    Private _pagoItems As List(Of CompraCabePagoItem)
    Public Property Pago() As Pago
        Get
            Return _pago
        End Get
        Set(ByVal value As Pago)
            _pago = value
        End Set
    End Property
    Public Property PagoItems() As List(Of CompraCabePagoItem)
        Get
            Return _pagoItems
        End Get
        Set(ByVal value As List(Of CompraCabePagoItem))
            _pagoItems = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarComboMedioPago()
            CargarComboSiNo()
            CargarComboOrigenCheque()
            CargarComboBanco()
            Me.txtFecha.Text = Today.ToShortDateString()
            Me.txtFechaEmision.Text = Today.ToShortDateString()
            Me.txtFechaVencimiento.Text = Today.ToShortDateString()
        Else 'PAGE IS POSTBACK
            If Not Me.ViewState("pagoItems") Is Nothing Then
                Me.PagoItems = CType(Me.ViewState("pagoItems"), List(Of CompraCabePagoItem))
                Me.grilla.DataSource = Me.PagoItems
                Me.grilla.DataBind()
            End If
        End If
    End Sub
    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.PagoItems Is Nothing Then
                Me.PagoItems = New List(Of CompraCabePagoItem)
            End If
            Dim cc As New CompraCabe
            Dim strarr() As String
            strarr = txtCompra.Text.Split(" ")
            'Todo lo que se encuentra antes del espacio es el nro de compra
            cc = Sistema.ObtenerCompraCabe(CType(strarr(0), Integer))
            Dim pi As New CompraCabePagoItem
            pi.CompraCabe = cc
            pi.MontoCancelado = CType(txtMontoCancelado.Text, Double)
            Me.PagoItems.Add(pi)
            Me.ViewState("pagoItems") = Me.PagoItems
            Me.grilla.DataSource = Me.PagoItems
            Me.grilla.DataBind()
            txtCompra.Text = ""
            txtMontoCancelado.Text = ""
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario() Then
            Me.Pago = New Pago
            Me.Pago.Fecha = CType(Me.txtFecha.Text, Date)
            Me.Pago.Importe = CType(txtImporte.Text, Double)
            Me.Pago.MedioPago = Sistema.ObtenerMedioPago(CType(cmbMedioPago.SelectedValue, Integer))
            Me.Pago.Observaciones = txtObservaciones.Text
            Me.Pago.Compras = Me.PagoItems
            If Me.Pago.MedioPago.Descripcion.Trim.ToLower = "cheque" Then
                If Me.cmbEsCartera.SelectedValue = "Si" Then
                    Dim strarr() As String = txtChequeCartera.Text.Split(" ")
                    Me.Pago.Cheque = Sistema.ObtenerCheque(CType(strarr(0), Integer))
                Else
                    Dim ch As New Cheque
                    ch.EnCartera = False
                    ch.FechaEmision = CType(txtFechaEmision.Text, Date)
                    ch.FechaVencimiento = CType(txtFechaVencimiento.Text, Date)
                    ch.Importe = CType(txtImporte.Text, Double)
                    ch.Numero = txtNroCheque.Text
                    ch.OrigenCheque = Sistema.ObtenerOrigenCheque(CType(cmbOrigenCheque.SelectedValue, Integer))
                    ch.Banco = Sistema.ObtenerBanco(CType(cmbBanco.SelectedValue, Integer))
                    Me.Pago.Cheque = ch
                End If
            End If
            Sistema.AgregarPago(Me.Pago)
            Response.Redirect("frmPago.aspx")
        End If
    End Sub
    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.PagoItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), CompraCabePagoItem))
            Me.ViewState("pagoItems") = Me.PagoItems
            Me.grilla.DataSource = Me.PagoItems
            Me.grilla.DataBind()
        End If
    End Sub

    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        Dim strarr() As String
        strarr = txtCompra.Text.Split(" ")
        Dim number As Double
        If Not Double.TryParse(txtMontoCancelado.Text, number) Then
            esValido = False
            msg += "El monto cancelado debe tener el formato 00,00.<br />"
        Else
            If CType(txtMontoCancelado.Text, Double) <= 0 Then
                esValido = False
                msg += "El monto cancelado debe ser mayor que $0.<br />"
            End If
        End If
        Dim inte As Integer
        If Not Integer.TryParse(strarr(0), inte) Then
            esValido = False
            msg += "Debe seleccionar una compra.<br />"
        Else

            Dim cItem As CompraCabe = Sistema.ObtenerCompraCabe(CType(strarr(0), Integer))
            If cItem Is Nothing Then
                esValido = False
                msg += "Debe seleccionar un número de compra válido.<br />"
            End If
            If Double.TryParse(txtMontoCancelado.Text, number) And Not cItem Is Nothing Then
                If CType(txtMontoCancelado.Text, Double) > Sistema.MontoSSaldarDeCompra(cItem) Then
                    esValido = False
                    msg += "El monto cancelado no puede ser mayor que el monto sin saldar de la compra.<br />"
                End If
            End If
            If Not cItem Is Nothing And Not Me.PagoItems Is Nothing Then
                For Each ip In Me.PagoItems
                    If cItem.IdCompraCabe = ip.CompraCabe.IdCompraCabe Then
                        esValido = False
                        msg += "Un mismo pago no puede imputarse dos veces a la misma compra.<br />"
                    End If
                Next
            End If
        End If
        If Not esValido Then
            Me.divErrorItem.Visible = True
            Me.lblErrorItem.Text = msg
        Else
            Me.divErrorItem.Visible = False
            Me.lblErrorItem.Text = ""
        End If
        Return esValido
    End Function
    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        If Not IsDate(Me.txtFecha.Text) Then
            esValido = False
            msg += "La fecha no es válida.<br />"
        End If
        Dim number As Double
        If Not Double.TryParse(txtImporte.Text, number) Then
            esValido = False
            msg += "El importe debe tener el formato 00,00.<br />"
        End If
        If Double.TryParse(txtImporte.Text, number) And Not Me.PagoItems Is Nothing Then
            Dim totalCanceladoEnPago As Double = 0
            For Each ip In Me.PagoItems
                totalCanceladoEnPago += ip.MontoCancelado
            Next
            If totalCanceladoEnPago <> CType(txtImporte.Text, Double) Then
                esValido = False
                msg += "El importe abonado en el pago debe ser igual a la suma de los montos cancelados.<br />"
            End If
        End If
        If grilla.Items.Count = 0 Then
            esValido = False
            msg += "Debe agregar al menos una compra para saldar.<br />"
        Else
            If Sistema.ObtenerMedioPago(CType(cmbMedioPago.SelectedValue, Integer)).Descripcion.Trim.ToLower = "cheque" Then
                If Me.cmbEsCartera.SelectedValue = "Si" Then
                    'En CARTERA
                    Dim strarr() As String = txtChequeCartera.Text.Split(" ")
                    Dim ch = Sistema.ObtenerCheque(CType(strarr(0), Integer))
                    If ch Is Nothing Then
                        esValido = False
                        msg += "Debe seleccionar un número válido de cheque en cartera.<br />"
                    Else
                        If ch.EnCartera = False Then
                            esValido = False
                            msg += "Debe seleccionar un número válido de cheque en cartera.<br />"
                        End If
                    End If
                Else
                    'CHEQUE NO EN CARTERA
                    If CType(txtFechaEmision.Text, Date) > CType(txtFechaVencimiento.Text, Date) Then
                        esValido = False
                        msg += "La fecha de emisión del cheque no puede ser mayor que la fecha de vencimiento.<br />"
                    End If
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
    Private Sub CargarComboBanco()
        Me.cmbBanco.DataSource = Sistema.VistaBanco
        Me.cmbBanco.DataValueField = "idBanco"
        Me.cmbBanco.DataTextField = "descripcion"
        Me.cmbBanco.DataBind()
    End Sub
    Private Sub CargarComboMedioPago()
        Me.cmbMedioPago.DataSource = Sistema.VistaMedioPago
        Me.cmbMedioPago.DataValueField = "idMedioPago"
        Me.cmbMedioPago.DataTextField = "descripcion"
        Me.cmbMedioPago.DataBind()
    End Sub
    Private Sub CargarComboOrigenCheque()
        Me.cmbOrigenCheque.DataSource = Sistema.VistaOrigenCheque
        Me.cmbOrigenCheque.DataValueField = "idOrigenCheque"
        Me.cmbOrigenCheque.DataTextField = "descripcion"
        Me.cmbOrigenCheque.DataBind()
    End Sub
    Private Sub CargarComboSiNo()
        Me.cmbEsCartera.Items.Add(New ListItem("Seleccionar..."))
        Me.cmbEsCartera.Items.Add(New ListItem("Si"))
        Me.cmbEsCartera.Items.Add(New ListItem("No"))
    End Sub
    Private Sub cmbMedioPago_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbMedioPago.SelectedIndexChanged
        If Me.cmbMedioPago.SelectedItem.Text = "Cheque" Then
            pnlCheque.Visible = True
        Else
            pnlCheque.Visible = False
        End If
    End Sub


    Private Sub cmbEsCartera_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbEsCartera.SelectedIndexChanged
        If Me.cmbEsCartera.SelectedValue = "Si" Then
            pnlChequeCartera.Visible = True
            pnlChequeComun.Visible = False
        Else
            pnlChequeCartera.Visible = False
            pnlChequeComun.Visible = True
        End If
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmPago.aspx")
    End Sub
End Class