Public Class Evento

    Private _idEvento As Integer
    Private _fecha As DateTime
    Private _trabajo As String
    Private _datosContacto As String
    Private _estado As String
    Private _domicilio As String
    Private _cliente As Cliente
    Public Property IdEvento() As Integer
        Get
            Return Me._idEvento
        End Get
        Set(ByVal value As Integer)
            Me._idEvento = value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return Me._fecha
        End Get
        Set(ByVal value As DateTime)
            Me._fecha = value
        End Set
    End Property
    Public Property Trabajo() As String
        Get
            Return Me._trabajo
        End Get
        Set(ByVal value As String)
            Me._trabajo = value
        End Set
    End Property
    Public Property DatosContacto() As String
        Get
            Return Me._datosContacto
        End Get
        Set(ByVal value As String)
            Me._datosContacto = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return Me._estado
        End Get
        Set(ByVal value As String)
            Me._estado = value
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
    Public Property Cliente() As Cliente
        Get
            Return Me._cliente
        End Get
        Set(ByVal value As Cliente)
            Me._cliente = value
        End Set
    End Property
End Class
