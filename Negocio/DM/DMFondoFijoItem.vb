Imports AccesoDatos
Public Class DMFondoFijoItem
    Public Shared Function ObtenerFondoFijoItem(ByVal idFondoFijoItem As Integer) As FondoFijoItem
        Dim cmd As New comando("dbo.FondoFijoItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijoItem", idFondoFijoItem)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim f As New FondoFijoItem
                f.idFondoFijoItem = CType(.Rows(0).Item("idFondoFijoItem"), Integer)
                f.Cuenta = Sistema.ObtenerCuenta(CType(.Rows(0).Item("codigoCuenta"), String))
                f.observaciones = CType(.Rows(0).Item("observaciones"), String)
                f.monto = CType(.Rows(0).Item("monto"), Double)
                Return f
            Else : Return Nothing
            End If
        End With
    End Function

    Public Shared Function AgregarFondoFijoItem(ByVal fc As FondoFijo, ByVal f As FondoFijoItem) As Integer
        Dim cmd As New comando("dbo.FondoFijoItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijo", fc.IdFondoFijo)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuenta", f.Cuenta.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", f.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@monto", f.Monto)
        Return CType(cmd.ejecutar().Rows(0).Item("idFondoFijoItem"), Integer)
    End Function


    Public Shared Function ActualizarFondoFijoItem(ByVal fc As FondoFijo, ByVal f As FondoFijoItem) As Integer
        Dim cmd As New comando("dbo.FondoFijoItemUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijoItem", f.IdFondoFijoItem)
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijo", fc.IdFondoFijo)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuenta", f.Cuenta.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", f.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@monto", f.Monto)
        Return CType(cmd.ejecutar().Rows(0).Item("idFondoFijoItem"), Integer)
    End Function


    Public Shared Function VistaFondoFijoItem() As DataTable
        Dim cmd As New comando("dbo.FondoFijoItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijoItem")
        Return cmd.ejecutar()
    End Function

    Public Shared Sub BorrarFondoFijoItem(ByVal ff As FondoFijo)
        Dim cmd As New comando("dbo.fondoFijoItemDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijo", ff.IdFondoFijo)
        cmd.ejecutar()
    End Sub

End Class
