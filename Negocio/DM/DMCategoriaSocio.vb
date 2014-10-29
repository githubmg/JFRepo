Imports AccesoDatos
Public Class DMCategoriaSocio
    Public Shared Function VistaCategoriaSocio() As DataTable
        Dim cmd As New comando("CategoriaSocioSelect")
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerCategoriaSocioPorEdad(ByVal edad As Integer) As CategoriaSocio
        Dim cmd As New comando("categoriaSocioEdadSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@edad", edad)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Return Sistema.ObtenerCategoriaSocio(CType(.Rows(0).Item("idcategoriaSocio"), Integer))
            Else
                Return Nothing
            End If
        End With

    End Function

    Public Shared Function ObtenerCategoriaSocio(ByVal idCategoriaSocio As Integer) As CategoriaSocio
        Dim cmd As New comando("CategoriaSocioSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCategoriaSocio", idCategoriaSocio)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim o As New CategoriaSocio
                o.IdcategoriaSocio = idCategoriaSocio
                o.Descripcion = .Rows(0).Item("descripcion").ToString()
                o.EdadMinima = CType(.Rows(0).Item("edadMinima"), Integer)
                o.EdadMaxima = CType(.Rows(0).Item("edadMaxima"), Integer)
                Return o
            Else
                Return Nothing
            End If
        End With
    End Function
End Class
