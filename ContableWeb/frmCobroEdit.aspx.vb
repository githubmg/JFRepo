Imports Negocio

Public Class frmCobroEdit
    Inherits System.Web.UI.Page
    Private _cobro As Cobro
    Private _cobroItems As List(Of PedidoCabeCobroItem)
    Public Property Cobro() As Cobro
        Get
            Return _cobro
        End Get
        Set(ByVal value As Cobro)
            _cobro = value
        End Set
    End Property
    Public Property CobroItems() As List(Of PedidoCabeCobroItem)
        Get
            Return _cobroItems
        End Get
        Set(ByVal value As List(Of PedidoCabeCobroItem))
            _cobroItems = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarComboBanco()
            CargarComboMedioPago()
            CargarComboOrigenCheque()
            Me.txtFecha.Text = Today.ToShortDateString()
            Me.txtFechaEmision.Text = Today.ToShortDateString()
            Me.txtFechaVencimiento.Text = Today.ToShortDateString()
        Else 'PAGE IS POSTBACK
            If Not Me.ViewState("cobroItems") Is Nothing Then
                Me.CobroItems = CType(Me.ViewState("cobroItems"), List(Of PedidoCabeCobroItem))
                Me.grilla.DataSource = Me.CobroItems
                Me.grilla.DataBind()
            End If
        End If
    End Sub
    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.CobroItems Is Nothing Then
                Me.CobroItems = New List(Of PedidoCabeCobroItem)
            End If
            Dim pc As New PedidoCabe
            Dim strarr() As String
            strarr = txtPedido.Text.Split(" ")
            'Todo lo que se encuentra antes del espacio es el nro de compra
            pc = Sistema.ObtenerPedidoCabe(CType(strarr(0), Integer))
            Dim pi As New PedidoCabeCobroItem
            pi.PedidoCabe = pc
            pi.MontoCancelado = CType(txtMontoCancelado.Text, Double)
            Me.CobroItems.Add(pi)
            Me.ViewState("cobroItems") = Me.CobroItems
            Me.grilla.DataSource = Me.CobroItems
            Me.grilla.DataBind()
            txtPedido.Text = ""
            txtMontoCancelado.Text = ""
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario() Then
            Me.Cobro = New Cobro
            Me.Cobro.Fecha = CType(Me.txtFecha.Text, Date)
            Me.Cobro.Importe = CType(txtImporte.Text, Double)
            Me.Cobro.MedioPago = Sistema.ObtenerMedioPago(CType(cmbMedioPago.SelectedValue, Integer))
            Me.Cobro.Observaciones = txtObservaciones.Text
            Me.Cobro.Pedidos = Me.CobroItems
            If Me.Cobro.MedioPago.Descripcion.Trim.ToLower = "cheque" Then
                Dim ch As New Cheque
                ch.Banco = Sistema.ObtenerBanco(CType(cmbBanco.SelectedValue, Integer))
                ch.EnCartera = False
                ch.FechaEmision = CType(txtFechaEmision.Text, Date)
                ch.FechaVencimiento = CType(txtFechaVencimiento.Text, Date)
                ch.Importe = CType(txtImporte.Text, Double)
                ch.Numero = txtNroCheque.Text
                ch.OrigenCheque = Sistema.ObtenerOrigenCheque(CType(cmbOrigenCheque.SelectedValue, Integer))
                ch.EnCartera = True
                Me.Cobro.Cheque = ch
            End If
            Sistema.AgregarCobro(Me.Cobro)
        Response.Redirect("frmCobro.aspx")
        End If
    End Sub
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
        If Double.TryParse(txtImporte.Text, number) And Not Me.CobroItems Is Nothing Then
            Dim totalCanceladoEnPago As Double = 0
            For Each ic In Me.CobroItems
                totalCanceladoEnPago += ic.MontoCancelado
            Next
            If totalCanceladoEnPago <> CType(txtImporte.Text, Double) Then
                esValido = False
                msg += "El importe del cobro debe ser igual a la suma de los montos cancelados.<br />"
            End If
        End If
        If grilla.Items.Count = 0 Then
            esValido = False
            msg += "Debe agregar al menos un pedido para saldar.<br />"
        End If
        If Sistema.ObtenerMedioPago(CType(cmbMedioPago.SelectedValue, Integer)).Descripcion.Trim.ToLower = "cheque" Then
            'CHEQUE NO EN CARTERA
            If CType(txtFechaEmision.Text, Date) > CType(txtFechaVencimiento.Text, Date) Then
                esValido = False
                msg += "La fecha de emisión del cheque no puede ser mayor que la fecha de vencimiento.<br />"
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
    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        Dim strarr() As String
        strarr = txtPedido.Text.Split(" ")
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

            Dim pitem As PedidoCabe = Sistema.ObtenerPedidoCabe(CType(strarr(0), Integer))
            If pitem Is Nothing Then
                esValido = False
                msg += "Debe seleccionar un número de pedido válido.<br />"
            End If
            If Double.TryParse(txtMontoCancelado.Text, number) And Not pitem Is Nothing Then
                If CType(txtMontoCancelado.Text, Double) > Sistema.MontoSSaldarDePedido(pitem) Then
                    esValido = False
                    msg += "El monto cancelado no puede ser mayor que el monto sin saldar del pedido.<br />"
                End If
            End If
            If Not pitem Is Nothing And Not Me.CobroItems Is Nothing Then
                For Each ci In Me.CobroItems
                    If pitem.IdPedidoCabe = ci.PedidoCabe.IdPedidoCabe Then
                        esValido = False
                        msg += "Un mismo cobro no puede imputarse dos veces al mismo pedido.<br />"
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
    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.CobroItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), PedidoCabeCobroItem))
            Me.ViewState("cobroItems") = Me.CobroItems
            Me.grilla.DataSource = Me.CobroItems
            Me.grilla.DataBind()
        End If
    End Sub
    Protected Sub cmbMedioPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedioPago.SelectedIndexChanged
        If Me.cmbMedioPago.SelectedItem.Text = "Cheque" Then
            pnlCheque.Visible = True
        Else
            pnlCheque.Visible = False
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmCobro.aspx")
    End Sub
End Class