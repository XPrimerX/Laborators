using Laboratorka_1.Task_1;
using Laboratorka_1.Task_2;
using Laboratorka_1.Task_3;
using Laboratorka_1.Task_4;
using System;
using System.Diagnostics.Tracing;
using System.Text;
using System.Text.Json;

class Program
{
    public static int Checking()
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
    public static List<Print_work> print_Works { get; set; } = new List<Print_work>();
    public static List<string> PrintLog { get; set; } = new List<string>();

    static async Task Task_1()
    {
        bool flag = true;
        string fileName = "date.json";
        List<Bus> buses = await Job_1.Deserilezid_by_json<Bus>(fileName);
        while (flag)
        {
            Console.WriteLine("\n--- Меню ---");
            Console.WriteLine("1. Додати інформацію");
            Console.WriteLine("2. Показати всю інформацію");
            Console.WriteLine("3. Редагувати інформацію");
            Console.WriteLine("4. Видалити інформацію");
            Console.WriteLine("5. Пошук");
            Console.WriteLine("6. Вийти");
            Console.Write("Напишіть число: ");

            int choice = Checking();

            switch (choice)
            {
                case 1:
                    await Job_1.Add(buses, fileName);
                    break;

                case 2:
                    await Job_1.Show(buses);
                    break;

                case 3:
                    await Job_1.Edit(buses, fileName);
                    break;

                case 4:
                    await Job_1.Delete(buses, fileName);
                    break;

                case 5:
                    await Job_1.FindAsync(buses);
                    break;

                case 6:
                    flag = false;
                    break;

                default:
                    Console.WriteLine("Невірне число. Введіть від 1 до 6.");
                    break;
            }
        }

        Console.WriteLine("Програма завершена.");
    }
    static async Task Task_2()
    {
        Console.Write("Введіть шлях до каталогу: ");
        string path = Console.ReadLine();

        List<string> files = Job_2.find_file(path);

        if (files.Count > 0)
        {
            while (true)
            {
                Console.Write("\nВведіть номер файлу для аналізу: ");
                int otvet = int.Parse(Console.ReadLine() ?? "-1");
                if (otvet >= 0 && otvet < files.Count)
                {
                    string selectedFile = files[otvet];
                    Dictionary<string, int> count = Job_2.rachunok_word(selectedFile);
                    Job_2.Satistic(count);
                    Console.Write("\nБажаєте обрати ще один файл? 1 - так 2 - ні: ");
                    int answer = int.Parse(Console.ReadLine() ?? "2");
                    if (answer == 2) break;
                }
                else
                {
                    Console.WriteLine("Невірний вибір!");

                }
            }
        }
        else
        {
            Console.WriteLine("Текстових файлів не знайдено.");
            return;
        }

    }
    static async Task Task_3()
    {

        List<Print_work> druk = new List<Print_work>();


        Job_3 printer = new Job_3();

        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1 - Додати завдання на друк");
            Console.WriteLine("2 - Запустити друк");
            Console.WriteLine("3 - Показати статистику");
            Console.WriteLine("0 - Вийти");

            Console.Write("Вибір: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    await Job_1.Add(druk, "Druk.json");
                    break;

                case "2":
                    await printer.Printing(druk);
                    break;

                case "3":
                    await printer.ShowStatsAsync();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
    static async Task Task_4()
    {
        Job_4 manager = new Job_4();
        Speak currentDict = null;

        while (true)
        {
            Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
            Console.WriteLine("1. Створити словник");
            Console.WriteLine("2. Вибрати словник для роботи");
            Console.WriteLine("3. Додати слово");
            Console.WriteLine("4. Замінити слово");
            Console.WriteLine("5. Замінити переклад");
            Console.WriteLine("6. Видалити слово");
            Console.WriteLine("7. Видалити переклад");
            Console.WriteLine("8. Пошук слова");
            Console.WriteLine("9. Експорт слова");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть назву словника: ");
                    string name = Console.ReadLine();
                    Console.Write("Мова оригіналу (from): ");
                    string fromLang = Console.ReadLine();
                    Console.Write("Мова перекладу (to): ");
                    string toLang = Console.ReadLine();
                    await manager.CreateDictionary(name, fromLang, toLang);
                    break;

                case "2": 
                    var allDicts = await Job_1.Deserilezid_by_json<Speak>("Dictionaries.json");
                    if (!allDicts.Any()) { Console.WriteLine("Словники відсутні."); break; }

                    Console.WriteLine("Доступні словники:");
                    for (int i = 0; i < allDicts.Count; i++)
                        Console.WriteLine($"{i + 1}. {allDicts[i].Name} ({allDicts[i].LanguageFrom} → {allDicts[i].LanguageTo})");

                    Console.Write("Введіть номер словника: ");
                    if (int.TryParse(Console.ReadLine(), out int dictIndex) &&
                        dictIndex >= 1 && dictIndex <= allDicts.Count)
                    {
                        currentDict = allDicts[dictIndex - 1];
                        Console.WriteLine($"Словник \"{currentDict.Name}\" обрано!");
                    }
                    else
                    {
                        Console.WriteLine("Невірний номер словника!");
                    }
                    break;

                case "3":
                    if (currentDict == null) { Console.WriteLine("Спочатку оберіть словник!"); break; }
                    Console.Write("Слово: ");
                    string word = Console.ReadLine();
                    Console.Write("Переклад: ");
                    string translation = Console.ReadLine();
                    await manager.AddWord(currentDict, word, translation);
                    break;

                case "4":
                    if (currentDict == null) { Console.WriteLine("Оберіть словник!"); break; }
                    Console.Write("Старе слово: ");
                    string oldWord = Console.ReadLine();
                    Console.Write("Нове слово: ");
                    string newWord = Console.ReadLine();
                    await manager.ReplaceWord(currentDict, oldWord, newWord);
                    break;

                case "5":
                    if (currentDict == null) { Console.WriteLine("Оберіть словник!"); break; }
                    Console.Write("Слово: ");
                    string wordForReplace = Console.ReadLine();
                    Console.Write("Старий переклад: ");
                    string oldTr = Console.ReadLine();
                    Console.Write("Новий переклад: ");
                    string newTr = Console.ReadLine();
                    await manager.ReplaceTranslation(currentDict, wordForReplace, oldTr, newTr);
                    break;

                case "6":
                    if (currentDict == null) { Console.WriteLine("Оберіть словник!"); break; }
                    Console.Write("Слово для видалення: ");
                    string delWord = Console.ReadLine();
                    await manager.DeleteWord(currentDict, delWord);
                    break;

                case "7":
                    if (currentDict == null) { Console.WriteLine("Оберіть словник!"); break; }
                    Console.Write("Слово: ");
                    string w = Console.ReadLine();
                    Console.Write("Переклад для видалення: ");
                    string delTr = Console.ReadLine();
                    await manager.DeleteTranslation(currentDict, w, delTr);
                    break;

                case "8":
                    if (currentDict == null) { Console.WriteLine("Оберіть словник!"); break; }
                    Console.Write("Слово для пошуку: ");
                    string searchWord = Console.ReadLine();
                    await manager.SearchWordAsync(currentDict, searchWord);
                    break;

                case "9":
                    if (currentDict == null) { Console.WriteLine("Оберіть словник!"); break; }
                    Console.Write("Слово для експорту: ");
                    string expWord = Console.ReadLine();
                    await manager.ExportWordAsync(currentDict, expWord);
                    break;

                case "0":
                    return;


                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }
        } 
    }
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool flag = true;
            Console.WriteLine("Виберіть завдання");
            Console.WriteLine("Завдання 1");
            Console.WriteLine("Завдання 2");
            Console.WriteLine("Завдання 3");
            Console.WriteLine("Завдання 4");
            Console.WriteLine("Вийти 5");
            Console.Write("Напишіть число: ");
            int task = Checking();
            while (flag)
            {
                switch (task)
                {

                    case 1:
                        await Task_1();
                        break;

                    case 2:
                        await Task_2();
                        break;

                    case 3:
                        await Task_3();
                        break;

                    case 4:
                        await Task_4();
                        break;
                    case 5:
                        flag = false;
                        break;


                    default:
                        Console.WriteLine("Невірне число. Введіть від 1 до 6.");
                        break;
                }


            }

        }
    
}


