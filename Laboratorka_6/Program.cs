
using Laboratorka_6.Task_1;
using Laboratorka_6.Task_1.utilits;
using Laboratorka_6.Task_2;
using Laboratorka_6.Task_2.Interface_and_Utilits;
using System.Text;

class Program
{
    static void Task1()
    {
        var animal = util_animals.generateAnimals();

        Console.WriteLine(" Інформація про тварину:");
        Console.WriteLine(animal.ToString()); 

        Console.WriteLine("\n Чи є небезпечною?");
        Console.WriteLine(animal.IsDangerous() ? "Так, тварина небезпечна!" : "Ні, тварина не становить загрози.");
    }
    static void Task2()
    {
        Autopark park = new Autopark();

        park.AddVehicle(utilits_bus.generateBus());
        park.AddVehicle(utilits_minibus.generateMiniBus());
        park.AddVehicle(utilits_car.generateCar());
        Console.WriteLine("Список транспорту у автопарку:\n");
        foreach (var vehicle in park.Vehicles)
        {
            Console.WriteLine(vehicle.ToString());
            Console.WriteLine("---------------------------");
        }

        // Подсчёт людей (только если не грузовой транспорт)
        Console.WriteLine("Загальна кількість людей у легковому транспорті: " + park.CountPeople());
    }
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Виберіть завдання від 1 до 2");
        Console.Write("Напишіть число:");
        byte solution = Convert.ToByte(Console.ReadLine());
        switch (solution)
        {
            case 1:
                {
                Console.WriteLine("\r\nПриклад 9");
                    Task1();
                    break;
                }
            case 2:
                {
                    Task2();
                    break;
                }
        }
    }
}
