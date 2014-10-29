<Serializable()> _
Public Class TipoCuenta
    Private _idTipoCuenta As Integer
    Private _descripcion As String
    Public Property IdTipoCuenta() As Integer
        Get
            Return Me._idTipoCuenta
        End Get
        Set(ByVal value As Integer)
            Me._idTipoCuenta = value
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
