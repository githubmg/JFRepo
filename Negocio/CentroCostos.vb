<Serializable()> _
Public Class CentroCostos
    Private _idCentroCostos As Integer
    Private _descripcion As String
    Public Property IdCentroCostos() As Integer
        Get
            Return Me._idCentroCostos
        End Get
        Set(ByVal value As Integer)
            Me._idCentroCostos = value
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
