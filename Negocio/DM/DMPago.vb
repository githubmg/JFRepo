Imports AccesoDatos

Public Class DMPago
    Public Shared Function ObtenerPago(ByVal idPago As Integer) As Pago
        Dim cmd As New comando("dbo.PagoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", idPago)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim p As New Pago
                p.IdPago = CType(.Rows(0).Item("idPago"), Integer)
                p.Fecha = CType(.Rows(0).Item("fecha"), Date)
                p.MedioPago = Sistema.ObtenerMedioPago(CType(.Rows(0).Item("idMedioPago"), Integer))
                p.Importe = CType(.Rows(0).Item("importe"), Double)
                p.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                Return p
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarPago(ByVal p As Pago) As Integer
        Dim cmd As New comando("dbo.PagoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", p.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago", p.MedioPago.IdMedioPago)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", p.importe)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.Observaciones)
        p.IdPago = CType(cmd.ejecutar().Rows(0).Item("idPago"), Integer)
        For Each c As CompraCabePagoItem In p.Compras
            Sistema.AgregarCompraPago(c, p)
        Next
        If p.MedioPago.Descripcion.ToLower.Trim = "cheque" Then
            If Not p.Cheque.EnCartera Then
                p.Cheque.IdCheque = Sistema.AgregarCheque(p.Cheque)
            Else
                p.Cheque.EnCartera = False
                Sistema.ActualizarCheque(p.Cheque)
            End If
            Sistema.AgregarPagoCheque(p)
        End If
        Return 0
    End Function
    Public Shared Function AgregarPagoCheque(ByVal p As Pago) As Integer
        Dim cmd As New comando("dbo.PagoChequeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", p.IdPago)
        cmd.agregarParametro(ParameterDirection.Input, "@idCheque", p.Cheque.IdCheque)
        Return CType(cmd.ejecutar().Rows(0).Item("idPago"), Integer)
    End Function
    Public Shared Function ActualizarPago(ByVal p As Pago) As Integer
        Dim cmd As New comando("dbo.PagoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", p.idPago)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", p.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago", p.MedioPago.IdMedioPago)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", p.importe)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idPago"), Integer)
    End Function
    Public Shared Function VistaPago() As DataTable
        Dim cmd As New comando("dbo.PagoVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function AgregarCompraPago(c As CompraCabePagoItem, p As Pago) As DataTable
        Dim cmd As New comando("dbo.PagoCompraInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", p.IdPago)
        cmd.agregarParametro(ParameterDirection.Input, "@idCompra", c.CompraCabe.IdCompraCabe)
        cmd.agregarParametro(ParameterDirection.Input, "@montoCancelado", c.MontoCancelado)
        Return cmd.ejecutar()
    End Function
End Class
