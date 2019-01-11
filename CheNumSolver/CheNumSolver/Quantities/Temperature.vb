Public Class Temperature
    Private ReadOnly FREEZING_POINT_OF_ICE_IN_KELVIN As Double = 273.15
    Private Kelvin As Double
    Private Celsius As Double
    Private Fahrenheit As Double

    Property KelvinValue
        Get
            If IsNothing(Kelvin) Then
                Initialize()
            End If
            Return Kelvin
        End Get
        Set(value)
            Kelvin = value
            Initialize()
        End Set
    End Property

    Property CelsiusValue
        Get
            If IsNothing(Celsius) Then
                Initialize()
            End If
            Return Celsius
        End Get
        Set(value)
            Celsius = value
            Initialize()
        End Set
    End Property

    Property FahrenheitValue
        Get
            If IsNothing(Fahrenheit) Then
                Initialize()
            End If
            Return Fahrenheit
        End Get
        Set(value)
            Fahrenheit = value
            Initialize()
        End Set
    End Property

    Private Sub Initialize()
        If IsNothing(Celsius) = False Then

        End If
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

    Private Sub SetCelsiusFromFahrenheit()
        CelsiusValue = FahrenheitValue - FREEZING_POINT_OF_ICE_IN_KELVIN
    End Sub
End Class
