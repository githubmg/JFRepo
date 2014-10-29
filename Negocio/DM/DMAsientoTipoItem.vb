Imports AccesoDatos
Public Class DMAsientoTipoItem
    Public Shared Function ObtenerAsientoTipoItem(ByVal idAsientoTipoItem As Integer) As AsientoItem
        Dim cmd As New comando("AsientoTipoItemSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsientoTipoItem", idAsientoTipoItem)
        With cmd.ejecutar
            If .Rows.Count > 0 Then
                Dim ai As New AsientoItem
                ai.IdAsientoItem = idAsientoTipoItem
                ai.Cuenta = Sistema.ObtenerCuenta(.Rows(0).Item("codigoCuenta").ToString())
                ai.Debe = CType(.Rows(0).Item("debe"), Double)
                ai.Haber = CType(.Rows(0).Item("Haber"), Double)
                Return ai
            Else
                Return Nothing
            End If
        End With
    End Function
    Public Shared Function ObtenerAsientoTipoItems(ByVal idAsientoTipo As Integer) As List(Of AsientoItem)
        Dim cmd As New comando("AsientoTipoItemsSelect")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsientoTipo", idAsientoTipo)
        Dim l As New List(Of AsientoItem)
        For Each r As DataRow In cmd.ejecutar.Rows()
            l.Add(Sistema.ObtenerAsientoTipoItem(CType(r.Item("idAsientoTipoItem"), Integer)))
        Next
        Return l
    End Function
    Public Shared Function AgregarAsientoTipoItem(ByVal ai As AsientoItem, ByVal idAsientoTipo As Integer) As Integer
        Dim cmd As New comando("dbo.AsientoTipoItemInsert")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsientoTipo", idAsientoTipo)
        cmd.agregarParametro(ParameterDirection.Input, "@codigoCuenta", ai.Cuenta.Codigo)
        cmd.agregarParametro(ParameterDirection.Input, "debe", ai.Debe)
        cmd.agregarParametro(ParameterDirection.Input, "haber", ai.Haber)
        Return CType(cmd.ejecutar().Rows(0).Item("idAsientoTipoItem"), Integer)
    End Function
    Public Shared Sub BorrarAsientoTipoItem(ByVal idAsientoTipo As Integer)
        Dim cmd As New comando("dbo.AsientoTipoItemDelete")
        cmd.agregarParametro(ParameterDirection.Input, "@idAsientoTipo", idAsientoTipo)
        cmd.ejecutar()
    End Sub
End Class
