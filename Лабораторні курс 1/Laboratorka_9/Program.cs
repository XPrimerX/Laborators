
using Laboratorka_9;
using System.Text;

namespace laboratorka_9
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

        static void Task1()
        {
            string text;
            Console.Write("Напишіть шлях до файлу: ");
            string dirName = Console.ReadLine();
            Console.WriteLine("У вас вже створений файл?");
            Console.WriteLine("1-Створити файл\n2-Створений файл\n");
            if (Checking() == 1)
            {
                Console.Write("Напишіть текст який бажаєте додати: ");
                text = Console.ReadLine();
                Manager_for_file.Create_file(dirName, text);

            }
            if (!File.Exists(dirName))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }
            Manager_for_file.find_file(dirName);
            Work_for_text.Read_file_and_find_something(dirName);


        }

        static void Task2()
        {
            string text = null;
            Console.WriteLine("Це додаток Цензор: ");
            Console.WriteLine("Напишіть шлях до першого файлу: ");
            string dirName_1 = Console.ReadLine();
            Console.Write("Введіть шлях до файлу зі словами для цензури: ");
            string dirName_2 = Console.ReadLine();
            Console.WriteLine("У вас вже створені ці файли?");
            Console.WriteLine("1-Створити файли\n2-Створені файли\n");
            if (Checking() == 1)
            {
                Console.Write("Напишіть текст який бажаєте додати до першого файлу: ");
                text = Console.ReadLine();
                Manager_for_file.Create_file(dirName_1, text);
                Console.Write("Напишіть текст який бажаєте додати до другого файлу: ");
                text = Console.ReadLine();
                Manager_for_file.Create_file(dirName_2, text);

            }
            if (!File.Exists(dirName_1) || !File.Exists(dirName_2))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }
            //Console.WriteLine("Директорія першого Файлу: ");
            //Evrything_for_file.find_file(dirName_1);
            //Console.WriteLine("Директорія другого Файлу: ");
            //Evrything_for_file.find_file(dirName_2);
            Console.WriteLine("Що ви бажаєте зробити із небажаними словами?");
            Console.WriteLine("1-Видалити\n2-Засекретити\n");
            if (Checking() == 1)
            {
               text= Work_for_text.delete_wrong_word(dirName_1, dirName_2);

            }
            else if (Checking() == 2) 
            {
                text = Work_for_text.Secret_word(dirName_1, dirName_2);
            }
            Manager_for_file.Save_file(text);

        }

        static void Task3() 
        {
           
            Console.WriteLine("1. Додати пісню");
            Console.WriteLine("2. Видалити пісню");
            Console.WriteLine("3. Редагувати пісню");
            Console.WriteLine("4. Пошук пісень");
            Console.WriteLine("5. Зберегти колекцію у файл");
            Console.WriteLine("6. Завантажити пісні з файлу");
            Console.WriteLine("7. Вивести пісні за виконавцем");
            Console.WriteLine("0. Вийти");
            switch (Checking())
            {
                case 1:
                    Function_menu_for_Task3.AddSong();
                    break;
                case 2:
                    Function_menu_for_Task3.RemoveSong();
                    break;
                case 3:
                    Function_menu_for_Task3.EditSong();
                    break;
                case 4:
                    Function_menu_for_Task3.SearchSongs();
                    break;
                case 5:
                    Function_menu_for_Task3.Save_Songs();
                    break;
                case 6:
                    Function_menu_for_Task3.Vivang_in_file();
                    break;
                case 7:
                    Function_menu_for_Task3.Show_songs();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Невірна опція.");
                    break;
            }

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
