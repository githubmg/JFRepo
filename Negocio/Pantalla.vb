<Serializable()>
Public Class Pantalla
    Private _idPantalla As Integer
    Private _url As String
    Private _descripcion As String
    Private _tipo As String
    Public Property IdPantalla() As Integer
        Get
            Return Me._idPantalla
        End Get
        Set(ByVal value As Integer)
            Me._idPantalla = value
        End Set
    End Property
    Public Property Url() As String
        Get
            Return Me._url
        End Get
        Set(ByVal value As String)
            Me._url = value
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
    Public Property Tipo() As String
        Get
            Return Me._tipo
        End Get
        Set(ByVal value As String)
            Me._tipo = value
        End Set
    End Property
End Class
