Public Class OrigenCheque
    Private _idOrigenCheque As Integer
    Private _descripcion As String
    Public Property IdOrigenCheque() As Integer
        Get
            Return Me._idOrigenCheque
        End Get
        Set(ByVal value As Integer)
            Me._idOrigenCheque = value
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
