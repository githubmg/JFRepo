Imports Negocio
Partial Public Class frmCuentaEdit
    Inherits System.Web.UI.Page

    Private _cuenta As Cuenta
    Public Property Cuenta() As Cuenta
        Get
            Return _cuenta
        End Get
        Set(ByVal value As Cuenta)
            _cuenta = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Request.QueryString("codigo") Is Nothing Then
            Dim codigo As String = Me.Request.QueryString("codigo").ToString()
            Me.Cuenta = Sistema.ObtenerCuenta(codigo)
        End If

        If Not Me.Page.IsPostBack Then
            Me.cmbTipoCuenta.DataSource = Sistema.VistaTipoCuenta()
            Me.cmbTipoCuenta.DataValueField = "idTipoCuenta"
            Me.cmbTipoCuenta.DataTextField = "descripcion"
            Me.cmbTipoCuenta.DataBind()

            Me.cmbCentroCostos.DataSource = Sistema.VistaCentroCostos()
            Me.cmbCentroCostos.DataValueField = "idCentroCostos"
            Me.cmbCentroCostos.DataTextField = "descripcion"
            Me.cmbCentroCostos.DataBind()

            If Not Me.Cuenta Is Nothing Then
                Me.txtCuenta.Text = Me.Cuenta.Codigo
                Me.txtDescripcion.Text = Me.Cuenta.Descripcion
                Me.cmbCentroCostos.SelectedValue = Me.Cuenta.CentroCostos.IdCentroCostos.ToString()
                Me.cmbTipoCuenta.SelectedValue = Me.Cuenta.TipoCuenta.IdTipoCuenta.ToString()
                Me.chkActiva.Checked = Me.Cuenta.Activa
                Me.chkImputable.Checked = Me.Cuenta.Imputable
                Me.chkAjustable.Checked = Me.Cuenta.Ajustable
            End If

        End If

    End Sub


    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario Then
            If Me.Cuenta Is Nothing Then
                Me.Cuenta = New Cuenta
                Me.Cuenta.Codigo = Me.txtCuenta.Text
                Me.Cuenta.Descripcion = Me.txtDescripcion.Text
                Me.Cuenta.Activa = Me.chkActiva.Checked
                Me.Cuenta.Imputable = Me.chkImputable.Checked
                Me.Cuenta.Ajustable = Me.chkAjustable.Checked
                Me.Cuenta.CentroCostos = Sistema.ObtenerCentroCostos(CType(Me.cmbCentroCostos.SelectedValue, Integer))
                Me.Cuenta.TipoCuenta = Sistema.ObtenerTipoCuenta(CType(Me.cmbTipoCuenta.SelectedValue, Integer))
                Sistema.AgregarCuenta(Me.Cuenta)

            Else
                Me.Cuenta.Codigo = Me.txtCuenta.Text
                Me.Cuenta.Descripcion = Me.txtDescripcion.Text
                Me.Cuenta.Activa = Me.chkActiva.Checked
                Me.Cuenta.Imputable = Me.chkImputable.Checked
                Me.Cuenta.Ajustable = Me.chkAjustable.Checked
                Me.Cuenta.CentroCostos = Sistema.ObtenerCentroCostos(CType(Me.cmbCentroCostos.SelectedValue, Integer))
                Me.Cuenta.TipoCuenta = Sistema.ObtenerTipoCuenta(CType(Me.cmbTipoCuenta.SelectedValue, Integer))
                Sistema.ActualizarCuenta(Me.Cuenta)
            End If

            Response.Redirect("frmCuenta.aspx")
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmCuenta.aspx")
    End Sub
    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""

        If Me.txtCuenta.Text.Length <> 12 Then
            esValido = False
            msg += "Error en el formato de la cuenta. (X.X.XX.XX.XX) <br />"
        End If

        If (Me.Cuenta Is Nothing) AndAlso (Not Sistema.ObtenerCuenta(Me.txtCuenta.Text) Is Nothing) Then
            esValido = False
            msg += "La cuenta ya existe. <br />"
        End If

        If Me.txtDescripcion.Text = "" Then
            esValido = False
            msg += "Error en la descripción de la cuenta. <br />"
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
End Class