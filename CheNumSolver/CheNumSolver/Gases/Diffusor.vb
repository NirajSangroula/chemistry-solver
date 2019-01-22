Public Class Diffusor
    Public Property Rate1 As Double
    Public Property Rate2 As Double
    Public Property Time1 As Double
    Public Property Time2 As Double
    Public Property Distance As Double
    Private CompleteRatio As Double
    Private Container1 As SingleGasContainer
    Private Container2 As SingleGasContainer
    Public Sub SetContainers(C1 As SingleGasContainer, C2 As SingleGasContainer)
        Me.Container1 = C1
        Me.Container2 = C2
    End Sub

    Public Function Diffuse() As DiffusedResult
        Dim DR As New DiffusedResult()
        Me.SetCompleteRatio()
        Me.UpdateContainers()
        DR.Container1 = Container1
        DR.Container2 = Container2
        DR.Diffusor = Me
        DR.Distance1 = GetDistance()
        DR.Distance2 = Distance - DR.Distance1
        Return DR
    End Function

    Private Sub UpdateContainers()
        SetMolecularWeightIfCan()
        SetVapourDensityIfCan()


    End Sub

    Private Sub SetVapourDensityIfCan()
        If ((Container1.Gas.Density = 0) = False) Then
            Container2.Gas.Density = Container1.Gas.Density / CompleteRatio
        ElseIf (Container2.Gas.Density = 0) = False Then
            Container1.Gas.Density = Container2.Gas.Density * CompleteRatio
        End If
    End Sub

    Private Sub SetMolecularWeightIfCan()
        If ((Container1.Gas.MolecularWeight = 0) = False) Then
            Container2.Gas.MolecularWeight = Container1.Gas.MolecularWeight / CompleteRatio
        ElseIf ((Container2.Gas.MolecularWeight = 0) = False) Then
            Container1.Gas.MolecularWeight = Container2.Gas.MolecularWeight * CompleteRatio
        End If
    End Sub

    Private Function GetDistance() As Double
        Return (Time2 * Distance) / (CompleteRatio * Time1 + Time2)
    End Function

    Private Sub SetCompleteRatio()
        If ((Rate1 = 0) = False) And ((Rate2 = 0) = False) Then
            CompleteRatio = Rate1 / Rate2
        ElseIf (Container1.Gas.Density = 0) = False And (Container2.Gas.Density = 0) = False Then
            CompleteRatio = Math.Sqrt(Container2.Gas.Density / Container1.Gas.Density)
        ElseIf (Container1.Gas.MolecularWeight = 0) = False And (Container2.Gas.MolecularWeight = 0) = False Then
            CompleteRatio = Math.Sqrt(Container1.Gas.MolecularWeight / Container2.Gas.MolecularWeight)
        ElseIf (Container1.Volume.IsSet And Container2.Volume.IsSet) Then
            CompleteRatio = (Container1.Volume.MeterCubedValue * Time2) / (Container2.Volume.MeterCubedValue * Time1)
        End If
    End Sub
End Class