Imports Negocio

Public Class frmDepositoEdit
    Inherits System.Web.UI.Page
    Private _deposito As Deposito
    Public Property Deposito() As Deposito
        Get
            Return _Deposito
        End Get
        Set(ByVal value As Deposito)
            _Deposito = value
        End Set
    End Property
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarComboBanco()
            Me.txtFecha.Text = Today.ToShortDateString()
        End If
    End Sub
   
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario() Then
            Me.Deposito = New Deposito
            Me.Deposito.Fecha = CType(Me.txtFecha.Text, Date)
            Me.Deposito.Banco = Sistema.ObtenerBanco(CType(cmbBanco.SelectedValue, Integer))
            Dim strarr() As String = txtChequeCartera.Text.Split(" ")
            Me.Deposito.Cheque = Sistema.ObtenerCheque(CType(strarr(0), Integer))
            Me.Deposito.NumeroTransaccion = txtNroTransaccion.Text
            Sistema.AgregarDeposito(Me.Deposito)
            Me.Deposito.Cheque.EnCartera = False
            Sistema.ActualizarCheque(Me.Deposito.Cheque)
            Response.Redirect("frmDeposito.aspx")
        End If
    End Sub
  

    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        If Not IsDate(Me.txtFecha.Text) Then
            esValido = False
            msg += "La fecha no es válida.<br />"
        End If
        Dim inte As Integer
        Dim strarr = txtChequeCartera.Text.Split(" ")

        If Not Integer.TryParse(strarr(0), inte) Then
            esValido = False
            msg += "Debe seleccionar un cheque.<br />"
        Else

            Dim ch As Cheque = Sistema.ObtenerCheque(CType(strarr(0), Integer))
            If ch Is Nothing Then
                esValido = False
                msg += "Debe seleccionar un número de cheque válido.<br />"
            Else
                If ch.EnCartera = False Then
                    esValido = False
                    msg += "Debe seleccionar un número válido de cheque en cartera.<br />"
                End If
            End If
           
        End If
        If txtNroTransaccion.Text = "" Then
            esValido = False
            msg += "Debe ingresar un nro. de transacción.<br />"
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
   
    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmDeposito.aspx")
    End Sub

End Class