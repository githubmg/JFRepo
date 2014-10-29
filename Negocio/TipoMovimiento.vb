Public Class TipoMovimiento
    Private _idTipoMovimiento As Integer
    Private _descripcion As String
    Public Property IdTipoMovimiento() As Integer
        Get
            Return Me._idTipoMovimiento
        End Get
        Set(ByVal value As Integer)
            Me._idTipoMovimiento = value
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
