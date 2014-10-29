<Serializable()> _
Public Class EstadoPedido
    Private _idEstadoPedido As Integer
    Private _descripcion As String
    Public Property IdEstadoPedido() As Integer
        Get
            Return Me._idEstadoPedido
        End Get
        Set(ByVal value As Integer)
            Me._idEstadoPedido = value
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
