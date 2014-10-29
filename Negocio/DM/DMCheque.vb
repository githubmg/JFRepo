Imports AccesoDatos

Public Class DMCheque
    Public Shared Function VistaChequeNoCobrado(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.VistaChequeNoCobrado")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaChequeCartera(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.ChequeCarteraPorNroBancoImporte")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerCheque(ByVal idCheque As Integer) As Cheque
        Dim cmd As New comando("dbo.ChequeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCheque", idCheque)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New Cheque
                c.IdCheque = CType(.Rows(0).Item("idCheque"), Integer)
                c.Banco = Sistema.ObtenerBanco(CType(.Rows(0).Item("idBanco"), Integer))
                c.Numero = CType(.Rows(0).Item("numero"), String)
                c.FechaEmision = CType(.Rows(0).Item("fechaEmision"), Date)
                c.FechaVencimiento = CType(.Rows(0).Item("fechaVencimiento"), Date)
                c.Importe = CType(.Rows(0).Item("importe"), Double)
                c.OrigenCheque = Sistema.ObtenerOrigenCheque(CType(.Rows(0).Item("idOrigenCheque"), Integer))
                c.EnCartera = CType(.Rows(0).Item("enCartera"), Boolean)
                c.Cobrado = CType(.Rows(0).Item("cobrado"), Boolean)
                Return c
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarCheque(ByVal c As Cheque) As Integer
        Dim cmd As New comando("dbo.ChequeInsert")
        If Not c.Banco Is Nothing Then
            cmd.agregarParametro(ParameterDirection.Input, "@idBanco", c.Banco.IdBanco)
        End If
        cmd.agregarParametro(ParameterDirection.Input, "@numero", c.Numero)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEmision", c.FechaEmision)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaVencimiento", c.FechaVencimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", c.Importe)
        cmd.agregarParametro(ParameterDirection.Input, "@idOrigenCheque", c.OrigenCheque.IdOrigenCheque)
        cmd.agregarParametro(ParameterDirection.Input, "@enCartera", c.EnCartera)
        cmd.agregarParametro(ParameterDirection.Input, "@cobrado", c.Cobrado)
        Return CType(cmd.ejecutar().Rows(0).Item("idCheque"), Integer)
    End Function
    Public Shared Function ActualizarCheque(ByVal c As Cheque) As Integer
        Dim cmd As New comando("dbo.ChequeUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idCheque", c.IdCheque)
        cmd.agregarParametro(ParameterDirection.Input, "@idBanco", c.Banco.IdBanco)
        cmd.agregarParametro(ParameterDirection.Input, "@numero", c.Numero)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEmision", c.FechaEmision)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaVencimiento", c.FechaVencimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", c.Importe)
        cmd.agregarParametro(ParameterDirection.Input, "@idOrigenCheque", c.OrigenCheque.IdOrigenCheque)
        cmd.agregarParametro(ParameterDirection.Input, "@enCartera", c.EnCartera)
        cmd.agregarParametro(ParameterDirection.Input, "@cobrado", c.Cobrado)
        Return CType(cmd.ejecutar().Rows(0).Item("idCheque"), Integer)
    End Function
End Class
