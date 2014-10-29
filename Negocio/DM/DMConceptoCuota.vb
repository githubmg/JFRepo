Imports AccesoDatos
Public Class DMConceptoCuota
    Public Shared Function VistaConceptoCuota(ByVal idcategoriaSocio As Integer, ByVal esProfesional As Boolean) As DataTable
        Dim cmd As New comando("dbo.conceptoCuotaVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idcategoriaSocio", idcategoriaSocio)
        cmd.agregarParametro(ParameterDirection.Input, "@esProfesional", esProfesional)
        Return cmd.ejecutar()
    End Function

    Public Shared Function ObtenerConceptoCota(ByVal idConcepto As String) As ConceptoCuota
        Dim cmd As New comando("dbo.conceptoCuotaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idConcepto", idConcepto)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim c As New ConceptoCuota
                c.IdConcepto = idConcepto
                c.Descripcion = .Rows(0).Item("Descripcion").ToString()
                c.Importe = CType(.Rows(0).Item("importe"), Double)
                c.Profesional = CType(.Rows(0).Item("Profesional"), Boolean)
                Return c
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
