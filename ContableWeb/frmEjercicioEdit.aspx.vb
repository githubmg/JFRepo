Imports Negocio
Partial Public Class frmEjercicioEdit
    Inherits System.Web.UI.Page

    Private _Ejercicio As Ejercicio
    Public Property Ejercicio() As Ejercicio
        Get
            Return Me._Ejercicio
        End Get
        Set(ByVal value As Ejercicio)
            Me._Ejercicio = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Request.QueryString("id") Is Nothing Then
            Dim id As Integer = CType(Me.Request.QueryString("id"), Integer)
            Me.Ejercicio = Sistema.ObtenerEjercicio(id)
        End If

        If Not Me.Page.IsPostBack Then

            If Not Me.Ejercicio Is Nothing Then
                Me.txtFechaInicio.Text = Me.Ejercicio.FechaInicio.ToShortDateString()
                Me.txtFechaFin.Text = Me.Ejercicio.FechaFin.ToShortDateString()
                Me.chkActivo.Checked = Me.Ejercicio.Activo
            End If

        End If
    End Sub
    Private Function validarForm() As Boolean
        Dim strError As String = ""
        Dim esValido As Boolean = True

        If Not IsDate(Me.txtFechaInicio.Text) Then
            strError += "Error en la fecha de inicio.<br />"
            esValido = False
        End If

        If Not IsDate(Me.txtFechaFin.Text) Then
            strError += "Error en la fecha de fin.<br />"
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
                If Me.Ejercicio Is Nothing Then
                    Me.Ejercicio = New Ejercicio
                    Me.Ejercicio.FechaInicio = CType(Me.txtFechaInicio.Text, Date)
                    Me.Ejercicio.FechaFin = CType(Me.txtFechaFin.Text, Date)
                    Me.Ejercicio.Activo = Me.chkActivo.Checked

                    Sistema.AgregarEjercicio(Me.Ejercicio)
                    Response.Redirect("frmEjercicio.aspx")
                Else
                    Me.Ejercicio.FechaInicio = CType(Me.txtFechaInicio.Text, Date)
                    Me.Ejercicio.FechaFin = CType(Me.txtFechaFin.Text, Date)
                    Me.Ejercicio.Activo = Me.chkActivo.Checked

                    Sistema.ActualizarEjercicio(Me.Ejercicio)
                    Response.Redirect("frmEjercicio.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmEjercicio.aspx")
    End Sub
End Class