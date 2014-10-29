Imports Negocio

Public Class frmMovimientoCajaEdit
    Inherits System.Web.UI.Page
    Private _movimientoCaja As MovimientoCaja
    Public Property MovimientoCaja() As MovimientoCaja
        Get
            Return _movimientoCaja
        End Get
        Set(ByVal value As MovimientoCaja)
            _movimientoCaja = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarComboBanco()
            CargarComboMedioPago()
            CargarComboOrigenCheque()
            CargarComboTipoMovimiento()
            CargarComboDescripcionMovCaja()
            Me.txtFecha.Text = Today.ToShortDateString()
            Me.txtFechaEmision.Text = Today.ToShortDateString()
            Me.txtFechaVencimiento.Text = Today.ToShortDateString()
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario() Then
            If Me.MovimientoCaja Is Nothing Then
                Me.MovimientoCaja = New MovimientoCaja
                Me.MovimientoCaja.Fecha = CType(Me.txtFecha.Text, Date)
                Me.MovimientoCaja.Monto = CType(txtMonto.Text, Double)
                Me.MovimientoCaja.MedioPago = Sistema.ObtenerMedioPago(CType(cmbMedioPago.SelectedValue, Integer))
                Me.MovimientoCaja.TipoMovimiento = Sistema.ObtenerTipoMovimiento(CType(cmbTipoMovimiento.SelectedValue, Integer))
                Me.MovimientoCaja.DescripcionMovCaja = Sistema.ObtenerDescripcionMovCaja(CType(cmbDescripcionMovCaja.SelectedValue, Integer))
                If Me.MovimientoCaja.MedioPago.Descripcion.Trim.ToLower = "cheque" Then
                    Dim ch As New Cheque
                    ch.Banco = Sistema.ObtenerBanco(CType(cmbBanco.SelectedValue, Integer))
                    ch.EnCartera = False
                    ch.FechaEmision = CType(txtFechaEmision.Text, Date)
                    ch.FechaVencimiento = CType(txtFechaVencimiento.Text, Date)
                    ch.Importe = CType(txtMonto.Text, Double)
                    ch.Numero = txtNroCheque.Text
                    ch.OrigenCheque = Sistema.ObtenerOrigenCheque(CType(cmbOrigenCheque.SelectedValue, Integer))
                    ch.EnCartera = True
                    Me.MovimientoCaja.Cheque = ch
                End If

                Sistema.AgregarMovimientoCaja(Me.MovimientoCaja)
            Else

            End If

            Response.Redirect("frmMovimientoCaja.aspx")
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
        If Not Double.TryParse(txtMonto.Text, number) Then
            esValido = False
            msg += "El monto debe tener el formato 00,00.<br />"
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
    Protected Sub cmbMedioPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedioPago.SelectedIndexChanged
        If Me.cmbMedioPago.SelectedItem.Text = "Cheque" Then
            pnlCheque.Visible = True
        Else
            pnlCheque.Visible = False
        End If
    End Sub

    Private Sub CargarComboBanco()
        Me.cmbBanco.DataSource = Sistema.VistaBanco
        Me.cmbBanco.DataValueField = "idBanco"
        Me.cmbBanco.DataTextField = "descripcion"
        Me.cmbBanco.DataBind()
    End Sub
    Private Sub CargarComboDescripcionMovCaja()
        Me.cmbDescripcionMovCaja.DataSource = Sistema.VistaDescripcionMovCaja
        Me.cmbDescripcionMovCaja.DataValueField = "idDescripcionMovCaja"
        Me.cmbDescripcionMovCaja.DataTextField = "descripcion"
        Me.cmbDescripcionMovCaja.DataBind()
    End Sub

    Private Sub CargarComboTipoMovimiento()
        Me.cmbTipoMovimiento.DataSource = Sistema.VistaTipoMovimiento
        Me.cmbTipoMovimiento.DataValueField = "idTipoMovimiento"
        Me.cmbTipoMovimiento.DataTextField = "descripcion"
        Me.cmbTipoMovimiento.DataBind()
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

    Protected Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmMovimientoCaja.aspx")
    End Sub
End Class