
namespace Laboratorka_3
{
    internal class Program
    {
        static Random rnd = new Random();
        static (int num_otr, long sum_otr) Videm_element(int[] iArray)
        {
            long sum_otr = 0;//сума від'ємних елементів
            int num_otr = 0; //кількість від'ємних елементів
            foreach (int num in iArray)
            {
                if (num < 0)
                {
                    sum_otr += num;
                    num_otr++;
                }
            }
            return (num_otr, sum_otr);
        }
      
        public static void Change_five(int[] iArray)
        {
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
                Console.Write($"Введіть {j+1} елемент:");
                strValue = Console.ReadLine();
                iArray[j] = Convert.ToInt32(strValue);

            }
            return iArray;
        }
        public static int[] Random_number(int Rosmir)
        {
            int j;

            int[] iArray = new int[Rosmir];
            for (j = 0; j < iArray.Length; j++)
            {
                iArray[j] = rnd.Next(-101, 101); /* заповнюється числами від -100 до 100 */
                
            }
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
                
            }
            return iArray;
        }
        public static double[][] Random_number_Dvoh(int Row,int Colm)
        {
            int j;
            double[][] iArray = new double[Row][];
            for (j = 0; j < Row; j++) 
            {
                iArray[j] = new double[Colm];
                for (int i = 0; i < Colm; i++) 
                {

                    iArray[j][i] = rnd.Next(-101, 101); /* заповнюється числами від -100 до 100 */
                
                }

            }
            return iArray;
        }
        public static double[][] Claviatura_Dvoh(int Row, int Colm)
        {
            double[][] iArray = new double[Row][];
            Console.WriteLine($"Масив складається з {Row}*{Colm} елементів");
            for (int j = 0; j < Row; j++)
            {
                iArray[j] = new double[Colm];
                for (int i = 0; i < Colm; i++) 
                {
                    Console.Write($"Введите элемент [{j + 1}, {i + 1}]: ");
                    iArray[j][i] = Convert.ToDouble(Console.ReadLine()); 
                }
            }
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
            double[] x = null;
            using (StreamReader reader = new StreamReader("dat_2.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    rows++;
                    int currentCols = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
                    if (currentCols > cols)
                    {
                        cols = currentCols; // Запам'ятовуємо найбільшу довжину
                    }
                }
            }

            double[][] matrix = new double[rows][];

            using (StreamReader reader = new StreamReader("dat_2.txt"))
            {
                for (int i = 0; i < rows; i++)
                {
                    string line = reader.ReadLine();
                    string[] elements = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int count = elements.Length;
                    matrix[i] = new double[count];
                    for (int j = 0; j < count; j++)
                    {
                        if (int.TryParse(elements[j], out int number))
                        {
                            matrix[i][j] = number;
                        }
                        else
                        {
                            Console.WriteLine($"Помилка: '{elements[j]}' не число. Замінюємо його на 1.");
                            matrix[i][j] = 1;
                        }
                    }
                }
            }
            Console.WriteLine("Масив: ");
            Print_Matrix(matrix);
            double[] A = FlattenJaggedArray(matrix);
            x = Generasia_X(cols);
          Nowei_masiv(x, A);
        }
        // 1 2 3
        // 4 5 6 
        // 7 8 9
        //1 2 3 4 5 6 7 8 9 
        //об'єднуємо всі підмасиви в один набір елементів
        static double[] FlattenJaggedArray(double[][] matrix)
        {
            int totalLength = 0;
            //Рахуємо кол елементів
            for (int i = 0; i < matrix.Length; i++)
            {
                totalLength += matrix[i].Length;
            }
            double[] result = new double[totalLength];
            int index = 0;
            
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    result[index++] = matrix[i][j];
                }
            }
            return result;
        }
        public static double[] Generasia_X(int Colm)
        {
            double[] x = new double[Colm];
            for (int j = 0; j < x.Length; j++){ 

                 x[j] = rnd.Next(0,2); 
            }
            print_x(x);
            return x;

        }
        static void print_x(double[] x)
        {
            Console.WriteLine("Масив (х)");
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write($"{x[i],8:F2}");
            }
            Console.WriteLine();
        }
        public static void Nowei_masiv(double[] x, double[] A)
        {
            double max = double.MinValue;
            double min = double.MaxValue;
            double dobavlen = 0;
            int i = 0;
            while (i < x.Length && i < A.Length)
            {
                    if (x[i] == 1)
                    {
                        A[i] = A[i] * (7 / 10);
                    }
                    else
                    {
                        A[i] = A[i] * (-1.4);
                    }
                    if (A[i] > 0 && A[i] > max)
                    {
                        max = A[i];
                    }
                    if(A[i] <0 && A[i] <min)
                    {
                        min = A[i];
                    }
                    i++;


            }
            Console.WriteLine("Масив,який помножили на 7/10 або -10/7");
            Print_Masiv(A);
            if (max == double.MinValue)
            {
                Console.WriteLine("Немає додатних чисел");
                max = 0;
            }
            else
            {
                Console.WriteLine($"Найбільший серед додатних:{max,8:F2}");
            }
            if (min == double.MaxValue)
            {
                Console.WriteLine("Немає відємних чисел");
                min = 0;
            }
            else
            {
                Console.WriteLine($"Найменший серед відємних:{min,8:F2}");

            }
            dobavlen = max + min;
            for (int j = 0; j < A.Length; j++)
            {

                A[j] = A[j] + dobavlen;
               

            }
            Console.WriteLine("");
            Console.WriteLine($"Масив,який додали:{dobavlen,8:F2}");
            Print_Masiv(A);
           
        }
        static double[][] SortArray(double[][] A)
        {
            for (int i = 0; i < A.Length; i+=2) 
            {

                Array.Sort(A[i]);
                Console.WriteLine(); 
            }
            return A;
        }
        public static void Print_Masiv(double[] iArray)
        {
            for (int j = 0; j < iArray.Length; j++)
            {
                Console.Write($"{iArray[j],8:F2}"); 
                
            }
            Console.WriteLine(); 
        }
        static void Print_Matrix(double[][] iArray)
        {
            for (int j = 0; j < iArray.Length; j++)
            {
                for (int i = 0; i < iArray[j].Length; i++)
                {
                    Console.Write($"{iArray[j][i],8:F2}");
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void Task2() // (3+1+27)%30 = 1
        {
            int Row;
            int Colm;
            double[][] Array = null;
            double[] x = null;
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
                    Row = Convert.ToInt32(Console.ReadLine());
                    if (solution_dva == 1)
                    {
                        Colm = Row;
                    }
                    else if (solution_dva == 2)
                    {
                        Console.Write("Введіть розмір стовбчиків");
                       Colm = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.Write("Ви ввели не те число вихід із програми...");
                        return;
                    }
                    if(Row ==0 || Colm == 0)
                    {
                        Console.Write("Розмір масиву не може бути 0 ");
                        return;
                    }
                    Array = Claviatura_Dvoh(Row, Colm);
                    x= Generasia_X(Row);
                    break;
                case 2:
                    Text_file_Dvoh();
                    break;
                case 3:
                    Console.WriteLine("Введіть тип багатовимірного масиву (1-прямокутний чи 2-ступінчатий)");
                    Console.Write("Введіть число:");
                    solution_dva = Convert.ToByte(Console.ReadLine());
                    Console.Write("Введіть розмір масиву: ");
                    Row = Convert.ToInt32(Console.ReadLine());
                    if (solution_dva == 1)
                    {
                        Colm = Row;
                    }
                    else if (solution_dva == 2)
                    {
                        Console.Write("Введіть розмір стовбчиків");
                        Colm = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.Write("Ви ввели не те число вихід із програми...");
                        return;
                    }
                    if (Row == 0 || Colm == 0)
                    {
                        Console.Write("Розмір масиву не може бути 0 ");
                        return;
                    }
                    Array = Random_number_Dvoh(Row, Colm);
                    x=Generasia_X(Row);
                    break;
                default:
                    Console.WriteLine("Вихід із програми...");
                    return;
            }
            double[] A = FlattenJaggedArray(Array);
            Nowei_masiv(x, A);
            Array = SortArray(Array);
            Console.WriteLine("Масив який відсортували у порядок зростання: ");
            Print_Matrix(Array);

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
            Videm_element(Array);
            var element = Videm_element(Array);
            Console.WriteLine($"Сума від'ємних ={element.sum_otr}");
            Console.WriteLine($"Кількість від'ємних ={element.num_otr}");
            Console.WriteLine("Старий масив: ");
            Print_Array(Array);
            Console.WriteLine("Новий масив: ");
            Change_five(Array);
            Print_Array(Array);
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
                    Console.WriteLine("Error");
                    return;
            }
        }
    }
}
