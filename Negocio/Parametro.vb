Public Class Parametro
    Private _idParametro As Integer
    Private _numeracionReintegros As Integer
    Private _numeracionAdelantos As Integer
    Private _cuentaAdelantoProveedor As Cuenta
    Private _cuentaReintegroProveedor As Cuenta

    Public Property IdParametro() As Integer
        Get
            Return Me._idParametro
        End Get
        Set(ByVal value As Integer)
            Me._idParametro = value
        End Set
    End Property
    Public Property NumeracionReintegros() As Integer
        Get
            Return Me._numeracionReintegros
        End Get
        Set(ByVal value As Integer)
            Me._numeracionReintegros = value
        End Set
    End Property
    Public Property NumeracionAdelantos() As Integer
        Get
            Return Me._numeracionAdelantos
        End Get
        Set(ByVal value As Integer)
            Me._numeracionAdelantos = value
        End Set
    End Property
    Public Property CuentaAdelantoProveedor() As Cuenta
        Get
            Return _cuentaAdelantoProveedor
        End Get
        Set(ByVal value As Cuenta)
            _cuentaAdelantoProveedor = value
        End Set
    End Property
    Public Property CuentaReintegroProveedor() As Cuenta
        Get
            Return _cuentaReintegroProveedor
        End Get
        Set(ByVal value As Cuenta)
            _cuentaReintegroProveedor = value
        End Set
    End Property


End Class
