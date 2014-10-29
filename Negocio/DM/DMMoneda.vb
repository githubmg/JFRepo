Imports AccesoDatos
Public Class DMMoneda
    Public Shared Function ObtenerMoneda(ByVal idMoneda As Integer) As Moneda
        Dim cmd As New comando("dbo.MonedaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", idMoneda)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim m As New Moneda
                m.IdMoneda = CType(.Rows(0).Item("idMoneda"), Integer)
                m.Descripcion = CType(.Rows(0).Item("descripcion"), String)
                m.Simbolo = CType(.Rows(0).Item("simbolo"), String)
                m.Abreviatura = CType(.Rows(0).Item("abreviatura"), String)
                Return m
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarMoneda(ByVal m As Moneda) As Integer
        Dim cmd As New comando("dbo.MonedaInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", m.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@simbolo", m.Simbolo)
        cmd.agregarParametro(ParameterDirection.Input, "@abreviatura", m.Abreviatura)
        Return CType(cmd.ejecutar().Rows(0).Item("idMoneda"), Integer)
    End Function
    Public Shared Function ActualizarMoneda(ByVal m As Moneda) As Integer
        Dim cmd As New comando("dbo.MonedaUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", m.IdMoneda)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", m.Descripcion)
        cmd.agregarParametro(ParameterDirection.Input, "@simbolo", m.Simbolo)
        cmd.agregarParametro(ParameterDirection.Input, "@abreviatura", m.Abreviatura)
        Return CType(cmd.ejecutar().Rows(0).Item("idMoneda"), Integer)
    End Function
    Public Shared Function VistaMoneda() As DataTable
        Dim cmd As New comando("dbo.monedaVista")
        Return cmd.ejecutar()
    End Function

End Class
