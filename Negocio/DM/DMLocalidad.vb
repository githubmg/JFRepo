Imports AccesoDatos

Public Class DMLocalidad
    Public Shared Function ObtenerLocalidad(ByVal idLocalidad As Integer) As Localidad
        Dim cmd As New comando("dbo.LocalidadSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idLocalidad", idLocalidad)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim l As New Localidad
                l.idLocalidad = CType(.Rows(0).Item("idLocalidad"), Integer)
                l.Provincia = Sistema.ObtenerProvincia(CType(.Rows(0).Item("idProvincia"), Integer))
                l.descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return l
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarLocalidad(ByVal l As Localidad) As Integer
        Dim cmd As New comando("dbo.LocalidadInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idProvincia", l.Provincia.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", l.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idLocalidad"), Integer)
    End Function
    Public Shared Function ActualizarLocalidad(ByVal l As Localidad) As Integer
        Dim cmd As New comando("dbo.LocalidadUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idLocalidad", l.idLocalidad)
        cmd.agregarParametro(ParameterDirection.Input, "@idProvincia", l.Provincia.IdProvincia)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", l.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idLocalidad"), Integer)
    End Function
    Public Shared Function VistaLocalidad() As DataTable
        Dim cmd As New comando("dbo.LocalidadSelect")
        'cmd.agregarParametro(ParameterDirection.Input, "@idLocalidad")
        Return cmd.ejecutar()
    End Function
    Public Shared Function VistaLocalidad(idProvincia As Integer) As DataTable
        Dim cmd As New comando("dbo.LocalidadPorProvinciaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idProvincia", idProvincia)
        Return cmd.ejecutar()
    End Function
End Class
