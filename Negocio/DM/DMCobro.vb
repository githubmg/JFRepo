Imports AccesoDatos

Public Class DMCobro
    Public Shared Function ObtenerCobro(ByVal idCobro As Integer) As Cobro
        Dim cmd As New comando("dbo.CobroSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCobro", idCobro)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New Cobro
                c.idCobro = CType(.Rows(0).Item("idCobro"), Integer)
                c.fecha = CType(.Rows(0).Item("fecha"), Date)
                c.MedioPago = Sistema.ObtenerMedioPago(CType(.Rows(0).Item("idMedioPago"), Integer))
                c.Importe = CType(.Rows(0).Item("importe"), Double)
                c.observaciones = CType(.Rows(0).Item("observaciones"), String)
                Return c
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarCobro(ByVal c As Cobro) As Integer
        Dim cmd As New comando("dbo.CobroInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", c.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago", c.MedioPago.IdMedioPago)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", c.importe)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.Observaciones)
        c.IdCobro = CType(cmd.ejecutar().Rows(0).Item("idCobro"), Integer)
        For Each p As PedidoCabeCobroItem In c.Pedidos
            Sistema.AgregarPedidoCobro(p, c)
        Next
        If c.MedioPago.Descripcion.ToLower.Trim = "cheque" Then
            c.Cheque.IdCheque = Sistema.AgregarCheque(c.Cheque)
            Sistema.AgregarCobroCheque(c)
        End If
        Return c.IdCobro
    End Function
    Public Shared Function AgregarPedidoCobro(ByVal p As PedidoCabeCobroItem, ByVal c As Cobro) As DataTable
        Dim cmd As New comando("dbo.CobroPedidoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idCobro", c.idCobro)
        cmd.agregarParametro(ParameterDirection.Input, "@idPedido", p.PedidoCabe.IdPedidoCabe)
        cmd.agregarParametro(ParameterDirection.Input, "@montoCancelado", p.MontoCancelado)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ActualizarCobro(ByVal c As Cobro) As Integer
        Dim cmd As New comando("dbo.CobroUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idCobro", c.idCobro)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", c.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago", c.MedioPago.IdMedioPago)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", c.importe)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idCobro"), Integer)
    End Function
    Public Shared Function VistaCobro() As DataTable
        Dim cmd As New comando("dbo.cobroVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function AgregarCobroCheque(ByVal c As Cobro) As Integer
        Dim cmd As New comando("dbo.CobroChequeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idCobro", c.IdCobro)
        cmd.agregarParametro(ParameterDirection.Input, "@idCheque", c.Cheque.IdCheque)
        Return CType(cmd.ejecutar().Rows(0).Item("idCobro"), Integer)
    End Function
End Class
