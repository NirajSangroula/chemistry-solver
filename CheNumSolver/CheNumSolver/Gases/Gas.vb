Public Class Gas
    Private N As String
    Private M As Double
    Private MW As Double
    Private NOM As Double
    Private NOMo As Double
    Private D As Double
    Private ROD As Double
    Private ReadOnly AVOGADRO_NUMBER As Double = 6.022140857E+23
    Private Property IsInitialized As Boolean = False

    Property Mass()
        Get
            If (M = 0 And Not IsInitialized) Then
                Initialize()
            End If
            Return M
        End Get
        Set(value)
            M = value
        End Set
    End Property

    Public Sub Initialize()
        IsInitialized = True
        If (NOM) Then
            SetFromNumberOfMoles()
        ElseIf (Mass And MolecularWeight) Then
            SetNumberOfMoles()
        ElseIf (NOMo) Then
            SetNumberOfMolesFromNumberOfMolecules()
        End If
    End Sub

    Private Sub SetFromNumberOfMoles()
        SetNumberOfMolecules()
        SetMass()
        SetMolecularWeight()
    End Sub

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
            If (MW = 0 And Not IsInitialized) Then
                Initialize()
            End If
            Return MW
        End Get
        Set(value)
            MW = value
        End Set
    End Property

    Property Density()
        Get
            If (D = 0 And Not IsInitialized) Then
                Initialize()
            End If
            Return D
        End Get
        Set(value)
            D = value
        End Set
    End Property

    Property RateOfDiffusion()
        Get
            If (ROD = 0 And Not IsInitialized) Then
                Initialize()
            End If
            Return ROD
        End Get
        Set(value)
            ROD = value
        End Set
    End Property


    Property NumberOfMoles()
        Get
            If (NOM = 0 And Not IsInitialized) Then
                Initialize()
            End If
            Return NOM
        End Get
        Set(value)
            NOM = value
        End Set
    End Property

    Property NumberOfMolecules()
        Get
            SetNumberOfMolecules()
            If (NOMo = 0 And Not IsInitialized) Then
                Initialize()
            End If
            Return NOMo
        End Get
        Set(value)
            NOM = value
        End Set
    End Property

    Public Sub SetNumberOfMolecules()
        NOMo = NOM * AVOGADRO_NUMBER
    End Sub

    Public Sub SetNumberOfMoles()
        If MolecularWeight Then
            NumberOfMoles = Mass / MolecularWeight
        End If
    End Sub

    Public Sub SetNumberOfMolesFromNumberOfMolecules()
        NOM = NOMo / AVOGADRO_NUMBER
    End Sub
    Public Sub SetMass()
        If MolecularWeight Then
            Mass = NumberOfMoles * MolecularWeight
        End If
    End Sub

    Public Sub SetMolecularWeight()
        If NumberOfMoles Then
            MolecularWeight = Mass / NumberOfMoles
        End If
    End Sub
End Class