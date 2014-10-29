Imports AccesoDatos
Public Class DMMultaSocioItem

    Public Shared Function ObtenerMultaSocioItem(ByVal idMultaSocioItem As Integer) As MultaSocioItem
        Dim cmd As New comando("dbo.multaSocioItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMultaSocioItem", idMultaSocioItem)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim mi As New MultaSocioItem
                mi.IdMultaSocioItem = idMultaSocioItem
                mi.Monto = CType(.Rows(0).Item("monto"), Double)
                mi.Socio = Sistema.ObtenerSocio(CType(.Rows(0).Item("idSocio"), Integer))
                mi.IdMultaSocio = CType(.Rows(0).Item("idMultaSocio"), Integer)
                Return mi
            Else
                Return Nothing
            End If
        End With

    End Function


    Public Shared Function AgregarMultaSocioItem(ByVal m As MultaSocioItem, ByVal idMultaSocio As Integer) As Integer
        Dim cmd As New comando("multaSocioItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idMultaSocio", idMultaSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@idSocio", m.Socio.IdSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@monto", m.Monto)
        Return CType(cmd.ejecutar().Rows(0).Item("idMultaSocioItem"), Integer)
    End Function


    Public Shared Function VistaMultaSocioImpaga(ByVal idSocio As Integer) As DataTable
        Dim cmd As New comando("multaSocioImpagaVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idSocio", idSocio)
        Return cmd.ejecutar()
    End Function

End Class
