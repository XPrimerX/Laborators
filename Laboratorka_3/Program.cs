
namespace Laboratorka_3
{
    internal class Program
    {
        public static void Sort_Array(int[] iArray)
        {
            long sum_otr = 0;//сума від'ємних елементів
            int num_otr = 0; //кількість від'ємних елементів
            int[] iArray2 = (int[])iArray.Clone(); // Клонування початкового масиву


            foreach (int num in iArray)
            {
                if (num < 0)
                {
                    sum_otr += num;
                    num_otr++;
                }
            }
            for (int i = 4; i < iArray.Length; i += 5) // Шукаємо 5 елемент
            {
                int maxValue = int.MinValue; 

                for (int j = i - 4; j < i; j++)
                {
                    if (iArray[j] > maxValue)
                    {
                        maxValue = iArray[j];
                    }
                }

                iArray[i] = maxValue; 
            }
            Console.WriteLine("Старий масив:(");
            foreach (int jA in iArray2)
            {
                Console.Write(jA + " ");
            }
            Console.WriteLine(")");

            Console.WriteLine("Новий масив:(");
            foreach (int jA in iArray)
            {
                Console.Write(jA + " ");
            }
            Console.WriteLine(")");
            Console.WriteLine($"Сума від'ємних ={sum_otr}");
            Console.WriteLine($"Кількість від'ємних ={num_otr}");
            Console.ReadKey();
            Console.WriteLine("");
        }
        public static int[] Claviatura(int Rosmir)
        {
            int j;
            string strValue;
            int[] iArray = new int[Rosmir];
            Console.WriteLine($"Масив складається з {Rosmir} елементів");
            for (j = 0; j < iArray.Length; j++)
            {
                Console.Write($"Введіть {j+1} елемент:");
                strValue = Console.ReadLine();
                iArray[j] = Convert.ToInt32(strValue);

            }

            foreach (int jA in iArray)
            {
                Console.Write("{0,5:D}", jA);
            }
            Console.ReadKey();
            Console.WriteLine("");
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
            foreach (int jA in iArray)
            {
                Console.Write("{0,5:D}", jA);
            }
            Console.ReadKey();
            Console.WriteLine("");
            return iArray;
        }
       
        public static int[] Text_file()
        {
            if (!File.Exists("dat.txt"))
            {
                Console.WriteLine("Файл не найден. Пожалуйста, создайте файл 'dat.txt' и добавьте числа.");
                return new int[0];

            }

            int count = 0;
            string strValue;
          
            using (StreamReader sRead = new StreamReader("dat.txt"))
            {
                while (sRead.ReadLine() != null)
                {
                    count++;
                }
            }
            int[] iArray = new int[count];

            using (StreamReader sRead = new StreamReader("dat.txt"))
            {

                for (int j = 0; j < iArray.Length; j++)
                {
                    strValue = sRead.ReadLine();
                    if (int.TryParse(strValue, out int number))
                    {
                        iArray[j] = number;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: '{strValue}' не число.Тому замінюємо його на 0");
                        iArray[j] = 0;
                    }
                    
                }
                foreach (int jA in iArray)
                {
                    Console.Write("{0,5:D}", jA);
                }
                Console.ReadKey();
                Console.WriteLine("");

            }
            return iArray;

        }
        public static double[,] Random_number_Dvoh(int Rosmir,int Rosmir_dva)
        {
            int j;
            Random rnd = new Random();
            double[,] iArray = new double[Rosmir, Rosmir_dva];
            for (j = 0; j < iArray.GetLength(0); j++) // Прохід по рядках
            {
                for (int i = 0; i < iArray.GetLength(1); i++) // Прохід по стовпцях
                {

                    iArray[j, i] = rnd.Next(-101, 101); /* заповнюється числами від -100 до 100 */
                
                }

            }
            // Вивід масиву у вигляді таблиці
            for (j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++)
                {
                    Console.Write("{0,8:F2}", iArray[j, i]);  // Форматований вивід
                }
                Console.WriteLine(); // Перехід на новий рядок
            }
            Console.ReadKey();
            Console.WriteLine("");
            return iArray;
        }
        public static double[,] Claviatura_Dvoh(int Rosmir, int Rosmir_dva)
        {
            int j;
            double[,] iArray = new double[Rosmir, Rosmir_dva];
            Console.WriteLine($"Масив складається з {Rosmir}*{Rosmir_dva} елементів");
            for (j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++) // Прохід по стовпцях
                {
                    Console.Write($"Введіть елемент [{j + 1}, {i + 1}]: ");
                    iArray[j,i] = Convert.ToInt32(Console.ReadLine());
                }

            }

