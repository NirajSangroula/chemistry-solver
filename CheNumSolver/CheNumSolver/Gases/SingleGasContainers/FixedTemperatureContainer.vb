Public Class FixedTemperatureContainer
    Inherits SingleGasContainer
    Public Sub New(ByVal G As Gas, ByVal Temper As Temperature)
        MyBase.New(G)
        Me.Temperature = Temper
    End Sub
End Class
