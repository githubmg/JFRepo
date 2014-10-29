<Serializable()> _
Public Class Cuenta
    Private _codigo As String
    Private _tipoCuenta As TipoCuenta
    Private _centroCostos As CentroCostos
    Private _activa As Boolean
    Private _imputable As Boolean
    Private _ajustable As Boolean
    Private _descripcion As String

    Public Property Activa() As Boolean
        Get
            Return Me._activa
        End Get
        Set(ByVal value As Boolean)
            Me._activa = value
        End Set
    End Property
    Public Property Imputable() As Boolean
        Get
            Return Me._imputable
        End Get
        Set(ByVal value As Boolean)
            Me._imputable = value
        End Set
    End Property
    Public Property Ajustable() As Boolean
        Get
            Return Me._ajustable
        End Get
        Set(ByVal value As Boolean)
            Me._ajustable = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return Me._codigo
        End Get
        Set(ByVal value As String)
            Me._codigo = value
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
    Public Property TipoCuenta() As TipoCuenta
        Get
            Return _tipoCuenta
        End Get
        Set(ByVal value As TipoCuenta)
            _tipoCuenta = value
        End Set
    End Property
    Public Property CentroCostos() As CentroCostos
        Get
            Return _centroCostos
        End Get
        Set(ByVal value As CentroCostos)
            _centroCostos = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return Me.Codigo + " - " + Me.Descripcion
    End Function



End Class
