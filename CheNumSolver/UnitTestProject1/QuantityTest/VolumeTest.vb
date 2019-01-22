Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CheNumSolver
Namespace UnitTestProject1
    <TestClass>
    Public Class VolumeTest
        <TestMethod>
        Sub TestSub()
            Assert.IsTrue(True)
        End Sub

        <DataTestMethod>
        <DataRow(9.0)>
        <DataRow(999)>
        Public Sub TestVolume(value As Double)
            Dim Vol As Volume = New Volume()
            Vol.MeterCubedValue = value
            Console.WriteLine(Vol.LitreValue)
            Assert.AreEqual(Vol.LitreValue, value * 1000)
            Assert.AreEqual(Vol.CMCubedValue, value * 1000000)

            Vol.CMCubedValue = value
            Vol.InitializeFromCMCubed()
            Assert.AreEqual(Vol.MeterCubedValue, value / 1000000)
            Assert.AreEqual(Double.Parse(Vol.LitreValue), value / 1000)

            Vol.LitreValue = value
            Vol.InitializeFromLitre()
            Assert.AreEqual(Vol.MeterCubedValue, value / 1000)
            Assert.AreEqual(Vol.CMCubedValue, value * 1000)
        End Sub
    End Class
End Namespace