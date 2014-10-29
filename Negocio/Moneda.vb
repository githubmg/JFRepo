<Serializable()> _
Public Class Moneda
    Private _idMoneda As Integer
    Private _descripcion As String
    Private _simbolo As String
    Private _abreviatura As String
    Public Property IdMoneda() As Integer
        Get
            Return Me._idMoneda
        End Get
        Set(ByVal value As Integer)
            Me._idMoneda = value
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
    Public Property Simbolo() As String
        Get
            Return Me._simbolo
        End Get
        Set(ByVal value As String)
            Me._simbolo = value
        End Set
    End Property
    Public Property Abreviatura() As String
        Get
            Return Me._abreviatura
        End Get
        Set(ByVal value As String)
            Me._abreviatura = value
        End Set
    End Property
    Public ReadOnly Property cotizacionActual() As Double
        Get
            Return Sistema.ObtenerCotizacionActual(Me.IdMoneda)
        End Get
    End Property

End Class
