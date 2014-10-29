Imports Negocio


Partial Public Class frmSocioEdit
    Inherits System.Web.UI.Page

    Private _socio As Socio
    Public Property Socio() As Socio
        Get
            Return Me._socio
        End Get
        Set(ByVal value As Socio)
            Me._socio = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Socio = Sistema.ObtenerSocio(id)
        End If

        If Not Me.Page.IsPostBack Then

            Me.cmbTipoDocumento.DataSource = Sistema.VistaTipoDocumento()
            Me.cmbTipoDocumento.DataTextField = "descripcion"
            Me.cmbTipoDocumento.DataValueField = "idTipoDocumento"
            Me.cmbTipoDocumento.DataBind()

            Me.cmbProvincia.DataSource = Sistema.VistaProvincia()
            Me.cmbProvincia.DataTextField = "descripcion"
            Me.cmbProvincia.DataValueField = "idProvincia"
            Me.cmbProvincia.DataBind()

            Me.cmbSexo.DataSource = Sistema.VistaSexo()
            Me.cmbSexo.DataTextField = "descripcion"
            Me.cmbSexo.DataValueField = "idSexo"
            Me.cmbSexo.DataBind()

            Me.cmbNacionalidad.DataSource = Sistema.VistaPais()
            Me.cmbNacionalidad.DataTextField = "descripcion"
            Me.cmbNacionalidad.DataValueField = "idPais"
            Me.cmbNacionalidad.DataBind()

            Me.cmbEstadoCivil.DataSource = Sistema.VistaEstadoCivil()
            Me.cmbEstadoCivil.DataTextField = "descripcion"
            Me.cmbEstadoCivil.DataValueField = "idEstadoCivil"
            Me.cmbEstadoCivil.DataBind()

            Me.cmbEstadoSocio.DataSource = Sistema.VistaEstadoSocio()
            Me.cmbEstadoSocio.DataTextField = "descripcion"
            Me.cmbEstadoSocio.DataValueField = "idEstadoSocio"
            Me.cmbEstadoSocio.DataBind()

            Me.txtFechaIngreso.Text = Today.ToShortDateString()
            Me.txtFechaNacimiento.Text = Today.ToShortDateString()


            If Not Me.Socio Is Nothing Then
                Me.txtNombre.Text = Me.Socio.Nombre
                Me.txtFechaNacimiento.Text = Me.Socio.FechaNacimiento.ToShortDateString()
                Me.cmbTipoDocumento.SelectedValue = Me.Socio.TipoDocumento.IdTipoDocumento.ToString()
                Me.txtNumeroDocumento.Text = Me.Socio.NumeroDocumento.ToString()
                Me.cmbSexo.SelectedValue = Me.Socio.Sexo.IdSexo.ToString()
                Me.cmbEstadoCivil.SelectedValue = Me.Socio.EstadoCivil.IdEstadoCivil.ToString()
                Me.cmbNacionalidad.SelectedValue = Me.Socio.PaisNacionalidad.IdPais.ToString()
                Me.cmbProvincia.SelectedValue = Me.Socio.Provincia.IdProvincia.ToString()
                Me.txtLocalidad.Text = Me.Socio.Localidad
                Me.txtDireccion.Text = Me.Socio.Direccion
                Me.txtCodigoPostal.Text = Me.Socio.CodigoPostal
                Me.txtTelefono.Text = Me.Socio.Telefono
                Me.txtCelular.Text = Me.Socio.Celular
                Me.txtEmail.Text = Me.Socio.Email
                Me.txtWeb.Text = Me.Socio.Web
                Me.txtClub.Text = Right("000000000" + Me.Socio.Club.IdClub.ToString(), 8) + " - " + Me.Socio.Club.Descripcion
                Me.txtFederacion.Text = Right("000000000" + Me.Socio.Federacion.IdFederacion.ToString(), 8) + " - " + Me.Socio.Federacion.Descripcion
                Me.txtFechaIngreso.Text = Me.Socio.FechaIngreso.ToShortDateString()
                Me.cmbEstadoSocio.SelectedValue = Me.Socio.EstadoSocio.IdestadoSocio.ToString()

                Me.txtClasificacionDobles.Text = Me.Socio.ClasificacionDobles.ToString()
                Me.txtClasificacionSingle.Text = Me.Socio.ClasificacionSingle.ToString()
                Me.chkEsProfesional.Checked = Me.Socio.EsProfesional

            End If

            Me.txtFechaNacimiento_TextChanged(Nothing, Nothing)
        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True

        If Me.txtNombre.Text = "" Then
            strError += "El nombre no puede estar vacío.<br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaNacimiento.Text) Then
            strError += "La fecha de nacimiento no es válida.<br />"
            esValido = False
        Else
            If CType(Me.txtFechaNacimiento.Text, Date).Date > Today.Date Then
                strError += "La fecha de nacimiento no puede ser mayor al día de hoy.<br />"
                esValido = False
            End If
        End If

        If Me.txtNumeroDocumento.Text = "" Then
            strError += "El número de documento no puede estar vacío.<br />"
            esValido = False
        End If

        If Not IsNumeric(Me.txtNumeroDocumento.Text) Then
            strError += "El número de documento debe ser un número válido.<br />"
            esValido = False
        End If

        If (Not IsNumeric(Me.txtClasificacionSingle.Text)) Or Me.txtClasificacionSingle.Text.Length > 2 Then
            strError += "La clasificación single no es válida.<br />"
            esValido = False
        End If

        If (Not IsNumeric(Me.txtClasificacionDobles.Text)) Or Me.txtClasificacionDobles.Text.Length > 2 Then
            strError += "La clasificación dobles no es válida.<br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaIngreso.Text) Then
            strError += "La fecha de ingreso no es válida.<br />"
            esValido = False
        Else
            If CType(Me.txtFechaIngreso.Text, Date).Date > Today.Date Then
                strError += "La fecha de ingreso no puede ser mayor al día de hoy.<br />"
                esValido = False
            End If
        End If
      
        If Me.txtClub.Text <> "" Then
            Try
                Dim idClub As Integer = CType(Left(Me.txtClub.Text, 8), Integer)
                Dim c As Club = Sistema.ObtenerClub(idClub)
                If c Is Nothing Then
                    strError += "No existe ningún club con el valor seleccionado en el campo 'Pertenece a'.<br />"
                    esValido = False
                End If
            Catch ex As Exception
                strError += "El valor ingresado en el campo 'Pertenece a' no es válido.<br />"
                esValido = False
            End Try
        Else
            strError += "El campo 'Pertenece a' no puede estar vacío.<br />"
            esValido = False
        End If


        If Me.txtFederacion.Text <> "" Then
            Try
                Dim idFederacion As Integer = CType(Left(Me.txtFederacion.Text, 8), Integer)
                Dim f As Federacion = Sistema.ObtenerFederacion(idFederacion)
                If f Is Nothing Then
                    strError += "No existe ninguna federación con el valor seleccionado en el campo 'Federación'.<br />"
                    esValido = False
                End If
            Catch ex As Exception
                strError += "El valor ingresado en el campo 'Federación' no es válido.<br />"
                esValido = False
            End Try
        Else
            strError += "El campo 'Federación' no puede estar vacío.<br />"
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
                If Me.Socio Is Nothing Then
                    Me.Socio = New Socio
                    Me.Socio.Nombre = Me.txtNombre.Text
                    Me.Socio.FechaNacimiento = CType(Me.txtFechaNacimiento.Text, Date)
                    Me.Socio.TipoDocumento = Sistema.ObtenerTipoDocumento(CType(Me.cmbTipoDocumento.SelectedValue, Integer))
                    Me.Socio.NumeroDocumento = CType(Me.txtNumeroDocumento.Text, Integer)
                    Me.Socio.Sexo = Sistema.ObtenerSexo(CType(Me.cmbSexo.SelectedValue, Integer))
                    Me.Socio.EstadoCivil = Sistema.ObtenerEstadoCivil(CType(Me.cmbEstadoCivil.SelectedValue, Integer))
                    Me.Socio.PaisNacionalidad = Sistema.ObtenerPais(CType(Me.cmbNacionalidad.SelectedValue, Integer))
                    Me.Socio.Provincia = Sistema.ObtenerProvincia(CType(Me.cmbProvincia.SelectedValue, Integer))
                    Me.Socio.Localidad = Me.txtLocalidad.Text
                    Me.Socio.Direccion = Me.txtDireccion.Text
                    Me.Socio.CodigoPostal = Me.txtCodigoPostal.Text
                    Me.Socio.Telefono = Me.txtTelefono.Text
                    Me.Socio.Celular = Me.txtCelular.Text
                    Me.Socio.Email = Me.txtEmail.Text
                    Me.Socio.Web = Me.txtWeb.Text
                    Me.Socio.Club = Sistema.ObtenerClub(CType(Left(Me.txtClub.Text, 8), Integer))
                    Me.Socio.Federacion = Sistema.ObtenerFederacion(CType(Left(Me.txtFederacion.Text, 8), Integer))
                    Me.Socio.FechaIngreso = CType(Me.txtFechaIngreso.Text, Date)
                    Me.Socio.EstadoSocio = Sistema.ObtenerEstadoSocio(CType(Me.cmbEstadoSocio.SelectedValue, Integer))
                    Me.Socio.EsProfesional = Me.chkEsProfesional.Checked
                    Me.Socio.ClasificacionSingle = CType(Me.txtClasificacionSingle.Text, Integer)
                    Me.Socio.ClasificacionDobles = CType(Me.txtClasificacionDobles.Text, Integer)

                    Sistema.AgregarSocio(Me.Socio)
                    Response.Redirect("frmSocio.aspx")
                Else
                    Me.Socio.Nombre = Me.txtNombre.Text
                    Me.Socio.FechaNacimiento = CType(Me.txtFechaNacimiento.Text, Date)
                    Me.Socio.TipoDocumento = Sistema.ObtenerTipoDocumento(CType(Me.cmbTipoDocumento.SelectedValue, Integer))
                    Me.Socio.NumeroDocumento = CType(Me.txtNumeroDocumento.Text, Integer)
                    Me.Socio.Sexo = Sistema.ObtenerSexo(CType(Me.cmbSexo.SelectedValue, Integer))
                    Me.Socio.EstadoCivil = Sistema.ObtenerEstadoCivil(CType(Me.cmbEstadoCivil.SelectedValue, Integer))
                    Me.Socio.PaisNacionalidad = Sistema.ObtenerPais(CType(Me.cmbNacionalidad.SelectedValue, Integer))
                    Me.Socio.Provincia = Sistema.ObtenerProvincia(CType(Me.cmbProvincia.SelectedValue, Integer))
                    Me.Socio.Localidad = Me.txtLocalidad.Text
                    Me.Socio.Direccion = Me.txtDireccion.Text
                    Me.Socio.CodigoPostal = Me.txtCodigoPostal.Text
                    Me.Socio.Telefono = Me.txtTelefono.Text
                    Me.Socio.Celular = Me.txtCelular.Text
                    Me.Socio.Email = Me.txtEmail.Text
                    Me.Socio.Web = Me.txtWeb.Text
                    Me.Socio.Club = Sistema.ObtenerClub(CType(Left(Me.txtClub.Text, 8), Integer))
                    Me.Socio.Federacion = Sistema.ObtenerFederacion(CType(Left(Me.txtFederacion.Text, 8), Integer))
                    Me.Socio.FechaIngreso = CType(Me.txtFechaIngreso.Text, Date)
                    Me.Socio.EstadoSocio = Sistema.ObtenerEstadoSocio(CType(Me.cmbEstadoSocio.SelectedValue, Integer))
                    Me.Socio.EsProfesional = Me.chkEsProfesional.Checked
                    Me.Socio.ClasificacionSingle = CType(Me.txtClasificacionSingle.Text, Integer)
                    Me.Socio.ClasificacionDobles = CType(Me.txtClasificacionDobles.Text, Integer)

                    Sistema.ActualizarSocio(Me.Socio)
                    Response.Redirect("frmSocio.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmSocio.aspx")
    End Sub

    Public Sub txtFechaNacimiento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaNacimiento.TextChanged
        Try
            Dim fechaNac As Date = CType(Me.txtFechaNacimiento.Text, Date) 'primera fecha
            Dim cat As CategoriaSocio = Sistema.ObtenerCategoriaSocioPorEdad(Me.CalcularEdad(fechaNac))
            Me.txtCategoria.Text = cat.Descripcion
        Catch ex As Exception
            Me.txtCategoria.Text = "ERROR"
        End Try

    End Sub

    Private Function CalcularEdad(ByVal fechaNacimiento As Global.System.DateTime) As Integer
        Dim anyos As Integer = Global.System.DateTime.Now.Year - fechaNacimiento.Year
        Return anyos
    End Function
End Class