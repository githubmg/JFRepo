Imports AccesoDatos
Public Class DMAsientoItem
    Public Shared Function ObtenerAsientoItem(ByVal idAsientoItem As Integer) As AsientoItem
        Dim cmd As New comando("asientoItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsientoItem", idAsientoItem)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim ai As New AsientoItem
                ai.IdAsientoItem = idAsientoItem
                ai.Cuenta = Sistema.ObtenerCuenta(.Rows(0).Item("codigoCuenta").ToString())
                ai.Debe = CType(.Rows(0).Item("debe"), Double)
                ai.Haber = CType(.Rows(0).Item("Haber"), Double)
                Return ai
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function ObtenerAsientoItems(ByVal idAsiento As Integer) As List(Of AsientoItem)
        Dim cmd As New comando("AsientoItemsSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsiento", idAsiento)
        Dim l As New List(Of AsientoItem)
        For Each r As DataRow In cmd.ejecutar.Rows()
            l.Add(Sistema.ObtenerAsientoItem(CType(r.Item("idAsientoItem"), Integer)))
        Next
        Return l
    End Function
    Public Shared Function AgregarAsientoItem(ByVal ai As AsientoItem, ByVal idAsiento As Integer) As Integer
        Dim cmd As New comando("dbo.asientoItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsiento", idAsiento)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuenta", ai.Cuenta.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "debe", ai.Debe)
        cmd.agregarParametro(ParameterDirection.Input, "haber", ai.Haber)
        Return CType(cmd.ejecutar().Rows(0).Item("idAsientoItem"), Integer)
    End Function
    Public Shared Sub BorrarAsientoItem(ByVal idAsiento As Integer)
        Dim cmd As New comando("dbo.asientoItemDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsiento", idAsiento)
        cmd.ejecutar()
    End Sub
End Class
