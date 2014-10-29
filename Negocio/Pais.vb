<Serializable()> _
Public Class Pais
    Private _idPais As Integer
    Private _descripcion As String
    Public Property IdPais() As Integer
        Get
            Return Me._idPais
        End Get
        Set(ByVal value As Integer)
            Me._idPais = value
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
