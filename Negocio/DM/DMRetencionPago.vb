Imports AccesoDatos
Public Class DMRetencionPago
    Public Shared Function AgregarRetencionPago(ByVal p As PagoProveedor, ByVal r As RetencionPago) As Integer
        Dim cmd As New comando("dbo.retencionPagoProveedorInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idPago", p.IdPago)
        cmd.agregarParametro(ParameterDirection.Input, "@idRetencion", r.Retencion.IdRetencion)
        cmd.agregarParametro(ParameterDirection.Input, "@idConceptoRetencion", r.ConceptoRetencion.IdConcepto)
        cmd.agregarParametro(ParameterDirection.Input, "@importe", r.Importe)
        Return CType(cmd.ejecutar().Rows(0).Item("idRetencionPago"), Integer)
    End Function
End Class
