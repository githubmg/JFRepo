Imports AccesoDatos
Public Class DMConceptoRetencion
    Public Shared Function VistaConceptoRetencion(ByVal idRetencion As Integer) As DataTable
        Dim cmd As New comando("dbo.ConceptoRetencionSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idRetencion", idRetencion)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerConceptoRetencion(ByVal IdConcepto As Integer) As ConceptoRetencion
        Dim cmd As New comando("dbo.ConceptoRetencionSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@IdConcepto", IdConcepto)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim cr As New ConceptoRetencion
                cr.IdConcepto = IdConcepto
                cr.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return cr
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
