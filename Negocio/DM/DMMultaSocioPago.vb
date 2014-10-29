Imports AccesoDatos
Public Class DMMultaSocioPago
    Public Shared Function AgregarMultaSocioPago(ByVal idMultaSocioItem As Integer) As Integer
        Dim cmd As New comando("MultaSocioPagoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idMultaSocioItem", idMultaSocioItem)
        cmd.ejecutar()
        Return idMultaSocioItem
    End Function

End Class
