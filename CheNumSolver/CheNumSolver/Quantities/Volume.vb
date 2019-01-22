Public Class Volume
    Private ReadOnly LITRES_PER_METERCUBED = 1000
    Private ReadOnly CMCUBED_PER_METERCUBED = 1000000
    Private Litre As Double
    Private MeterCubed As Double
    Private CMCubed As Double
    Private ReadOnly Property InitializedByLitres = 1
    Private ReadOnly Property InitializedByMeterCubed = 2
    Private ReadOnly Property InitializedByCMCubed = 3
    Private ReadOnly Property UnInitialized = 0
    Private Status As Integer = UnInitialized
    Public Function IsSet() As Boolean
        If (Status = 0) = False Then
            Return True
        End If
        Return False
    End Function
    Property LitreValue As Double
        Get
            If Litre = 0 Then
                Initialize()
            End If
            Return Litre
        End Get
        Set(value As Double)
            Litre = value
            Status = InitializedByLitres
        End Set
    End Property

    Property CMCubedValue As Double
        Get
            If CMCubed = 0 Then
                Initialize()
            End If
            Return CMCubed
        End Get
        Set(value As Double)
            CMCubed = value
            Status = InitializedByCMCubed
        End Set
    End Property

    Property MeterCubedValue As Double
        Get
            If MeterCubed = 0 Then
                Initialize()
            End If
            Return MeterCubed
        End Get
        Set(value As Double)
            MeterCubed = value
            Status = InitializedByMeterCubed
        End Set
    End Property
    Private Sub Initialize()
        If Status = InitializedByLitres Then
            InitializeFromLitre()

        ElseIf Status = InitializedByCMCubed Then
            InitializeFromCMCubed()
        Else
            InitializeFromMeterCubed()
        End If
    End Sub

    Public Sub InitializeFromMeterCubed()
        SetLitreFromMeterCubed()
        SetCMCubedFromMeterCubed()
    End Sub

    Public Sub InitializeFromCMCubed()
        SetMeterCubedFromCMCubed()
        SetLitreFromMeterCubed()
    End Sub

    Public Sub InitializeFromLitre()
        SetMeterCubedFromLitre()
        SetCMCubedFromMeterCubed()
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