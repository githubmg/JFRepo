<Serializable()> _
Public Class Retencion
    Private _idRetencion As Integer
    Private _descripcion As String
    Private _cuenta As Cuenta


    Public Property IdRetencion() As Integer
        Get
            Return _idRetencion
        End Get
        Set(ByVal value As Integer)
            _idRetencion = value
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
    Public Property Cuenta() As Cuenta
        Get
            Return _cuenta
        End Get
        Set(ByVal value As Cuenta)
            _cuenta = value
        End Set
    End Property

End Class
