
namespace laboratorka2
{
    internal class Program
    {
        public static int CheckingForANumber()
        {
            while (true)
            {
                string arr;
                arr = Console.ReadLine();

                if (int.TryParse(arr, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Введене значення не є числом.");
                    Console.WriteLine("Введіть відповідь повторно");

                }
            }
        }
        public static void big_game(int points_user, int points_comp)
        {
            Random random = new Random();
            int zagadchislo = random.Next(1, 3);
            Console.WriteLine("Ласкаво просимо вас в гру 'Все або нічого'!");
            Console.WriteLine("Вам потрібно вибрати 1 або 2. Якщо співпаде з комп’ютером — ви переможете.");
            Console.WriteLine("А якщо не співпаде з комп’ютером — ви втратите все.");
            if (CheckingForANumber() == zagadchislo)
            {
                points_user *= 10;
                points_comp *= 0;
            }
            else
            {
                points_user *= 0;
                points_comp *= 10;
            }

            if (points_user > 0)
            {
                Console.WriteLine("Вітаю ви вийграли джекпот");
            }
            else
            {
                Console.WriteLine("Ваші очки пішли на розвиток компанії :)");
            }
            Console.WriteLine($"Ваші очки:{points_user}");
            Console.WriteLine($"Компютера очки:{points_comp}");
            
        }
        public static void podscaska(int zagadchislo,int answer)
        {
            if (answer > zagadchislo)
            {
                Console.WriteLine("Загадане число меньше");
            }
            else
            {
                Console.WriteLine("Загадане число більше");
            }
        }
        public static void Level_two(int health, int points_user, int points_comp,int pod)
        {
            health *= 22;
            Console.WriteLine("\tРівень 2");
            Random random = new Random();
            for (int i = 0; i <= 2; i++)
            {
                health = 22;
                int zagadchislo = random.Next(10, 101);
                while (health > 0)
                {
                    Console.Write("Введіть число: ");
                    int anwser = CheckingForANumber();
                    if (anwser != zagadchislo)
                    {
                        health -= 1;
                        Console.WriteLine($"Неправильно! Залишилось життів: {health}");
                        Console.WriteLine("Бажаєте використати подсказку та відати 1 життя :) ");
                        Console.WriteLine("1 - так 2-ні ");
                        Console.Write("Введіть число: ");
                        if (CheckingForANumber() == 1 && health > 1)
                        {
                            health -= 1;
                            pod += 1;
                            podscaska(zagadchislo,anwser);
                        }
                    }
                    else
                    {
                         Console.WriteLine("Ви вгадали число");
                        break;
                    }
                   
                }

            }
            if(health == 0)
            {
                Console.WriteLine("Ви програли!");
            }
            else
            {
                Console.WriteLine("Ви вийграли!");
            }
            points_user = health * 22;
            points_comp = (22 - health) * 22;
            Console.WriteLine($"Ваші очки:{points_user}");
            Console.WriteLine($"Компютера очки:{points_comp}");
            Console.WriteLine($"Осталось життя {health}");
            if (pod > 5)
            {
                Console.WriteLine($"Ви не цінуєте своє життя використаних подсказок:{pod}");
            }
            Console.WriteLine("Чи бажаєте ви зіграти гру все або нічого?");
            Console.WriteLine("1 - так 2-ні ");
            Console.Write("Введіть число: ");
            if (CheckingForANumber() == 1)
            {
              
                big_game(points_user, points_comp);
            }

           
        }
        public static void Level_one(int health,int points_user, int points_comp,int pod)
        {
            health *= 5;
            Console.WriteLine("\tРівень 1");
            Random random = new Random();
            for (int i = 0; i <= 3; i++)
            {
                health = 5;
                int zagadchislo = random.Next(1,11);
                while (health > 0)
                {
                    Console.Write("Введіть число: ");
                    int anwser = CheckingForANumber();
                    if (anwser != zagadchislo)
                    {
                        health -= 1;
                        Console.WriteLine($"Неправильно! Залишилось життів: {health}");
                        Console.WriteLine("Бажаєте використати подсказку та відати 1 життя :) ");
                        Console.WriteLine("1 - так 2-ні ");
                        Console.Write("Введіть число: ");
                        if (CheckingForANumber() == 1 && health > 1)
                        {
                            health -= 1;
                            pod += 1;
                            podscaska(zagadchislo, anwser);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ви вгадали число");
                        break;
                    }

                }


            }
            if (health == 0)
            {
                Console.WriteLine("Ви програли!");
            }
            else
            {
                Console.WriteLine("Ви вийграли!");
            }
            points_user = health * 5;
            points_comp = (5 - health) * 5;
            Console.WriteLine($"Ваші очки:{points_user}");
            Console.WriteLine($"Компютера очки:{points_comp}");
            Console.WriteLine($"Осталось життя {health}");
            if (health == 5)
            {
                Console.Write("Бажаєте ви перейти на другий рівень? 1-так 2-ні");
                Console.Write("Введіть число: ");
                if(CheckingForANumber() != 1)
                {
                    
                    return;
                }
                Level_two(1, points_user, points_comp,pod);
                
            }

        }
        



        public static void Task2()
        {
            double x, y, s, u;
            int k;
            string rep;

            do
            {
                Console.WriteLine("Введіть x=");
                x = double.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine('\t' + "Поточні результати" + '\n');
                k = 2;
                s = -1 + (x + 1) / 3;
                u = (x + 1) / 3; //Значення першого елемента ряду
                while (Math.Abs(u) >= 0.000001)
                {
                    
                    u *= ((3 * k - 4) / (3.0 * k)) * (x + 1) / k;  // Використовуємо рекурентну формулу
                    s += u;
                    k++;
                }

                y = Math.Cbrt(x);
                Console.WriteLine($"РЕЗУЛЬТАТИ:\nЗначення x = {x}");
                Console.WriteLine($"\nОбчислення значення суми ряду S = {s}");
                Console.WriteLine($"Кількість членів ряду -{k}");
                Console.WriteLine($"Значення функції y(x)={y}");
                Console.WriteLine(" Для повторного вволу натисніть довільну клавішу" + " Для закінчення програми натисніть Enter");
                rep = Console.ReadLine();            
            } while (rep != "");
        }
        
        
        public static void Task1()
        {
            double xStart = -2;  // x начальное
            double xEnd = 2;     // x конечное
            double dx = 0.1;       // Шаг
            double y = 0;

            for (int a = 1; a <= 4; a++)
            {
                Console.WriteLine($"Розрахунки a = {a}:");
                for (double x = xStart; x <= xEnd; x += dx)
                {
                    y = (a * Math.Pow(x, 2)) / Math.Sqrt(1 + a * Math.Pow(x, 2));

                    Console.WriteLine($"x = {x:F2}, y = {y:F5}");
                }

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть завдання від 1 до 3");
            Console.Write("Напишіть число:");
            byte solution = Convert.ToByte(Console.ReadLine());
            switch (solution)
            {
                case 1:
                    Console.WriteLine("\r\nПриклад 29");
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Console.WriteLine("Це гра GUESS MY NUMBER");
                    Console.WriteLine("Це гра, де гравець повинен вгадати число, яке випадково загадав комп'ютер, з можливістю отримати підказку та накопичувати очки.");
                    Console.WriteLine("Тут два рівні складності,щоб перейти на друге тобі потрібно пройти перший");
                    Console.WriteLine("Для продовження нажміть Enter");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("\tПравила");
                    Console.WriteLine("Є два рівні:");
                    Console.WriteLine("Гра починається з першого рівня");
                    Console.WriteLine("Перший рівень: число від 1 до 10 всього 3 раунда");
                    Console.WriteLine("На перший рівень виділяється 5 життів");
                    Console.WriteLine("Очки за рівень: залишилися життя × 5");
                    Console.WriteLine("Якщо програв раунд, комп'ютер отримує: початкові життя × 5");
                    Console.WriteLine("Другий рівень доступний лише якщо пройдений перший рівень без поразок:");
                    Console.WriteLine("Число від 10 до 100 всього 2 раунда");
                    Console.WriteLine("На другий рівень виділяється 22 життів");
                    Console.WriteLine("Очки за рівень: залишилися життя × 10");
                    Console.WriteLine("Якщо гравець вгадав неправильно, є можливість отримати підказку (загадане число більше чи менше).");
                    Console.WriteLine("Вартість підказки: -1 життя");
                    Console.WriteLine("Для продовження нажміть Enter");
                    Console.ReadKey();
                    Console.Clear();
                    Level_one(1, 0, 0, 0);
                    Console.WriteLine("Для продовження нажміть Enter");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Error");
                    return;
            }
        }
    }
}
