Public Class Ejercicio
    Private _idEjercicio As Integer
    Private _fechaInicio As Date
    Private _fechaFin As Date
    Private _activo As Boolean
    Public Property IdEjercicio() As Integer
        Get
            Return Me._idEjercicio
        End Get
        Set(ByVal value As Integer)
            Me._idEjercicio = value
        End Set
    End Property
    Public Property FechaInicio() As Date
        Get
            Return Me._fechaInicio
        End Get
        Set(ByVal value As Date)
            Me._fechaInicio = value
        End Set
    End Property
    Public Property FechaFin() As Date
        Get
            Return Me._fechaFin
        End Get
        Set(ByVal value As Date)
            Me._fechaFin = value
        End Set
    End Property
    Public Property Activo() As Boolean
        Get
            Return Me._activo
        End Get
        Set(ByVal value As Boolean)
            Me._activo = value
        End Set
    End Property
End Class
