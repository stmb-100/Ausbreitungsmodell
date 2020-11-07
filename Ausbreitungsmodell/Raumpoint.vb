Public Class Raumpoint

    Public valX As Integer
    Public valY As Integer
    Public valR As Integer
    Public valG As Integer
    Public valB As Integer
    'Public valA As Integer
    Public valCol As Color
    'Public backcolor As Color

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByRef c As Color)

        Me.valX = x
        Me.valY = y
        Me.valCol = c

        Me.valR = c.R
        Me.valG = c.G
        Me.valB = c.B

    End Sub

    Public Property x As Integer
        Get
            Return valX
        End Get

        Set(ByVal x As Integer)
            valX = x
        End Set
    End Property

    Public Property y As Integer
        Get
            Return valY
        End Get

        Set(ByVal y As Integer)
            valX = y
        End Set
    End Property

    Public Property col As Color
        Get
            Return valCol
        End Get

        Set(ByVal col As Color)
            valCol = col
        End Set
    End Property



End Class

