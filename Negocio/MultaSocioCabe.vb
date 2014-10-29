Public Class MultaSocioCabe
    Private _idMultaSocio As Integer
    Private _nombreTorneo As String
    Private _club As Club
    Private _socioOrganizador As Socio
    Private _fechaRegistro As Date
    Private _items As List(Of MultaSocioItem)

    Public Property IdMultaSocio() As Integer
        Get
            Return Me._idMultaSocio
        End Get
        Set(ByVal value As Integer)
            Me._idMultaSocio = value
        End Set
    End Property
    Public Property Club() As Club
        Get
            Return Me._club
        End Get
        Set(ByVal value As Club)
            Me._club = value
        End Set
    End Property
    Public Property NombreTorneo() As String
        Get
            Return _nombreTorneo
        End Get
        Set(ByVal value As String)
            _nombreTorneo = value
        End Set
    End Property
    Public Property SocioOrganizador() As Socio
        Get
            Return Me._socioOrganizador
        End Get
        Set(ByVal value As Socio)
            Me._socioOrganizador = value
        End Set
    End Property
    Public Property FechaRegistro() As Date
        Get
            Return Me._fechaRegistro
        End Get
        Set(ByVal value As Date)
            Me._fechaRegistro = value
        End Set
    End Property
    Public Property Items() As List(Of MultaSocioItem)
        Set(ByVal value As List(Of MultaSocioItem))
            Me._items = value
        End Set
        Get
            Return _items
        End Get
    End Property



End Class