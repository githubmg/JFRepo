Imports AccesoDatos
Public Class DMCuenta
    Public Shared Function VistaCuenta() As DataTable
        Dim cmd As New comando("cuentaVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaCuenta(ByVal param As String) As DataTable
        Dim cmd As New comando("cuentaVista2")
        cmd.agregarParametro(ParameterDirection.Input, "@param", param)
        Return cmd.ejecutar()
    End Function

    Public Shared Function ObtenerCuenta(ByVal codigo As String) As Cuenta
        Dim cmd As New comando("cuentaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@codigo", codigo)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Cuenta
                o.Codigo = codigo
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                o.Activa = CType(.Rows(0).Item("activa"), Boolean)
                o.Ajustable = CType(.Rows(0).Item("ajustable"), Boolean)
                o.Imputable = CType(.Rows(0).Item("imputable"), Boolean)
                o.TipoCuenta = Sistema.ObtenerTipoCuenta(CType(.Rows(0).Item("idTipoCuenta"), Integer))
                o.CentroCostos = Sistema.ObtenerCentroCostos(CType(.Rows(0).Item("idCentroCostos"), Integer))
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarCuenta(ByVal c As Cuenta) As String
        Dim cmd As New comando("cuentaInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@codigo", c.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", c.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@activa", CType(c.Activa, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@imputable", CType(c.Imputable, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@ajustable ", CType(c.Ajustable, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoCuenta", c.TipoCuenta.IdTipoCuenta)
        cmd.agregarParametro(ParameterDirection.Input, "@idCentroCostos", c.CentroCostos.IdCentroCostos)
        cmd.ejecutar()
        Return c.Codigo

    End Function
    Public Shared Function ActualizarCuenta(ByVal c As Cuenta) As String
        Dim cmd As New comando("cuentaUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@codigo", c.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", c.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@activa", CType(c.Activa, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@imputable", CType(c.Imputable, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@ajustable ", CType(c.Ajustable, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoCuenta", c.TipoCuenta.IdTipoCuenta)
        cmd.agregarParametro(ParameterDirection.Input, "@idCentroCostos", c.CentroCostos.IdCentroCostos)
        cmd.ejecutar()
        Return c.Codigo

    End Function
End Class
