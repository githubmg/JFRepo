Imports Negocio

Public Class frmMovimientoStockEdit
    Inherits System.Web.UI.Page

    Private _movimientoStock As MovimientoStock
    Public Property MovimientoStock() As MovimientoStock
        Get
            Return _movimientoStock
        End Get
        Set(ByVal value As MovimientoStock)
            _movimientoStock = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Me.Request.QueryString("idMovimientoStock") Is Nothing) And IsNumeric(Me.Request.QueryString("idMovimientoStock")) Then
            Dim id As Integer = CType(Me.Request.QueryString("idMovimientoStock"), Integer)
            Me.MovimientoStock = Sistema.ObtenerMovimientoStock(id)
        End If
        If Not Me.Page.IsPostBack Then
           
            Me.txtFecha.Text = Today.ToShortDateString()
            CargarComboFamilia()
            ActualizarComboProducto()
            CargarComboTipoMovimiento()
            CargarComboOrigen()
            CargarComboDestino()
            CargarComboUbicacion()

            If Not Me.MovimientoStock Is Nothing Then
                Me.txtFecha.Text = Me.MovimientoStock.Fecha.ToShortDateString()
                Me.cmbTipoMovimiento.SelectedValue = Me.MovimientoStock.TipoMovimiento.IdTipoMovimiento
                Me.cmbFamilia.SelectedValue = Me.MovimientoStock.Producto.Familia.IdFamilia
                Me.cmbProducto.SelectedValue = Me.MovimientoStock.Producto.IdProducto
                Me.txtCantidad.Text = Me.MovimientoStock.Cantidad.ToString
                If Me.MovimientoStock.TipoMovimiento.IdTipoMovimiento = 3 Then
                    pnlUbicaciones.Visible = True
                    pnlUbicacion.Visible = False
                    cmbOrigen.SelectedValue = Me.MovimientoStock.UbicacionStockOrigen.IdUbicacionStock
                    cmbDestino.SelectedValue = Me.MovimientoStock.UbicacionStockDestino.IdUbicacionStock
                Else
                    pnlUbicaciones.Visible = False
                    pnlUbicacion.Visible = True
                    cmbUbicacionStock.SelectedValue = Me.MovimientoStock.UbicacionStock.IdUbicacionStock
                End If

            End If
        End If
    End Sub
    Private Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Try

            If Me.ValidarFormulario() Then
                If Me.MovimientoStock Is Nothing Then
                    Me.MovimientoStock = New MovimientoStock
                    Me.MovimientoStock.Cantidad = CType(txtCantidad.Text, Double)
                    Me.MovimientoStock.Fecha = CType(txtFecha.Text, Date)
                    Me.MovimientoStock.Producto = Sistema.ObtenerProducto(CType(cmbProducto.SelectedValue, Integer))
                    Me.MovimientoStock.TipoMovimiento = Sistema.ObtenerTipoMovimiento(CType(cmbTipoMovimiento.SelectedValue, Integer))
                    If Me.MovimientoStock.TipoMovimiento.IdTipoMovimiento = 3 Then
                        Me.MovimientoStock.UbicacionStockDestino = Sistema.ObtenerUbicacionStock(CType(cmbDestino.SelectedValue, Integer))
                        Me.MovimientoStock.UbicacionStockOrigen = Sistema.ObtenerUbicacionStock(CType(cmbOrigen.SelectedValue, Integer))
                    Else
                        Me.MovimientoStock.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(cmbUbicacionStock.SelectedValue, Integer))
                    End If
                    Sistema.AgregarMovimientoStock(Me.MovimientoStock)
                    Response.Redirect("frmMovimientoStock.aspx")
                Else
                    Me.MovimientoStock.Cantidad = CType(txtCantidad.Text, Double)
                    Me.MovimientoStock.Fecha = CType(txtFecha.Text, Date)
                    Me.MovimientoStock.Producto = Sistema.ObtenerProducto(CType(cmbProducto.SelectedValue, Integer))
                    Me.MovimientoStock.TipoMovimiento = Sistema.ObtenerTipoMovimiento(CType(cmbTipoMovimiento.SelectedValue, Integer))
                    If Me.MovimientoStock.TipoMovimiento.IdTipoMovimiento = 3 Then
                        Me.MovimientoStock.UbicacionStockDestino = Sistema.ObtenerUbicacionStock(CType(cmbDestino.SelectedValue, Integer))
                        Me.MovimientoStock.UbicacionStockOrigen = Sistema.ObtenerUbicacionStock(CType(cmbOrigen.SelectedValue, Integer))
                    Else
                        Me.MovimientoStock.UbicacionStock = Sistema.ObtenerUbicacionStock(CType(cmbUbicacionStock.SelectedValue, Integer))
                    End If
                    Sistema.ActualizarMovimientoStock(Me.MovimientoStock)
                    Response.Redirect("frmMovimientoStock.aspx")
                End If
            End If
        Catch ex As Exception
            Me.divErrorForm.Visible = True
            Me.lblErrorForm.Text = ex.Message
        End Try
    End Sub
    Private Function ValidarFormulario() As Boolean
        Dim esValido As Boolean = True
        Dim msg As String = ""

        If Not IsDate(Me.txtFecha.Text) Then
            esValido = False
            msg += "La fecha no es válida.<br />"
        End If
        Dim number As Double
        If Not Double.TryParse(txtCantidad.Text, number) Then
            esValido = False
            msg += "La cantidad debe tener el formato 00,00.<br />"
        Else
            If CType(txtCantidad.Text, Double) <= 0 Then
                esValido = False
                msg += "La cantidad debe ser mayor que 0.<br />"
            End If
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
    Private Sub CargarComboTipoMovimiento()
        Me.cmbTipoMovimiento.DataSource = Sistema.VistaTipoMovimiento()
        Me.cmbTipoMovimiento.DataValueField = "idTipoMovimiento"
        Me.cmbTipoMovimiento.DataTextField = "descripcion"
        Me.cmbTipoMovimiento.DataBind()
    End Sub
    Private Sub CargarComboFamilia()
        Me.cmbFamilia.DataSource = Sistema.VistaFamilia
        Me.cmbFamilia.DataValueField = "idFamilia"
        Me.cmbFamilia.DataTextField = "descripcion"
        Me.cmbFamilia.DataBind()
    End Sub
    Private Sub CargarComboOrigen()
        Me.cmbOrigen.DataSource = Sistema.VistaUbicacionStock()
        Me.cmbOrigen.DataValueField = "idUbicacionStock"
        Me.cmbOrigen.DataTextField = "descripcion"
        Me.cmbOrigen.DataBind()
    End Sub
    Private Sub CargarComboDestino()
        Me.cmbDestino.DataSource = Sistema.VistaUbicacionStock()
        Me.cmbDestino.DataValueField = "idUbicacionStock"
        Me.cmbDestino.DataTextField = "descripcion"
        Me.cmbDestino.DataBind()
    End Sub
    Private Sub CargarComboUbicacion()
        Me.cmbUbicacionStock.DataSource = Sistema.VistaUbicacionStock()
        Me.cmbUbicacionStock.DataValueField = "idUbicacionStock"
        Me.cmbUbicacionStock.DataTextField = "descripcion"
        Me.cmbUbicacionStock.DataBind()
    End Sub
    Private Sub cmbFamilia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFamilia.SelectedIndexChanged
        ActualizarComboProducto()
    End Sub
    Private Sub ActualizarComboProducto()
        Me.cmbProducto.DataSource = Sistema.VistaProductoByFamlia(CType(Me.cmbFamilia.SelectedValue, Integer))
        Me.cmbProducto.DataTextField = "descripcion"
        Me.cmbProducto.DataValueField = "idProducto"
        Me.cmbProducto.DataBind()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Response.Redirect("frmMovimientoStock.aspx")
    End Sub

    Protected Sub cmbTipoMovimiento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTipoMovimiento.SelectedIndexChanged
        If Me.cmbTipoMovimiento.SelectedValue = "3" Then
            pnlUbicaciones.Visible = True
            pnlUbicacion.Visible = False
        Else
            pnlUbicaciones.Visible = False
            pnlUbicacion.Visible = True
        End If
    End Sub
End Class