<Serializable()> _
Public Class EstadoSocio
    Private _idestadoSocio As Integer
    Private _descripcion As String
    Public Property IdestadoSocio() As Integer
        Get
            Return Me._idestadoSocio
        End Get
        Set(ByVal value As Integer)
            Me._idestadoSocio = value
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
