Public Class Temperature
    Private ReadOnly FREEZING_POINT_OF_ICE_IN_KELVIN As Double = 273.15
    Private Kelvin As Double
    Private Celsius As Double
    Private Fahrenheit As Double
    Private ReadOnly Property UNINITIALIZED As Integer = 0
    Private ReadOnly Property INITIALIZED_BY_KELVIN As Integer = 1
    Private ReadOnly Property INITIALIZED_BY_CELSIUS As Integer = 2
    Private ReadOnly Property INITIALIZED_BY_FAHRENHEIT As Integer = 3
    Private Status As Integer = UNINITIALIZED

    Public Function IsInitializedByKelvin() As Boolean
        Return Status = INITIALIZED_BY_KELVIN
    End Function

    Public Function IsInitializedByFahrenheit() As Boolean
        Return Status = INITIALIZED_BY_FAHRENHEIT
    End Function

    Public Function IsInitializedByCelsius() As Boolean
        Return Status = INITIALIZED_BY_CELSIUS
    End Function

    Public Function IsInitialized() As Boolean
        Return (Status = UNINITIALIZED) = False
    End Function

    Property KelvinValue
        Get
            If Kelvin = 0 And IsInitialized() Then
                Initialize()
            End If
            Return Kelvin
        End Get
        Set(value)
            Kelvin = value
            Status = INITIALIZED_BY_KELVIN
        End Set
    End Property

    Property CelsiusValue
        Get
            If Celsius = 0 And IsInitialized() Then
                Initialize()
            End If
            Return Celsius
        End Get
        Set(value)
            Celsius = value
            Status = INITIALIZED_BY_CELSIUS
        End Set
    End Property

    Property FahrenheitValue
        Get
            If Fahrenheit = 0 And IsInitialized() Then
                Initialize()
            End If
            Return Fahrenheit
        End Get
        Set(value)
            Fahrenheit = value
            Status = INITIALIZED_BY_FAHRENHEIT
        End Set
    End Property

    Private Sub Initialize()
        If IsInitializedByCelsius() Then
            InitializeFromCelsius()
        ElseIf IsInitializedByFahrenheit Then
            InitializeFromFahrenheit()
        Else
            InitializeFromKelvin()
        End If
    End Sub

    Public Sub InitializeFromKelvin()
        SetCelsiusFromKelvin()
        SetFahrenheitFromKelvin()
    End Sub

    Public Sub InitializeFromFahrenheit()
        SetKelvinFromFahrenheit()
        SetCelsiusFromKelvin()
    End Sub

    Public Sub InitializeFromCelsius()
        SetKelvinFromCelsius()
        SetFahrenheitFromKelvin()
    End Sub

    Private Sub SetKelvinFromCelsius()
        KelvinValue = Celsius + FREEZING_POINT_OF_ICE_IN_KELVIN
    End Sub

    Private Sub SetKelvinFromFahrenheit()
        KelvinValue = (FahrenheitValue - 32) * 5 / 9 + FREEZING_POINT_OF_ICE_IN_KELVIN
    End Sub

    Private Sub SetFahrenheitFromKelvin()
        FahrenheitValue = (KelvinValue - FREEZING_POINT_OF_ICE_IN_KELVIN) * 9 / 5 + 32
    End Sub

    Private Sub SetCelsiusFromKelvin()
        CelsiusValue = KelvinValue - FREEZING_POINT_OF_ICE_IN_KELVIN
    End Sub
End Class
