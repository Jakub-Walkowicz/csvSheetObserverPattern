namespace CsvSystem.ObserverPattern
{
    public class Cell : IObserver, ISubject
    {
        private byte _byteValue;
        public byte ByteValue
        {
            get => _byteValue;
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Wartość musi być z zakresu 0-255."
                    );
                }
                _byteValue = value;
                Notify();
            }
        }
        public string Name { get; }

        public Cell(byte byteValue, string name)
        {
            this.ByteValue = byteValue;
            this.Name = name;
        }

        // Lista obserwatorow tzn. zarowno innych 'Cell' jaki i 'Chart'
        private List<IObserver> _observers = new List<IObserver>();

        // // Aktualizacja PULL
        public void Update(ISubject subject)
        {
            if (subject is Cell cell)
            {
                byte ByteValue = cell.ByteValue;
                this.ByteValue = ByteValue;
                Console.WriteLine(
                    "Zaktualizowano komórkę o nazwie '{0}', nowa wartość: {1}",
                    Name,
                    ByteValue
                );
            }
        }

        // Aktualizacja PUSH
        // public void Update(byte byteValue, string name)
        // {
        //     this.ByteValue = byteValue;
        //     Console.WriteLine("Zaktualizowano komórkę o nazwie '{0}', nowa wartość: {1}", name, byteValue);
        // }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                // Powiadomienie PULL
                observer.Update(this);

                // Powiadomienie PUSH
                // observer.Update(this.ByteValue, this.Name);
            }
        }

        public void Attach(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            else
                throw new InvalidOperationException("Dany obserwator juz obserwuje tę komórkę");
        }

        public void Detach(IObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
            else
                throw new InvalidOperationException("Dany obserwator nie obserwuje tej komórki");
        }
    }
}
