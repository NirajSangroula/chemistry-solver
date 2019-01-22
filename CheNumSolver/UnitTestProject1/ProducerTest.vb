Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CheNumSolver
Namespace UnitTestProject1
    <TestClass>
    Public Class ProducerTest
        <DataTestMethod>
        Public Sub TestStateInConstantVolume()
            Dim P As Producer = New Producer()
            Dim V As New Volume()
            With V
                .MeterCubedValue = 10
            End With
            Dim Pr As New Pressure()
            With Pr
                Pr.PascalValue = 40
            End With

            Dim Tm As New Temperature
            With Tm
                Tm.KelvinValue = 400
            End With
            Dim Gass As New Gas()
            Dim C1 As FixedVolumeContainer = New FixedVolumeContainer(Gass, V)
            C1.Pressure = Pr
            C1.Temperature = Tm
            Pr.PascalValue = 20
            Tm.KelvinValue = 200

            Dim C2 As New FixedVolumeContainer(Gass, V)
            C2.Temperature = Tm
            C2.Pressure = New Pressure()
            P.Produce(C1, C2)

            C2.Temperature = New Temperature()
            C2.Pressure.PascalValue = 20.0
            Assert.AreEqual(20.0, C2.Pressure.PascalValue)
            P.Produce(C1, C2)
            Assert.AreEqual(200.0, C2.Temperature.KelvinValue)

        End Sub

        <DataTestMethod>
        <DataRow(900, 3, 600, 2)>
        Public Sub TestStateInConstantPressure(V1 As Double, T1 As Double, V2 As Double, T2 As Double)
            Dim V As New Volume()
            With V
                .MeterCubedValue = V1
            End With
            Dim Pr As New Pressure()
            With Pr
                Pr.PascalValue = 40
            End With

            Dim Tm As New Temperature
            With Tm
                Tm.KelvinValue = T1
            End With

            Dim C1 = New FixedPressureContainer(New Gas(), Pr)
            C1.Temperature = Tm
            C1.Volume = V
            Dim C2 = New FixedPressureContainer(New Gas(), Pr)
            C2.Volume = New Volume()
            C2.Volume.MeterCubedValue = V2
            C2.Temperature = New Temperature()
            Dim P As New Producer()
            P.Produce(C1, C2)
            Assert.AreEqual(T2, C2.Temperature.KelvinValue)
            C2.Pressure = New Pressure()
            P.Produce(C1, C2)
            Assert.AreEqual(V2, C2.Volume.MeterCubedValue)
        End Sub

        <DataTestMethod>
        <DataRow(900, 3, 1350, 2)>
        Public Sub TestStateInConstantTemperature(V1 As Double, P1 As Double, V2 As Double, P2 As Double)
            Dim V11 As New Volume() With {.MeterCubedValue = V1}
            Dim P11 As New Pressure() With {.PascalValue = P1}
            Dim P22 As New Pressure With {.PascalValue = P2}
            Dim T1 As New Temperature With {.KelvinValue = 273}

            Dim C1 = New FixedTemperatureContainer(New Gas(), T1)
            C1.Volume = V11
            C1.Pressure = P11

            Dim C2 = New FixedTemperatureContainer(New Gas(), T1)
            C2.Pressure = P22
            C2.Volume = New Volume()
            Dim P As New Producer()
            P.Produce(C1, C2)
            Assert.AreEqual(V2, C2.Volume.MeterCubedValue)

            C2.Pressure = New Pressure()
            P.Produce(C1, C2)
            Assert.AreEqual(P2, C2.Pressure.PascalValue)
        End Sub

        <DataTestMethod>
        <DataRow(9, 8, 2, 16, 9, 4)>
        Public Sub TestUnknownTemperature(V1 As Double, P1 As Double, T1 As Double, V2 As Double, P2 As Double, T2 As Double)
            Dim V11 As New Volume() With {.MeterCubedValue = V1}
            Dim P11 As New Pressure() With {.PascalValue = P1}
            Dim T11 As New Temperature With {.KelvinValue = T1}
            Dim P22 As New Pressure With {.PascalValue = P2}
            Dim V22 As New Volume With {.MeterCubedValue = V2}
            Dim C1 = New FixedAmountOfSubstanceContainer(New Gas())
            C1.Volume = V11
            C1.Pressure = P11
            C1.Temperature = T11

            Dim C2 = New FixedAmountOfSubstanceContainer(New Gas())
            C2.Pressure = P22
            C2.Volume = V22
            C2.Temperature = New Temperature()
            Dim P As New Producer()
            P.Produce(C1, C2)
            Assert.AreEqual(T2, C2.Temperature.KelvinValue)

            C2.Pressure = New Pressure()
            P.Produce(C1, C2)
            Assert.AreEqual(P2, C2.Pressure.PascalValue)

            C2.Volume = New Volume()
            P.Produce(C1, C2)
            Assert.AreEqual(V2, C2.Volume.MeterCubedValue)
        End Sub
    End Class
End Namespace