Public Class Volume
    Private ReadOnly LITRES_PER_METERCUBED = 1000
    Private ReadOnly CMCUBED_PER_METERCUBED = 1000000
    Private Litre As Double
    Private MeterCubed As Double
    Private CMCubed As Double
    Public Function IsSet() As Boolean
        Try
            If (IsNothing(MeterCubedValue) = False) Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Property LitreValue
        Get
            If IsNothing(Litre) Then
                Initialize()
            End If
            Return Litre
        End Get
        Set(value)
            Litre = value
            Initialize()
        End Set
    End Property

    Property CMCubedValue
        Get
            If IsNothing(CMCubed) Then
                Initialize()
            End If
            Return CMCubed
        End Get
        Set(value)
            CMCubed = value
            Initialize()
        End Set
    End Property

    Property MeterCubedValue
        Get
            If IsNothing(MeterCubed) Then
                Initialize()
            End If
            Return MeterCubed
        End Get
        Set(value)
            MeterCubed = value
            Initialize()
        End Set
    End Property
    Private Sub Initialize()
        If Not IsNothing(Litre) Then
            SetMeterCubedFromLitre()
            SetCMCubedFromMeterCubed()

        ElseIf Not IsNothing(CMCubed) Then
            SetMeterCubedFromCMCubed()
            SetLitreFromMeterCubed()
        Else
            SetLitreFromMeterCubed()
            SetCMCubedFromMeterCubed()
        End If
    End Sub

    Private Sub SetMeterCubedFromLitre()
        MeterCubedValue = Litre / LITRES_PER_METERCUBED
    End Sub

    Private Sub SetMeterCubedFromCMCubed()
        MeterCubedValue = CMCubed / CMCUBED_PER_METERCUBED
    End Sub

    Private Sub SetLitreFromMeterCubed()
        LitreValue = MeterCubedValue * LITRES_PER_METERCUBED
    End Sub

    Private Sub SetCMCubedFromMeterCubed()
        CMCubedValue = MeterCubedValue * CMCUBED_PER_METERCUBED
    End Sub
End Class