<Serializable()> _
Public Class ProductoKit

    Private _producto As Producto
    Public Property Producto() As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property


End Class
