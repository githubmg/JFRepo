Imports Negocio
Partial Public Class frmReporteMultas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdBuscarMultas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBuscarMultas.Click
        Me.divErrorForm.Visible = False
        Me.lblErrorForm.Text = ""


        Me.grillaTotales.DataSource = New DataTable
        Me.grillaTotales.DataBind()

        Me.grillaSocios.DataSource = New DataTable
        Me.grillaSocios.DataBind()

        Try
            Dim dt As DataTable = Sistema.VistaMultaSocioCabePorClub(CType(Left(Me.txtClub.Text, 8), Integer))

            If dt.Rows.Count > 0 Then
                Me.cmbMultaSocioCabe.DataSource = dt
                Me.cmbMultaSocioCabe.DataValueField = "idMultaSocio"
                Me.cmbMultaSocioCabe.DataTextField = "descripcion"
                Me.cmbMultaSocioCabe.DataBind()
            Else
                Me.cmbMultaSocioCabe.DataSource = New DataTable
                Me.cmbMultaSocioCabe.DataBind()
                Me.divErrorForm.Visible = True
                Me.lblErrorForm.Text = "No multas cargadas para este club."
            End If



        Catch ex As Exception
            Me.cmbMultaSocioCabe.DataSource = New DataTable
            Me.cmbMultaSocioCabe.DataBind()
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = "Club seleccionado inválido."
        End Try

    End Sub

    Protected Sub cmdVerDetalle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVerDetalle.Click
        Me.divErrorForm.Visible = False
        Me.lblErrorForm.Text = ""
        Try
            Me.grillaTotales.DataSource = Negocio.Sistema.ReporteTotalesMulta(CType(Me.cmbMultaSocioCabe.SelectedValue, Integer))
            Me.grillaTotales.DataBind()

            Me.grillaSocios.DataSource = Negocio.Sistema.ReporteDetalleMulta(CType(Me.cmbMultaSocioCabe.SelectedValue, Integer))
            Me.grillaSocios.DataBind()

        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try

    End Sub
End Class