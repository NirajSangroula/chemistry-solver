Public Class FixedPressureContainer
    Inherits SingleGasContainer
    Public Sub New(ByVal G As Gas, ByVal Pressure As Pressure)
        MyBase.New(G)
        Me.Pressure = Pressure
    End Sub
End Class
