Imports AccesoDatos
Public Class DMDeposito
    Public Shared Function ObtenerDeposito(ByVal idDeposito As Integer) As Deposito
        Dim cmd As New comando("dbo.DepositoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idDeposito", idDeposito)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Deposito
                o.IdDeposito = idDeposito
                o.Banco = Sistema.ObtenerBanco(CType(.Rows(0).Item("idBanco"), Integer))
                o.Cheque = Sistema.ObtenerCheque(CType(.Rows(0).Item("idCheque"), Integer))
                o.Fecha = CType(.Rows(0).Item("fecha"), Date)
                o.NumeroTransaccion = .Rows(0).Item("numeroTransaccion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaDeposito() As DataTable
        Return New comando("dbo.DepositoVista").ejecutar()
    End Function
    Public Shared Function AgregarDeposito(ByVal d As Deposito) As Integer
        Dim cmd As New comando("dbo.DepositoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idBanco", d.Banco.IdBanco)
        cmd.agregarParametro(ParameterDirection.Input, "@idCheque", d.Cheque.IdCheque)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", d.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@numeroTransaccion", d.NumeroTransaccion)


        Return CType(cmd.ejecutar().Rows(0).Item("idDeposito"), Integer)
    End Function

End Class
