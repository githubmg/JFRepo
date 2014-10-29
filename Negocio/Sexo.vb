<Serializable()> _
Public Class Sexo
    Private _idSexo As Integer
    Private _descripcion As String
    Public Property IdSexo() As Integer
        Get
            Return Me._idSexo
        End Get
        Set(ByVal value As Integer)
            Me._idSexo = value
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
