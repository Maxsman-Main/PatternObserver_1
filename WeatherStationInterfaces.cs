namespace WeatherStationInterfaces
{
    public interface ISubject
    {
        public void RegisterObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void NotifyObservers();
    }

    public interface IObserver
    {
        public void Update(float temp, float humidity, float pressure, float heatIndex);
    }

    public interface IDisplayElement
    {
        public void Display();
    }
}