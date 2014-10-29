Imports AccesoDatos
Public Class DMCliente
    Public Shared Function Obtenercliente(ByVal idCliente As Integer) As Cliente
        Dim cmd As New comando("dbo.clienteSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCliente", idCliente)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New Cliente
                c.IdCliente = idCliente
                c.Cuit = Convert.ToInt64(.Rows(0).Item("cuit"))
                c.RazonSocial = CType(.Rows(0).Item("razonSocial"), String)
                c.Localidad = Sistema.ObtenerLocalidad(CType(.Rows(0).Item("idLocalidad"), Integer))
                c.Domicilio = CType(.Rows(0).Item("domicilio"), String)
                c.CodigoPostal = CType(.Rows(0).Item("codigoPostal"), String)
                c.CondicionIva = Sistema.ObtenerCondicionIva(CType(.Rows(0).Item("idCondicionIva"), Integer))
                c.Telefono = CType(.Rows(0).Item("telefono"), String)
                c.Email = CType(.Rows(0).Item("email"), String)
                c.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                Return c
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function ObtenerclientePorCuit(ByVal cuit As Int64) As Cliente
        Dim cmd As New comando("dbo.clientePorCuit")
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", cuit)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New Cliente
                c.IdCliente = CType(.Rows(0).Item("idCliente"), Integer)
                c.Cuit = Convert.ToInt64(.Rows(0).Item("cuit"))
                c.RazonSocial = CType(.Rows(0).Item("razonSocial"), String)
                c.Localidad = Sistema.ObtenerLocalidad(CType(.Rows(0).Item("idLocalidad"), Integer))
                c.Domicilio = CType(.Rows(0).Item("domicilio"), String)
                c.CodigoPostal = CType(.Rows(0).Item("codigoPostal"), String)
                c.CondicionIva = Sistema.ObtenerCondicionIva(CType(.Rows(0).Item("idCondicionIva"), Integer))
                c.Telefono = CType(.Rows(0).Item("telefono"), String)
                c.Email = CType(.Rows(0).Item("email"), String)
                c.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                Return c
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function Agregarcliente(ByVal c As Cliente) As Integer
        Dim cmd As New comando("dbo.clienteInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", c.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@razonSocial", c.RazonSocial)
        cmd.agregarParametro(ParameterDirection.Input, "@idLocalidad", c.Localidad.IdLocalidad)
        cmd.agregarParametro(ParameterDirection.Input, "@domicilio", c.Domicilio)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoPostal", c.CodigoPostal)
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionIva", c.CondicionIva.IdCondicionIva)
        cmd.agregarParametro(ParameterDirection.Input, "@telefono", c.Telefono)
        cmd.agregarParametro(ParameterDirection.Input, "@email", c.Email)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.Observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idCliente"), Integer)
    End Function
    Public Shared Function Actualizarcliente(ByVal c As Cliente) As Integer
        Dim cmd As New comando("dbo.clienteUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idCliente", c.IdCliente)
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", c.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@razonSocial", c.RazonSocial)
        cmd.agregarParametro(ParameterDirection.Input, "@idLocalidad", c.Localidad.IdLocalidad)
        cmd.agregarParametro(ParameterDirection.Input, "@domicilio", c.Domicilio)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoPostal", c.CodigoPostal)
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionIva", c.CondicionIva.IdCondicionIva)
        cmd.agregarParametro(ParameterDirection.Input, "@telefono", c.Telefono)
        cmd.agregarParametro(ParameterDirection.Input, "@email", c.Email)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", c.Observaciones)
        Return CType(cmd.ejecutar().Rows(0).Item("idCliente"), Integer)
    End Function
    Public Shared Function Vistacliente() As DataTable
        Dim cmd As New comando("dbo.clienteVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaCliente(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.ClienteVistaPorCuitORazon")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function
End Class
