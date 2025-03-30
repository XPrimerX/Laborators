

using laboratorka_5;

class Program
{
    static void Main()
    {
        // Варіант 10
        try
        {
            Person manufacturer = new Person("Іван", "Бондарчук", new DateTime(1980, 5, 20));
            Detail engine = new Detail(manufacturer, "Двигун", 500);
            Detail wheel = new Detail(manufacturer, "Колесо", 100);
            Transport car = new Transport("Автомобіль", TransportType.Ground, DateTime.Now, 50000, new Detail[] { engine, wheel });
            Console.WriteLine(car.ToShortString());
            Console.WriteLine($"Ground: {car[TransportType.Ground]}, Air: {car[TransportType.Air]}, Water: {car[TransportType.Water]}");
            car.AddDetails(new Detail(manufacturer, "Сидіння", 50));
            Console.WriteLine(car);
            Transport plane = new Transport("Літак", TransportType.Air, DateTime.Now, 200000, new Detail[] { new Detail(manufacturer, "Крило", 800) });
            Transport boat = new Transport("Катер", TransportType.Water, DateTime.Now, 100000, new Detail[] { new Detail(manufacturer, "Гвинт", 300) });
            Console.WriteLine("\nСписок транспорту:");
            Console.WriteLine(car);
            Console.WriteLine(plane);
            Console.WriteLine(boat);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            Console.WriteLine(" Уведіть знову!");
        }
    
    }
}