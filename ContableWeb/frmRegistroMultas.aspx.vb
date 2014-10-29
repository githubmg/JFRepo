Imports Negocio
Partial Public Class frmRegistroMultas
    Inherits System.Web.UI.Page

    Private _listaSocio As List(Of Socio)

    Public Property ListaSocio() As List(Of Socio)
        Get
            Return Me._listaSocio
        End Get
        Set(ByVal value As List(Of Socio))
            Me._listaSocio = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ListaSocio = New List(Of Socio)
        If Not Me.Page.IsPostBack Then

            Me.grilla.DataSource = Me.ListaSocio
            Me.grilla.DataBind()

            Me.txtFecha.Text = Today.Date.ToShortDateString()



        Else
            If Not Me.ViewState("ListaSocio") Is Nothing Then
                Me.ListaSocio = CType(Me.ViewState("ListaSocio"), List(Of Socio))
                Me.grilla.DataSource = Me.ListaSocio
                Me.grilla.DataBind()
            End If
        End If


    End Sub

    Protected Sub cmdBuscarSocio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscarSocio.Click
        Try
            Dim s As Socio = Sistema.ObtenerSocioPorNumeroDocumento(CType(Me.txtDocumentoOrganizador.Text, Integer))
            If Not s Is Nothing Then
                Me.txtNombreOrganizador.Text = s.Nombre
            Else
                Me.txtNombreOrganizador.Text = "Socio no encontrado"
            End If
        Catch ex As Exception
            Me.txtNombreOrganizador.Text = "Error en el documento (sólo números)"
        End Try
    End Sub

    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        Me.divErrorItem.Visible = False
        Me.lblErrorItem.Text = ""

        Try
            Dim nroDocumento As Integer = CType(Me.txtNumeroDocumentoSocio.Text, Integer)
            Dim s As Socio = Sistema.ObtenerSocioPorNumeroDocumento(nroDocumento)

            If s Is Nothing Then
                Me.divErrorItem.Visible = True
                Me.lblErrorItem.Text = "No existe un socio con ese número de documento."
            Else
                Dim existe As Boolean = False
                For Each se As Socio In Me.ListaSocio
                    If s.IdSocio = se.IdSocio Then existe = True
                Next
                If Not existe Then
                    Me.ListaSocio.Add(s)
                    Me.grilla.DataSource = Me.ListaSocio
                    Me.grilla.DataBind()
                    Me.ViewState("ListaSocio") = Me.ListaSocio

                    Me.txtNumeroDocumentoSocio.Text = ""

                Else
                    Me.divErrorItem.Visible = True
                    Me.lblErrorItem.Text = "El socio ya fue cargado."
                End If
            End If

        Catch ex As Exception
            Me.divErrorItem.Visible = True
            Me.lblErrorItem.Text = "Error en el número de documento ingresado."
        End Try
    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.ListaSocio.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), Socio))
            Me.ViewState("ListaSocio") = Me.ListaSocio
            Me.grilla.DataSource = Me.ListaSocio
            Me.grilla.DataBind()
        End If
    End Sub

    Private Function validarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim mensaje As String = ""

        If Not IsDate(Me.txtFecha.Text) Then
            esValido = False
            mensaje += "La fecha no es válida.<br />"
        End If

        If Not IsNumeric(Me.txtMontoMulta.Text) Then
            esValido = False
            mensaje += "El monto de la multa no es válido.<br />"
        End If

        If Me.ListaSocio.Count = 0 Then
            esValido = False
            mensaje += "No hay socios en la lista.<br />"
        End If

        If Me.txtNombreTorneo.Text = "" Then
            esValido = False
            mensaje += "El nombre del torneo no puede estar vacío.<br />"
        End If

        Try
            Dim c As Club = Sistema.ObtenerClub(CType(Left(Me.txtClub.Text, 8), Integer))
            If c Is Nothing Then
                esValido = False
                mensaje += "Club Inexistente.<br />"
            End If

        Catch ex As Exception
            esValido = False
            mensaje += "Error en el club seleccionado.<br />"
        End Try

        If Me.txtDocumentoOrganizador.Text <> "" Then
            Try
                Dim s As Socio = Sistema.ObtenerSocioPorNumeroDocumento(CType(Me.txtDocumentoOrganizador.Text, Integer))
                If s Is Nothing Then
                    esValido = False
                    mensaje += "Organizador inexistente.<br />"
                    'Else
                    '    If IsNumeric(Left(Me.txtClub.Text, 8)) Then
                    '        Dim c As Club = Sistema.ObtenerClub(CType(Left(Me.txtClub.Text, 8), Integer))
                    '        If s.Club.IdClub <> c.IdClub Then
                    '            esValido = False
                    '            mensaje += "El socio organizador no forma parte del club seleccionado.<br />"
                    '        End If
                    '    End If
                End If

            Catch ex As Exception
                esValido = False
                mensaje += "Error en el socio organizador seleccionado.<br />"
            End Try
        End If

        If Not esValido Then
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = mensaje
        Else
            Me.divErrorForm.Visible = False
            Me.lblErrorForm.Text = mensaje
        End If
        Return esValido
    End Function

    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click

        Me.divErrorForm.Visible = False
        Me.lblErrorForm.Text = ""


        If Me.validarFormulario() Then
            Try
                Dim m As New MultaSocioCabe
                m.FechaRegistro = CType(Me.txtFecha.Text, Date)
                m.Club = Sistema.ObtenerClub(CType(Left(Me.txtClub.Text, 8), Integer))
                m.NombreTorneo = Me.txtNombreTorneo.Text
                If Me.txtDocumentoOrganizador.Text <> "" Then
                    m.SocioOrganizador = Sistema.ObtenerSocioPorNumeroDocumento(CType(Me.txtDocumentoOrganizador.Text, Integer))
                End If
                m.Items = New List(Of MultaSocioItem)
                For Each s As Socio In Me.ListaSocio
                    Dim i As New MultaSocioItem
                    i.Monto = CType(Me.txtMontoMulta.Text, Double)
                    i.Socio = s
                    m.Items.Add(i)
                Next

                m.IdMultaSocio = Sistema.AgregarMultaSocioCabe(m)
                ComprobanteCabe.GenerarPorMultaSocio(m) 'GENERO EL COMPROBANTE AUTOMATIZADO PARA CADA MULTA DE LOS SOCIOS

                Response.Redirect("Default.aspx")
            Catch ex As Exception
                Me.divErrorForm.Visible = True
                Me.lblErrorForm.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class