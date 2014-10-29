Public Class MedioPago
    Private _idMedioPago As Integer
    Private _descripcion As String
    Public Property IdMedioPago() As Integer
        Get
            Return Me._idMedioPago
        End Get
        Set(ByVal value As Integer)
            Me._idMedioPago = value
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
