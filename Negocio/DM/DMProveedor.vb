Imports AccesoDatos
Public Class DMProveedor
    Public Shared Function ObtenerProveedor(ByVal cuit As Long) As Proveedor
        Dim cmd As New comando("dbo.ProveedorSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", cuit)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim p As New Proveedor
                p.Cuit = CType(.Rows(0).Item("cuit"), Long)
                p.RazonSocial = CType(.Rows(0).Item("razonSocial"), String)
                p.Localidad = Sistema.ObtenerLocalidad(CType(.Rows(0).Item("idLocalidad"), Integer))
                p.Domicilio = CType(.Rows(0).Item("domicilio"), String)
                p.CodigoPostal = CType(.Rows(0).Item("codigoPostal"), String)
                p.Telefono = CType(.Rows(0).Item("telefono"), String)
                p.Email = CType(.Rows(0).Item("email"), String)
                p.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                Return p
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarProveedor(ByVal p As Proveedor) As Long
        Dim cmd As New comando("dbo.ProveedorInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", p.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@razonSocial", p.RazonSocial)
        cmd.agregarParametro(ParameterDirection.Input, "@idLocalidad", p.Localidad.IdLocalidad)
        cmd.agregarParametro(ParameterDirection.Input, "@domicilio", p.Domicilio)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoPostal", p.CodigoPostal)
        cmd.agregarParametro(ParameterDirection.Input, "@telefono", p.Telefono)
        cmd.agregarParametro(ParameterDirection.Input, "@email", p.Email)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.Observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("cuit"), Long)
    End Function
    Public Shared Function ActualizarProveedor(ByVal p As Proveedor) As Long
        Dim cmd As New comando("dbo.ProveedorUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", p.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@razonSocial", p.RazonSocial)
        cmd.agregarParametro(ParameterDirection.Input, "@idLocalidad", p.Localidad.IdLocalidad)
        cmd.agregarParametro(ParameterDirection.Input, "@domicilio", p.Domicilio)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoPostal", p.CodigoPostal)
        cmd.agregarParametro(ParameterDirection.Input, "@telefono", p.Telefono)
        cmd.agregarParametro(ParameterDirection.Input, "@email", p.Email)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", p.Observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("cuit"), Long)
    End Function
    Public Shared Function VistaProveedor() As DataTable
        Dim cmd As New comando("dbo.ProveedorVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaProveedor(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.ProveedorVistaPorCuitORazon")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function
End Class
