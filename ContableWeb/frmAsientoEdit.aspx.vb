Imports Negocio
Partial Public Class frmAsientoEdit
    Inherits System.Web.UI.Page

    Private _asiento As Asiento
    Private _asientoTipo As Asiento

    Private _asientoItems As List(Of AsientoItem)

    Public Property Asiento() As Asiento
        Get
            Return _asiento
        End Get
        Set(ByVal value As Asiento)
            _asiento = value
        End Set
    End Property
    Public Property AsientoTipo() As Asiento
        Get
            Return _asientoTipo
        End Get
        Set(ByVal value As Asiento)
            _asientoTipo = value
        End Set
    End Property

    Public Property AsientoItems() As List(Of AsientoItem)
        Get
            Return _asientoItems
        End Get
        Set(ByVal value As List(Of AsientoItem))
            _asientoItems = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Me.Request.QueryString("id") Is Nothing) And IsNumeric(Me.Request.QueryString("id")) Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Asiento = Sistema.obtenerasiento(id)
        End If



        If Not Me.Page.IsPostBack Then
            Me.cmbTipoComprobante.DataSource = Sistema.VistaTipoComprobante()
            Me.cmbTipoComprobante.DataValueField = "idTipoComprobante"
            Me.cmbTipoComprobante.DataTextField = "descripcion"
            Me.cmbTipoComprobante.DataBind()
            Me.txtFecha.Text = Today.ToShortDateString()

            If Not Me.Asiento Is Nothing Then
                Me.txtFecha.Text = Me.Asiento.Fecha.ToShortDateString()
                Me.txtNumeroComprobante.Text = Me.Asiento.NumeroComprobante
                Me.txtConcepto.Text = Me.Asiento.Concepto
                Me.txtObservaciones.Text = Me.Asiento.Observaciones
                Me.cmbTipoComprobante.SelectedValue = Me.Asiento.TipoComprobante.IdTipoComprobante.ToString()
                Me.AsientoItems = Me.Asiento.Items

                Me.ViewState("asientoItems") = Me.AsientoItems
                Me.grilla.DataSource = Me.AsientoItems
                Me.grilla.DataBind()
            End If

            If (Not Me.Request.QueryString("idAsientoTipo") Is Nothing) And IsNumeric(Me.Request.QueryString("idAsientoTipo")) Then
                Dim id As Integer = CType(Me.Request.QueryString("idAsientoTipo"), Integer)
                Me.AsientoTipo = Sistema.ObtenerAsientoTipo(id)

                Me.txtFecha.Text = Today.ToShortDateString()
                Me.txtNumeroComprobante.Text = ""
                Me.txtConcepto.Text = Me.AsientoTipo.Concepto
                Me.txtObservaciones.Text = Me.AsientoTipo.Observaciones
                Me.cmbTipoComprobante.SelectedValue = Me.AsientoTipo.TipoComprobante.IdTipoComprobante.ToString()
                Me.AsientoItems = Me.AsientoTipo.Items

                Me.ViewState("asientoItems") = Me.AsientoItems
                Me.grilla.DataSource = Me.AsientoItems
                Me.grilla.DataBind()
            End If

        Else 'PAGE IS POSTBACK
            If Not Me.ViewState("asientoItems") Is Nothing Then
                Me.AsientoItems = CType(Me.ViewState("asientoItems"), List(Of AsientoItem))
                Me.grilla.DataSource = Me.AsientoItems
                Me.grilla.DataBind()
            End If
        End If

    End Sub

    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.AsientoItems Is Nothing Then
                Me.AsientoItems = New List(Of AsientoItem)
            End If

            Dim ai As New AsientoItem
            ai.Cuenta = Sistema.ObtenerCuenta(Me.txtCuenta.Text)
            If Me.txtDebe.Text = "" Then
                ai.Debe = 0
            Else
                ai.Debe = CType(Me.txtDebe.Text, Double)
            End If
            If Me.txtHaber.Text = "" Then
                ai.Haber = 0
            Else
                ai.Haber = CType(Me.txtHaber.Text, Double)
            End If
            Me.AsientoItems.Add(ai)
            Me.ViewState("asientoItems") = Me.AsientoItems
            Me.grilla.DataSource = Me.AsientoItems
            Me.grilla.DataBind()

            Me.txtCuenta.Text = ""
            Me.txtDebe.Text = ""
            Me.txtHaber.Text = ""

        End If
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click

        'ASIENTO REAL
        If Me.ValidarFormulario() Then
            If Not Me.chkEsAsientoTipo.Checked Then
                If Me.Asiento Is Nothing Then
                    Me.Asiento = New Asiento
                    Me.Asiento.Concepto = Me.txtConcepto.Text
                    Me.Asiento.Fecha = CType(Me.txtFecha.Text, Date)
                    Me.Asiento.NumeroComprobante = Me.txtNumeroComprobante.Text
                    Me.Asiento.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
                    Me.Asiento.Observaciones = Me.txtObservaciones.Text
                    Me.Asiento.Items = Me.AsientoItems
                    Sistema.AgregarAsiento(Me.Asiento)
                Else
                    Me.Asiento.Concepto = Me.txtConcepto.Text
                    Me.Asiento.Fecha = CType(Me.txtFecha.Text, Date)
                    Me.Asiento.NumeroComprobante = Me.txtNumeroComprobante.Text
                    Me.Asiento.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
                    Me.Asiento.Observaciones = Me.txtObservaciones.Text
                    Me.Asiento.Items = Me.AsientoItems
                    Sistema.ActualizarAsiento(Me.Asiento)
                End If

            Else 'ASIENTO TIPO
                Me.Asiento = New Asiento
                Me.Asiento.Concepto = Me.txtConcepto.Text
                Me.Asiento.Fecha = CType(Me.txtFecha.Text, Date)
                Me.Asiento.NumeroComprobante = Me.txtNumeroComprobante.Text
                Me.Asiento.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(Me.cmbTipoComprobante.SelectedValue, Integer))
                Me.Asiento.Observaciones = Me.txtObservaciones.Text
                Me.Asiento.Items = Me.AsientoItems
                Sistema.AgregarAsientoTipo(Me.Asiento)
            End If

            Response.Redirect("frmAsiento.aspx")
        End If
    End Sub

    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.AsientoItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), AsientoItem))
            Me.ViewState("asientoItems") = Me.AsientoItems
            Me.grilla.DataSource = Me.AsientoItems
            Me.grilla.DataBind()

        ElseIf e.CommandName = "Editar" Then
            Dim ai As AsientoItem = CType(Me.grilla.DataSource(e.Item.ItemIndex), AsientoItem)

            Me.txtCuenta.Text = ai.Cuenta.ToString()
            If ai.Debe <> 0 Then
                Me.txtDebe.Text = ai.Debe.ToString()
            Else
                Me.txtDebe.Text = ""
            End If

            If ai.Haber <> 0 Then
                Me.txtHaber.Text = ai.Haber.ToString()
            Else
                Me.txtHaber.Text = ""
            End If

            Me.AsientoItems.Remove(ai)
            Me.ViewState("asientoItems") = Me.AsientoItems
            Me.grilla.DataSource = Me.AsientoItems
            Me.grilla.DataBind()
        End If
    End Sub

    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        Dim cuenta As Cuenta = Sistema.ObtenerCuenta(Left(Me.txtCuenta.Text, 12))
        If cuenta Is Nothing Then
            esValido = False
            msg += "El código de cuenta no es válido.<br />"
        End If

        If (Not cuenta Is Nothing) AndAlso (Not cuenta.Imputable) Then
            esValido = False
            msg += "La cuenta no es imputable.<br />"
        End If

        If (Not cuenta Is Nothing) AndAlso (Not cuenta.Activa) Then
            esValido = False
            msg += "La cuenta no está activa.<br />"
        End If


        If Not IsNumeric(Me.txtDebe.Text) And Me.txtDebe.Text <> "" Then
            esValido = False
            msg += "El monto del campo Debe no es válido.<br />"
        End If

        If Not IsNumeric(Me.txtHaber.Text) And Me.txtHaber.Text <> "" Then
            esValido = False
            msg += "El monto del campo Haber no es válido.<br />"
        End If

        If Me.txtDebe.Text <> "" And Me.txtHaber.Text <> "" Then
            esValido = False
            msg += "Sólo se puede completar el campo Debe o el Campo Haber.<br />"
        End If
        If Me.txtDebe.Text = "" And Me.txtHaber.Text = "" Then
            esValido = False
            msg += "Debe por lo menos completar uno de los campos Debe o el Campo Haber.<br />"
        End If

        If Me.chkEsAsientoTipo.Checked Then
            If Me.txtDebe.Text <> "1" And Me.txtDebe.Text <> "" Then
                esValido = False
                msg += "Para 'Asientos Tipo', el único valor posible para el Debe es el 1.<br />"
            End If
            If Me.txtHaber.Text <> "1" And Me.txtHaber.Text <> "" Then
                esValido = False
                msg += "Para 'Asientos Tipo', el único valor posible para el Haber es el 1.<br />"
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


        If Me.txtNumeroComprobante.Text = "" Then
            esValido = False
            msg += "El número de comprobante no puede estar vacío.<br />"
        End If

        If Me.txtConcepto.Text = "" Then
            esValido = False
            msg += "El concepto no puede estar vacío.<br />"
        End If

        Dim sumDebe As Double = 0
        Dim sumHaber As Double = 0
        If Not Me.AsientoItems Is Nothing Then
            For Each i As AsientoItem In Me.AsientoItems
                sumDebe += i.Debe
                sumHaber += i.Haber
            Next
        End If

        If sumDebe <> sumHaber Then
            esValido = False
            msg += "El Debe y el Haber no están balanceados.<br />"
        End If
        If sumDebe + sumHaber = 0 Then
            esValido = False
            msg += "No hay importes en el Debe y el Haber.<br />"
        End If

        'VALIDACION ASIENTOS TIPO
        If Me.chkEsAsientoTipo.Checked AndAlso Not Me.AsientoItems Is Nothing Then
            Dim validaAsientosTipo As Boolean = True
            For Each i As AsientoItem In Me.AsientoItems
                If (i.Debe > 0 And i.Debe <> 1) Or (i.Haber > 0 And i.Haber <> 1) Then
                    validaAsientosTipo = False
                End If
            Next
            If Not validaAsientosTipo Then
                esValido = False
                msg += "Para 'Asientos Tipo', los únicos valores válidos son 1.<br />"
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

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmAsiento.aspx")
    End Sub
End Class