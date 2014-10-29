Imports AccesoDatos
Public Class DMUsuario
    Private Shared Function Mapear(ByVal r As DataRow) As Usuario
        Dim u As New Usuario
        u.IdUsuario = CType(r.Item("idUsuario"), Integer)
        u.NombreUsuario = CType(r.Item("NombreUsuario"), String)
        u.Clave = CType(r.Item("Clave"), String)
        u.Nombre = CType(r.Item("Nombre"), String)
        u.Email = CType(r.Item("Email"), String)
        If Not IsDBNull(r.Item("Pantalla")) Then
            u.PantallaDefault = CType(r.Item("Pantalla"), String)
        End If
        Return u
    End Function
    Public Shared Function VistaUsuario() As DataTable
        Return New comando("dbo.UsuarioVista").ejecutar()
    End Function
    Public Shared Sub AgregarPermisosUsuario(ByVal u As Usuario, ByVal pantallas As List(Of PantallaUsuarioItem))
        Dim cmd1 As New comando("UsuarioPantallaDelete")
        cmd1.agregarParametro(ParameterDirection.Input, "@idUsuario", u.IdUsuario)
        cmd1.ejecutar()
        For Each p In pantallas
            Dim cmd As New comando("UsuarioPantallaInsert")
            cmd.agregarParametro(ParameterDirection.Input, "@idPantalla", p.Pantalla.IdPantalla)
            cmd.agregarParametro(ParameterDirection.Input, "@idUsuario", u.IdUsuario)
            Select Case p.EsPantallaPrincipal.ToLower
                Case "si"
                    cmd.agregarParametro(ParameterDirection.Input, "@esPantallaPrincipal", 1)
                Case "no"
                    cmd.agregarParametro(ParameterDirection.Input, "@esPantallaPrincipal", 0)
            End Select
            cmd.ejecutar()
        Next
    End Sub


    Public Shared Function VistaUsuarioAjax(ByVal param As String) As DataTable
        Dim cmd As New comando("usuarioVistaAjax")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", param)
        Return cmd.ejecutar()
    End Function
    Public Shared Function PermisosVistaAjax(ByVal param As String) As DataTable
        Dim cmd As New comando("PermisosVistaAjax")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", param)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerUsuario(ByVal idUsuario As Integer) As Usuario
        Dim cmd As New comando("dbo.usuarioSelectById")
        cmd.agregarParametro(ParameterDirection.Input, "@idUsuario", idUsuario)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Return DMUsuario.Mapear(.Rows(0))
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function ObtenerUsuario(ByVal nombreUsuario As String) As Usuario
        Dim cmd As New comando("dbo.usuarioSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@nombreUsuario", nombreUsuario)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Return DMUsuario.Mapear(.Rows(0))
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarUsuario(ByVal u As Usuario) As Integer
        Dim cmd As New comando("dbo.usuarioInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@NombreUsuario", u.NombreUsuario)
        cmd.agregarParametro(ParameterDirection.Input, "@Clave", u.Clave)
        cmd.agregarParametro(ParameterDirection.Input, "@Nombre", u.Nombre)
        cmd.agregarParametro(ParameterDirection.Input, "@Email", u.Email)
        Return CType(cmd.ejecutar().Rows(0).Item("idUsuario"), Integer)
    End Function
    Public Shared Function ActualizarUsuario(ByVal u As Usuario) As Integer
        Dim cmd As New comando("dbo.usuarioUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@IdUsuario", u.IdUsuario)
        cmd.agregarParametro(ParameterDirection.Input, "@NombreUsuario", u.NombreUsuario)
        cmd.agregarParametro(ParameterDirection.Input, "@Clave", u.Clave)
        cmd.agregarParametro(ParameterDirection.Input, "@Nombre", u.Nombre)
        cmd.agregarParametro(ParameterDirection.Input, "@Email", u.Email)
        cmd.ejecutar()
        Return u.IdUsuario
    End Function
    Public Shared Function ObtenerPantallasByTipo(ByVal u As Usuario, ByVal tipo As String) As DataTable
        Dim cmd As New comando("dbo.usuarioPantallasByTipo")
        cmd.agregarParametro(ParameterDirection.Input, "@idUsuario", u.IdUsuario)
        cmd.agregarParametro(ParameterDirection.Input, "@tipo", tipo)
        Return cmd.ejecutar()
    End Function
    Public Shared Sub BorrarUsuario(ByVal idUsuario As Integer)
        Dim cmd As New comando("dbo.usuarioDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idUsuario", idUsuario)

        cmd.ejecutar()
    End Sub
    Public Shared Function PantallasUsuarioVista(ByVal idUsuario As Integer) As List(Of PantallaUsuarioItem)
        Dim cmd As New comando("dbo.PantallasUsuarioVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idUsuario", idUsuario)
        Dim l As New List(Of PantallaUsuarioItem)
        For Each r As DataRow In cmd.ejecutar.Rows()
            Dim p As New Pantalla
            Dim pi As New PantallaUsuarioItem
            p.IdPantalla = CType(r.Item("idPantalla"), Integer)
            p.Descripcion = CType(r.Item("descripcion"), String)
            p.Tipo = CType(r.Item("tipo"), String)
            p.Url = CType(r.Item("url"), String)
            pi.Pantalla = p
            pi.EsPantallaPrincipal = CType(r.Item("esPantallaPrincipal"), String)
            l.Add(pi)
        Next
        Return l
    End Function
End Class
