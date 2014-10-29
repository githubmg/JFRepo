Imports Negocio
Public Class frmUsuarioPantalla
    Inherits System.Web.UI.Page
    Private _pantallas As List(Of PantallaUsuarioItem)
    Private _usuario As Usuario
    Public Property Pantallas() As List(Of PantallaUsuarioItem)
        Get
            Return _pantallas
        End Get
        Set(ByVal value As List(Of PantallaUsuarioItem))
            _pantallas = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Page.IsPostBack Then
            If Not Me.ViewState("Pantallas") Is Nothing Then
                Me.Pantallas = CType(Me.ViewState("Pantallas"), List(Of PantallaUsuarioItem))
                Me.grilla.DataSource = Me.Pantallas
                Me.grilla.DataBind()
            End If
        Else
            CargarComboSiNo()
        End If
    End Sub
    Private Function ValidarFormulario() As Boolean
        Dim msgError As String = ""
        Dim esValido As Boolean = True
        Dim strarr() As String
        strarr = txtUsuario.Text.Split(" ")
        If Not Me.txtUsuario.Text = "" Then
            If Not IsNumeric(strarr(0)) Then
                msgError += "Error debe seleccionar un usuario.<br />"
                esValido = False
            Else
                Dim u As Usuario = Sistema.ObtenerUsuario(CType(strarr(0), Integer))
                If u Is Nothing Then
                    msgError += "Error debe seleccionar un usuario.<br />"
                    esValido = False
                End If
            End If
        Else
            msgError += "Error debe seleccionar un usuario.<br />"
            esValido = False
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
    Private Function ValidarGuardado()
        Dim msgError As String = ""
        Dim esValido As Boolean = True
        If Not ValidarFormulario() Then
            Return False
        End If
        If Me.Pantallas.Count = 0 Then
            msgError += "Error debe seleccionar al menos un permiso. <br />"
            esValido = False
        End If
        Dim principales = 0
        For Each ip In Me.Pantallas
            If ip.EsPantallaPrincipal.ToLower = "si" Then
                principales += 1
            End If
        Next
        If principales <> 1 Then
            msgError += "Error debe haber una y solo una pantalla principal.<br />"
            esValido = False
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

    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.Pantallas Is Nothing Then
                Me.Pantallas = New List(Of PantallaUsuarioItem)
            End If
            Dim strarr() As String
            strarr = txtPermisos.Text.Split(" ")
            'Todo lo que se encuentra antes del espacio es el nro de compra

            Dim pi As New PantallaUsuarioItem
            pi.Pantalla = Sistema.ObtenerPantalla(CType(strarr(0), Integer))
            pi.EsPantallaPrincipal = cmbSiNo.SelectedValue
            Me.Pantallas.Add(pi)
            Me.ViewState("Pantallas") = Me.Pantallas
            Me.grilla.DataSource = Me.Pantallas
            Me.grilla.DataBind()
            txtPermisos.Text = ""
            cmbSiNo.SelectedValue = "No"
        End If
    End Sub
    Private Sub cmdVerValores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVerPermisos.Click
        If ValidarFormulario() Then
            Dim strarr() As String
            strarr = txtUsuario.Text.Split(" ")
            Me.Pantallas = Sistema.PantallasUsuarioVista(strarr(0))
            Me.ViewState("Pantallas") = Me.Pantallas
            Me.ViewState("Usuario") = Sistema.ObtenerUsuario(CType(strarr(0), Integer))
            Me.grilla.DataSource = Me.Pantallas
            Me.grilla.DataBind()
            Permisos.Visible = True
        Else
            Permisos.Visible = False
        End If

    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarGuardado() Then
            Sistema.AgregarPermisosUsuario(CType(Me.ViewState("Usuario"), Usuario), Me.Pantallas)
            Me.ViewState("Pantallas") = Nothing
            Me.ViewState("Usuario") = Nothing
            Response.Redirect("frmUsuarioPantalla.aspx")
        End If
    End Sub
    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        Dim strarr() As String
        strarr = txtPermisos.Text.Split(" ")
        Dim inte As Integer
        If Not Integer.TryParse(strarr(0), inte) Then
            esValido = False
            msg += "Debe seleccionar una permiso.<br />"
        Else

            Dim pantalla As Pantalla = Sistema.ObtenerPantalla(CType(strarr(0), Integer))
            If pantalla Is Nothing Then
                esValido = False
                msg += "Debe seleccionar un permiso.<br />"
            End If
            If Not pantalla Is Nothing And Not Me.Pantallas Is Nothing Then
                For Each ip In Me.Pantallas
                    If pantalla.IdPantalla = ip.Pantalla.IdPantalla Then
                        esValido = False
                        msg += "Un mismo permiso no se puede otorgar dos veces.<br />"
                    End If
                    If cmbSiNo.SelectedValue = "1" AndAlso ip.EsPantallaPrincipal = 1 Then
                        esValido = False
                        msg += "Sólo una pantalla puede marcarse como principal.<br />"
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
    Private Sub CargarComboSiNo()
        Me.cmbSiNo.Items.Add(New ListItem("No"))
        Me.cmbSiNo.Items.Add(New ListItem("Si"))
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.ViewState("Pantallas") = Nothing
        Me.ViewState("Usuario") = Nothing
        Response.Redirect("frmUsuarioPantalla.aspx")
    End Sub
    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.Pantallas.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), PantallaUsuarioItem))
            Me.ViewState("Pantallas") = Me.Pantallas
            Me.grilla.DataSource = Me.Pantallas
            Me.grilla.DataBind()
        End If
    End Sub

    Private Sub cmdVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Me.ViewState("Pantallas") = Nothing
        Me.ViewState("Usuario") = Nothing
        Response.Redirect("frmUsuarioPantalla.aspx")
    End Sub
End Class