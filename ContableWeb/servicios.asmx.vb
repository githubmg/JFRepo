Imports Negocio
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
Public Class servicios
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function PermisosVistaAjax(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim dt As DataTable = Sistema.PermisosVistaAjax(prefixText)
        Dim l As New List(Of String)
        For Each r As DataRow In dt.Rows
            l.Add(r.Item("descripcion").ToString())
        Next
        Return l.ToArray()
    End Function

    <WebMethod()> _
    Public Function VistaUsuarioAjax(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim dt As DataTable = Sistema.VistaUsuarioAjax(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item("descripcion").ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <WebMethod()> _
    Public Function VistaCuenta(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim dt As DataTable = Sistema.VistaCuenta(prefixText)
        Dim l As New List(Of String)
        For Each r As DataRow In dt.Rows
            l.Add(r.Item("descripcion").ToString())
        Next
        Return l.ToArray()
    End Function
    <WebMethod()> _
    Public Function VistaProductoStockByDecripcion(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim dt As DataTable = Sistema.VistaProductoStockByDecripcion(prefixText)
        Dim l As New List(Of String)
        For Each r As DataRow In dt.Rows
            l.Add(r.Item("descripcion").ToString())
        Next
        Return l.ToArray()
    End Function

    <WebMethod()> _
    Public Function VistaCliente(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim dt As DataTable = Sistema.VistaCliente(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item("descripcion").ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
        End Try
    End Function
    <WebMethod()> _
    Public Function VistaProveedor(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim dt As DataTable = Sistema.VistaProveedor(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item("descripcion").ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
        End Try
    End Function
    <WebMethod()> _
    Public Function VistaChequeNoCobrado(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim dt As DataTable = Sistema.VistaChequeNoCobrado(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item("descripcion").ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
        End Try
    End Function
    <WebMethod()> _
    Public Function VistaChequeCartera(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim dt As DataTable = Sistema.VistaChequeCartera(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item("descripcion").ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
        End Try
    End Function
    <WebMethod()> _
    Public Function VistaCompraSinSaldar(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim dt As DataTable = Sistema.VistaCompraSinSaldar(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item(0).ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
        End Try
    End Function
    <WebMethod()> _
    Public Function VistaPedidoSinSaldar(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim dt As DataTable = Sistema.VistaPedidoSinSaldar(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item(0).ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
        End Try
    End Function
    <WebMethod()> _
    Public Function VistaRemitoSinFacturar(ByVal prefixText As String) As String()
        Try
            Dim dt As DataTable = Sistema.VistaRemitoSinFacturar(prefixText)
            Dim l As New List(Of String)
            For Each r As DataRow In dt.Rows
                l.Add(r.Item(0).ToString())
            Next
            Return l.ToArray()
        Catch ex As Exception
        End Try
    End Function
End Class