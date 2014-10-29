Public Class CondicionVenta

    Private _idCondicionVenta As Integer
    Private _descripcion As String
    Public Property IdCondicionVenta() As Integer
        Get
            Return _idCondicionVenta
        End Get
        Set(ByVal value As Integer)
            _idCondicionVenta = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
End Class
