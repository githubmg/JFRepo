Imports AccesoDatos
Public Class DMSocio
    Public Shared Function VistaSocio() As DataTable
        Dim cmd As New comando("dbo.socioVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaSocio(ByVal nombreSocio As String) As DataTable
        Dim cmd As New comando("dbo.socioVistaPorNombre")
        cmd.agregarParametro(ParameterDirection.Input, "@nombre", nombreSocio)
        Return cmd.ejecutar()
    End Function

    Public Shared Function ObtenerSocioPorNumeroDocumento(ByVal NumeroDocumento As Integer) As Socio
        Dim cmd As New comando("dbo.socioSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@NumeroDocumento", NumeroDocumento)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Return Sistema.ObtenerSocio(CType(.Rows(0).Item("idSocio"), Integer))
            Else
                Return Nothing
            End If
        End With

    End Function

    Public Shared Function ObtenerSocio(ByVal idSocio As Integer) As Socio
        Dim cmd As New comando("dbo.socioSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idSocio", idSocio)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim s As New Socio
                s.IdSocio = idSocio
                s.Nombre = .Rows(0).Item("Nombre").ToString()
                s.FechaNacimiento = CType(.Rows(0).Item("FechaNacimiento"), Date)
                s.TipoDocumento = Sistema.ObtenerTipoDocumento(CType(.Rows(0).Item("idTipoDocumento"), Integer))
                s.NumeroDocumento = CType(.Rows(0).Item("NumeroDocumento"), Integer)
                s.Sexo = Sistema.ObtenerSexo(CType(.Rows(0).Item("idSexo"), Integer))
                s.PaisNacionalidad = Sistema.ObtenerPais(CType(.Rows(0).Item("idPaisNacionalidad"), Integer))
                s.Direccion = .Rows(0).Item("Direccion").ToString()
                s.Provincia = Sistema.ObtenerProvincia(CType(.Rows(0).Item("idProvincia"), Integer))
                s.Localidad = .Rows(0).Item("Localidad").ToString()
                s.CodigoPostal = .Rows(0).Item("CodigoPostal").ToString()
                s.Telefono = .Rows(0).Item("Telefono").ToString()
                s.Celular = .Rows(0).Item("Celular").ToString()
                s.Email = .Rows(0).Item("Email").ToString()
                s.Web = .Rows(0).Item("Web").ToString()
                s.EstadoCivil = Sistema.ObtenerEstadoCivil(CType(.Rows(0).Item("idEstadoCivil"), Integer))
                s.FechaIngreso = CType(.Rows(0).Item("FechaIngreso"), Date)
                s.CategoriaSocio = Sistema.ObtenerCategoriaSocio(CType(.Rows(0).Item("idCategoriaSocio"), Integer))
                s.EstadoSocio = Sistema.ObtenerEstadoSocio(CType(.Rows(0).Item("idEstadoSocio"), Integer))
                s.Club = Sistema.ObtenerClub(CType(.Rows(0).Item("idClub"), Integer))
                s.Federacion = Sistema.ObtenerFederacion(CType(.Rows(0).Item("idfederacion"), Integer))
                s.EsProfesional = CType(.Rows(0).Item("EsProfesional"), Boolean)
                s.ClasificacionDobles = CType(.Rows(0).Item("ClasificacionDobles"), Integer)
                s.ClasificacionSingle = CType(.Rows(0).Item("ClasificacionSingle"), Integer)

                Return s
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarSocio(ByVal s As Socio) As Integer
        Dim cmd As New comando("dbo.socioInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@nombre", s.Nombre)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaNacimiento", s.FechaNacimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoDocumento", s.TipoDocumento.IdTipoDocumento)
        cmd.agregarParametro(ParameterDirection.Input, "@numeroDocumento", s.NumeroDocumento)
        cmd.agregarParametro(ParameterDirection.Input, "@idSexo", s.Sexo.IdSexo)
        cmd.agregarParametro(ParameterDirection.Input, "@idPaisNacionalidad", s.PaisNacionalidad.IdPais)
        cmd.agregarParametro(ParameterDirection.Input, "@direccion", s.Direccion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvincia", s.Provincia.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@localidad", s.Localidad)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoPostal", s.CodigoPostal)
        cmd.agregarParametro(ParameterDirection.Input, "@telefono", s.Telefono)
        cmd.agregarParametro(ParameterDirection.Input, "@celular", s.Celular)
        cmd.agregarParametro(ParameterDirection.Input, "@email", s.Email)
        cmd.agregarParametro(ParameterDirection.Input, "@web", s.Web)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoCivil", s.EstadoCivil.IdEstadoCivil)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaIngreso", s.FechaIngreso)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoSocio", s.EstadoSocio.IdestadoSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@idClub", s.Club.IdClub)
        cmd.agregarParametro(ParameterDirection.Input, "@idFederacion", s.Federacion.IdFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@EsProfesional", s.EsProfesional)
        cmd.agregarParametro(ParameterDirection.Input, "@ClasificacionDobles", s.ClasificacionDobles)
        cmd.agregarParametro(ParameterDirection.Input, "@ClasificacionSingle", s.ClasificacionSingle)

        Return CType(cmd.ejecutar().Rows(0).Item("idSocio"), Integer)
    End Function

    Public Shared Function ActualizarSocio(ByVal s As Socio) As Integer
        Dim cmd As New comando("dbo.socioUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idSocio", s.IdSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@nombre", s.Nombre)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaNacimiento", s.FechaNacimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoDocumento", s.TipoDocumento.IdTipoDocumento)
        cmd.agregarParametro(ParameterDirection.Input, "@numeroDocumento", s.NumeroDocumento)
        cmd.agregarParametro(ParameterDirection.Input, "@idSexo", s.Sexo.IdSexo)
        cmd.agregarParametro(ParameterDirection.Input, "@idPaisNacionalidad", s.PaisNacionalidad.IdPais)
        cmd.agregarParametro(ParameterDirection.Input, "@direccion", s.Direccion)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvincia", s.Provincia.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@localidad", s.Localidad)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoPostal", s.CodigoPostal)
        cmd.agregarParametro(ParameterDirection.Input, "@telefono", s.Telefono)
        cmd.agregarParametro(ParameterDirection.Input, "@celular", s.Celular)
        cmd.agregarParametro(ParameterDirection.Input, "@email", s.Email)
        cmd.agregarParametro(ParameterDirection.Input, "@web", s.Web)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoCivil", s.EstadoCivil.IdEstadoCivil)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaIngreso", s.FechaIngreso)
        cmd.agregarParametro(ParameterDirection.Input, "@idEstadoSocio", s.EstadoSocio.IdestadoSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@idClub", s.Club.IdClub)
        cmd.agregarParametro(ParameterDirection.Input, "@idFederacion", s.Federacion.IdFederacion)
        cmd.agregarParametro(ParameterDirection.Input, "@EsProfesional", s.EsProfesional)
        cmd.agregarParametro(ParameterDirection.Input, "@ClasificacionDobles", s.ClasificacionDobles)
        cmd.agregarParametro(ParameterDirection.Input, "@ClasificacionSingle", s.ClasificacionSingle)

        Return CType(cmd.ejecutar().Rows(0).Item("idSocio"), Integer)
    End Function
End Class
