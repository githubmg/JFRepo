Imports AccesoDatos
Public Class DMPagoCuotaSocio
    Public Shared Function AgregarPagoCuotaSocio(ByVal p As PagoCuotaSocio) As Integer
        Dim cmd As New comando("dbo.pagoCuotaSocioInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idSocio", p.Socio.IdSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@idConcepto", p.ConceptoCuota.IdConcepto)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", p.Importe)
        cmd.agregarParametro(ParameterDirection.Input, "@año", p.Año)
        Return CType(cmd.ejecutar().Rows(0).Item("idPagoCuotaSocio"), Integer)
    End Function
End Class
