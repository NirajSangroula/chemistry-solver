Imports CheNumSolver
Imports Microsoft.VisualStudio.TestTools.UnitTesting
<TestClass>
Public Class ContainerTest
    <DataTestMethod>
    Public Sub TestContainer()
        Dim C1 As New Container With {.Pressure = New Pressure With {.PascalValue = 10000}, .Volume = New Volume With {.MeterCubedValue = 1200}, .Temperature = New Temperature With {.KelvinValue = 233}}
        Dim C2 As New FixedAmountOfSubstanceContainer(New Gas) With {.Pressure = New Pressure With {.PascalValue = 100}, .Volume = New Volume With {.MeterCubedValue = 1200}, .Temperature = New Temperature With {.KelvinValue = 233}}
        Dim C3 As New FixedAmountOfSubstanceContainer(New Gas) With {.Pressure = New Pressure With {.PascalValue = 10000}, .Volume = New Volume With {.MeterCubedValue = 1200}, .Temperature = New Temperature With {.KelvinValue = 233}}
        Assert.AreEqual(10000.0, Math.Round(C1.Pressure.PascalValue))
        C1.AddGas(C2)
        Assert.AreEqual(10100.0, Math.Round(C1.Pressure.PascalValue))
        Assert.AreEqual(100.0, Math.Round(C1.MergedContainers.Item(1).Pressure.PascalValue))
        C1.RemoveGas(C2)
        Assert.AreEqual(10000.0, Math.Round(C1.Pressure.PascalValue))
    End Sub
End Class