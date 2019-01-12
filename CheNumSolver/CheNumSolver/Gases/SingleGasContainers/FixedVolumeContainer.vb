Public Class FixedVolumeContainer
    Inherits SingleGasContainer
    Public Sub New(ByVal G As Gas, ByVal Vol As Volume)
        MyBase.New(G)
        Me.Volume = Vol
    End Sub
End Class
