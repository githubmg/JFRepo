<Serializable()> _
Public Class PagoSocio

    Private _multaSocioItem As MultaSocioItem
    Private _pagoCuotaSocio As PagoCuotaSocio

    Public Property MultaSocioItem() As MultaSocioItem
        Get
            Return _multaSocioItem
        End Get
        Set(ByVal value As MultaSocioItem)
            _multaSocioItem = value
        End Set
    End Property

    Public Property PagoCuotaSocio() As PagoCuotaSocio
        Get
            Return _pagoCuotaSocio
        End Get
        Set(ByVal value As PagoCuotaSocio)
            _pagoCuotaSocio = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        If Not Me.MultaSocioItem Is Nothing Then
            Dim mc As MultaSocioCabe = Sistema.ObtenerMultaSocioCabe(Me.MultaSocioItem.IdMultaSocio)
            Return "Pago de Multa por torneo " + mc.NombreTorneo
        End If
        If Not Me.PagoCuotaSocio Is Nothing Then
            Return Me.PagoCuotaSocio.ConceptoCuota.IdConcepto + " AÑO: " + Me.PagoCuotaSocio.Año.ToString() + " - Pago Cuota Socio: " + Me.PagoCuotaSocio.Socio.Nombre
        End If
        Return ""
    End Function

    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.ToString()
        End Get
    End Property

    Public ReadOnly Property Monto() As Double
        Get
            Dim m As Double = 0
            If Not Me.MultaSocioItem Is Nothing Then m += Me.MultaSocioItem.Monto
            If Not Me.PagoCuotaSocio Is Nothing Then m += Me.PagoCuotaSocio.Importe
            Return m
        End Get
    End Property




End Class
