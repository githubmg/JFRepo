<Serializable()> _
Public Class Familia
    Private _idFamilia As Integer
    Private _descripcion As String
    Public Property IdFamilia() As Integer
        Get
            Return Me._idFamilia
        End Get
        Set(ByVal value As Integer)
            Me._idFamilia = value
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
