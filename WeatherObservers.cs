using WeatherStationInterfaces;
using WeatherDataCollection;
using System;

namespace WeatherObserver
{

    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private float heatIndex;
        private ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure, float heatIndex)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.heatIndex = heatIndex;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("CurrentConditions: " + temperature + " F degrees and " + humidity + " % humidity");
            Console.WriteLine("Heat index is " + heatIndex);
        }
    }
}