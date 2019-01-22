Public Class Container
    Property Pressure As Pressure
    Property Volume As Volume
    Property Temperature As Temperature
    Protected DT As Double
    Protected M As Double
    Protected Property Gases As ArrayList
    Public Property MergedContainers As ArrayList
    Public Sub New()
        Gases = New ArrayList()
        MergedContainers = New ArrayList()
        MergedContainers.Add(Me)
    End Sub
    Property DiffusionTime() As Double
        Get
            If IsNothing(DT) = False Then
                Return DT
            End If
            Throw New UnknownValueException()
        End Get
        Set(value As Double)
            DT = value
        End Set
    End Property

    Property Mass() As Double
        Get
            If IsNothing(M) = False Then
                Return M
            End If
            Throw New UnknownValueException()
        End Get
        Set(value As Double)
            M = value
        End Set
    End Property

    Public Function GetTotalMass() As Double
        Return M + GetGasesMass()
    End Function

    Public Function GetGasesMass() As Double
        Dim M = 0
        For Each G As Gas In Gases
            M += G.Mass
        Next
        Return M
    End Function

    Public Function GetTotalNumberOfMoles() As Double
        Dim N As Double = 0
        For Each G As Gas In Gases
            N += G.NumberOfMoles
        Next
        Return N
    End Function

    Public Sub AddGas(C As FixedAmountOfSubstanceContainer)
        Dim OC = ProduceFixedAmountOfContainer(C)
        MergedContainers.Add(C)
        Pressure.PascalValue += OC.Pressure.PascalValue
    End Sub

    Public Sub RemoveGas(C As FixedAmountOfSubstanceContainer)
        MergedContainers.Remove(C)
        Pressure.PascalValue -= ProduceFixedAmountOfContainer(C).Pressure.PascalValue
    End Sub

    Public Function ProduceFixedAmountOfContainer(C As FixedAmountOfSubstanceContainer) As FixedAmountOfSubstanceContainer
        Dim P As Producer = New Producer()
        Dim OC As FixedAmountOfSubstanceContainer = New FixedAmountOfSubstanceContainer(New Gas())
        With OC
            .Temperature = Temperature
            .Volume = Volume
            .Pressure = New Pressure()
        End With
        P.Produce(C, OC)
        Return OC
    End Function


End Class