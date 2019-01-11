Public Class Pressure
    Private ReadOnly PASCAL_PER_MM_OF_MERCURY As Decimal = 133.322
    Private ReadOnly PASCAL_PER_ATM As Double = 101325
    Private Pascal As Double
    Private Atm As Double
    Private MMOFMercury As Decimal
<<<<<<< HEAD
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
=======

    Public Sub SetPascal(ByVal Pascal As Double)
        Me.Pascal = Pascal
    End Sub

    Public Sub SetAtm(ByVal Atm As Double)
        Me.Atm = Atm
    End Sub

    Public Sub SetMMOFMercury(ByVal MMOFMercury)
        Me.MMOFMercury = MMOFMercury
    End Sub

    Public Sub GetPascal()
        If Pascal = Nothing Then
            Initialize()
        End If
    End Sub

    Public Sub GetAtm()
        If Atm = Nothing Then
            Initialize()
        End If
    End Sub

    Public Sub GetMMOFMercury()
        If MMOFMercury = Nothing Then
            Initialize()
        End If
    End Sub
>>>>>>> 0757203e80da861cb75c25124e4272b8ace9fb33

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
<<<<<<< HEAD
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
=======
        SetPascal(PASCAL_PER_MM_OF_MERCURY * MMOFMercury)
    End Sub

    Private Sub SetPascalFromAtm()
        SetPascal(Atm * PASCAL_PER_ATM)
    End Sub

    Private Sub SetAtmFromPascal()
        SetAtm(Pascal / PASCAL_PER_ATM)
    End Sub

    Private Sub SetMMOFMercuryFromPascal()
        SetMMOFMercury(Pascal * PASCAL_PER_MM_OF_MERCURY)
>>>>>>> 0757203e80da861cb75c25124e4272b8ace9fb33
    End Sub

    Private Function MeterOfMercury() As Decimal
        Return MMOFMercury / 1000
    End Function
End Class