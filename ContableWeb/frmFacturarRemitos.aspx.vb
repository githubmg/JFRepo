Imports Negocio
Public Class frmFacturarRemitos
    Inherits System.Web.UI.Page
    Private _remitos As List(Of RemitoVistaClass)
    Public Property Remitos() As List(Of RemitoVistaClass)
        Get
            Return _remitos
        End Get
        Set(ByVal value As List(Of RemitoVistaClass))
            _remitos = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.txtFecha.Text = Today.ToShortDateString()
        Else 'PAGE IS POSTBACK
            If Not Me.ViewState("remitos") Is Nothing Then
                Me.Remitos = CType(Me.ViewState("remitos"), List(Of RemitoVistaClass))
                Me.grilla.DataSource = Me.Remitos
                Me.grilla.DataBind()
            End If
        End If
    End Sub
    Private Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
        If ValidarItem() Then
            If Me.Remitos Is Nothing Then
                Me.Remitos = New List(Of RemitoVistaClass)
            End If
            Dim rmto As RemitoVistaClass
            Dim strarr() As String
            strarr = txtRemito.Text.Split(" ")
            'Todo lo que se encuentra antes del espacio es el nro de compra
            rmto = Sistema.VistaRemitoObj(CType(strarr(0), Integer))
            Me.Remitos.Add(rmto)
            Me.ViewState("remitos") = Me.Remitos
            Me.grilla.DataSource = Me.Remitos
            Me.grilla.DataBind()
            txtRemito.Text = ""
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        If Me.ValidarFormulario() Then
            Dim factura = New Factura
            factura.Fecha = CType(Me.txtFecha.Text, Date)
            factura.Observaciones = txtObservaciones.Text
            factura.Remitos = New List(Of Remito)
            For Each rmto In Me.Remitos
                factura.Remitos.Add(Sistema.ObtenerRemito(rmto.IdRemito))
            Next
            Dim idFactura = Sistema.AgregarFactura(factura)
            Response.Redirect("frmViewer.aspx?tipo=FA&id=" & idFactura.ToString)
        End If
    End Sub
    Private Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles grilla.ItemCommand
        If e.CommandName = "Borrar" Then
            Me.Remitos.Remove(CType(Me.grilla.DataSource(e.Item.ItemIndex), RemitoVistaClass))
            Me.ViewState("remitos") = Me.Remitos
            Me.grilla.DataSource = Me.Remitos
            Me.grilla.DataBind()
        End If
    End Sub
    Private Function ValidarItem() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        Dim strarr() As String
        strarr = txtRemito.Text.Split(" ")
        Dim inte As Integer
        If Not Integer.TryParse(strarr(0), inte) Then
            esValido = False
            msg += "Debe seleccionar un remito.<br />"
        Else

            Dim rmto As Remito = Sistema.ObtenerRemito(CType(strarr(0), Integer))
            If rmto Is Nothing Then
                esValido = False
                msg += "Debe seleccionar un número de remito válido.<br />"
            End If
            If Not rmto Is Nothing And Not Me.Remitos Is Nothing Then
                For Each ip In Me.Remitos
                    If rmto.IdRemito = ip.IdRemito Then
                        esValido = False
                        msg += "Un mismo remito no puede imputarse dos veces a la misma factura.<br />"
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
    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""
        If Not IsDate(Me.txtFecha.Text) Then
            esValido = False
            msg += "La fecha no es válida.<br />"
        End If
        If grilla.Items.Count = 0 Then
            esValido = False
            msg += "Debe agregar al menos un remito a la factura.<br />"
        End If
        Dim idCliente = Sistema.ObtenerRemito(Me.Remitos(0).IdRemito).Pedido.Cliente.IdCliente
        For Each r As RemitoVistaClass In Me.Remitos
            If Sistema.ObtenerRemito(r.IdRemito).Pedido.Cliente.IdCliente <> idCliente Then
                esValido = False
            End If
        Next
        If Not esValido Then
            msg += "Error: todos los remitos seleccionados deben pertenecer al mismo cliente.<br />"
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
    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmRemitos.aspx")
    End Sub
End Class