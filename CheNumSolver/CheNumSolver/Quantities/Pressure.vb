Public Class Pressure
    Private ReadOnly PASCAL_PER_MM_OF_MERCURY As Decimal = 133.322
    Private ReadOnly PASCAL_PER_ATM As Double = 101325
    Private Pascal As Double
    Private Atm As Double
    Private MMOFMercury As Decimal
    Public Property PascalValue()
        Get
            If Pascal = Nothing Then
                Initialize()
            End If
            Return Pascal
        End Get
        Set(value)
            Pascal = value
            Initialize()
        End Set
    End Property

    Public Property AtmValue()
        Get
            If Atm = Nothing Then
                Initialize()
            End If
            Return Atm
        End Get
        Set(value)
            Atm = value
            Initialize()
        End Set
    End Property

    Public Property MMOFMercuryValue()
        Get
            If MMOFMercury = Nothing Then
                Initialize()
            End If
            Return MMOFMercury
        End Get
        Set(value)
            MMOFMercury = value
            Initialize()
        End Set
    End Property

    Private Sub Initialize()
        If Pascal Then
            SetFromPascal()
        ElseIf Atm Then
            SetFromAtm()
        Else
            SetFromMMOFMercury()
        End If
    End Sub

    Private Sub SetFromMMOFMercury()
        SetPascalFromMMOFMercury()
        SetAtmFromPascal()
    End Sub

    Private Sub SetFromAtm()
        SetPascalFromAtm()
        SetMMOFMercuryFromPascal()
    End Sub

    Private Sub SetFromPascal()
        SetAtmFromPascal()
        SetMMOFMercuryFromPascal()
    End Sub

    Private Sub SetPascalFromMMOFMercury()
        PascalValue = PASCAL_PER_MM_OF_MERCURY * MMOFMercury
    End Sub

    Private Sub SetPascalFromAtm()
        PascalValue = Atm * PASCAL_PER_ATM
    End Sub

    Private Sub SetAtmFromPascal()
        AtmValue = Pascal / PASCAL_PER_ATM
    End Sub

    Private Sub SetMMOFMercuryFromPascal()
        MMOFMercuryValue = Pascal * PASCAL_PER_MM_OF_MERCURY
    End Sub

    Private Function MeterOfMercury() As Decimal
        Return MMOFMercury / 1000
    End Function
End Class