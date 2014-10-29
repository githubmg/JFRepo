Imports AccesoDatos
Public Class DMComprobanteCabe

    Public Shared Function ObtenerProximoNumeroComprobante(ByVal idTipoComprobante As Integer, ByVal puntoVenta As Integer) As Integer
        Dim cmd As New comando("dbo.proximoNumeroComprobante")
        cmd.agregarParametro(ParameterDirection.Input, "@puntoVenta", puntoVenta)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", idTipoComprobante)
        Return CType(cmd.ejecutar().Rows(0).Item("numeroComprobante"), Integer)
    End Function

    Public Shared Function ObtenerComprobanteCabe(ByVal idComprobante As Integer) As ComprobanteCabe
        Dim cmd As New comando("dbo.comprobanteCabeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", idComprobante)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim c As New ComprobanteCabe
                c.IdComprobante = idComprobante
                c.PuntoVenta = CType(.Rows(0).Item("PuntoVenta"), Integer)
                c.TipoComprobante = Sistema.ObtenerTipoComprobante(CType(.Rows(0).Item("idTipoComprobante"), Integer))
                c.NumeroComprobante = CType(.Rows(0).Item("numeroComprobante"), Integer)
                c.FechaEmision = CType(.Rows(0).Item("fechaEmision"), Date)
                c.FechaVencimiento = CType(.Rows(0).Item("fechaVencimiento"), Date)
                c.FechaServDesde = CType(.Rows(0).Item("fechaServDesde"), Date)
                c.FechaServHasta = CType(.Rows(0).Item("fechaServHasta"), Date)
                c.CondicionPago = CType(.Rows(0).Item("condicionPago"), Integer)
                c.ObservacionesComprobante = CType(.Rows(0).Item("ObservacionesComprobante"), String)

                If Not .Rows(0).IsNull("idSocio") Then c.Socio = Sistema.ObtenerSocio(CType(.Rows(0).Item("idSocio"), Integer))
                If Not .Rows(0).IsNull("idClub") Then c.Club = Sistema.ObtenerClub(CType(.Rows(0).Item("idClub"), Integer))
                If Not .Rows(0).IsNull("idFederacion") Then c.Federacion = Sistema.ObtenerFederacion(CType(.Rows(0).Item("idFederacion"), Integer))

                c.Items = Sistema.ObtenerComprobanteItemPorComprobante(idComprobante)


                Return c
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarComprobanteCabe(ByVal c As ComprobanteCabe) As Integer
        Dim cmd As New comando("dbo.comprobanteCabeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@puntoVenta", c.PuntoVenta)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", c.TipoComprobante.IdTipoComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEmision", c.FechaEmision)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaVencimiento", c.FechaVencimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaServDesde", c.FechaServDesde)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaServHasta", c.FechaServHasta)
        cmd.agregarParametro(ParameterDirection.Input, "@condicionPago", c.CondicionPago)
        cmd.agregarParametro(ParameterDirection.Input, "@ObservacionesComprobante", c.ObservacionesComprobante)

        If Not c.Socio Is Nothing Then cmd.agregarParametro(ParameterDirection.Input, "idSocio", c.Socio.IdSocio)
        If Not c.Club Is Nothing Then cmd.agregarParametro(ParameterDirection.Input, "idClub", c.Club.IdClub)
        If Not c.Federacion Is Nothing Then cmd.agregarParametro(ParameterDirection.Input, "idFederacion", c.Federacion.IdFederacion)

        Dim dt As DataTable = cmd.ejecutar()

        c.IdComprobante = CType(dt.Rows(0).Item("idComprobante"), Integer)
        c.NumeroComprobante = CType(dt.Rows(0).Item("NumeroComprobante"), Integer)

        For Each ci As ComprobanteItem In c.Items
            Sistema.AgregarComprobanteItem(ci, c.IdComprobante)
        Next

        Return c.IdComprobante
    End Function
    Public Shared Function ActualizarComprobanteCabe(ByVal c As ComprobanteCabe) As Integer
        Dim cmd As New comando("dbo.comprobanteCabeUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@puntoVenta", c.IdComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@puntoVenta", c.PuntoVenta)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoComprobante", c.TipoComprobante.IdTipoComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@numeroComprobante", c.NumeroComprobante)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaEmision", c.FechaEmision)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaVencimiento", c.FechaVencimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaServDesde", c.FechaServDesde)
        cmd.agregarParametro(ParameterDirection.Input, "@fechaServHasta", c.FechaServHasta)
        cmd.agregarParametro(ParameterDirection.Input, "@condicionPago", c.CondicionPago)
        cmd.agregarParametro(ParameterDirection.Input, "@ObservacionesComprobante", c.ObservacionesComprobante)

        If Not c.Socio Is Nothing Then cmd.agregarParametro(ParameterDirection.Input, "idSocio", c.Socio.IdSocio)
        If Not c.Club Is Nothing Then cmd.agregarParametro(ParameterDirection.Input, "idClub", c.Club.IdClub)
        If Not c.Federacion Is Nothing Then cmd.agregarParametro(ParameterDirection.Input, "idFederacion", c.Federacion.IdFederacion)

        Return CType(cmd.ejecutar().Rows(0).Item("idComprobante"), Integer)

        Sistema.BorrarComprobanteItem(c.IdComprobante)
        For Each ci As ComprobanteItem In c.Items
            Sistema.AgregarComprobanteItem(ci, c.IdComprobante)
        Next
        Return c.IdComprobante
    End Function
End Class
