Imports AccesoDatos
Public Class DMFondoFijo
    Public Shared Function ObtenerFondoFijo(ByVal idFondoFijo As Integer) As FondoFijo
        Dim cmd As New comando("dbo.FondoFijoSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijo", idFondoFijo)
        With cmd.ejecutar()
            If .Rows.Count > 0 Then
                Dim f As New FondoFijo
                f.IdFondoFijo = CType(.Rows(0).Item("idFondoFijo"), Integer)
                f.FormaPago = Sistema.ObtenerFormaPago(CType(.Rows(0).Item("idFormaPago"), Integer))
                f.Observaciones = CType(.Rows(0).Item("observaciones"), String)
                f.Fecha = CType(.Rows(0).Item("fecha"), Date)
                Return f
            Else : Return Nothing
            End If
        End With
    End Function
    Public Shared Function AgregarFondoFijo(ByVal f As FondoFijo) As Integer
        Dim cmd As New comando("dbo.FondoFijoInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idFormaPago", f.FormaPago.IdFormaPago)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", f.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", f.Fecha)
        f.IdFondoFijo = CType(cmd.ejecutar().Rows(0).Item("idFondoFijo"), Integer)

        Sistema.BorrarFondoFijoItem(f)

        For Each fi As FondoFijoItem In f.Items
            Sistema.AgregarFondoFijoItem(f, fi)
        Next


        Return f.IdFondoFijo
    End Function
    Public Shared Function ActualizarFondoFijo(ByVal f As FondoFijo) As Integer
        Dim cmd As New comando("dbo.FondoFijoUpdate")
        cmd.agregarParametro(ParameterDirection.Input, "@idFondoFijo", f.IdFondoFijo)
        cmd.agregarParametro(ParameterDirection.Input, "@idFormaPago", f.FormaPago.IdFormaPago)
        cmd.agregarParametro(ParameterDirection.Input, "@observaciones", f.Observaciones)
        cmd.agregarParametro(ParameterDirection.Input, "@fecha", f.Fecha)
        f.IdFondoFijo = CType(cmd.ejecutar().Rows(0).Item("idFondoFijo"), Integer)

        Sistema.BorrarFondoFijoItem(f)

        For Each fi As FondoFijoItem In f.Items
            Sistema.AgregarFondoFijoItem(f, fi)
        Next

        Return f.IdFondoFijo
    End Function
    Public Shared Function VistaFondoFijo() As DataTable
        Dim cmd As New comando("dbo.FondoFijoVista")
        Return cmd.ejecutar()
    End Function

End Class
