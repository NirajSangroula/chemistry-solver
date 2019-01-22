Public Class Pressure
    Private ReadOnly PASCAL_PER_MM_OF_MERCURY As Decimal = 133.322
    Private ReadOnly PASCAL_PER_ATM As Double = 101325
    Private IsValueSet As Boolean = False
    Private Pascal As Double
    Private Atm As Double
    Private MMOFMercury As Double

    Public Function IsSet() As Boolean
        Return IsValueSet
    End Function

    Public Property PascalValue()
        Get
            If Pascal = 0 And IsSet() Then
                Initialize()
            End If
            Return Pascal
        End Get
        Set(value)
            Pascal = value
            SetFlagValue()
        End Set
    End Property

    Public Property AtmValue()
        Get
            If Atm = 0 And IsSet() Then
                Initialize()
            End If
            Return Atm
        End Get
        Set(value)
            Atm = value
            SetFlagValue()
        End Set
    End Property

    Private Sub SetFlagValue()
        IsValueSet = True
    End Sub

    Public Property MMOFMercuryValue()
        Get
            If MMOFMercury = 0 And IsSet() Then
                Initialize()
            End If
            Return MMOFMercury
        End Get
        Set(value)
            MMOFMercury = value
            SetFlagValue()
        End Set
    End Property

    Private Sub Initialize()
        If Pascal Then
            InitializeFromPascal()
        ElseIf Atm Then
            InitializeFromAtm()
        Else
            InitializeFromMMOFMercury()
        End If
    End Sub

    Public Sub InitializeFromMMOFMercury()
        SetPascalFromMMOFMercury()
        SetAtmFromPascal()
    End Sub

    Public Sub InitializeFromAtm()
        SetPascalFromAtm()
        SetMMOFMercuryFromPascal()
    End Sub

    Public Sub InitializeFromPascal()
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
        MMOFMercuryValue = Pascal / PASCAL_PER_MM_OF_MERCURY
    End Sub

    Private Function MeterOfMercury() As Decimal
        Return MMOFMercury / 1000
    End Function
End Class