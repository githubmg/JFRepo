Imports AccesoDatos

Public Class DMMovimientoCaja
    Public Shared Function ObtenerMovimientoCaja(ByVal idMovimientoCaja As Integer) As MovimientoCaja
        Dim cmd As New comando("dbo.MovimientoCajaSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoCaja", idMovimientoCaja)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim m As New MovimientoCaja
                m.idMovimientoCaja = CType(.Rows(0).Item("idMovimientoCaja"), Integer)
                m.TipoMovimiento = Sistema.ObtenerTipoMovimiento(CType(.Rows(0).Item("idTipoMovimiento"), Integer))
                m.fecha = CType(.Rows(0).Item("fecha"), Date)
                m.MedioPago = Sistema.ObtenerMedioPago(CType(.Rows(0).Item("idMedioPago"), Integer))
                m.DescripcionMovCaja = Sistema.ObtenerDescripcionMovCaja(CType(.Rows(0).Item("idDescripcionMovCaja"), Integer))
                m.Monto = CType(.Rows(0).Item("monto"), Double)
                Return m
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarMovimientoCaja(ByVal m As MovimientoCaja) As Integer
        Dim cmd As New comando("dbo.MovimientoCajaInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoMovimiento", m.TipoMovimiento.IdTipoMovimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", m.fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago", m.MedioPago.IdMedioPago)
        cmd.agregarParametro(ParameterDirection.Input, "@monto", m.Monto)
        cmd.agregarParametro(ParameterDirection.Input, "@idDescripcionMovCaja", m.DescripcionMovCaja.IdDescripcionMovCaja)
        m.IdMovimientoCaja = CType(cmd.ejecutar().Rows(0).Item("idMovimientoCaja"), Integer)
        If m.MedioPago.Descripcion.ToLower.Trim = "cheque" Then
            If m.TipoMovimiento.Descripcion.ToLower.Trim = "ingreso" Then
                m.Cheque.EnCartera = True
            End If
            m.Cheque.IdCheque = Sistema.AgregarCheque(m.Cheque)
            Sistema.AgregarMovimientoCajaCheque(m)
        End If
        Return m.IdMovimientoCaja
    End Function
    Public Shared Function ActualizarMovimientoCaja(ByVal m As MovimientoCaja) As Integer
        Sistema.BorrarMovimientoCajaCheque(m)
        Dim cmd As New comando("dbo.MovimientoCajaUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoCaja", m.IdMovimientoCaja)
        cmd.agregarParametro(ParameterDirection.Input, "@idTipoMovimiento", m.TipoMovimiento.IdTipoMovimiento)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", m.Fecha)
        cmd.agregarParametro(ParameterDirection.Input, "@idMedioPago", m.MedioPago.IdMedioPago)
        cmd.agregarParametro(ParameterDirection.Input, "@idDescripcionMovCaja", m.DescripcionMovCaja.IdDescripcionMovCaja)
        cmd.agregarParametro(ParameterDirection.Input, "@monto", m.Monto)
        m.IdMovimientoCaja = CType(cmd.ejecutar().Rows(0).Item("idMovimientoCaja"), Integer)
        If m.MedioPago.Descripcion.ToLower.Trim = "cheque" Then
            If m.TipoMovimiento.Descripcion.ToLower.Trim = "ingreso" Then
                m.Cheque.EnCartera = True
            End If
            m.Cheque.IdCheque = Sistema.AgregarCheque(m.Cheque)
            Sistema.AgregarMovimientoCajaCheque(m)
        End If
        Return m.IdMovimientoCaja
    End Function
    Public Shared Function VistaMovimientoCaja() As DataTable
        Dim cmd As New comando("dbo.MovimientoCajaVista")
        Return cmd.ejecutar()
    End Function
    Public Shared Function AgregarMovimientoCajaCheque(ByVal m As MovimientoCaja) As Integer
        Dim cmd As New comando("dbo.MovimientoCajaChequeInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoCaja", m.IdMovimientoCaja)
        cmd.agregarParametro(ParameterDirection.Input, "@idCheque", m.Cheque.IdCheque)
        Return CType(cmd.ejecutar().Rows(0).Item("idMovimientoCaja"), Integer)
    End Function
    Public Shared Function BorrarMovimientoCajaCheque(ByVal m As MovimientoCaja) As Integer
        Dim cmd As New comando("dbo.MovimientoCajaChequeDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idMovimientoCaja", m.IdMovimientoCaja)
        Return CType(cmd.ejecutar().Rows(0).Item("idMovimientoCaja"), Integer)
    End Function
End Class
