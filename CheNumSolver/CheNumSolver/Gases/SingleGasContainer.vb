Public Class SingleGasContainer
    Inherits Container

    Private ReadOnly REAL_GAS_CONSTANT As Double = 8.3145

    Public Sub New(ByRef G As Gas)
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

    Public Sub Initialize()
        If (IsNothing(Pressure)) Then
            Pressure.PascalValue = (GetTotalNumberOfMoles() * REAL_GAS_CONSTANT * Temperature.KelvinValue) / Volume.MeterCubedValue()
        End If

        If (IsNothing(Volume)) Then
            Volume.MeterCubedValue = (GetTotalNumberOfMoles() * REAL_GAS_CONSTANT * Temperature.KelvinValue) / Pressure.PascalValue
        End If

        If (IsNothing(Temperature)) Then
            Temperature.KelvinValue = (Volume.MeterCubedValue * Pressure.PascalValue) / (GetTotalNumberOfMoles() * REAL_GAS_CONSTANT)
        End If

        If (IsNothing(Mass)) Then
            Try
                Mass = GetTotalNumberOfMoles() * Gas.MolecularWeight
            Catch ex As Exception

            End Try
        End If

        If (IsNothing(Gas.MolecularWeight)) Then
            Try
                Gas.MolecularWeight = Mass / GetTotalNumberOfMoles()
            Catch ex As Exception

            End Try
        End If

        If (IsNothing(Gas.NumberOfMoles)) Then
            Try
                Gas.NumberOfMoles = Mass / Gas.MolecularWeight
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
