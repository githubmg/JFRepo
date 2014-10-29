<Serializable()> _
Public Class Club
    Private _idClub As Integer
    Private _descripcion As String
    Private _pleno As Boolean
    Private _activo As Boolean
    Private _cantidadCanchas As Integer
    Private _direccionAdministracion As String
    Private _localidadAdministracion As String
    Private _ProvinciaAdministracion As Provincia
    Private _telefonoAdministracion As String
    Private _direccionClub As String
    Private _localidadClub As String
    Private _ProvinciaClub As Provincia
    Private _telefonoClub As String
    Private _web As String
    Private _correo As String
    Private _contacto As String
    Private _telefonoContacto As String
    Private _celularContacto As String
    Private _cuit As String
    Private _fechaEstatuto As Date
    Private _fechaAlta As Date
    Private _CondicionIva As CondicionIva

    Public Property IdClub() As Integer
        Get
            Return Me._idClub
        End Get
        Set(ByVal value As Integer)
            Me._idClub = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return Me._descripcion
        End Get
        Set(ByVal value As String)
            Me._descripcion = value
        End Set
    End Property
    Public Property Pleno() As Boolean
        Get
            Return Me._pleno
        End Get
        Set(ByVal value As Boolean)
            Me._pleno = value
        End Set
    End Property
    Public Property Activo() As Boolean
        Get
            Return Me._activo
        End Get
        Set(ByVal value As Boolean)
            Me._activo = value
        End Set
    End Property
    Public Property CantidadCanchas() As Integer
        Get
            Return Me._cantidadCanchas
        End Get
        Set(ByVal value As Integer)
            Me._cantidadCanchas = value
        End Set
    End Property
    Public Property DireccionAdministracion() As String
        Get
            Return Me._direccionAdministracion
        End Get
        Set(ByVal value As String)
            Me._direccionAdministracion = value
        End Set
    End Property
    Public Property LocalidadAdministracion() As String
        Get
            Return Me._localidadAdministracion
        End Get
        Set(ByVal value As String)
            Me._localidadAdministracion = value
        End Set
    End Property
    Public Property ProvinciaAdministracion() As Provincia
        Get
            Return Me._ProvinciaAdministracion
        End Get
        Set(ByVal value As Provincia)
            Me._ProvinciaAdministracion = value
        End Set
    End Property
    Public Property TelefonoAdministracion() As String
        Get
            Return Me._telefonoAdministracion
        End Get
        Set(ByVal value As String)
            Me._telefonoAdministracion = value
        End Set
    End Property
    Public Property DireccionClub() As String
        Get
            Return Me._direccionClub
        End Get
        Set(ByVal value As String)
            Me._direccionClub = value
        End Set
    End Property
    Public Property LocalidadClub() As String
        Get
            Return Me._localidadClub
        End Get
        Set(ByVal value As String)
            Me._localidadClub = value
        End Set
    End Property
    Public Property ProvinciaClub() As Provincia
        Get
            Return Me._ProvinciaClub
        End Get
        Set(ByVal value As Provincia)
            Me._ProvinciaClub = value
        End Set
    End Property
    Public Property TelefonoClub() As String
        Get
            Return Me._telefonoClub
        End Get
        Set(ByVal value As String)
            Me._telefonoClub = value
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
    Public Property Correo() As String
        Get
            Return Me._correo
        End Get
        Set(ByVal value As String)
            Me._correo = value
        End Set
    End Property
    Public Property Contacto() As String
        Get
            Return Me._contacto
        End Get
        Set(ByVal value As String)
            Me._contacto = value
        End Set
    End Property
    Public Property TelefonoContacto() As String
        Get
            Return Me._telefonoContacto
        End Get
        Set(ByVal value As String)
            Me._telefonoContacto = value
        End Set
    End Property
    Public Property CelularContacto() As String
        Get
            Return Me._celularContacto
        End Get
        Set(ByVal value As String)
            Me._celularContacto = value
        End Set
    End Property
    Public Property Cuit() As String
        Get
            Return Me._cuit
        End Get
        Set(ByVal value As String)
            Me._cuit = value
        End Set
    End Property
    Public Property FechaEstatuto() As Date
        Get
            Return Me._fechaEstatuto
        End Get
        Set(ByVal value As Date)
            Me._fechaEstatuto = value
        End Set
    End Property
    Public Property FechaAlta() As Date
        Get
            Return Me._fechaAlta
        End Get
        Set(ByVal value As Date)
            Me._fechaAlta = value
        End Set
    End Property
    Public Property CondicionIva() As CondicionIva
        Get
            Return Me._CondicionIva
        End Get
        Set(ByVal value As CondicionIva)
            Me._CondicionIva = value
        End Set
    End Property

End Class
