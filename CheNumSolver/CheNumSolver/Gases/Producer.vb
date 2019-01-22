Public Class Producer
    Public Sub Produce(InputContainer As FixedPressureContainer, ByRef OutputContainer As FixedPressureContainer)
        If (OutputContainer.Temperature.IsInitialized()) Then
            SetFinalVolumeInFixedPressureContainer(InputContainer, OutputContainer)
        ElseIf (OutputContainer.Volume.IsSet) Then
            SetFinalTemperatureInFixedPressureContainer(InputContainer, OutputContainer)
        End If
    End Sub

    Public Sub Produce(IC As FixedTemperatureContainer, ByRef OC As FixedTemperatureContainer)
        If (OC.Pressure.IsSet()) Then
            SetFinalVolumeInFixedTemperatureContainer(IC, OC)
        ElseIf (OC.Volume.IsSet()) Then
            SetFinalPressureInFixedTemperatureContainer(IC, OC)
        End If
    End Sub

    Public Sub Produce(IC As FixedVolumeContainer, ByRef OC As FixedVolumeContainer)
        If (OC.Pressure.IsSet) Then
            SetFinalTemperatureInFixedVolumeContainer(IC, OC)
        ElseIf (OC.Temperature.IsInitialized()) Then
            SetFinalPressureInFixedVolumeContainer(IC, OC)
        End If
    End Sub

    Public Sub Produce(IC As FixedAmountOfSubstanceContainer, ByRef OC As FixedAmountOfSubstanceContainer)
        If (OC.Pressure.IsSet) = False Then
            SetFinalPressureInFixedGasContainer(IC, OC)
        ElseIf (OC.Volume.IsSet) = False Then
            SetFinalVolumeInFixedGasContainer(IC, OC)
        ElseIf (OC.Temperature.IsInitialized) = False Then
            SetFinalTemperatureInFixedGasContainer(IC, OC)
        End If
    End Sub


    Private Sub SetFinalTemperatureInFixedPressureContainer(I As FixedPressureContainer, ByRef O As FixedPressureContainer)
        O.Temperature.KelvinValue = (O.Volume.MeterCubedValue * I.Temperature.KelvinValue) / I.Volume.MeterCubedValue
    End Sub

    Private Sub SetFinalVolumeInFixedPressureContainer(I As FixedPressureContainer, ByRef O As FixedPressureContainer)
        O.Volume.MeterCubedValue = (I.Volume.MeterCubedValue * O.Temperature.KelvinValue) / I.Temperature.KelvinValue
    End Sub

    Private Sub SetFinalVolumeInFixedTemperatureContainer(I As FixedTemperatureContainer, ByRef O As FixedTemperatureContainer)
        O.Volume.MeterCubedValue = (I.Pressure.PascalValue * I.Volume.MeterCubedValue) / O.Pressure.PascalValue
    End Sub

    Private Sub SetFinalPressureInFixedTemperatureContainer(I As FixedTemperatureContainer, ByRef O As FixedTemperatureContainer)
        O.Pressure.PascalValue = (I.Pressure.PascalValue * I.Volume.MeterCubedValue) / O.Volume.MeterCubedValue
    End Sub

    Private Sub SetFinalTemperatureInFixedVolumeContainer(I As FixedVolumeContainer, ByRef O As FixedVolumeContainer)
        O.Temperature.KelvinValue = (O.Pressure.PascalValue * I.Temperature.KelvinValue) / I.Pressure.PascalValue
    End Sub

    Private Sub SetFinalPressureInFixedVolumeContainer(I As FixedVolumeContainer, ByRef O As FixedVolumeContainer)
        O.Pressure.PascalValue = (I.Pressure.PascalValue * O.Temperature.KelvinValue) / I.Temperature.KelvinValue
    End Sub

    Private Sub SetFinalPressureInFixedGasContainer(I As FixedAmountOfSubstanceContainer, ByRef O As FixedAmountOfSubstanceContainer)
        Dim P1 As Double = I.Pressure.PascalValue
        Dim T1 As Double = I.Temperature.KelvinValue
        Dim T2 As Double = O.Temperature.KelvinValue
        Dim V1 As Double = I.Volume.MeterCubedValue
        Dim V2 As Double = O.Volume.MeterCubedValue
        O.Pressure.PascalValue = (P1 * V1 * T2) / (T1 * V2)
    End Sub

    Private Sub SetFinalVolumeInFixedGasContainer(I As FixedAmountOfSubstanceContainer, ByRef O As FixedAmountOfSubstanceContainer)
        Dim P1 As Double = I.Pressure.PascalValue
        Dim P2 As Double = O.Pressure.PascalValue
        Dim T1 As Double = I.Temperature.KelvinValue
        Dim T2 As Double = O.Temperature.KelvinValue
        Dim V1 As Double = I.Volume.MeterCubedValue
        O.Volume.MeterCubedValue = (P1 * V1 * T2) / (P2 * T1)
    End Sub

    Private Sub SetFinalTemperatureInFixedGasContainer(I As FixedAmountOfSubstanceContainer, ByRef O As FixedAmountOfSubstanceContainer)
        Dim P1 As Double = I.Pressure.PascalValue
        Dim P2 As Double = O.Pressure.PascalValue
        Dim T1 As Double = I.Temperature.KelvinValue
        Dim V1 As Double = I.Volume.MeterCubedValue
        Dim V2 As Double = O.Volume.MeterCubedValue
        O.Temperature.KelvinValue = (P2 * V2 * T1) / (P1 * V1)
    End Sub

End Class