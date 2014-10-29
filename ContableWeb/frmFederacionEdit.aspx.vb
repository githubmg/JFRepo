Imports Negocio


Partial Public Class frmFederacionEdit
    Inherits System.Web.UI.Page

    Private _Federacion As Federacion
    Public Property Federacion() As Federacion
        Get
            Return Me._Federacion
        End Get
        Set(ByVal value As Federacion)
            Me._Federacion = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Federacion = Sistema.ObtenerFederacion(id)
        End If

        If Not Me.Page.IsPostBack Then

            Me.cmbCondicionIva.DataSource = Sistema.VistaCondicionIva
            Me.cmbCondicionIva.DataTextField = "descripcion"
            Me.cmbCondicionIva.DataValueField = "idCondicionIva"
            Me.cmbCondicionIva.DataBind()
            Me.cmbCondicionIva.SelectedValue = 4 'SUJETO EXENTO

            Me.cmbProvinciaAdministracion.DataSource = Sistema.VistaProvincia
            Me.cmbProvinciaAdministracion.DataTextField = "descripcion"
            Me.cmbProvinciaAdministracion.DataValueField = "idProvincia"
            Me.cmbProvinciaAdministracion.DataBind()

            Me.cmbProvinciaFederacion.DataSource = Sistema.VistaProvincia
            Me.cmbProvinciaFederacion.DataTextField = "descripcion"
            Me.cmbProvinciaFederacion.DataValueField = "idProvincia"
            Me.cmbProvinciaFederacion.DataBind()

            Me.txtfechaAlta.Text = Today.ToShortDateString()
            Me.txtfechaEstatuto.Text = Today.ToShortDateString()

            Me.chkActivo.Checked = True

            If Not Me.Federacion Is Nothing Then
                Me.txtDescripcion.Text = Me.Federacion.Descripcion
                Me.chkActivo.Checked = Me.Federacion.Activo
                Me.txtcantidadClubesesAfiliados.Text = Me.Federacion.CantidadClubesAfiliados
                Me.txtdireccionAdministracion.Text = Me.Federacion.DireccionAdministracion
                Me.txtlocalidadAdministracion.Text = Me.Federacion.LocalidadAdministracion
                Me.cmbProvinciaAdministracion.SelectedValue = Me.Federacion.ProvinciaAdministracion.IdProvincia
                Me.txttelefonoAdministracion.Text = Me.Federacion.TelefonoAdministracion
                Me.txtdireccionFederacion.Text = Me.Federacion.DireccionFederacion
                Me.txtlocalidadFederacion.Text = Me.Federacion.LocalidadFederacion
                Me.cmbProvinciaFederacion.SelectedValue = Me.Federacion.ProvinciaFederacion.IdProvincia
                Me.txttelefonoFederacion.Text = Me.Federacion.TelefonoFederacion
                Me.txtweb.Text = Me.Federacion.Web
                Me.txtcorreo.Text = Me.Federacion.Correo
                Me.txtcontacto.Text = Me.Federacion.Contacto
                Me.txttelefonoContacto.Text = Me.Federacion.TelefonoContacto
                Me.txtcelularContacto.Text = Me.Federacion.CelularContacto
                Me.txtcuit.Text = Me.Federacion.Cuit
                Me.txtfechaEstatuto.Text = Me.Federacion.FechaEstatuto.ToShortDateString()
                Me.txtfechaAlta.Text = Me.Federacion.FechaAlta.ToShortDateString()
                Me.cmbCondicionIva.SelectedValue = Me.Federacion.CondicionIva.IdCondicionIva
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

        If (Not Utiles.validarCuit(Me.txtcuit.Text)) And (Me.txtcuit.Text <> "11111111111") Then
            strError += "La CUIT informada no es válida.<br />"
            esValido = False
        End If

        If Not IsNumeric(Me.txtcantidadClubesesAfiliados.Text) Then
            strError += "La cantidad de clubes afiliados debe ser un valor numérico.<br />"
            esValido = False
        End If

        If Not IsDate(Me.txtfechaAlta.Text) Then
            strError += "La fecha de alta no es válida.<br />"
            esValido = False
        End If

        If Not IsDate(Me.txtfechaEstatuto.Text) Then
            strError += "La fecha de estatuto no es válida.<br />"
            esValido = False
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
                If Me.Federacion Is Nothing Then
                    Me.Federacion = New Federacion
                    Me.Federacion.Descripcion = Me.txtDescripcion.Text
                    Me.Federacion.Activo = Me.chkActivo.Checked
                    Me.Federacion.CantidadClubesAfiliados = Me.txtcantidadClubesesAfiliados.Text
                    Me.Federacion.DireccionAdministracion = Me.txtdireccionAdministracion.Text
                    Me.Federacion.LocalidadAdministracion = Me.txtlocalidadAdministracion.Text
                    Me.Federacion.ProvinciaAdministracion = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaAdministracion.SelectedValue, Integer))
                    Me.Federacion.TelefonoAdministracion = Me.txttelefonoAdministracion.Text
                    Me.Federacion.DireccionFederacion = Me.txtdireccionFederacion.Text
                    Me.Federacion.LocalidadFederacion = Me.txtlocalidadFederacion.Text
                    Me.Federacion.ProvinciaFederacion = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaFederacion.SelectedValue, Integer))
                    Me.Federacion.TelefonoFederacion = Me.txttelefonoFederacion.Text
                    Me.Federacion.Web = Me.txtweb.Text
                    Me.Federacion.Correo = Me.txtcorreo.Text
                    Me.Federacion.Contacto = Me.txtcontacto.Text
                    Me.Federacion.TelefonoContacto = Me.txttelefonoContacto.Text
                    Me.Federacion.CelularContacto = Me.txtcelularContacto.Text
                    Me.Federacion.Cuit = Me.txtcuit.Text
                    Me.Federacion.FechaEstatuto = Me.txtfechaEstatuto.Text
                    Me.Federacion.FechaAlta = Me.txtfechaAlta.Text
                    Me.Federacion.CondicionIva = Sistema.ObtenerCondicionIva(CType(Me.cmbCondicionIva.SelectedValue, Integer))
                    Sistema.AgregarFederacion(Me.Federacion)
                    Response.Redirect("frmFederacion.aspx")
                Else
                    Me.Federacion.Descripcion = Me.txtDescripcion.Text
                    Me.Federacion.Activo = Me.chkActivo.Checked
                    Me.Federacion.CantidadClubesAfiliados = Me.txtcantidadClubesesAfiliados.Text
                    Me.Federacion.DireccionAdministracion = Me.txtdireccionAdministracion.Text
                    Me.Federacion.LocalidadAdministracion = Me.txtlocalidadAdministracion.Text
                    Me.Federacion.ProvinciaAdministracion = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaAdministracion.SelectedValue, Integer))
                    Me.Federacion.TelefonoAdministracion = Me.txttelefonoAdministracion.Text
                    Me.Federacion.DireccionFederacion = Me.txtdireccionFederacion.Text
                    Me.Federacion.LocalidadFederacion = Me.txtlocalidadFederacion.Text
                    Me.Federacion.ProvinciaFederacion = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaFederacion.SelectedValue, Integer))
                    Me.Federacion.TelefonoFederacion = Me.txttelefonoFederacion.Text
                    Me.Federacion.Web = Me.txtweb.Text
                    Me.Federacion.Correo = Me.txtcorreo.Text
                    Me.Federacion.Contacto = Me.txtcontacto.Text
                    Me.Federacion.TelefonoContacto = Me.txttelefonoContacto.Text
                    Me.Federacion.CelularContacto = Me.txtcelularContacto.Text
                    Me.Federacion.Cuit = Me.txtcuit.Text
                    Me.Federacion.FechaEstatuto = Me.txtfechaEstatuto.Text
                    Me.Federacion.FechaAlta = Me.txtfechaAlta.Text
                    Me.Federacion.CondicionIva = Sistema.ObtenerCondicionIva(CType(Me.cmbCondicionIva.SelectedValue, Integer))
                    Sistema.ActualizarFederacion(Me.Federacion)
                    Response.Redirect("frmFederacion.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmFederacion.aspx")
    End Sub
End Class