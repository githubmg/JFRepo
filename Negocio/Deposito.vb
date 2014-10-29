Public Class Deposito
    Private _idDeposito As Integer
    Private _cheque As Cheque
    Private _banco As Banco
    Private _numeroTransaccion As String
    Private _fecha As Date
    Public Property IdDeposito() As Integer
        Get
            Return Me._idDeposito
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Public Property Cheque() As Cheque
        Get
            Return Me._cheque
        End Get
        Set(ByVal value As Cheque)
            Me._cheque = value
        End Set
    End Property
    Public Property Banco() As Banco
        Get
            Return Me._banco
        End Get
        Set(ByVal value As Banco)
            Me._banco = value
        End Set
    End Property
    Public Property NumeroTransaccion() As String
        Get
            Return Me._numeroTransaccion
        End Get
        Set(ByVal value As String)
            Me._numeroTransaccion = value
        End Set
    End Property
    Public Property Fecha() As Date
        Get
            Return Me._fecha
        End Get
        Set(ByVal value As Date)
            Me._fecha = value
        End Set
    End Property
End Class
