<Serializable()> _
Public Class EstadoCivil
    Private _idEstadoCivil As Integer
    Private _descripcion As String
    Public Property IdEstadoCivil() As Integer
        Get
            Return Me._idEstadoCivil
        End Get
        Set(ByVal value As Integer)
            Me._idEstadoCivil = value
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
