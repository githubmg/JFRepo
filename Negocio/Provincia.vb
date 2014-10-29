<Serializable()> _
Public Class Provincia
    Private _idProvincia As Integer
    Private _descripcion As String
    Public Property IdProvincia() As Integer
        Get
            Return _idProvincia
        End Get
        Set(ByVal value As Integer)
            _idProvincia = value
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
