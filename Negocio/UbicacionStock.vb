<Serializable()> _
Public Class UbicacionStock
    Private _idUbicacionStock As Integer
    Private _descripcion As String
    Public Property IdUbicacionStock() As Integer
        Get
            Return _idUbicacionStock
        End Get
        Set(ByVal value As Integer)
            _idUbicacionStock = value
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

