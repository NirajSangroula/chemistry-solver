Public Class FixedVolumeContainer
    Inherits SingleGasContainer
    Public Sub New(G As Gas, Vol As Volume)
        MyBase.New(G)
        Me.Volume = Vol
    End Sub
End Class
