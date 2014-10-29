<Serializable()> _
Public Class Ganancias
    Private _idGanancias As Integer
    Private _descripcion As String
    Public Property IdGanancias() As Integer
        Get
            Return _idGanancias
        End Get
        Set(ByVal value As Integer)
            _idGanancias = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

End Class
