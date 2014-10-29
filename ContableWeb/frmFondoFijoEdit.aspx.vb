Imports Negocio
Partial Public Class frmFondoFijoEdit
    Inherits System.Web.UI.Page

    Private _FondoFijo As FondoFijo
    Private _FondoFijoItems As List(Of FondoFijoItem)

    Public Property FondoFijo() As FondoFijo
        Get
            Return Me._FondoFijo
        End Get
        Set(ByVal value As FondoFijo)
            Me._FondoFijo = value
        End Set
    End Property
    Public Property FondoFijoItems() As List(Of FondoFijoItem)
        Get
            Return _FondoFijoItems
        End Get
        Set(ByVal value As List(Of FondoFijoItem))
            _FondoFijoItems = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.FondoFijo = Sistema.ObtenerFondoFijo(id)
        End If

        If Not Me.Page.IsPostBack Then

            Me.cmbFormaPago.DataSource = Sistema.VistaFormaPagoFondoFijo()
            Me.cmbFormaPago.DataValueField = "idFormaPago"
            Me.cmbFormaPago.DataTextField = "descripcion"
            Me.cmbFormaPago.DataBind()

            If Not Me.FondoFijo Is Nothing Then

                Me.cmdGuardar.Enabled = False 'ESTO LO HAGO PARA EVITAR QUE CREE MÁS DE UN ASIENTO

                'Me.txtCuenta.Text = Me.FondoFijo.Cuenta.ToString()
                Me.txtFecha.Text = Me.FondoFijo.Fecha.ToShortDateString()
                Me.txtObservaciones.Text = Me.FondoFijo.Observaciones()
                Me.ViewState("FondoFijoItems") = Me.FondoFijoItems
                Me.grilla.DataSource = Me.FondoFijoItems
                Me.grilla.DataBind()


            End If
        Else
            If Not Me.ViewState("FondoFijoItems") Is Nothing Then
                Me.FondoFijoItems = CType(Me.ViewState("FondoFijoItems"), List(Of FondoFijoItem))
                Me.grilla.DataSource = Me.FondoFijoItems
                Me.grilla.DataBind()
            End If
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


        If Not IsNumeric(Me.txtMonto.Text) Or (Me.txtMonto.Text = "") Then
            esValido = False
            msg += "El monto no es válido.<br />"
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

    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True

        If Not IsDate(Me.txtFecha.Text) Then
            strError += "Error en la fecha.<br />"
            esValido = False
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = strError
        End If
        Return esValido
    End Function

    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.FondoFijoItems Is Nothing Then
                Me.FondoFijoItems = New List(Of FondoFijoItem)
            End If

            Dim fi As New FondoFijoItem
            fi.Cuenta = Sistema.ObtenerCuenta(Me.txtCuenta.Text)
            fi.Monto = CType(Me.txtMonto.Text, Double)
            fi.Observaciones = Me.txtObservacionesItem.Text
 
            Me.FondoFijoItems.Add(fi)
            Me.ViewState("FondoFijoItems") = Me.FondoFijoItems
            Me.grilla.DataSource = Me.FondoFijoItems
            Me.grilla.DataBind()

            Me.txtCuenta.Text = ""
            Me.txtMonto.Text = ""
            Me.txtObservacionesItem.Text = ""

        End If
    End Sub


    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.FondoFijoItems.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), FondoFijoItem))
            Me.ViewState("FondoFijoItems") = Me.FondoFijoItems
            Me.grilla.DataSource = Me.FondoFijoItems
            Me.grilla.DataBind()

        ElseIf e.CommandName = "Editar" Then
            Dim fi As FondoFijoItem = CType(Me.grilla.DataSource(e.Item.ItemIndex), FondoFijoItem)

            Me.txtCuenta.Text = fi.Cuenta.ToString()
            Me.txtMonto.Text = fi.Monto.ToString()
            Me.txtObservacionesItem.Text = fi.Observaciones

            Me.FondoFijoItems.Remove(fi)
            Me.ViewState("FondoFijoItems") = Me.FondoFijoItems
            Me.grilla.DataSource = Me.FondoFijoItems
            Me.grilla.DataBind()
        End If
    End Sub


    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try

            If Me.validarForm() Then
                If Me.FondoFijo Is Nothing Then
                    Me.FondoFijo = New FondoFijo

                    'Me.FondoFijo.Cuenta = Sistema.ObtenerCuenta(Me.txtCuenta.Text)
                    Me.FondoFijo.Fecha = CType(Me.txtFecha.Text, Date)
                    Me.FondoFijo.FormaPago = Sistema.ObtenerFormaPago(CType(Me.cmbFormaPago.SelectedValue, Integer))
                    Me.FondoFijo.Observaciones = Me.txtObservaciones.Text
                    Me.FondoFijo.Items = Me.FondoFijoItems

                    Me.FondoFijo.IdFondoFijo = Sistema.AgregarFondoFijo(Me.FondoFijo)
                Else
                    'Me.FondoFijo.Cuenta = Sistema.ObtenerCuenta(Me.txtCuenta.Text)
                    Me.FondoFijo.Fecha = CType(Me.txtFecha.Text, Date)
                    Me.FondoFijo.FormaPago = Sistema.ObtenerFormaPago(CType(Me.cmbFormaPago.SelectedValue, Integer))
                    Me.FondoFijo.Observaciones = Me.txtObservaciones.Text
                    Me.FondoFijo.Items = Me.FondoFijoItems

                    Me.FondoFijo.IdFondoFijo = Sistema.ActualizarFondoFijo(Me.FondoFijo)
                End If

                Dim a As New Asiento(Me.FondoFijo)
                Sistema.AgregarAsiento(a)

                Dim mc As New MovimientoCajaCabe(Me.FondoFijo)
                Sistema.AgregarMovimientoCajaCabe(mc)

                Response.Redirect("frmFondoFijo.aspx")
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try




    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmFondoFijo.aspx")
    End Sub
End Class