Imports AccesoDatos
Public Class DMBanco
    Public Shared Function ObtenerBanco(ByVal idBanco As Integer) As Banco
        Dim cmd As New comando("dbo.BancoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idBanco", idBanco)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New Banco
                o.IdBanco = idBanco
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaBanco() As DataTable
        Return New comando("dbo.BancoSelect").ejecutar()
    End Function
    Public Shared Function AgregarBanco(ByVal b As Banco) As Integer
        Dim cmd As New comando("dbo.bancoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", b.Descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idBanco"), Integer)
    End Function
    Public Shared Function ActualizarBanco(ByVal b As Banco) As Integer
        Dim cmd As New comando("dbo.bancoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idBanco", b.IdBanco)
        cmd.agregarParametro(ParameterDirection.Input, "@descripcion", b.Descripcion)
        Return CType(cmd.ejecutar().Rows(0).Item("idBanco"), Integer)
    End Function
End Class
