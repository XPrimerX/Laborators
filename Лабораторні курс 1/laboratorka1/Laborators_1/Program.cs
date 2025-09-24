namespace laboratorka1
{
    internal class Program 
    {
 
        public static void Task4()
        {
            float AB = 0, BC = 0, kg = 0, palevo = 0, AB_palevo_nado = 0, BC_palevo_nado = 0, dozap = 0,trata_km = 0;
            Console.WriteLine("This is a mini program that calculates whether the plane will fly from point A to C.");
            Console.WriteLine("Press Enter for continuum...");
            Console.ReadKey();
            Console.WriteLine("Write the name of the file.");
            string txt = Console.ReadLine();
            if (!File.Exists($"{txt}.txt"))
            {
                
                Console.WriteLine("File dont find.Plesea,create file...");
                return;

            }
            using (StreamReader f = new StreamReader($"{txt}.txt"))
            {

                string data = f.ReadLine();
                string[] parts = data.Split(',');
                if (parts.Length < 4)
                {
                    Console.WriteLine("Error: There is not enough data in the file!");
                    return;
                }
                AB = float.Parse(parts[0]);
                BC = float.Parse(parts[1]);
                kg = float.Parse(parts[2]);
                palevo = float.Parse(parts[3]);
            }

            if (kg <= 500) trata_km = 1;
            else if (kg <= 1000) trata_km = 4;
            else if (kg <= 1500) trata_km = 7;
            else if (kg <= 2000) trata_km = 9;
            else
            {
                Console.WriteLine($"We have {palevo} liters, but the plane cannot take off with this weight.");
                return;
            }
            Console.WriteLine($"We have {palevo} liters. Fuel consumption is {trata_km} liters/km.");
            AB_palevo_nado = trata_km * AB;
            Console.WriteLine($"AB requires fuel: {AB_palevo_nado}");
            BC_palevo_nado = trata_km * BC;
            Console.WriteLine($"BC requires fuel: {BC_palevo_nado}");
            if (palevo < AB_palevo_nado && palevo<BC_palevo_nado)
            {
                Console.WriteLine($"It is not possible to fly on this route, because we do not have enough fuel: {AB_palevo_nado - palevo} liters.");
                return;
            }
 
            dozap = palevo - (AB_palevo_nado + BC_palevo_nado);
            if (dozap < 0)
            {
                Console.WriteLine($"You need to refuel at point B: {Math.Abs(dozap)} fuel");
            }
            else
            {
                Console.WriteLine("No refueling is needed.You can reach point C");
            }




        }


        // провірка на число,для завдання 3 i 4
        public static byte Checking()
        {
            while (true)
            {
                string arr = Console.ReadLine();

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


        public static void Task3()
        {
            byte ball = 0;
            Console.WriteLine("Check your options");
            Console.WriteLine("Points will be awarded for each correct answer");
            Console.WriteLine("Press Enter for continuum...");
            Console.ReadKey();

            Console.WriteLine("The professor went to bed at 8 o'clock and got up at 9 o'clock. How many hours did the professor sleep?");
            if (Checking() == 1) { ball++; }

            Console.WriteLine("Ten fingers on two hands. How many fingers in 10?");
            if (Checking() == 50) { ball++; }

            Console.WriteLine("How many numbers are there in a dozen?");
            if (Checking() == 2) { ball++; }

            Console.WriteLine("How many cuts do you need to cut a log into 12 parts?");
            if (Checking() == 11) { ball++; }

            Console.WriteLine("The doctor gave three injections at an interval of 30 minutes. How much time did he spend?");
            if (Checking() == 30) { ball++; }

            Console.WriteLine("How many digits 9 in the interval 1100?");
            if (Checking() == 1) { ball++; }

            Console.WriteLine("The shepherd had 30 sheep. All but one ran away. How many sheep are left?");
            if (Checking() == 1) { ball++; }

            switch (ball)
            {
                case 3:
                    Console.WriteLine("Below average abilities.");
               
                    break;
                case 4:
                    Console.WriteLine("Abilities are average.");
              
                    break;
                case 5:
                    Console.WriteLine("Normal");
          
                    break;
                case 6:
                    Console.WriteLine("Erudite.");
                 
                    break;
                case 7:
                    Console.WriteLine("Genius.");
              
                    break;
                default:
                    Console.WriteLine("You need to rest!");
               
                    break;
            }
            Console.WriteLine($"You have scored {ball} points.");
        }
        public static void Task2()
        {   //29
            double y;
            string txt = "LAB2.txt";
            string txt2 = "RES.txt";
            string name = "Шпак Антон";
            double xmin = 0, xmax = 0;
            int n = 0;

            if (!File.Exists(txt))
            {
                Console.WriteLine("File dont find. Plesea,create file...");
                return;

            }
            try
            {
                using (StreamReader f = new StreamReader(txt))
                {

                    string data = f.ReadLine();
                    string[] parts = data.Split(',');
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Error: There is not enough data in the file!");
                        return;
                    }
                    xmin = double.Parse(parts[0]); // замість масиву можна використовувати ReadLine але треба у файлі змінити подачу даних(Кожне число з нового рядка)
                    xmax = double.Parse(parts[1]);
                    n = int.Parse(parts[2]);

                    if (n < 2)
                    {
                        Console.WriteLine("Error: n must be at least 2.");
                        return;
                    }
                    

                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return;
            }


            if (!File.Exists(txt2))
            {
                Console.WriteLine("File dont find. Plesea,create file...");
                return;

            }
            try
            {
                using (StreamWriter f2 = new StreamWriter(txt2))
                {
                    f2.WriteLine("I----------------------------------------I");
                    f2.WriteLine("I       Х          I  Function Task2     I");
                    f2.WriteLine("I----------------------------------------I");
                    double step = Math.Abs(xmax - xmin) / (n - 1);
                    for (int i = 0; i < n; i++)
                    {
                        double x = xmin + i * step;
                        y = ((2 * x) - (5 * Math.Pow(Math.Abs(x), 2.0 / 3.0)));
                        f2.WriteLine($"I  X={x,6:F3}    I  Y={y,10:F3}           I");
                    }
                    f2.WriteLine("I----------------------------------------I");
                    f2.WriteLine($"Form a table {name}");
                }
                Console.WriteLine("The source finish");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }


        public static double Task1(double x, double y,double z)
        {
            if (Math.Abs(x + y) < 1e-7)
            {
                Console.WriteLine("Error: Division by zero.");
                return throw new Exception("Errror NAN number!!!!!!");//double.NaN; // Повертаємо "не число"
            }
            double part1,part2,part3,b;
            double e = 2.718;
            part1 = (Math.Pow(y, Math.Cbrt(Math.Abs(x))) + Math.Pow(Math.Cos(y),3));
            part2 = (Math.Abs(x - y) * (1+ (Math.Pow(Math.Sin(z),2)/Math.Sqrt(x+y))));
            part3 = (Math.Pow(e, Math.Abs(x - y)) + x / 2);
            if (Math.Abs(part3) < 1e-7)
            {
                Console.WriteLine("Error: Division by zero in the denominator.");
                return double.NaN;
            }
            b = part1 * (part2 / part3);
            return b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Choose tasks from 1 to 4");
            Console.Write("Write number:");
            byte solution = Convert.ToByte(Console.ReadLine());

            switch (solution)
            {
                case 1:
                    {
                        Console.WriteLine("Example 11");
                        Console.WriteLine("Write x:");
                        double x = double.TryParse(Console.ReadLine(), out double result1) ? result1 : 1;
                        Console.WriteLine("Write y:");
                        double y = double.TryParse(Console.ReadLine(), out double result2) ? result2 : 1;
                        Console.WriteLine("Write z:");
                        double z = double.TryParse(Console.ReadLine(), out double result3) ? result3 : 1;
                        try
                        {
                            Console.WriteLine($"Answer:{Task1(x, y, z)}");
                        }catch(Exception ex)
                        {
                            Console.Write(ex.ToString());
                        }
                        break;
                    }
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                default:
                    Console.WriteLine("Error");
                    return;
            }


        }
    }
}
