Public Class Gas
    Private N As String
    Private M As Double
    Private MW As Double
    Private NOM As Double
    Private D As Double
    Private ROD As Double

    Property Mass()
        Get
            SetMass()
            If IsNothing(M) Then
                Throw New UnknownValueException()
            End If
            Return M
        End Get
        Set(value)
            M = value
        End Set
    End Property

    Property Name()
        Get
            If IsNothing(N) Then
                Throw New UnknownValueException()
            End If
            Return N
        End Get
        Set(value)
            N = value
        End Set
    End Property

    Property MolecularWeight()
        Get
            SetMolecularWeight()
            If IsNothing(MW) Then
                Throw New UnknownValueException()
            End If
            Return MW
        End Get
        Set(value)
            MW = value
        End Set
    End Property

    Property Density()
        Get
            If IsNothing(D) Then
                Throw New UnknownValueException()
            End If
            Return D
        End Get
        Set(value)
            D = value
        End Set
    End Property

    Property RateOfDiffusion()
        Get
            If IsNothing(ROD) Then
                Throw New UnknownValueException()
            End If
            Return ROD
        End Get
        Set(value)
            ROD = value
        End Set
    End Property


    Property NumberOfMoles()
        Get
            SetNumberOfMoles()
            If IsNothing(NOM) Then
                Throw New UnknownValueException()
            End If
            Return NOM
        End Get
        Set(value)
            NOM = value
        End Set
    End Property

    Public Sub SetNumberOfMoles()
        NumberOfMoles = Mass / MolecularWeight
    End Sub

    Public Sub SetMass()
        Mass = NumberOfMoles * MolecularWeight
    End Sub

    Public Sub SetMolecularWeight()
        MolecularWeight = Mass / NumberOfMoles
    End Sub
End Class