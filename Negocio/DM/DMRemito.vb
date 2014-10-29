Imports AccesoDatos

Public Class DMRemito
    Public Shared Function VistaRemito() As DataTable
        Dim cmd As New comando("dbo.RemitoVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaRemitoReporte(idRemito As Integer) As DataTable
        Dim cmd As New comando("dbo.rptRemito_comprobantes")
        cmd.agregarParametro(ParameterDirection.Input, "@idRemito", idRemito)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaRemitosSinFacturar(ByVal prefix As String) As DataTable
        Dim cmd As New comando("dbo.rptRemitoSinFacturarVista")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", prefix)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaRemitoObj() As List(Of RemitoVistaClass)
        Dim l As New List(Of RemitoVistaClass)
        Dim cmd As New comando("dbo.RemitoVista")
        For Each r As DataRow In cmd.ejecutar.Rows
            Dim rc As New RemitoVistaClass
            rc.Chasis = CType(r.Item("chasis"), String)
            rc.Cliente = CType(r.Item("cliente"), String)
            rc.Estado = CType(r.Item("estado"), String)
            rc.Factura = CType(r.Item("factura"), String)
            rc.FechaPedido = CType(r.Item("fechaPedido"), Date)
            rc.IdRemito = CType(r.Item("idRemito"), Integer)
            rc.Orden = CType(r.Item("orden"), String)
            rc.Pendiente = CType(r.Item("pendiente"), String)
            rc.Total = CType(r.Item("total"), String)
            l.Add(rc)
        Next
        Return l
    End Function
    Public Shared Function VistaRemitoObj(ByVal idRemito As Integer) As RemitoVistaClass
        Dim l As New List(Of RemitoVistaClass)
        Dim cmd As New comando("dbo.RemitoVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idRemito", idRemito)
        For Each r As DataRow In cmd.ejecutar.Rows
            Dim rc As New RemitoVistaClass
            rc.Chasis = CType(r.Item("chasis"), String)
            rc.Cliente = CType(r.Item("cliente"), String)
            rc.Estado = CType(r.Item("estado"), String)
            rc.Factura = CType(r.Item("factura"), String)
            rc.FechaPedido = CType(r.Item("fechaPedido"), Date)
            rc.IdRemito = CType(r.Item("idRemito"), Integer)
            rc.Orden = CType(r.Item("orden"), String)
            rc.Pendiente = CType(r.Item("pendiente"), String)
            rc.Total = CType(r.Item("total"), String)
            l.Add(rc)
        Next
        Return l(0)
    End Function
    Public Shared Function ObtenerRemitos(ByVal idFactura As Integer) As List(Of Remito)
        Dim l As New List(Of Remito)
        Dim cmd As New comando("dbo.RemitosDeFactura")
        cmd.agregarParametro(ParameterDirection.Input, "@idfactura", idFactura)
        For Each r As DataRow In cmd.ejecutar.Rows
            Dim rto As New Remito
            rto.IdRemito = CType(r.Item("idRemito"), Integer)
            rto.Pedido = Sistema.ObtenerPedidoCabe(CType(r.Item("idPedido"), Integer))
            l.Add(rto)
        Next
        Return l
    End Function
    Public Shared Function ObtenerRemito(ByVal idRemito As Integer) As Remito
        Dim cmd As New comando("dbo.RemitoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idRemito", idRemito)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim r As New Remito
                r.IdRemito = CType(.Rows(0).Item("idRemito"), Integer)
                r.Pedido = Sistema.ObtenerPedidoCabe(CType(.Rows(0).Item("idPedido"), Integer))
                Return r
            Else
                Return Nothing
            End If
        End With

    End Function
End Class
