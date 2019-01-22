Imports CheNumSolver
Imports Microsoft.VisualStudio.TestTools.UnitTesting
<TestClass>
Public Class DiffusionTest
    <TestMethod>
    Public Sub TestSetter()
        Dim D1 As New Diffusor()
        Dim C1 As New SingleGasContainer(New Gas() With {.Density = 10})
        Dim C2 As New SingleGasContainer(New Gas() With {.Density = 20})
        D1.SetContainers(C1, C2)
        D1.Rate1 = 4
        Assert.AreEqual(8.0, Math.Round(D1.Diffuse().Diffusor.Rate2))
    End Sub
End Class
