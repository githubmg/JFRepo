Imports AccesoDatos
Public Class DMDescripcionMovCaja
    Public Shared Function ObtenerDescripcionMovCaja(ByVal idDescripcionMovCaja As Integer) As DescripcionMovCaja
        Dim cmd As New comando("dbo.DescripcionMovCajaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idDescripcionMovCaja", idDescripcionMovCaja)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim o As New DescripcionMovCaja
                o.IdDescripcionMovCaja = idDescripcionMovCaja
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function VistaDescripcionMovCaja() As DataTable
        Return New comando("dbo.DescripcionMovCajaSelect").ejecutar()
    End Function
End Class
