Imports AccesoDatos
Public Class DMClub
    Public Shared Function VistaClub() As DataTable
        Dim cmd As New comando("dbo.clubVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaClub(ByVal descripcion As String) As DataTable
        Dim cmd As New comando("dbo.clubVistaPorNombre")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", descripcion)
        Return cmd.ejecutar()
    End Function


    Public Shared Function ObtenerClub(ByVal idClub As Integer) As Club
        Dim cmd As New comando("dbo.ClubSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idClub", idClub)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New Club
                c.IdClub = CType(.Rows(0).Item("idClub"), Integer)
                c.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                c.Pleno = CType(.Rows(0).Item("pleno"), Boolean)
                c.Activo = CType(.Rows(0).Item("activo"), Boolean)
                c.CantidadCanchas = CType(.Rows(0).Item("cantidadCanchas"), Integer)
                c.DireccionAdministracion = CType(.Rows(0).Item("direccionAdministracion"), String)
                c.LocalidadAdministracion = CType(.Rows(0).Item("localidadAdministracion"), String)
                c.ProvinciaAdministracion = Sistema.ObtenerProvincia(CType(.Rows(0).Item("idProvinciaAdministracion"), Integer))
                c.TelefonoAdministracion = CType(.Rows(0).Item("telefonoAdministracion"), String)
                c.DireccionClub = CType(.Rows(0).Item("direccionClub"), String)
                c.LocalidadClub = CType(.Rows(0).Item("localidadClub"), String)
                c.ProvinciaClub = Sistema.ObtenerProvincia(CType(.Rows(0).Item("idProvinciaClub"), Integer))
                c.TelefonoClub = CType(.Rows(0).Item("telefonoClub"), String)
                c.Web = CType(.Rows(0).Item("web"), String)
                c.Correo = CType(.Rows(0).Item("correo"), String)
                c.Contacto = CType(.Rows(0).Item("contacto"), String)
                c.TelefonoContacto = CType(.Rows(0).Item("telefonoContacto"), String)
                c.CelularContacto = CType(.Rows(0).Item("celularContacto"), String)
                c.Cuit = CType(.Rows(0).Item("cuit"), String)
                c.FechaEstatuto = CType(.Rows(0).Item("fechaEstatuto"), Date)
                c.FechaAlta = CType(.Rows(0).Item("fechaAlta"), Date)
                c.CondicionIva = Sistema.ObtenerCondicionIva(CType(.Rows(0).Item("idCondicionIva"), Integer))
                Return c
            Else : Return Nothing
            End If
        End With
    End Function

    Public Shared Function AgregarClub(ByVal c As Club) As Integer
        Dim cmd As New comando("dbo.ClubInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", c.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@pleno", CType(c.Pleno, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@activo", CType(c.Activo, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@cantidadCanchas", c.CantidadCanchas)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionAdministracion", c.DireccionAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadAdministracion", c.LocalidadAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciaAdministracion", c.ProvinciaAdministracion.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoAdministracion", c.TelefonoAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionClub", c.DireccionClub)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadClub", c.LocalidadClub)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciaClub", c.ProvinciaClub.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoClub", c.TelefonoClub)
        cmd.agregarParametro(ParameterDirection.Input, "@web", c.Web)
        cmd.agregarParametro(ParameterDirection.Input, "@correo", c.Correo)
        cmd.agregarParametro(ParameterDirection.Input, "@contacto", c.Contacto)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoContacto", c.TelefonoContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@celularContacto", c.CelularContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", c.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEstatuto", c.FechaEstatuto)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaAlta", c.FechaAlta)
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionIva", c.CondicionIva.IdCondicionIva)
        Return CType(cmd.ejecutar().Rows(0).Item("idClub"), Integer)
    End Function


    Public Shared Function ActualizarClub(ByVal c As Club) As Integer
        Dim cmd As New comando("dbo.ClubUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idClub", c.IdClub)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", c.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@pleno", CType(c.Pleno, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@activo", CType(c.Activo, Integer))
        cmd.agregarParametro(ParameterDirection.Input, "@cantidadCanchas", c.CantidadCanchas)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionAdministracion", c.DireccionAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadAdministracion", c.LocalidadAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciaAdministracion", c.ProvinciaAdministracion.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoAdministracion", c.TelefonoAdministracion)
        cmd.agregarParametro(ParameterDirection.Input, "@direccionClub", c.DireccionClub)
        cmd.agregarParametro(ParameterDirection.Input, "@localidadClub", c.LocalidadClub)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvinciaClub", c.ProvinciaClub.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoClub", c.TelefonoClub)
        cmd.agregarParametro(ParameterDirection.Input, "@web", c.Web)
        cmd.agregarParametro(ParameterDirection.Input, "@correo", c.Correo)
        cmd.agregarParametro(ParameterDirection.Input, "@contacto", c.Contacto)
        cmd.agregarParametro(ParameterDirection.Input, "@telefonoContacto", c.TelefonoContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@celularContacto", c.CelularContacto)
        cmd.agregarParametro(ParameterDirection.Input, "@cuit", c.Cuit)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEstatuto", c.FechaEstatuto)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaAlta", c.FechaAlta)
        cmd.agregarParametro(ParameterDirection.Input, "@idCondicionIva", c.CondicionIva.IdCondicionIva)
        Return CType(cmd.ejecutar().Rows(0).Item("idClub"), Integer)
    End Function

End Class
