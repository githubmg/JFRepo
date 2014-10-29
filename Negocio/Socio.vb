<Serializable()> _
Public Class Socio
    Private _idSocio As Integer
    Private _TipoDocumento As TipoDocumento
    Private _numeroDocumento As Integer
    Private _Sexo As Sexo
    Private _PaisNacionalidad As Pais
    Private _Provincia As Provincia
    Private _EstadoCivil As EstadoCivil
    Private _club As Club
    Private _federacion As Federacion
    Private _EstadoSocio As EstadoSocio
    Private _CategoriaSocio As CategoriaSocio
    Private _fechaNacimiento As Date
    Private _fechaIngreso As Date
    Private _nombre As String
    Private _direccion As String
    Private _localidad As String
    Private _codigoPostal As String
    Private _telefono As String
    Private _celular As String
    Private _email As String
    Private _web As String

    Private _esProfesional As Boolean
    Private _clasificacionSingle As Integer
    Private _clasificacionDobles As Integer


    Public Property IdSocio() As Integer
        Get
            Return Me._idSocio
        End Get
        Set(ByVal value As Integer)
            Me._idSocio = value
        End Set
    End Property
    Public Property TipoDocumento() As TipoDocumento
        Get
            Return Me._TipoDocumento
        End Get
        Set(ByVal value As TipoDocumento)
            Me._TipoDocumento = value
        End Set
    End Property
    Public Property NumeroDocumento() As Integer
        Get
            Return Me._numeroDocumento
        End Get
        Set(ByVal value As Integer)
            Me._numeroDocumento = value
        End Set
    End Property
    Public Property Sexo() As Sexo
        Get
            Return Me._Sexo
        End Get
        Set(ByVal value As Sexo)
            Me._Sexo = value
        End Set
    End Property
    Public Property PaisNacionalidad() As Pais
        Get
            Return Me._PaisNacionalidad
        End Get
        Set(ByVal value As Pais)
            Me._PaisNacionalidad = value
        End Set
    End Property
    Public Property Provincia() As Provincia
        Get
            Return Me._Provincia
        End Get
        Set(ByVal value As Provincia)
            Me._Provincia = value
        End Set
    End Property
    Public Property EstadoCivil() As EstadoCivil
        Get
            Return Me._EstadoCivil
        End Get
        Set(ByVal value As EstadoCivil)
            Me._EstadoCivil = value
        End Set
    End Property
    Public Property Club() As Club
        Get
            Return Me._club
        End Get
        Set(ByVal value As Club)
            Me._club = value
        End Set
    End Property
    Public Property Federacion() As Federacion
        Get
            Return _federacion
        End Get
        Set(ByVal value As Federacion)
            _federacion = value
        End Set
    End Property
    Public Property EstadoSocio() As EstadoSocio
        Get
            Return Me._EstadoSocio
        End Get
        Set(ByVal value As EstadoSocio)
            Me._EstadoSocio = value
        End Set
    End Property
    Public Property CategoriaSocio() As CategoriaSocio
        Get
            Return Me._CategoriaSocio
        End Get
        Set(ByVal value As CategoriaSocio)
            Me._CategoriaSocio = value
        End Set
    End Property
    Public Property FechaNacimiento() As Date
        Get
            Return Me._fechaNacimiento
        End Get
        Set(ByVal value As Date)
            Me._fechaNacimiento = value
        End Set
    End Property
    Public Property FechaIngreso() As Date
        Get
            Return Me._fechaIngreso
        End Get
        Set(ByVal value As Date)
            Me._fechaIngreso = value
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
    Public Property Direccion() As String
        Get
            Return Me._direccion
        End Get
        Set(ByVal value As String)
            Me._direccion = value
        End Set
    End Property
    Public Property Localidad() As String
        Get
            Return Me._localidad
        End Get
        Set(ByVal value As String)
            Me._localidad = value
        End Set
    End Property
    Public Property CodigoPostal() As String
        Get
            Return Me._codigoPostal
        End Get
        Set(ByVal value As String)
            Me._codigoPostal = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return Me._telefono
        End Get
        Set(ByVal value As String)
            Me._telefono = value
        End Set
    End Property
    Public Property Celular() As String
        Get
            Return Me._celular
        End Get
        Set(ByVal value As String)
            Me._celular = value
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
    Public Property Web() As String
        Get
            Return Me._web
        End Get
        Set(ByVal value As String)
            Me._web = value
        End Set
    End Property
    Public Property EsProfesional() As Boolean
        Get
            Return _esProfesional
        End Get
        Set(ByVal value As Boolean)
            _esProfesional = value
        End Set
    End Property
    Public Property ClasificacionSingle() As Integer
        Get
            Return _clasificacionSingle
        End Get
        Set(ByVal value As Integer)
            _clasificacionSingle = value
        End Set
    End Property
    Public Property ClasificacionDobles() As Integer
        Get
            Return _clasificacionDobles
        End Get
        Set(ByVal value As Integer)
            _clasificacionDobles = value
        End Set
    End Property


End Class
