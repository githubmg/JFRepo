Imports System.Data.SqlClient

Public Class comando

    Private _conString As String
    Private _storedProcedure As String
    Private _parametros As New List(Of SqlParameter)

    Public Property StoredProcedure() As String
        Get
            Return _storedProcedure
        End Get
        Set(ByVal value As String)
            _storedProcedure = value
        End Set
    End Property

    Public ReadOnly Property ConString() As String
        Get
            Return Me._conString
        End Get
    End Property

    Public Sub New(ByVal sp As String)
        Dim archIni As New clsINI()
        'MsgBox(System.Windows.Forms.Application.StartupPath)
        Me._conString = archIni.IniGet(System.Windows.Forms.Application.StartupPath & "\Configuracion\config.ini", "Connection", "connectionString")
        If Me._conString = "" Then Me._conString = System.Configuration.ConfigurationManager.ConnectionStrings.Item("strcnn").ConnectionString
        Me._storedProcedure = sp
    End Sub

    Public Sub New(ByVal sp As String, ByVal strcon As String)
        Me._conString = strcon
        Me._storedProcedure = sp
    End Sub

    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String)
        Dim par As New SqlParameter
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = DBNull.Value
        _parametros.Add(par)
    End Sub
    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String, ByVal valor As Boolean)
        Dim par As New SqlParameter
        'par.OleDbType = OleDbType.Empty
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = valor
        _parametros.Add(par)
    End Sub
    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String, ByVal valor As Double)
        Dim par As New SqlParameter
        par.SqlDbType = SqlDbType.Decimal
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = valor
        _parametros.Add(par)
    End Sub

    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String, ByVal valor As String)
        Dim par As New SqlParameter
        par.SqlDbType = SqlDbType.VarChar
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = valor
        _parametros.Add(par)
    End Sub

    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String, ByVal valor As Integer)
        Dim par As New SqlParameter
        par.SqlDbType = SqlDbType.Int
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = valor
        _parametros.Add(par)
    End Sub

    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String, ByVal valor As Long)
        Dim par As New SqlParameter
        par.SqlDbType = SqlDbType.BigInt
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = valor
        _parametros.Add(par)
    End Sub

    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String, ByVal valor As Date)
        Dim par As New SqlParameter
        par.SqlDbType = SqlDbType.DateTime
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = valor
        _parametros.Add(par)
    End Sub

    Public Sub agregarParametro(ByVal direccion As ParameterDirection, ByVal nombre As String, ByVal valor As DBNull)
        Dim par As New SqlParameter
        'par.OleDbType = OleDbType.Empty
        par.Direction = direccion
        par.ParameterName = nombre
        par.Value = valor
        _parametros.Add(par)
    End Sub

    Public Function ejecutar() As DataTable
        Dim dt As New DataTable()
        Dim con As New SqlConnection(_conString)

        Dim cmd As New SqlCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoredProcedure
        cmd.CommandTimeout = con.ConnectionTimeout
        For Each par As SqlParameter In _parametros
            cmd.Parameters.Add(par)
        Next
        Dim da As New SqlDataAdapter(cmd)
        con.Open()

        'MsgBox(cmd.CommandTimeout.ToString)
        da.Fill(dt)
        con.Close()
        Return dt
    End Function

    Public Function ejecutarInsert() As Integer
        Dim con As New SqlConnection(_conString)
        Dim cmd As New SqlCommand()
        Dim newid As Integer

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoredProcedure

        For Each par As SqlParameter In _parametros
            cmd.Parameters.Add(par)
        Next
        con.Open()
        cmd.ExecuteNonQuery()

        'Leo el id asignado si fue un insert
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT @@identity"
        Dim data As SqlDataReader
        data = cmd.ExecuteReader()
        data.Read()
        newid = CInt(data.Item(0))

        con.Close()
        Return newid
    End Function

    Public Function ejecutarBatch(ByVal con As SqlConnection, ByVal tran As SqlTransaction) As Integer
        Dim cmd As New SqlCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoredProcedure
        cmd.Transaction = tran
        For Each par As SqlParameter In _parametros
            cmd.Parameters.Add(par)
        Next
        cmd.ExecuteNonQuery()
    End Function

    Public Sub ejecutarNonQuery()
        Dim con As New SqlConnection(_conString)
        Dim cmd As New SqlCommand()

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoredProcedure

        For Each par As SqlParameter In _parametros
            cmd.Parameters.Add(par)
        Next

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub mantenerPool()
        Dim con As New SqlConnection(_conString)
        con.Open()
        con.Close()
    End Sub

End Class
