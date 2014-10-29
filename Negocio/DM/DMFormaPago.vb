Imports AccesoDatos
Public Class DMFormaPago
    Public Shared Function VistaFormaPago() As DataTable
        Return New comando("dbo.FormaPagoSelect").ejecutar()
    End Function
    Public Shared Function VistaFormaPagoFondoFijo() As DataTable
        Return New comando("dbo.FormaPagoFondoFijoSelect").ejecutar()
    End Function

    Public Shared Function ObtenerFormaPago(ByVal idFormaPago As Integer) As FormaPago
        Dim cmd As New comando("dbo.FormaPagoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFormaPago", idFormaPago)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim f As New FormaPago
                f.IdFormaPago = idFormaPago
                f.Descripcion = .Rows(0).Item("descripcion").ToString()
                f.Cuenta = Sistema.ObtenerCuenta(.Rows(0).Item("codigoCuenta").ToString())
                f.EsCheque = CType(.Rows(0).Item("EsCheque"), Boolean)
                f.EsTarjeta = CType(.Rows(0).Item("EsTarjeta"), Boolean)
                f.EsInterdeposito = CType(.Rows(0).Item("EsInterdeposito"), Boolean)
                f.Moneda = Sistema.ObtenerMoneda(CType(.Rows(0).Item("idMoneda"), Integer))
                f.UsadoParaFondoFijo = CType(.Rows(0).Item("usadoFondoFijo"), Boolean)
                Return f
            Else
                Return Nothing
            End If
        End With
    End Function

    Public Shared Function AgregarFormaPago(ByVal f As FormaPago) As Integer
        Dim cmd As New comando("dbo.FormaPagoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", f.descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuenta", f.Cuenta.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@esCheque", CType(f.EsCheque, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@esTarjeta", CType(f.EsTarjeta, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@esInterdeposito", CType(f.EsInterdeposito, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", f.Moneda.IdMoneda)
        cmd.agregarParametro(ParameterDirection.Input, "@usadoFondoFijo", f.UsadoParaFondoFijo)
        Return CType(cmd.ejecutar().Rows(0).Item("idFormaPago"), Integer)
    End Function

    Public Shared Function ActualizarFormaPago(ByVal f As FormaPago) As Integer
        Dim cmd As New comando("dbo.FormaPagoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idFormaPago", f.idFormaPago)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", f.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuenta", f.Cuenta.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@esCheque", CType(f.EsCheque, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@esTarjeta", CType(f.EsTarjeta, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@esInterdeposito", CType(f.EsInterdeposito, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", f.Moneda.IdMoneda)
        cmd.agregarParametro(ParameterDirection.Input, "@usadoFondoFijo", f.UsadoParaFondoFijo)
        Return CType(cmd.ejecutar().Rows(0).Item("idFormaPago"), Integer)
    End Function

End Class
