Imports AccesoDatos
Public Class DMCotizacion
    Public Shared Function ObtenerCotizacion(ByVal idCotizacion As Integer) As Cotizacion
        Dim cmd As New comando("dbo.CotizacionSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idCotizacion", idCotizacion)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New Cotizacion
                c.IdCotizacion = CType(.Rows(0).Item("idCotizacion"), Integer)
                c.Moneda = Sistema.ObtenerMoneda(CType(.Rows(0).Item("idMoneda"), Integer))
                c.Fecha = CType(.Rows(0).Item("fecha"), Date)
                c.Cotizacion = CType(.Rows(0).Item("cotizacion"), Double)
                Return c
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarCotizacion(ByVal c As Cotizacion) As Integer
        Dim cmd As New comando("dbo.CotizacionInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", c.Moneda.IdMoneda)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", c.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@cotizacion", c.cotizacion)
        Return CType(cmd.ejecutar().Rows(0).Item("idCotizacion"), Integer)
    End Function
    Public Shared Function ActualizarCotizacion(ByVal c As Cotizacion) As Integer
        Dim cmd As New comando("dbo.CotizacionUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idCotizacion", c.idCotizacion)
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", c.Moneda.IdMoneda)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", c.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@cotizacion", c.cotizacion)
        Return CType(cmd.ejecutar().Rows(0).Item("idCotizacion"), Integer)
    End Function
    Public Shared Function VistaCotizacion(ByVal idMoneda As Integer) As DataTable
        Dim cmd As New comando("dbo.cotizacionVista")
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", idMoneda)
        Return cmd.ejecutar()
    End Function
    Public Shared Function ObtenerCotizacionActual(ByVal idMoneda As Integer) As Double
        Dim cmd As New comando("dbo.cotizacionActual")
        cmd.agregarParametro(ParameterDirection.Input, "@idMoneda", idMoneda)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Return CType(.Rows(0).Item("cotizacion"), Double)
            Else
                Return 0
            End If
        End With
    End Function
End Class
