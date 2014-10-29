<Serializable()> _
Public Class ConceptoRetencion
    Private _idConcepto As Integer
    Private _descripcion As String
    Public Property IdConcepto() As Integer
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As Integer)
            _idConcepto = value
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
