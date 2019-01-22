Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CheNumSolver
Namespace UnitTestProject1
    <TestClass>
    Public Class TemperatureTest
        <DataTestMethod>
        <DataRow(273.15, 32, 0)>
        Public Sub TestKelvin(Kelvin As Double, F As Double, C As Double)
            Dim T As Temperature = New Temperature()
            T.KelvinValue = Kelvin
            Assert.AreEqual(F, Math.Round(T.FahrenheitValue))
            Assert.AreEqual(C, Math.Round(T.CelsiusValue))
        End Sub

        <DataTestMethod>
        <DataRow(273.15, 32, 0)>
        Public Sub TestCelsius(Kelvin As Double, F As Double, C As Double)
            Dim T As Temperature = New Temperature()
            T.CelsiusValue = C
            Assert.AreEqual(F, T.FahrenheitValue)
            Assert.AreEqual(Kelvin, T.KelvinValue)
        End Sub

        <DataTestMethod>
        <DataRow(273.15, 32, 0)>
        Public Sub TestFahrenheit(Kelvin As Double, F As Double, C As Double)
            Dim T As Temperature = New Temperature()
            T.FahrenheitValue = F
            Assert.AreEqual(Kelvin, T.KelvinValue)
            Assert.AreEqual(C, T.CelsiusValue)
        End Sub
    End Class
End Namespace
