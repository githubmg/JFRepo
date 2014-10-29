<Serializable()> _
Public Class Vendedor
    Private _idVendedor As Integer
    Private _descripcion As String
    Public Property IdVendedor() As Integer
        Get
            Return Me._idVendedor
        End Get
        Set(ByVal value As Integer)
            Me._idVendedor = value
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
