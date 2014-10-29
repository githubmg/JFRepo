<Serializable()> _
Public Class Producto
    Private _idProducto As Integer
    Private _familia As Familia
    Private _alicuotaIva As AlicuotaIva
    Private _descripcion As String
    Public Property IdProducto() As Integer
        Get
            Return Me._idProducto
        End Get
        Set(ByVal value As Integer)
            Me._idProducto = value
        End Set
    End Property
    Public Property Familia() As Familia
        Get
            Return Me._familia
        End Get
        Set(ByVal value As Familia)
            Me._familia = value
        End Set
    End Property
    Public Property AlicuotaIva() As AlicuotaIva
        Get
            Return Me._alicuotaIva
        End Get
        Set(ByVal value As AlicuotaIva)
            Me._alicuotaIva = value
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

    Private _codProducto As String
    Public Property CodProducto() As String
        Get
            Return _codProducto
        End Get
        Set(ByVal value As String)
            _codProducto = value
        End Set
    End Property

End Class
