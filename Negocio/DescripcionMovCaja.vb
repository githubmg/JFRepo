<Serializable()> _
Public Class DescripcionMovCaja
    Private _idDescripcionMovCaja As Integer
    Private _descripcion As String
    Public Property IdDescripcionMovCaja() As Integer
        Get
            Return _idDescripcionMovCaja
        End Get
        Set(ByVal value As Integer)
            _idDescripcionMovCaja = value
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
