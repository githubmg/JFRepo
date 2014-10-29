Imports AccesoDatos
Public Class DMParametro
    Public Shared Function ObtenerParametro() As Parametro
        Dim cmd As New comando("dbo.ParametroSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idParametro", 1)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim p As New Parametro
                p.IdParametro = CType(.Rows(0).Item("idParametro"), Integer)
                p.NumeracionReintegros = CType(.Rows(0).Item("numeracionReintegros"), Integer)
                p.NumeracionAdelantos = CType(.Rows(0).Item("numeracionAdelantos"), Integer)
                p.CuentaAdelantoProveedor = Sistema.ObtenerCuenta(.Rows(0).Item("codigoCuentaAdelantoProveedor").ToString())
                p.CuentaReintegroProveedor = Sistema.ObtenerCuenta(.Rows(0).Item("codigoCuentaReintegroProveedor").ToString())
                Return p
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarParametro(ByVal p As Parametro) As Integer
        Dim cmd As New comando("dbo.ParametroInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@numeracionReintegros", p.numeracionReintegros)
        cmd.agregarParametro(ParameterDirection.Input, "@numeracionAdelantos", p.NumeracionAdelantos)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuentaAdelantoProveedor", p.CuentaAdelantoProveedor.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuentaReintegroProveedor", p.CuentaReintegroProveedor.Codigo)
        Return CType(cmd.ejecutar().Rows(0).Item("idParametro"), Integer)
    End Function

    Public Shared Function ActualizarParametro(ByVal p As Parametro) As Integer
        Dim cmd As New comando("dbo.ParametroUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idParametro", p.idParametro)
        cmd.agregarParametro(ParameterDirection.Input, "@numeracionReintegros", p.numeracionReintegros)
        cmd.agregarParametro(ParameterDirection.Input, "@numeracionAdelantos", p.NumeracionAdelantos)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuentaAdelantoProveedor", p.CuentaAdelantoProveedor.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuentaReintegroProveedor", p.CuentaReintegroProveedor.Codigo)
        Return CType(cmd.ejecutar().Rows(0).Item("idParametro"), Integer)
    End Function
    Public Shared Function VistaParametro() As DataTable
        Dim cmd As New comando("dbo.ParametroVista")
        Return cmd.ejecutar()
    End Function

End Class
