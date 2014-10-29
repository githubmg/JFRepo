<Serializable()> _
Public Class TipoDocumento
    Private _idTipoDocumento As Integer
    Private _descripcion As String
    Public Property IdTipoDocumento() As Integer
        Get
            Return Me._idTipoDocumento
        End Get
        Set(ByVal value As Integer)
            Me._idTipoDocumento = value
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
