<Serializable()> _
Public Class Proveedor
  Private _cuit AS Long
    Private _razonSocial As String
    Private _localidad As Localidad
    Private _domicilio As String
    Private _codigoPostal As String
    Private _telefono As String
    Private _email As String
    Private _observaciones As String
    Public Property Cuit() As Long
        Get
            Return Me._cuit
        End Get
        Set(ByVal value As Long)
            Me._cuit = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return Me._razonSocial
        End Get
        Set(ByVal value As String)
            Me._razonSocial = value
        End Set
    End Property
    Public Property Localidad() As Localidad
        Get
            Return Me._localidad
        End Get
        Set(ByVal value As Localidad)
            Me._localidad = value
        End Set
    End Property
    Public Property Domicilio() As String
        Get
            Return Me._domicilio
        End Get
        Set(ByVal value As String)
            Me._domicilio = value
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
    Public Property Email() As String
        Get
            Return Me._email
        End Get
        Set(ByVal value As String)
            Me._email = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return Me._observaciones
        End Get
        Set(ByVal value As String)
            Me._observaciones = value
        End Set
    End Property


End Class