            // Вивід масиву у вигляді таблиці
            for (j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++)
                {
                    Console.Write("{0,8:F2}", iArray[j, i]);  // Форматований вивід
                }
                Console.WriteLine(); // Перехід на новий рядок
            }
            Console.ReadKey();
            Console.WriteLine("");
            return iArray;
        }
  
        public static void Text_file_Dvoh()
        {
            if (!File.Exists("dat_2.txt"))
            {
                Console.WriteLine("Файл не найден. Пожалуйста, создайте файл 'dat_2.txt' и добавьте числа.");
                return;

            }
            int rows = 0;
            int cols = 0;
            int[,] x = null;
            using (StreamReader reader = new StreamReader("dat_2.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    rows++;
                    int currentCols = line.Split(' ').Length; // Кількість чисел у рядку
                    if (currentCols > cols)
                    {
                        cols = currentCols; // Запам'ятовуємо найбільшу довжину
                    }
                }
            }

            double[,] matrix = new double[rows, cols];

            using (StreamReader reader = new StreamReader("dat_2.txt"))
            {
                for (int i = 0; i < rows; i++)
                {
                    string line = reader.ReadLine();
                    string[] elements = line.Split(' ');

                    for (int j = 0; j < elements.Length; j++)
                    {
                        if (int.TryParse(elements[j], out int number))
                        {
                            matrix[i, j] = number;
                        }
                        else
                        {
                            Console.WriteLine($"Помилка: '{elements[j]}' не число. Замінюємо його на 1.");
                            matrix[i, j] = 1;
                        }
                    }
                }
            }
            Console.WriteLine("Масив: ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0,8:F2}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.WriteLine("");

            x =Generasia_X(rows, cols);
          Nowei_masiv(x, matrix);
        }
        public static int[,] Generasia_X(int Rosmir, int Rosmir_dva)
        {
            int j;
            Random rnd = new Random();
            int[,] x = new int[Rosmir, Rosmir_dva];
            for (j = 0; j < x.GetLength(0); j++) // Прохід по рядках
            {
                for (int i = 0; i < x.GetLength(1); i++) // Прохід по стовпцях
                {

                    x[j, i] = rnd.Next(0,2); 

                }

            }
            Console.WriteLine("Масив (х)");
            // Вивід масиву у вигляді таблиці
            for (j = 0; j < x.GetLength(0); j++)
            {
                for (int i = 0; i < x.GetLength(1); i++)
                {
                    Console.Write("{0,5:D}", x[j, i]);  // Форматований вивід
                }
                Console.WriteLine(); // Перехід на новий рядок
            }
            Console.ReadKey();
            Console.WriteLine("");
            return x;

        }
        public static void Nowei_masiv(int[,] x, double[,] iArray)
        {
            double max = double.MinValue;
            double min = double.MaxValue;
            double dobavlen = 0;
            for (int j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++) // Прохід по стовпцях
                {
                    if (x[j,i] == 1)
                    {
                        iArray[j,i] = iArray[j, i] * 0.7;
                    }
                    else
                    {
                        iArray[j, i] = iArray[j, i] * (-0.7);
                    }
                    if (iArray[j, i] > 0 && iArray[j, i] > max)
                    {
                        max = iArray[j, i];
                    }
                    if(iArray[j, i] <0 && iArray[j,i]<min)
                    {
                        min = iArray[j, i];
                    }
                }

            }
            Console.WriteLine("Масив,який помножили на 0,7 або -0,7");
            for (int j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++)
                {
                    Console.Write("{0,8:F2}", iArray[j, i]);  // Форматований вивід
                }
                Console.WriteLine(); // Перехід на новий рядок
            }
            Console.ReadKey();
            Console.WriteLine("");
            if (max == double.MinValue)
            {
                Console.WriteLine("Немає додатних чисел");
                max = 0;
            }
            else
            {
                Console.WriteLine($"Найбільший серед додатних:{max}");
            }
            if (min == double.MaxValue)
            {
                Console.WriteLine("Немає відємних чисел");
                min = 0;
            }
            else
            {
                Console.WriteLine($"Найменший серед відємних:{min}");

            }
            dobavlen = max + min;
            for (int j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++) // Прохід по стовпцях
                {
                    iArray[j, i] = iArray[j, i] + dobavlen;
                }

            }
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine($"Масив,який додали:{dobavlen}");
            for (int j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++)
                {
                    Console.Write("{0,8:F2}", iArray[j, i]);  // Форматований вивід
                }
                Console.WriteLine(); // Перехід на новий рядок
            }
            for (int j = 0; j < iArray.GetLength(0); j ++)
            {
                double[] tempRow = new double[iArray.GetLength(1)];
                // Копіюємо рядок у масив
                for (int i = 0; i < iArray.GetLength(1); i++)
                    tempRow[i] = iArray[j, i];
                // Сортуємо масив
                Array.Sort(tempRow);
                // Записуємо відсортований рядок назад у масив
                for (int i = 0; i < iArray.GetLength(1); i++)
                    iArray[j, i] = tempRow[i];
            }
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("Масив який відсортували у порядок зростання: ");
            for (int j = 0; j < iArray.GetLength(0); j++)
            {
                for (int i = 0; i < iArray.GetLength(1); i++)
                {
                    Console.Write("{0,8:F2}", iArray[j, i]);  // Форматований вивід
                }
                Console.WriteLine(); // Перехід на новий рядок
            }
        }
        public static void Task2() // (3+1+27)%30 = 1
        {
            int Rosmir;
            int Rosmir_dva;
            double[,] Array = null;
            int[,] x = null;
            byte solution_dva = 0;
            Console.WriteLine("Виберіть введення значень у масив написавши число 1,2,3 якщо бажаєте вийти напишіть любе інше число");
            Console.WriteLine("1-Введення даних з клавіатури(через консоль)");
            Console.WriteLine("2-Введення даних через файл");
            Console.WriteLine("3-Рандомна генерація даних");
            Console.Write("Введіть число:");
            byte solution = Convert.ToByte(Console.ReadLine());
            
            switch (solution)
            {
                case 1:
                    Console.WriteLine("Введіть тип багатовимірного масиву (1-прямокутний чи 2-ступінчатий)");
                    Console.Write("Введіть число:");
                    solution_dva = Convert.ToByte(Console.ReadLine());
                    Console.Write("Введіть розмір масиву: ");
                    Rosmir = Convert.ToInt32(Console.ReadLine());
                    if (solution_dva == 1)
                    {
                        Rosmir_dva = Rosmir;
                    }
                    else if (solution_dva == 2)
                    {
                        Console.Write("Введіть розмір стовбчиків");
                        Rosmir_dva = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.Write("Ви ввели не те число вихід із програми...");
                        return;
                    }
                    if(Rosmir ==0 || Rosmir_dva == 0)
                    {
                        Console.Write("Розмір масиву не може бути 0 ");
                        return;
                    }
                    Array = Claviatura_Dvoh(Rosmir, Rosmir_dva);
                    x=Generasia_X(Rosmir, Rosmir_dva);
                    break;
                case 2:
                    Text_file_Dvoh();
                    break;
                case 3:
                    Console.WriteLine("Введіть тип багатовимірного масиву (1-прямокутний чи 2-ступінчатий)");
                    Console.Write("Введіть число:");
                    solution_dva = Convert.ToByte(Console.ReadLine());
                    Console.Write("Введіть розмір масиву: ");
                    Rosmir = Convert.ToInt32(Console.ReadLine());
                    if (solution_dva == 1)
                    {
                        Rosmir_dva = Rosmir;
                    }
                    else if (solution_dva == 2)
                    {
                        Console.Write("Введіть розмір стовбчиків");
                        Rosmir_dva = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.Write("Ви ввели не те число вихід із програми...");
                        return;
                    }
                    if (Rosmir == 0 || Rosmir_dva == 0)
                    {
                        Console.Write("Розмір масиву не може бути 0 ");
                        return;
                    }
                    Array = Random_number_Dvoh(Rosmir, Rosmir_dva);
                    x=Generasia_X(Rosmir, Rosmir_dva);
                    break;
                default:
                    Console.WriteLine("Вихід із програми...");
                    return;
            }
            Nowei_masiv(x, Array);
            Console.ReadKey();
            Console.WriteLine("");
        }
        public static void Task1()
        {
            int Rosmir;
            int[] Array = null;
            Console.WriteLine("Виберіть введення значень у масив написавши число 1,2,3 якщо бажаєте вийти напишіть любе інше число");
            Console.WriteLine("1-Введення даних з клавіатури(через консоль)");
            Console.WriteLine("2-Введення даних через файл");
            Console.WriteLine("3-Рандомна генерація даних");
            Console.WriteLine("Введіть число:");
            byte solution = Convert.ToByte(Console.ReadLine());
            switch (solution)
            {
                case 1:
                    Console.Write("Введіть розмір масиву: ");
                    Rosmir = Convert.ToInt32(Console.ReadLine());
                    if (Rosmir == 0)
                    {
                        Console.Write("Розмір масиву не може бути 0 ");
                        return;
                    }
                    Array = Claviatura(Rosmir);
                    break;
                case 2:
                    Array = Text_file();
                    break;
                case 3:
                    Console.Write("Введіть розмір масиву: ");
                    Rosmir = Convert.ToInt32(Console.ReadLine());
                    if (Rosmir == 0)
                    {
                        Console.Write("Розмір масиву не може бути 0 ");
                        return;
                    }
                    Array = Random_number(Rosmir);
                    break;
                default:
                    Console.WriteLine("Вихід із програми...");
                    return;
            }
            Sort_Array(Array);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть завдання від 1 до 2");
            Console.Write("Напишіть число:");
            byte solution = Convert.ToByte(Console.ReadLine());
            switch (solution)
            {
                case 1:

                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                default:
                    Console.WriteLine("Error");
                    return;



            }
        }
    }
}
