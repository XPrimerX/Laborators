using Lb_7.Task_1;
using Lb_7.Task_2;
using Lb_7.Task_3.Interface;
using Lb_7.Task_3;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lb_7
{
    public class program
    {
        public static string CheckingForANumber()
        {
            while (true)
            {
                string arr = Console.ReadLine();


                if (Regex.IsMatch(arr, @"^[А-ЩЬЮЯЄІЇҐа-щьюяєіїґ\s]+$"))
                {
                    return arr;
                }
                else
                {
                    Console.WriteLine("Введене значення є числом.");
                    Console.WriteLine("Введіть відповідь повторно");
                    

                }
            }
        }
        public static void Task1()
        {
            Container container = new Container();

            // Створення кількох об'єктів Transport_from_lb5
            Transport_from_lb5 transport1 = util_Transport_from_lb5.generateTransport();
            Transport_from_lb5 transport2 = util_Transport_from_lb5.generateTransport();
            Transport_from_lb5 transport3 = util_Transport_from_lb5.generateTransport();

            // Додаємо об'єкти у контейнер
            container.Add(transport1);
            container.Add(transport2);
            container.Add(transport3);

            // Відсортувати об'єкти
            List<Transport_from_lb5> sortedList = new List<Transport_from_lb5>();
            foreach (Transport_from_lb5 t in container)
            {
                sortedList.Add(t);
            }
            sortedList.Sort();

            // Очистити контейнер і додати відсортовані об'єкти назад
            container = new Container();
            foreach (Transport_from_lb5 t in sortedList)
            {
                container.Add(t);
            }

            // Вивести вміст контейнера на екран
            Console.WriteLine("Відсортовані об'єкти:");
            foreach (Transport_from_lb5 t in container)
            {
                Console.WriteLine(t.ToShortString());
            }

            // Зберегти контейнер у файл
            container.Save("sorted_transports.txt");

            // Створити новий контейнер і скопіювати перші 2 або 3 елементи
            Container newContainer = new Container();
            int elementsToCopy = Math.Min(3, container.Count); // якщо є тільки 2 елементи — копіюємо 2
            for (int i = 0; i < elementsToCopy; i++)
            {
                newContainer.Add((Transport_from_lb5)container[i]);
            }

            // Вивести новий контейнер на екран
            Console.WriteLine("\nНовий контейнер (перші 2-3 елементи):");
            foreach (Transport_from_lb5 t in newContainer)
            {
                Console.WriteLine(t.ToShortString());
            }

            // Зберегти новий контейнер у файл
            newContainer.Save("new_transports.txt");
        }
        public static void Task2()
        {
            var registry = new Register();

            registry.AddDevice(util_Air.GetRandomTransporte());
            registry.AddDevice(util_Air.GetRandomTransporte());
            registry.AddDevice(util_Air.GetRandomTransporte());
            registry.AddDevice(util_Air.GetRandomTransporte());
            registry.AddDevice(util_Air.GetRandomTransporte());

            registry.DisplayAll();
            Console.WriteLine();

            registry.Havemotor();
            Console.WriteLine();

            registry.Nohavemotor();
            Console.WriteLine();

            Console.WriteLine("Сортування за іменем:");
            registry.SortByName();
            registry.DisplayAll();
        }
        public static void Task3()
        {
            ICipher aCipher = new ACiper();
            ICipher bCipher = new BCipher();

            string text = CheckingForANumber();

            Console.WriteLine("Оригінал: " + text);

            string encodedA = aCipher.encode(text);
            Console.WriteLine("ACipher закодовано: " + encodedA);
            Console.WriteLine("ACipher декодовано: " + aCipher.decode(encodedA));

            string encodedB = bCipher.encode(text);
            Console.WriteLine("BCipher закодовано: " + encodedB);
            Console.WriteLine("BCipher декодовано: " + bCipher.decode(encodedB));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть завдання від 1 до 3");
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
                case 3:
                    Task3();
                    break;
                default:
                    Console.WriteLine("Error");
                    return;
            }
        }



    }
}