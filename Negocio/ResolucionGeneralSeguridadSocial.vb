<Serializable()> _
Public Class ResolucionGeneralSeguridadSocial
    Private _idResolucionGeneral As Integer
    Private _descripcion As String
    Public Property IdResolucionGeneral() As Integer
        Get
            Return _idResolucionGeneral
        End Get
        Set(ByVal value As Integer)
            _idResolucionGeneral = value
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
