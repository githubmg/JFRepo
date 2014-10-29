<Serializable()>
Public Class PantallaUsuarioItem
    Private _pantalla As Pantalla

    Private _esPantallaPrincipal As String
    Public Property EsPantallaPrincipal() As String
        Get
            Return _esPantallaPrincipal
        End Get
        Set(ByVal value As String)
            _esPantallaPrincipal = value
        End Set
    End Property
    Public Property Pantalla() As Pantalla
        Get
            Return _pantalla
        End Get
        Set(ByVal value As Pantalla)
            _pantalla = value
        End Set
    End Property
End Class
