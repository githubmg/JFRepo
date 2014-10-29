Imports Negocio


Partial Public Class frmClubEdit
    Inherits System.Web.UI.Page

    Private _club As Club
    Public Property Club() As Club
        Get
            Return Me._club
        End Get
        Set(ByVal value As Club)
            Me._club = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Club = Sistema.ObtenerClub(id)
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

            Me.cmbProvinciaClub.DataSource = Sistema.VistaProvincia
            Me.cmbProvinciaClub.DataTextField = "descripcion"
            Me.cmbProvinciaClub.DataValueField = "idProvincia"
            Me.cmbProvinciaClub.DataBind()

            Me.txtfechaAlta.Text = Today.ToShortDateString()
            Me.txtfechaEstatuto.Text = Today.ToShortDateString()

            Me.chkActivo.Checked = True
            Me.chkPleno.Checked = True

            If Not Me.Club Is Nothing Then
                Me.txtDescripcion.Text = Me.Club.Descripcion
                Me.chkPleno.Checked = Me.Club.Pleno
                Me.chkActivo.Checked = Me.Club.Activo
                Me.txtcantidadCanchas.Text = Me.Club.CantidadCanchas
                Me.txtdireccionAdministracion.Text = Me.Club.DireccionAdministracion
                Me.txtlocalidadAdministracion.Text = Me.Club.LocalidadAdministracion
                Me.cmbProvinciaAdministracion.SelectedValue = Me.Club.ProvinciaAdministracion.IdProvincia
                Me.txttelefonoAdministracion.Text = Me.Club.TelefonoAdministracion
                Me.txtdireccionClub.Text = Me.Club.DireccionClub
                Me.txtlocalidadClub.Text = Me.Club.LocalidadClub
                Me.cmbProvinciaClub.SelectedValue = Me.Club.ProvinciaClub.IdProvincia
                Me.txttelefonoClub.Text = Me.Club.TelefonoClub
                Me.txtweb.Text = Me.Club.Web
                Me.txtcorreo.Text = Me.Club.Correo
                Me.txtcontacto.Text = Me.Club.Contacto
                Me.txttelefonoContacto.Text = Me.Club.TelefonoContacto
                Me.txtcelularContacto.Text = Me.Club.CelularContacto
                Me.txtcuit.Text = Me.Club.Cuit
                Me.txtfechaEstatuto.Text = Me.Club.FechaEstatuto.ToShortDateString()
                Me.txtfechaAlta.Text = Me.Club.FechaAlta.ToShortDateString()
                Me.cmbCondicionIva.SelectedValue = Me.Club.CondicionIva.IdCondicionIva
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

        If Not IsNumeric(Me.txtcantidadCanchas.Text) Then
            strError += "La cantidad de canchas debe ser un valor numérico.<br />"
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
                If Me.Club Is Nothing Then
                    Me.Club = New Club
                    Me.Club.Descripcion = Me.txtDescripcion.Text
                    Me.Club.Pleno = Me.chkPleno.Checked
                    Me.Club.Activo = Me.chkActivo.Checked
                    Me.Club.CantidadCanchas = Me.txtcantidadCanchas.Text
                    Me.Club.DireccionAdministracion = Me.txtdireccionAdministracion.Text
                    Me.Club.LocalidadAdministracion = Me.txtlocalidadAdministracion.Text
                    Me.Club.ProvinciaAdministracion = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaAdministracion.SelectedValue, Integer))
                    Me.Club.TelefonoAdministracion = Me.txttelefonoAdministracion.Text
                    Me.Club.DireccionClub = Me.txtdireccionClub.Text
                    Me.Club.LocalidadClub = Me.txtlocalidadClub.Text
                    Me.Club.ProvinciaClub = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaClub.SelectedValue, Integer))
                    Me.Club.TelefonoClub = Me.txttelefonoClub.Text
                    Me.Club.Web = Me.txtweb.Text
                    Me.Club.Correo = Me.txtcorreo.Text
                    Me.Club.Contacto = Me.txtcontacto.Text
                    Me.Club.TelefonoContacto = Me.txttelefonoContacto.Text
                    Me.Club.CelularContacto = Me.txtcelularContacto.Text
                    Me.Club.Cuit = Me.txtcuit.Text
                    Me.Club.FechaEstatuto = Me.txtfechaEstatuto.Text
                    Me.Club.FechaAlta = Me.txtfechaAlta.Text
                    Me.Club.CondicionIva = Sistema.ObtenerCondicionIva(CType(Me.cmbCondicionIva.SelectedValue, Integer))

                    Sistema.AgregarClub(Me.Club)
                    Response.Redirect("frmClub.aspx")
                Else
                    Me.Club.Descripcion = Me.txtDescripcion.Text
                    Me.Club.Descripcion = Me.txtDescripcion.Text
                    Me.Club.Pleno = Me.chkPleno.Checked
                    Me.Club.Activo = Me.chkActivo.Checked
                    Me.Club.CantidadCanchas = Me.txtcantidadCanchas.Text
                    Me.Club.DireccionAdministracion = Me.txtdireccionAdministracion.Text
                    Me.Club.LocalidadAdministracion = Me.txtlocalidadAdministracion.Text
                    Me.Club.ProvinciaAdministracion = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaAdministracion.SelectedValue, Integer))
                    Me.Club.TelefonoAdministracion = Me.txttelefonoAdministracion.Text
                    Me.Club.DireccionClub = Me.txtdireccionClub.Text
                    Me.Club.LocalidadClub = Me.txtlocalidadClub.Text
                    Me.Club.ProvinciaClub = Sistema.ObtenerProvincia(CType(Me.cmbProvinciaClub.SelectedValue, Integer))
                    Me.Club.TelefonoClub = Me.txttelefonoClub.Text
                    Me.Club.Web = Me.txtweb.Text
                    Me.Club.Correo = Me.txtcorreo.Text
                    Me.Club.Contacto = Me.txtcontacto.Text
                    Me.Club.TelefonoContacto = Me.txttelefonoContacto.Text
                    Me.Club.CelularContacto = Me.txtcelularContacto.Text
                    Me.Club.Cuit = Me.txtcuit.Text
                    Me.Club.FechaEstatuto = Me.txtfechaEstatuto.Text
                    Me.Club.FechaAlta = Me.txtfechaAlta.Text
                    Me.Club.CondicionIva = Sistema.ObtenerCondicionIva(CType(Me.cmbCondicionIva.SelectedValue, Integer))
                    Sistema.ActualizarClub(Me.Club)
                    Response.Redirect("frmClub.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmClub.aspx")
    End Sub
End Class
