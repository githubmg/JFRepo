<Serializable()> _
Public Class CategoriaSocio
    Private _idcategoriaSocio As Integer
    Private _descripcion As String
    Private _edadMinima As Integer
    Private _edadMaxima As Integer

    Public Property IdcategoriaSocio() As Integer
        Get
            Return Me._idcategoriaSocio
        End Get
        Set(ByVal value As Integer)
            Me._idcategoriaSocio = value
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
    Public Property EdadMinima() As Integer
        Get
            Return _edadMinima
        End Get
        Set(ByVal value As Integer)
            _edadMinima = value
        End Set
    End Property
    Public Property EdadMaxima() As Integer
        Get
            Return _edadMaxima
        End Get
        Set(ByVal value As Integer)
            _edadMaxima = value
        End Set
    End Property


End Class
