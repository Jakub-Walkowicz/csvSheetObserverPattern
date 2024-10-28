namespace CsvSystem.ObserverPattern
{
    public interface IObserver
    {
        // Aktualizacja PULL
        void Update(ISubject subject);

        // Aktualizacja PUSH
        // void Update(byte byteValue, string name);
    }
}
