
using laboratorka_8.Task_1;
using laboratorka_8.Task_2;
using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace laboratorka_8
{
    class Program
    {
        public static byte Checking()
        {
            while (true)
            {
                string? arr = Console.ReadLine();

                if (byte.TryParse(arr, out byte number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("The value entered is not a number");
                    Console.WriteLine("Re-enter your answer");

                }
            }
        }

        public static int CheckingInt()
        {
            while (true)
            {
                string? arr = Console.ReadLine();

                if (int.TryParse(arr, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("The value entered is not a number");
                    Console.WriteLine("Re-enter your answer");

                }
            }
        }


        static void Task1()
        {
            Method_Task_1.Time_Now();

            Method_Task_1.Date_Now();
            Method_Task_1.Day_Now();
            Console.Write("Напишіть число:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Число {number} просте? {Method_Task_1.Prostoe_or_not(number)}");
            Console.WriteLine($"Число {number} — число Фібоначчі? {Method_Task_1.Fibanachi(number)}");
            Console.WriteLine($"Площа трикутника (a=5, h=3): {Method_Task_1.plosha_trekutnika(5, 3)}");
            Console.WriteLine($"Площа прямокутника (a=4, b=6): {Method_Task_1.plosha_pramokut(4, 6)}");
        }
        static void Task2()
        {
         
            Valisa valisa = util_valisa.genereteValisa();
            suitcase.ItemAdded += (item) => Console.WriteLine($"Додано новий предмет {item.Name}");

            Element_do_Valisi item1 = util_element.genereteElement();
            Element_do_Valisi item2 = util_element.genereteElement();
            Element_do_Valisi item3 = util_element.genereteElement();
            Element_do_Valisi item4 = util_element.genereteElement(); 


            Console.WriteLine(item1.ToString());
            Console.WriteLine(item2.ToString());
            Console.WriteLine(item3.ToString());
            Console.WriteLine(item4.ToString());
           
            try
            {
                valisa.DodatyObiekt(item1);
                valisa.DodatyObiekt(item2);
                valisa.DodatyObiekt(item3);
                valisa.DodatyObiekt(item4); 
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            Console.WriteLine(valisa.ToString());

            Console.ReadKey();
        }
        public static void Print_Array(int[] Array)
        {
            foreach (int jA in Array)
            {
                Console.Write(jA + " ");
            }
            Console.WriteLine();
        }
        public static int[] Claviatura(int Rosmir)
        {
            int j;
            string strValue;
            int[] iArray = new int[Rosmir];
            Console.WriteLine($"Масив складається з {Rosmir} елементів");
            for (j = 0; j < iArray.Length; j++)
            {
                Console.Write($"Введіть {j + 1} елемент:");
                strValue = Console.ReadLine();
                iArray[j] = Convert.ToInt32(strValue);

            }
            Print_Array(iArray);
            return iArray;
        }
        public static int[] Random_number(int Rosmir)
        {
            int j;
            Random rnd = new Random();
            int[] iArray = new int[Rosmir];
            for (j = 0; j < iArray.Length; j++)
            {
                iArray[j] = rnd.Next(-101, 101); /* заповнюється числами від -100 до 100 */

            }
            Print_Array(iArray);
            return iArray;
        }
        public static  Action isprogramday = () => Console.WriteLine((DateTime.Now.DayOfYear == 256)? "True" : "False");
        public static  Func<int[], int> delet_na_seven = arr => arr.Count(x => x % 7 == 0);
        public static  Func<int[], int> Positiv = arr => arr.Count(x => x > 0);
        public static Func<string, string[], bool> proverka = (text, words) => words.Any(word => text.Contains(word, StringComparison.OrdinalIgnoreCase));
        static void Task3()
        {
            int[] masiv = null;
            Console.WriteLine("Напишіть розмір масиву:");
            int Rosmir = CheckingInt();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Виберіть введення значень масиву 1-ручний 2-генерує");
                switch (Checking())
                {
                    case 1:
                        masiv = Claviatura(Rosmir);
                        flag = false;
                        break;
                    case 2:
                        masiv = Random_number(Rosmir);
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
            Console.WriteLine($"Кількість чисел, кратних 7: {delet_na_seven(masiv)}");
            Console.WriteLine($"Кількість додатних чисел: {Positiv(masiv)}");
            isprogramday();
            Console.WriteLine("Введіть текст для перевірки: ");
            string Text = Console.ReadLine();
            string[] searchWords = { "наче", "щось" };
            Console.WriteLine($"Чи містить текст задані слова? {proverka(Text, searchWords)}");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Виберіть завдання від 1 до 3");
                Console.Write("Напишіть число:");

                switch (Checking())
                {
                    case 1:

                        Task1();
                        flag = false;
                        break;

                    case 2:

                        Task2();
                        flag = false;
                        break;

                    case 3:
                        Task3();
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Невірне число. Введіть 1, 2 або 3.");
                        break;
                }
            }
        }
    }
}
