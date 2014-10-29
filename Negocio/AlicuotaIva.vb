<Serializable()> _
Public Class AlicuotaIva
    Private _idAlicuotaIva As Integer
    Private _valor As Double
    Private _descripcion As String
    Public Property IdAlicuotaIva() As Integer
        Get
            Return Me._idAlicuotaIva
        End Get
        Set(ByVal value As Integer)
            Me._idAlicuotaIva = value
        End Set
    End Property
    Public Property Valor() As Double
        Get
            Return Me._valor
        End Get
        Set(ByVal value As Double)
            Me._valor = value
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
