<Serializable()> _
Public Class Localidad
    Private _idLocalidad As Integer
    Private _provincia As Provincia
    Private _descripcion As String
    Public Property IdLocalidad() As Integer
        Get
            Return Me._idLocalidad
        End Get

        Set(ByVal value As Integer)
            Me._idLocalidad = value
        End Set
    End Property
    Public Property Provincia() As Provincia
        Get
            Return Me._provincia
        End Get
        Set(ByVal value As Provincia)
            Me._provincia = value
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
