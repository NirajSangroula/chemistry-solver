Public Class SingleGasContainer
    Inherits Container

    Private ReadOnly REAL_GAS_CONSTANT As Double = 8.3145

    Public Sub New(G As Gas)
        Me.Gases.Insert(0, G)
    End Sub

    Property Gas As Gas
        Get
            If (Gases.Count = 0) = False Then
                Return Me.Gases.Item(0)
            End If
            Throw New UnknownValueException()
        End Get
        Set(value As Gas)
            Me.Gases.Insert(0, value)
        End Set
    End Property

    Public Sub SetNumberOfMoles()
        Gas.NumberOfMoles = (Pressure.PascalValue * Volume.MeterCubedValue) / (REAL_GAS_CONSTANT * Temperature.KelvinValue)
    End Sub

    Public Sub SetTemperature()
        Temperature.KelvinValue = (Volume.MeterCubedValue * Pressure.PascalValue) / (GetTotalNumberOfMoles() * REAL_GAS_CONSTANT)
    End Sub

    Public Sub SetVolume()
        Volume.MeterCubedValue = (GetTotalNumberOfMoles() * REAL_GAS_CONSTANT * Temperature.KelvinValue) / Pressure.PascalValue
    End Sub

    Public Sub SetPressure()
        Pressure.PascalValue = (GetTotalNumberOfMoles() * REAL_GAS_CONSTANT * Temperature.KelvinValue) / Volume.MeterCubedValue()
    End Sub

End Class