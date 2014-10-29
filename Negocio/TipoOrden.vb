<Serializable()> _
Public Class TipoOrden
    Private _idTipoOrden As Integer
    Private _descripcion As String
    Public Property IdTipoOrden() As Integer
        Get
            Return Me._idTipoOrden
        End Get
        Set(ByVal value As Integer)
            Me._idTipoOrden = value
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
End Class
