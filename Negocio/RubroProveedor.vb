<Serializable()> _
Public Class RubroProveedor
    Private _idRubroProveedor As Integer
    Private _descripcion As String
    Public Property IdRubroProveedor() As Integer
        Get
            Return _idRubroProveedor
        End Get
        Set(ByVal value As Integer)
            _idRubroProveedor = value
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
