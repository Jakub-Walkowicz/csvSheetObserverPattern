using System.Data;
using CsvSystem.ObserverPattern;

Cell cell1 = new Cell(5, "A1");
Cell cell2 = new Cell(8, "A2");

Chart chart1 = new Chart(cell1, "Plot1");

// "Każdy wykres powiązany jest z pewną komórką"
cell1.Attach(chart1);
Console.ReadKey();

// "Narysowanie wykresu polega na wypisaniu znaku ‘+’ tyle razy, ile wynosi wartość komórki, do której odnosi się wykres."
chart1.DrawChart("+++++");
Console.ReadKey();

// "Jeśli komórka obserwowana przez wykres zmieni wartość,wykres jest ponownie rysowany"
cell1.ByteValue = 6;
Console.ReadKey();

// "Komórka może również obserwować inną komórkę"
cell1.Attach(cell2);
Console.ReadKey();

// Odpinam wykres, celem wiekszej przejrzystosci
cell1.Detach(chart1);
Console.ReadKey();

// Zmieniam wartosc obserwowanej komorki
cell1.ByteValue = 7;
Console.ReadKey();

// Sprawdzam wartosc obserwujacej komorki, powinna byc rowna cell1.ByteValue = 7;
Console.WriteLine("Wartość komórki {0} wynosi: {1}", cell2.Name, cell2.ByteValue);
