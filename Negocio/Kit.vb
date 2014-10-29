Public Class Kit
    Private _idKit As Integer
    Private _descripcion As String
    Private _productoPrincipal As Producto
    Private _productos As List(Of ProductoKit)
    Public Property Productos As List(Of ProductoKit)
        Get
            Return _productos
        End Get
        Set(ByVal value As List(Of ProductoKit))
            _productos = value
        End Set
    End Property

    Public Property IdKit() As Integer
        Get
            Return Me._idKit
        End Get
        Set(ByVal value As Integer)
            Me._idKit = value
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
    Public Property ProductoPrincipal() As Producto
        Get
            Return Me._productoPrincipal
        End Get
        Set(ByVal value As Producto)
            Me._productoPrincipal = value
        End Set
    End Property
End Class
