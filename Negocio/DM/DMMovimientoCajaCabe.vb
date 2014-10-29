Imports AccesoDatos

Public Class DMMovimientoCajaCabe
    Public Shared Function ObtenerMovimientoCajaCabe(ByVal idMovimientoCaja As Integer) As MovimientoCajaCabe
        Dim cmd As New comando("dbo.MovimientoCajaCabeSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoCaja", idMovimientoCaja)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim m As New MovimientoCajaCabe
                m.IdMovimientoCaja = CType(.Rows(0).Item("idMovimientoCaja"), Integer)
                m.Fecha = CType(.Rows(0).Item("fecha"), Date)
                m.IdComprobante = CType(.Rows(0).Item("idComprobante"), Integer)
                m.IdPago = CType(.Rows(0).Item("idPago"), Integer)
                m.IdFondoFijo = CType(.Rows(0).Item("IdFondoFijo"), Integer)
                Return m
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarMovimientoCajaCabe(ByVal m As MovimientoCajaCabe) As Integer
        Dim cmd As New comando("dbo.MovimientoCajaCabeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", m.Fecha)
        If m.IdComprobante > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@idComprobante", m.IdComprobante)
        If m.IdPago > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@idPago", m.IdPago)
        If m.IdFondoFijo > 0 Then cmd.agregarParametro(ParameterDirection.Input, "@IdFondoFijo", m.IdFondoFijo)
        m.IdMovimientoCaja = CType(cmd.ejecutar().Rows(0).Item("idMovimientoCaja"), Integer)

        For Each mi As MovimientoCajaItem In m.Items
            mi.IdMovimientoCaja = m.IdMovimientoCaja
            Sistema.AgregarMovimientoCajaItem(mi)
        Next

        Return m.IdMovimientoCaja
    End Function

    Public Shared Function VistaMovimientoCajaCabe() As DataTable
        Dim cmd As New comando("dbo.MovimientoCajaCabeVista")
        Return cmd.ejecutar()
    End Function

End Class
