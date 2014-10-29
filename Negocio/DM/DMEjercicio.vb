Imports AccesoDatos
Public Class DMEjercicio
    Public Shared Function ObtenerEjercicio(ByVal idEjercicio As Integer) As Ejercicio
        Dim cmd As New comando("dbo.EjercicioSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idEjercicio", idEjercicio)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim e As New Ejercicio
                e.idEjercicio = CType(.Rows(0).Item("idEjercicio"), Integer)
                e.fechaInicio = CType(.Rows(0).Item("fechaInicio"), Date)
                e.fechaFin = CType(.Rows(0).Item("fechaFin"), Date)
                e.activo = CType(.Rows(0).Item("activo"), Boolean)
                Return e
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarEjercicio(ByVal e As Ejercicio) As Integer
        Dim cmd As New comando("dbo.EjercicioInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fechaInicio", e.fechaInicio)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaFin", e.fechaFin)
        cmd.agregarParametro(ParameterDirection.Input, "@activo", e.activo)
        Return CType(cmd.ejecutar().Rows(0).Item("idEjercicio"), Integer)
    End Function
    Public Shared Function ActualizarEjercicio(ByVal e As Ejercicio) As Integer
        Dim cmd As New comando("dbo.EjercicioUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idEjercicio", e.idEjercicio)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaInicio", e.fechaInicio)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaFin", e.fechaFin)
        cmd.agregarParametro(ParameterDirection.Input, "@activo", e.activo)
        Return CType(cmd.ejecutar().Rows(0).Item("idEjercicio"), Integer)
    End Function
    Public Shared Function VistaEjercicio() As DataTable
        Dim cmd As New comando("dbo.EjercicioSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idEjercicio")
        Return cmd.ejecutar()
    End Function

End Class
