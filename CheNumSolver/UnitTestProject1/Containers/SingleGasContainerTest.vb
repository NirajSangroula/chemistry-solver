Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CheNumSolver
Namespace UnitTestProject1
    <TestClass>
    Public Class SingleGasContainerTest
        <DataTestMethod>
        <DataRow(1000, 10, 3, 400.9070477, 1000, 2.49435)>
        Public Sub TestManyThings(Pr As Double, Vo As Double, Te As Double, N As Double, M As Double, Mw As Double)
            Dim P As New Pressure With {.PascalValue = Pr}
            Dim V As New Volume With {.MeterCubedValue = Vo}
            Dim T As New Temperature With {.KelvinValue = Te}

            Dim C As New SingleGasContainer(New Gas()) With {.Pressure = P, .Volume = V, .Temperature = T}
            C.SetNumberOfMoles()
            Assert.AreEqual(Math.Round(N), Math.Round(C.GetTotalNumberOfMoles()))

            Dim C4 As New SingleGasContainer(New Gas With {.NumberOfMoles = N}) With {.Pressure = P, .Volume = V, .Temperature = New Temperature()}
            C4.SetTemperature()
            Assert.AreEqual(Math.Round(Te), Math.Round(C4.Temperature().KelvinValue))

            Dim C1 As New SingleGasContainer(New Gas With {.Mass = M, .MolecularWeight = Mw}) With {.Pressure = P, .Volume = New Volume(), .Temperature = T}
            C1.Gas.SetNumberOfMoles()
            C1.SetVolume()
            Assert.AreEqual(Math.Round(Vo), Math.Round(C1.Volume.MeterCubedValue))
            Dim C2 As New SingleGasContainer(New Gas With {.Mass = M, .NumberOfMoles = N}) With {.Pressure = P, .Volume = V, .Temperature = T}
            Dim C3 As New SingleGasContainer(New Gas With {.Mass = M, .NumberOfMolecules = N}) With {.Pressure = P, .Volume = V, .Temperature = T}

        End Sub
    End Class
End Namespace