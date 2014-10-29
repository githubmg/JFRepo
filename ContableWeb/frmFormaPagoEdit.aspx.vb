Imports Negocio


Partial Public Class frmFormaPagoEdit
    Inherits System.Web.UI.Page

    Private _FormaPago As FormaPago
    Public Property FormaPago() As FormaPago
        Get
            Return Me._FormaPago
        End Get
        Set(ByVal value As FormaPago)
            Me._FormaPago = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.FormaPago = Sistema.ObtenerFormaPago(id)
        End If

        If Not Me.Page.IsPostBack Then

            Me.cmbMoneda.DataSource = Sistema.VistaMoneda()
            Me.cmbMoneda.DataTextField = "Descripcion"
            Me.cmbMoneda.DataValueField = "idMoneda"
            Me.cmbMoneda.DataBind()


            If Not Me.FormaPago Is Nothing Then
                Me.txtDescripcion.Text = Me.FormaPago.Descripcion
                Me.txtCuenta.Text = Me.FormaPago.Cuenta.ToString()
                Me.chkEsCheque.Checked = Me.FormaPago.EsCheque
                Me.chkEsTarjeta.Checked = Me.FormaPago.EsTarjeta
                Me.chkEsInterdeposito.Checked = Me.FormaPago.EsInterdeposito
                Me.chkUsadoParaFondoFijo.Checked = Me.FormaPago.UsadoParaFondoFijo
                Me.cmbMoneda.SelectedValue = Me.FormaPago.Moneda.IdMoneda
            End If

        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True

        If Me.txtDescripcion.Text = "" Then
            strError += "La descripcion no puede estar vacía.<br />"
            esValido = False
        End If

        Dim cuenta As Cuenta = Sistema.ObtenerCuenta(Left(Me.txtCuenta.Text, 12))
        If cuenta Is Nothing Then
            esValido = False
            strError += "El código de cuenta no es válido.<br />"
        End If

        If (Not cuenta Is Nothing) AndAlso (Not cuenta.Imputable) Then
            esValido = False
            strError += "La cuenta no es imputable.<br />"
        End If

        If (Not cuenta Is Nothing) AndAlso (Not cuenta.Activa) Then
            esValido = False
            strError += "La cuenta no está activa.<br />"
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = strError
        End If
        Return esValido
    End Function
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try

            If Me.validarForm() Then
                If Me.FormaPago Is Nothing Then
                    Me.FormaPago = New FormaPago
                    Me.FormaPago.Descripcion = Me.txtDescripcion.Text
                    Me.FormaPago.Cuenta = Sistema.ObtenerCuenta(Left(Me.txtCuenta.Text, 12))
                    Me.FormaPago.EsCheque = Me.chkEsCheque.Checked
                    Me.FormaPago.EsTarjeta = Me.chkEsTarjeta.Checked
                    Me.FormaPago.EsInterdeposito = Me.chkEsInterdeposito.Checked
                    Me.FormaPago.UsadoParaFondoFijo = Me.chkUsadoParaFondoFijo.Checked
                    Me.FormaPago.Moneda = Sistema.ObtenerMoneda(CType(Me.cmbMoneda.SelectedValue, Integer))
                    Sistema.AgregarFormaPago(Me.FormaPago)
                    Response.Redirect("frmFormaPago.aspx")
                Else
                    Me.FormaPago.Descripcion = Me.txtDescripcion.Text
                    Me.FormaPago.Cuenta = Sistema.ObtenerCuenta(Left(Me.txtCuenta.Text, 12))
                    Me.FormaPago.EsCheque = Me.chkEsCheque.Checked
                    Me.FormaPago.EsTarjeta = Me.chkEsTarjeta.Checked
                    Me.FormaPago.EsInterdeposito = Me.chkEsInterdeposito.Checked
                    Me.FormaPago.UsadoParaFondoFijo = Me.chkUsadoParaFondoFijo.Checked
                    Me.FormaPago.Moneda = Sistema.ObtenerMoneda(CType(Me.cmbMoneda.SelectedValue, Integer))
                    Sistema.ActualizarFormaPago(Me.FormaPago)
                    Response.Redirect("frmFormaPago.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmFormaPago.aspx")
    End Sub
End Class