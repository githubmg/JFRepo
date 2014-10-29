Imports AccesoDatos

Public Class DMFamilia
    Public Shared Function ObtenerFamilia(ByVal idFamilia As Integer) As Familia
        Dim cmd As New comando("dbo.FamiliaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFamilia", idFamilia)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim f As New Familia
                f.idFamilia = CType(.Rows(0).Item("idFamilia"), Integer)
                f.descripcion = CType(.Rows(0).Item("descripcion"), String)
                Return f
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarFamilia(ByVal f As Familia) As Integer
        Dim cmd As New comando("dbo.familiaInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", f.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idFamilia"), Integer)
    End Function
    Public Shared Function ActualizarFamilia(ByVal f As Familia) As Integer
        Dim cmd As New comando("dbo.familiaUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idFamilia", f.idFamilia)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", f.descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idFamilia"), Integer)
    End Function
    Public Shared Function VistaFamilia() As DataTable
        Dim cmd As New comando("dbo.familiaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFamilia")
        Return cmd.ejecutar()
    End Function
End Class
