<Serializable()> _
Public Class CondicionIva
    Private _idCondicionIva As Integer
    Private _descripcion As String
    Public Property IdCondicionIva() As Integer
        Get
            Return _idCondicionIva
        End Get
        Set(ByVal value As Integer)
            _idCondicionIva = value
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
