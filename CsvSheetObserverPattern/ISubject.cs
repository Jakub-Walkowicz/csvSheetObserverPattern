namespace CsvSystem.ObserverPattern
{
    public interface ISubject
    {
        // Dołącz obserwatora do obiektu
        void Attach(IObserver observer);

        // Odłączenie obserwatora od obiektu
        void Detach(IObserver observer);

        // Powiadomienie wszystkich obserwatorów o zdarzeniu
        void Notify();
    }
}
