using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_1
{
    public class Job_1
    {

        public static async Task Serilezid_by_json<T>(List<T> list, string name_file)
        {

            using (FileStream fs = new FileStream(name_file, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, list, new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true 
                });
                Console.WriteLine($"Обєкт серіалізовано до файлу {name_file}");
            }
        }
        public static async Task<List<T>> Deserilezid_by_json<T>(string name_file)
        {
           
            if (!File.Exists(name_file))
            {
                Console.WriteLine("Створіть файл і спробуйте знову");
            }


            using (FileStream fs = new FileStream(name_file, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    return await JsonSerializer.DeserializeAsync<List<T>>(fs, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                catch
                {
                    Console.WriteLine("Помилка при десеріалізації. Файл можливо пошкоджений або порожній.");
                    return new List<T>();
                }
            }
        }
        static PropertyInfo Vibor_values<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список порожній.");
                return null;
            }
            // Отримуємо всі публічні і приватні властивості класу T на основі Reflection
            var vlastivosti = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Доступні поля для фільтрації:");
            for (int i = 0; i < vlastivosti.Length; i++)
            {
                Console.WriteLine($"{i} - {vlastivosti[i].Name}");
            }
            Console.Write("Виберіть поле: ");
            int pole = int.Parse(Console.ReadLine() ?? "-1");
            if (pole < 0 || pole >= vlastivosti.Length)
            {
                Console.WriteLine("Невірний вибір");
                return null;
            }
            return vlastivosti[pole];
        }
        public static async Task Add<T>(List<T> list, string fileName)
        {
            //Створюємо такийже тип обєкта 
            var obj = (T?)Activator.CreateInstance(typeof(T));
            var vlastivosti = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in vlastivosti)
            {
                //Провіряємо чи властивість має set
                if (!item.CanWrite) continue;
                Console.Write($"Введіть значення для {item.Name}: ");
                string? value = Console.ReadLine();
                if (value == null) return;
                try
                {
                    if (item.PropertyType == typeof(DateTime))
                    {
                        if (DateTime.TryParse(value, out DateTime dt))
                            item.SetValue(obj, dt);
                        else
                            item.SetValue(obj, DateTime.Now); 
                    }
                    else
                    {
                        var conver = Convert.ChangeType(value, item.PropertyType);
                        item.SetValue(obj, conver);
                    }
                }
                catch
                {
                    Console.WriteLine($"Не вдалося встановити {item.Name}, залишаю значення за замовчуванням.");
                }

            }
            list.Add(obj);
            Console.WriteLine($"{typeof(T).Name} додано!");
            await Serilezid_by_json(list, fileName);

        }
        public static async Task Show<T>(List<T> list)
        {

            if (list.Count == 0)
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            // Отримуємо всі публічні і приватні властивості класу T на основі Reflection
            var vlastivosti = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine($"\nСписок {typeof(T).Name}:");
            foreach (var item in list)
            {
                //перетворюємо кожен елемента колекції у нову форму та виводемо
                var values = vlastivosti.Select(p => $"{p.Name}={p.GetValue(item)}");
                Console.WriteLine(string.Join(", ", values));
            }

            await Task.CompletedTask;

        }
        public static async Task Edit<T>(List<T> list, string fileName)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            // Отримуємо всі публічні і приватні властивості класу T на основі Reflection
            var vlastivosti = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Доступні поля для фільтрації:");
            for (int i = 0; i < vlastivosti.Length; i++)
            {
                Console.WriteLine($"{i} - {vlastivosti[i].Name}");
            }
            Console.Write("Виберіть поле: ");
            int pole = int.Parse(Console.ReadLine() ?? "-1");
            if (pole < 0 || pole >= vlastivosti.Length)
            {
                Console.WriteLine("Невірний вибір");
                return;
            }
            var vibor = vlastivosti[pole];
            if (vibor == null) return;
            Console.Write($"Введіть значення для {vibor.Name}: ");
            string value = Console.ReadLine();
            if (value == null)
            {
                Console.WriteLine("Значення не може бути порожнім.");
                return;
            }
            object searchValue;

            if (vibor.PropertyType == typeof(string))
            {
                searchValue = value; 
            }
            else if (vibor.PropertyType == typeof(int))
            {
                if (!int.TryParse(value, out int intVal))
                {
                    Console.WriteLine("Невірне число!");
                    return;
                }
                searchValue = intVal;
            }
            else if (vibor.PropertyType == typeof(float))
            {
                if (!float.TryParse(value, out float intVal))
                {
                    Console.WriteLine("Невірне число!");
                    return;
                }
                searchValue = intVal;
            }
            else if (vibor.PropertyType == typeof(double))
            {
                if (!double.TryParse(value, out double doubleVal))
                {
                    Console.WriteLine("Невірне число!");
                    return;
                }
                searchValue = doubleVal;
            }
            else
            {
                Console.WriteLine("Тип даних не підтримується!");
                return;
            }

            var result = list.FirstOrDefault(item =>
            {
                var propValue = vibor.GetValue(item);
                if (propValue == null) return false;
                return propValue.Equals(searchValue);
            });

            if (result != null)
            {
                Console.WriteLine("Редагування об'єкта:");
                foreach (var ele in vlastivosti)
                {
                    Console.Write($"{ele.Name} (Enter — залишити старе): ");
                    string? otvet = Console.ReadLine();
                    if (otvet == null)
                    {
                        Console.WriteLine("Залишаємо старе");
                        continue;
                    }
                    try
                    {
                        var convertedValue = Convert.ChangeType(otvet, ele.PropertyType);
                        ele.SetValue(result, convertedValue);

                    }
                    catch
                    {
                        Console.WriteLine($"Неможливо встановити значення для {ele.Name}, пропускаємо...");
                    }
                }
            }
            else
            {
                Console.WriteLine("Не знайдено");
            }
            await Serilezid_by_json(list, fileName);
            Console.WriteLine("Об'єкт змінено!");

        }
        public static async Task Delete<T>(List<T> list, string fileName)
        {

            var vibor = Vibor_values(list);
            if (vibor == null) return;
            Console.Write($"Введіть значення для {vibor.Name}: ");
            string? value = Console.ReadLine();
            if (value == null)
            {
                Console.WriteLine("Значення не може бути порожнім.");
                return;
            }
            // Використовуємо LINQ для фільтрації
            var result = list.FirstOrDefault(item =>
            {
                var Value = vibor.GetValue(item);
                if (Value == null) return false;

                // Якщо властивість число пробуємо порівняти як число
                if (Value is IComparable comparable)
                {
                    // Якщо тип string  шукаємо частковий збіг
                    if (Value is string strVal)
                    {
                        return strVal.Contains(value, StringComparison.OrdinalIgnoreCase);
                    }

                    // Якщо це число конвертуємо введене значення
                    try
                    {
                        var convertedValue = Convert.ChangeType(value, Value.GetType());
                        return Value.Equals(convertedValue);
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            });
            if (result != null)
            {
                list.Remove(result);
                Console.WriteLine("Елемент видалено");
                await Serilezid_by_json(list, fileName);
            }
            else
            {
                Console.WriteLine("Не знайдено");
            }
        }

        public static async Task FindAsync<T>(List<T> list)
        {
            var vibor = Vibor_values(list);
            if (vibor == null) return;
            Console.Write($"Введіть значення для {vibor.Name}: ");
            string? value = Console.ReadLine();
            if (value == null)
            {
                Console.WriteLine("Значення не може бути порожнім.");
                return;
            }
            // Використовуємо LINQ для фільтрації
            var result = list.Where(item =>
            {
                object? Value = vibor.GetValue(item);
                if (Value == null) return false;

                // Якщо властивість число пробуємо порівняти як число
                if (Value is IComparable comparable)
                {
                    // Якщо тип string  шукаємо частковий збіг
                    if (Value is string strVal)
                    {
                        return strVal.Contains(value, StringComparison.OrdinalIgnoreCase);
                    }

                    // Якщо це число конвертуємо введене значення
                    try
                    {
                        var convertedValue = Convert.ChangeType(value, Value.GetType());
                        return comparable.CompareTo(convertedValue) == 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            }).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("Нічого не знайдено.");
            }
            else
            {
                Console.WriteLine("\nРезультати фільтрації:");
                foreach (var item in result)
                {
                    //перетворюємо кожен елемента колекції у нову форму та виводемо
                    var values = typeof(T).GetProperties().Select(p => $"{p.Name}={p.GetValue(item)}");
                    Console.WriteLine(string.Join(", ", values));
                }
                await Serilezid_by_json(result, "find_result.json");
            }
        }

    }
}

