Public Class Configuracion

    Private Shared _objConfiguracion As Configuracion

    Private _puntoVenta As Integer
    Private _separadorDecimal As String
    Public Property PuntoVenta() As Integer
        Get
            Return _puntoVenta
        End Get
        Set(ByVal value As Integer)
            _puntoVenta = value
        End Set
    End Property
    Public Property SeparadorDecimal() As String
        Get
            Return _separadorDecimal
        End Get
        Set(ByVal value As String)
            _separadorDecimal = value
        End Set
    End Property

    Private Sub New()
        Me._puntoVenta = 1
        Me._separadorDecimal = My.Computer.Info.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator
    End Sub

    Public Shared Function ObtenerInstancia() As Configuracion
        If _objConfiguracion Is Nothing Then
            _objConfiguracion = New Configuracion
        End If
        Return _objConfiguracion
    End Function
End Class
