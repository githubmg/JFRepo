<Serializable()> _
Public Class TipoInterdeposito
    Private _idTipoInterdeposito As Integer
    Private _descripcion As String
    Public Property IdTipoInterdeposito() As Integer
        Get
            Return Me._idTipoInterdeposito
        End Get
        Set(ByVal value As Integer)
            Me._idTipoInterdeposito = value
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
