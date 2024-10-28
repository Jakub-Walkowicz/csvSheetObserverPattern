using System.Linq;

namespace CsvSystem.ObserverPattern
{
    public class Chart : IObserver
    {
        public Cell Cell { get; }
        public string Name { get; }

        public Chart(Cell cell, string name)
        {
            this.Cell = cell;
            this.Name = name;
        }

        // Metoda rysowanie wykresu
        public void DrawChart(string pluses)
        {
            // sprawdzam czy podana wartosc jest NULL
            // jezeli tak to rzucam wyjatek
            if (pluses == null)
            {
                throw new ArgumentNullException(nameof(pluses), "Podana wartość nie moze być NULL");
            }

            // sprawdzam czy dlugosc podanych znakow zgadza sie z liczba przechowywana przez dana komorke
            if (pluses.Length != (int)Cell.ByteValue || !pluses.All(c => c == '+'))
            {
                throw new ArgumentException("Wartość nie jest poprawna do rysowania wykresu.");
            }

            Console.WriteLine("{0}: {1}", Name, pluses);
        }

        // Aktualizacja PULL
        public void Update(ISubject subject)
        {
            if (subject is Cell cell)
            {
                byte ByteValue = cell.ByteValue;
                string Name = cell.Name;
                string Pluses = new string('+', ByteValue);
                Console.WriteLine(
                    "Zaktualizowano komórkę o nazwie: '{0}', nowa wartość: {1}",
                    Name,
                    ByteValue
                );
                DrawChart(Pluses);
            }
        }

        // Aktualizacja PUSH

        // public void Update(byte byteValue, string name)
        // {
        //     string Pluses = new string('+', byteValue);
        //     Console.WriteLine("Zaktualizowano komórkę o nazwie '{0}', nowa wartość: {1}", name, byteValue);
        //     DrawChart(Pluses);
        // }
    }
}
