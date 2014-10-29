Imports AccesoDatos
Public Class DMMultaSocioCabe
    Public Shared Function AgregarMultaSocioCabe(ByVal m As MultaSocioCabe) As Integer
        Dim cmd As New comando("dbo.multaSocioCabeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fechaRegistro", m.FechaRegistro)
        cmd.agregarParametro(ParameterDirection.Input, "@idClub", m.Club.IdClub)
        cmd.agregarParametro(ParameterDirection.Input, "@nombreTorneo", m.NombreTorneo)
        If Not m.SocioOrganizador Is Nothing Then cmd.agregarParametro(ParameterDirection.Input, "@idSocioOrganizador", m.SocioOrganizador.IdSocio)
        m.IdMultaSocio = CType(cmd.ejecutar().Rows(0).Item("IdMultaSocio"), Integer)

        For Each i As MultaSocioItem In m.Items
            i.IdMultaSocioItem = Sistema.AgregarMultaSocioItem(i, m.IdMultaSocio)
        Next
        Return m.IdMultaSocio
    End Function
    Public Shared Function VistaMultaSocioCabePorClub(ByVal idClub As Integer) As DataTable
        Dim cmd As New comando("multaSocioCabePorClubVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idClub", idClub)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerMultaSocioCabe(ByVal idMultaSocio As Integer) As MultaSocioCabe
        Dim cmd As New comando("dbo.multaSocioCabeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMultaSocio", idMultaSocio)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim m As New MultaSocioCabe
                m.IdMultaSocio = idMultaSocio
                m.Club = Sistema.ObtenerClub(CType(.Rows(0).Item("idClub"), Integer))
                m.FechaRegistro = CType(.Rows(0).Item("FechaRegistro"), Date)
                If Not .Rows(0).IsNull("idSocioOrganizador") Then m.SocioOrganizador = Sistema.ObtenerSocio(CType(.Rows(0).Item("idSocioOrganizador"), Integer))
                m.NombreTorneo = CType(.Rows(0).Item("nombreTorneo"), String)
                Return m
            Else
                Return Nothing
            End If
        End With
    End Function


End Class
