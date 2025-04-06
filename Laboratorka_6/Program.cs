
using Laboratorka_6.Task_1;
using Laboratorka_6.Task_2;

class Program
{
    static void Main()
    {
        void Task1()
        {
            Wild_animals[] animals = new Wild_animals[]
            {
                new Wild_animals("Кабан", 5,2),
                new Predatory_animal("Вовк", 4, 3,"Карпати", 60, 1.2),
                 new Predatory_animal("Лисиця", 3,2, "Полісся", 30, 0.8)
            };
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine("\nДемонстрація роботи ReplaceFields:");
            animals[0].ReplaceFields("Олень", 6,10);
            Console.WriteLine(animals[0]);
        }
        void Task2()
        {
            int totalPassengers = 0;
            Vehicle[] fleet =
            {
                new Car(5, 150, "Toyota"),
                new Bus(50, 70, "InterCity"),
                new Minibus(12, 85, "Маршрут №32"),
            };

            if (fleet.Length == 0)
            {
                Console.WriteLine("Автопарк порожній!");
                return;
            }
            foreach(var auto in fleet)
            {
                Console.WriteLine(auto.ToString());
            }
            for (int i = 0; i < fleet.Length; i++)
            {
                totalPassengers += fleet[i].People;
            }
            Console.WriteLine("Максимальна кількість людей, яких можна перевезти за одну подорож: " + totalPassengers);
        }
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
