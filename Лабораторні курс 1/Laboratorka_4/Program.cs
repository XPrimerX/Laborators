using System.Text.RegularExpressions;

namespace Laboratorka_4
{
    internal class Program
    {
        public static string CheckingForANumber()
        {
            while (true)
            {
                string arr;
                arr = Console.ReadLine();

                if (int.TryParse(arr, out int number))
                {
                    Console.WriteLine("Введене значення є числом.");
                    Console.WriteLine("Введіть відповідь повторно");
                }
                else
                {
                    return arr;
                }
            }
        }
        static void Task1_1()
        {
            Console.Write("Напишіть вираз: ");
            string user_answer = Console.ReadLine();
            if (Regex.IsMatch(user_answer, @"^[a-v]{22}18340$"))
            {
                Console.WriteLine($"правильний вираз:{user_answer}");
            }
            else
            {
                Console.WriteLine($"невірний вираз:{user_answer}");
            }
            

        }
        static void Task5()
        {
            string anwser;
            string user_answer = "";
            Console.WriteLine("Код визначає, чи є заданий рядок  шістнадцятковим ідентифікатором кольору HTML");
            Console.Write("Чи потрібна вам допомога введіть так або нет: ");
            string solution = CheckingForANumber();
            if (solution.ToLower() == "так") // добавил от себя
            {
                Console.WriteLine("Приклад #FFFF00");
                Console.Write("Введіть шістнадцятковим ідентифікатором кольору:#");
                anwser = Console.ReadLine();
                if (anwser.Length > 6)
                {
                    anwser = anwser.Substring(0, 6);
                }
                user_answer = $"#{anwser}".ToUpper();
              

            }
            else if(solution.ToLower() == "нет")
            {
                Console.Write("Введіть шістнадцятковим ідентифікатором кольору: ");
                user_answer = Console.ReadLine();
                if (user_answer.Length > 7)
                {
                    user_answer = user_answer.Substring(0, 7);
                }
               
            }
            else
            {
                Console.WriteLine("Вихід із програми...");
                return;
            }
            // проверяет на перший символ хештег(щоб був одни раз) і 6 символів після нього
            if (Regex.IsMatch(user_answer, @"^#([A-Fa-f0-9]{6})$"))
            {
                Console.WriteLine($"Вираз правильний: {user_answer}");
            }
            else
            {
                Console.WriteLine($"Неправильний вираз: {user_answer}");
            }
            Console.WriteLine("Натисніть Enter для продовження...");
            Console.ReadKey();
        }

        static string[] Ruchne()
        {
            try
            {
                Console.WriteLine("Напишіть слова,розділяйте кожне слово пробілом: ");
                string sent = Console.ReadLine();
                string[] words;
                words = sent.Split(' ');
                print(words);
                return words;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new string[0];
            }
        }
        static string[] Two_in_one(string[] words)
        {
            string[] result = new string[(words.Length+1) / 2];
            for (int i = 1,j=0; j < result.Length; i += 2,j++)
            {
                if (i < words.Length)
                {
                    result[j] += words[i-1] + words[i] + " ";
                }
                else
                {
                    result[j] += words[i-1];
                }
            }
            return result;
        }
        static void Write_text(string[] result,string txt)
        {
            using (StreamWriter f2 = new StreamWriter(txt))
            {
                foreach (string line in result)
                {
                    f2.Write(line);
                }
            }
        }
        static void print(string[] words)
        {
            foreach (string jA in words)
            {
                Console.Write(jA + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Кількість слів у рядку: " + words.Length);
            Console.WriteLine("Натисніть Enter для продовження...");
            Console.ReadKey();

        }
        static string[] text()
        {
            Console.Write("Введіть ім'я файлу в якому дані: ");
            string txt = Console.ReadLine();
            if (!File.Exists($"{txt}.txt"))
            {
                Console.WriteLine($"Файл не найден. Пожалуйста, создайте файл '{txt}.txt' и добавьте числа.");
                return new string[0];

            }

            string strValue;
            string[] words ;

            using (StreamReader sRead = new StreamReader($"{txt}.txt"))
            {

                    strValue = sRead.ReadToEnd();
                    words = strValue.Split(' ');



                print(words);
            }
            return words;
        }
        static void Task2()
        {
            string[] words = null;
            string[] result = null;
            Console.Write("Введіть ім'я файлу для збереження інформації: ");
            string txt = Console.ReadLine();
            if (!File.Exists($"{txt}.txt"))
            {
                Console.WriteLine($"Файл не найден. Пожалуйста, создайте файл '{txt}.txt' и добавьте числа.");
                return;

            }
            Console.WriteLine("Цей код об'єднує у одне слово кожні два слова рядка, що поряд розташовані");
            Console.Write("Виберіть тип введення даних,напишіть ручне або файл: ");
            string solution = CheckingForANumber();
            Console.WriteLine("Натисніть Enter для продовження...");
            Console.ReadKey();
            Console.Clear();
            if (solution.ToLower() == "ручне") 
            {
                try
                {
                    words = Ruchne();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                    return;
                }
            }
            else if (solution.ToLower() == "файл")
            {
            
                try
                {
                    words = text();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                    return;
                }

            }
            else
            {
                Console.WriteLine("Вихід із програми...");
                return;
            }
            result = Two_in_one(words);
            print(result);
            Write_text(result, $"{txt}.txt");
        }
       
        static void Task1()
        { //1 and 5
            Console.WriteLine("Це завдання складається з падзавдання 1 та 5");
            Console.WriteLine("Виберіть завдання 1 або 5,якщо бажаєте вийти напишіть любе друге число");
            Console.Write("Напишіть число:");
            byte solution = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Натисніть Enter для продовження...");
            Console.ReadKey();
            Console.Clear();
            switch (solution)
            {
                case 1:
                    {
                        Task1_1();
                        break;
                    }
                case 5:
                    {
                        Task5();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Вихід із програми");
                        return;
                    }


            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть завдання від 1 до 2");
            Console.Write("Напишіть число:");
            byte solution = Convert.ToByte(Console.ReadLine());
            switch (solution)
            {
                case 1:
                    {
                        Task1();
                        break;
                    }
                case 2:
                    {
                        Task2();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error");
                        return;
                    }


            }
        }
    }
}
