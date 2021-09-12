using System.Collections;
using WeatherStationInterfaces;

namespace WeatherDataCollection
{
    public class WeatherData : ISubject
    {
        private ArrayList observers;
        private float temperature;
        private float humidity;
        private float pressure;
        private float heatIndex;

        public WeatherData()
        {
            observers = new ArrayList();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            int indexOfObserver = observers.IndexOf(observer);
            if(indexOfObserver >= 0)
            {
                observers.Remove(indexOfObserver);
            }
        }

        public void NotifyObservers()
        {
            for(int i = 0; i < observers.Count; ++i)
            {
                IObserver nextObserver = (IObserver)observers[i];
                nextObserver.Update(temperature, humidity, pressure, heatIndex);
            }
        }

        private float computeHeatIndex(float t, float rh)
        {
            float index = (float)((16.923 + (0.185212 * t) + (5.37941 * rh) - (0.100254 * t * rh) +
                (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) +
                (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
                (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 *
                (rh * rh * rh)) + (0.00000142721 * (t * t * t * rh)) +
                (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
                0.000000000843296 * (t * t * rh * rh * rh)) -
                (0.0000000000481975 * (t * t * t * rh * rh * rh)));
            return index;
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.heatIndex = computeHeatIndex(temperature, humidity);
            MeasurementsChanged();
        }
    }
}