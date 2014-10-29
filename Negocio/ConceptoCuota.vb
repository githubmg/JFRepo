<Serializable()> _
Public Class ConceptoCuota
    Private _idConcepto As String
    Private _descripcion As String
    Private _importe As Double
    Private _profesional As Boolean

    Public Property IdConcepto() As String
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As String)
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
    Public Property Importe() As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
        End Set
    End Property
    Public Property Profesional() As Boolean
        Get
            Return _profesional
        End Get
        Set(ByVal value As Boolean)
            _profesional = value
        End Set
    End Property


End Class
