Imports AccesoDatos
Public Class DMFederacion
    Public Shared Function VistaFederacion() As DataTable
        Dim cmd As New comando("dbo.FederacionVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaFederacion(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.FederacionVistaPorNombre")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerFederacion(ByVal idFederacion As Integer) As Federacion
        Dim cmd As New comando("dbo.FederacionSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFederacion", idFederacion)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim f As New Federacion
                f.IdFederacion = CType(.Rows(0).Item("idFederacion"), Integer)
                f.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                f.Activo = CType(.Rows(0).Item("activo"), Boolean)
                f.CantidadClubesAfiliados = CType(.Rows(0).Item("cantidadClubesAfiliados"), Integer)
                f.DireccionAdministracion = CType(.Rows(0).Item("direccionAdministracion"), String)
                f.LocalidadAdministracion = CType(.Rows(0).Item("localidadAdministracion"), String)
                f.ProvinciaAdministracion = Sistema.ObtenerProvincia(CType(.Rows(0).Item("idProvinciaAdministracion"), Integer))
                f.TelefonoAdministracion = CType(.Rows(0).Item("telefonoAdministracion"), String)
                f.DireccionFederacion = CType(.Rows(0).Item("direccionfederacion"), String)
                f.LocalidadFederacion = CType(.Rows(0).Item("localidadfederacion"), String)
                f.ProvinciaFederacion = Sistema.ObtenerProvincia(CType(.Rows(0).Item("idProvinciafederacion"), Integer))
                f.TelefonoFederacion = CType(.Rows(0).Item("telefonofederacion"), String)
                f.Web = CType(.Rows(0).Item("web"), String)
                f.Correo = CType(.Rows(0).Item("correo"), String)
                f.Contacto = CType(.Rows(0).Item("contacto"), String)
                f.TelefonoContacto = CType(.Rows(0).Item("telefonoContacto"), String)
                f.CelularContacto = CType(.Rows(0).Item("celularContacto"), String)
                f.Cuit = CType(.Rows(0).Item("cuit"), String)
                f.FechaEstatuto = CType(.Rows(0).Item("fechaEstatuto"), Date)
                f.FechaAlta = CType(.Rows(0).Item("fechaAlta"), Date)
                f.CondicionIva = Sistema.ObtenerCondicionIva(CType(.Rows(0).Item("idCondicionIva"), Integer))
                Return f
            Else : Return Nothing
            End If
        End With
    End Function

    Public Shared Function AgregarFederacion(ByVal f As Federacion) As Integer
        Dim cmd As New comando("dbo.FederacionInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", f.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@activo", CType(f.Activo, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@cantidadClubesAfiliados", f.CantidadClubesAfiliados)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionAdministracion", f.DireccionAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadAdministracion", f.LocalidadAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciaAdministracion", f.ProvinciaAdministracion.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoAdministracion", f.TelefonoAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionfederacion", f.DireccionFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadfederacion", f.LocalidadFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciafederacion", f.ProvinciaFederacion.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonofederacion", f.TelefonoFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@web", f.Web)
        cmd.agregarParametro(ParameterDirection.Input, "@correo", f.Correo)
        cmd.agregarParametro(ParameterDirection.Input, "@contacto", f.Contacto)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoContacto", f.TelefonoContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@celularContacto", f.CelularContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", f.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEstatuto", f.FechaEstatuto)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaAlta", f.FechaAlta)
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionIva", f.CondicionIva.IdCondicionIva)
        Return CType(cmd.ejecutar().Rows(0).Item("idFederacion"), Integer)
    End Function


    Public Shared Function ActualizarFederacion(ByVal f As Federacion) As Integer
        Dim cmd As New comando("dbo.FederacionUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idFederacion", f.IdFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", f.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@activo", CType(f.Activo, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@cantidadClubesAfiliados", f.CantidadClubesAfiliados)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionAdministracion", f.DireccionAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadAdministracion", f.LocalidadAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciaAdministracion", f.ProvinciaAdministracion.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoAdministracion", f.TelefonoAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionfederacion", f.DireccionFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadfederacion", f.LocalidadFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciafederacion", f.ProvinciaFederacion.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonofederacion", f.TelefonoFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@web", f.Web)
        cmd.agregarParametro(ParameterDirection.Input, "@correo", f.Correo)
        cmd.agregarParametro(ParameterDirection.Input, "@contacto", f.Contacto)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoContacto", f.TelefonoContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@celularContacto", f.CelularContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", f.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEstatuto", f.FechaEstatuto)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaAlta", f.FechaAlta)
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionIva", f.CondicionIva.IdCondicionIva)
        Return CType(cmd.ejecutar().Rows(0).Item("idFederacion"), Integer)
    End Function




End Class
