<Serializable()> _
Public Class TipoComprobante
    Private _idTipoComprobante As Integer
    Private _orden As Integer
    Private _descripcion As String
    Private _sigla As String
    Private _letra As String
    Public Property IdTipoComprobante() As Integer
        Get
            Return Me._idTipoComprobante
        End Get
        Set(ByVal value As Integer)
            Me._idTipoComprobante = value
        End Set
    End Property
    Public Property Orden() As Integer
        Get
            Return Me._orden
        End Get
        Set(ByVal value As Integer)
            Me._orden = value
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
    Public Property Sigla() As String
        Get
            Return Me._sigla
        End Get
        Set(ByVal value As String)
            Me._sigla = value
        End Set
    End Property
    Public Property Letra() As String
        Get
            Return Me._letra
        End Get
        Set(ByVal value As String)
            Me._letra = value
        End Set
    End Property


End Class
