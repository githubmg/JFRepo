Imports AccesoDatos

Public Class DMFactura
    Public Shared Function ObtenerFactura(ByVal idFactura As Integer) As Factura
        Dim cmd As New comando("dbo.FacturaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFactura", idFactura)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim f As New Factura
                f.IdFactura = CType(.Rows(0).Item("idFactura"), Integer)
                f.Fecha = CType(.Rows(0).Item("fecha"), Date)
                f.Remitos = Sistema.ObtenerRemitos(f.IdFactura)
                Return f
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarFactura(ByVal f As Factura) As Integer
        Dim cmd As New comando("dbo.FacturaInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", f.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", f.Observaciones)
        f.IdFactura = CType(cmd.ejecutar().Rows(0).Item("idFactura"), Integer)
        For Each r In f.Remitos
            Sistema.AgregarFacturaRemito(r, f.IdFactura)
        Next
        'Cambio el estado de cada uno de los pedidos
        For Each r In f.Remitos
            r.Pedido.EstadoPedido = Sistema.ObtenerEstadoPedido(4)
            Sistema.ActualizarPedidoCabe(r.Pedido)
        Next
        Return f.IdFactura
    End Function
    Public Shared Function VistaFactura() As DataTable
        Dim cmd As New comando("dbo.FacturaVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function AgregarFacturaRemito(ByVal r As Remito, ByVal idFactura As Integer) As Integer
        Dim cmd As New comando("dbo.FacturaRemitoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idFactura", idFactura)
        cmd.agregarParametro(ParameterDirection.Input, "@idRemito", r.IdRemito)
        cmd.ejecutar()
        Return r.IdRemito
    End Function
    Public Shared Function VistaFacturaReporte(ByVal idFactura As Integer) As DataTable
        Dim cmd As New comando("dbo.rptFactura_comprobantes")
        cmd.agregarParametro(ParameterDirection.Input, "@idFactura", idFactura)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaFacturaCabe(ByVal idFactura As Integer) As DataTable
        Dim cmd As New comando("dbo.rptFactura_cabe")
        cmd.agregarParametro(ParameterDirection.Input, "@idFactura", idFactura)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaFacturaDetalle(ByVal idFactura As Integer) As DataTable
        Dim cmd As New comando("dbo.rptFactura_detalle")
        cmd.agregarParametro(ParameterDirection.Input, "@idFactura", idFactura)
        Return cmd.ejecutar()
    End Function
End Class
