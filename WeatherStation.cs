using System;
using WeatherDataCollection;
using WeatherObserver;
using WeatherStationInterfaces;

namespace PatternObserver
{
    class WeatherStation
    {
        static void Main()
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.SetMeasurements(78, 90, 29.2f);
        }
    }
}
