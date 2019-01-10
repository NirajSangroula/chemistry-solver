Public Class Pressure
    Private ReadOnly PASCAL_PER_MM_OF_MERCURY As Decimal = 133.322
    Private ReadOnly PASCAL_PER_ATM As Double = 101325
    Private Pascal As Double
    Private Atm As Double
    Private MMOFMercury As Decimal

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
    End Sub

    Private Function MeterOfMercury() As Decimal
        Return MMOFMercury / 1000
    End Function
End Class