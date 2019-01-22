Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CheNumSolver
Namespace UnitTestProject1
    <TestClass>
    Public Class PressureTest
        <TestMethod>
        Public Sub TestSomething()
            Assert.IsTrue(True)
        End Sub

        <DataTestMethod>
        <DataRow(101325, 1, 760)>
        Public Sub TestPascal(Pascal As Double, Atm As Double, MM As Double)
            Dim Pressure1 As Pressure = New Pressure()
            Pressure1.PascalValue = Pascal
            Assert.AreEqual(Atm, Math.Round(Pressure1.AtmValue))
            Assert.AreEqual(MM, Math.Round(Pressure1.MMOFMercuryValue))
        End Sub

        <DataTestMethod>
        <DataRow(1, 101325, 760)>
        Public Sub TestAtm(Atm As Double, Pascal As Double, MM As Double)
            Dim Pressure1 As Pressure = New Pressure()
            Pressure1.AtmValue = Atm
            Assert.AreEqual(Pascal, Math.Round(Pressure1.PascalValue))
            Assert.AreEqual(MM, Math.Round(Pressure1.MMOFMercuryValue))
        End Sub

        <DataTestMethod>
        <DataRow(760, 101325, 1)>
        Public Sub TestMMOFMercury(MM As Double, Pascal As Double, Atm As Double)
            Dim Pressure1 As Pressure = New Pressure()
            Pressure1.MMOFMercuryValue = MM
            Assert.AreEqual(Atm, Math.Round(Pressure1.AtmValue))
            Assert.AreEqual(Pascal, Math.Round(Pressure1.PascalValue))
        End Sub
    End Class
End Namespace