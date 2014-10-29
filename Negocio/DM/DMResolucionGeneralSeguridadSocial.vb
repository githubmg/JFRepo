Imports AccesoDatos
Public Class DMResolucionGeneralSeguridadSocial
    Public Shared Function ObtenerResolucionGeneralSeguridadSocial(ByVal idResolucionGeneral As Integer) As ResolucionGeneralSeguridadSocial
        Dim cmd As New comando("dbo.ResolucionGeneralSeguridadSocialSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idResolucionGeneral", idResolucionGeneral)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New ResolucionGeneralSeguridadSocial
                o.IdResolucionGeneral = idResolucionGeneral
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaResolucionGeneralSeguridadSocial() As DataTable
        Return New comando("dbo.ResolucionGeneralSeguridadSocialSelect").ejecutar()
    End Function
End Class
