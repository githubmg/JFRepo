<Serializable()> _
Public Class Cheque
    Private _idCheque As Integer
    Private _banco As Banco
    Private _numero As String
    Private _fechaEmision As Date
    Private _fechaVencimiento As Date
    Private _importe As Double
    Private _origenCheque As OrigenCheque
    Private _enCartera As Boolean
    Private _cobrado As Boolean
    Public Property Cobrado() As Boolean
        Get
            Return _cobrado
        End Get
        Set(ByVal value As Boolean)
            _cobrado = value
        End Set
    End Property

    Public Property IdCheque() As Integer
        Get
            Return Me._idCheque
        End Get
        Set(ByVal value As Integer)
            Me._idCheque = value
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
    Public Property Numero() As String
        Get
            Return Me._numero
        End Get
        Set(ByVal value As String)
            Me._numero = value
        End Set
    End Property
    Public Property FechaEmision() As Date
        Get
            Return Me._fechaEmision
        End Get
        Set(ByVal value As Date)
            Me._fechaEmision = value
        End Set
    End Property
    Public Property FechaVencimiento() As Date
        Get
            Return Me._fechaVencimiento
        End Get
        Set(ByVal value As Date)
            Me._fechaVencimiento = value
        End Set
    End Property
    Public Property Importe() As Double
        Get
            Return Me._importe
        End Get
        Set(ByVal value As Double)
            Me._importe = value
        End Set
    End Property
    Public Property OrigenCheque() As OrigenCheque
        Get
            Return Me._OrigenCheque
        End Get
        Set(ByVal value As OrigenCheque)
            Me._OrigenCheque = value
        End Set
    End Property
    Public Property EnCartera() As Boolean
        Get
            Return Me._enCartera
        End Get
        Set(ByVal value As Boolean)
            Me._enCartera = value
        End Set
    End Property
End Class
