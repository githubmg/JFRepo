<Serializable()>
Public Class Usuario
    Private _idUsuario As Integer
    Private _nombreUsuario As String
    Private _clave As String
    Private _nombre As String
    Private _email As String
    Private _pantallaDefault As String
    Public Property PantallaDefault() As String
        Get
            Return Me._pantallaDefault
        End Get
        Set(ByVal value As String)
            Me._pantallaDefault = value
        End Set
    End Property
    Public Property IdUsuario() As Integer
        Get
            Return Me._idUsuario
        End Get
        Set(ByVal value As Integer)
            Me._idUsuario = value
        End Set
    End Property
    Public Property NombreUsuario() As String
        Get
            Return Me._nombreUsuario
        End Get
        Set(ByVal value As String)
            Me._nombreUsuario = value
        End Set
    End Property
    Public Property Clave() As String
        Get
            Return Me._clave
        End Get
        Set(ByVal value As String)
            Me._clave = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return Me._nombre
        End Get
        Set(ByVal value As String)
            Me._nombre = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return Me._email
        End Get
        Set(ByVal value As String)
            Me._email = value
        End Set
    End Property


End Class
