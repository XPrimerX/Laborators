using laboratorka_9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_9
{
    class Function_menu_for_Task3
    {
        static Colection_song collection = new Colection_song();
        public static void AddSong()
        {
            var song = new Add_music();

            Console.Write("Назва пісні: ");
            song.Name_music = Console.ReadLine();

            Console.Write("Автор пісні (П.І.Б.): ");
            song.Name_songer = Console.ReadLine();

            Console.Write("Композитор: ");
            song.Komposito = Console.ReadLine();

            Console.Write("Рік написання: ");
            song.Year = int.Parse(Console.ReadLine());

            Console.Write("Текст пісні: ");
            song.Text = Console.ReadLine();

            Console.Write("Виконавці (через кому): ");
            string[] Kompositori= Console.ReadLine().Split(',');
            song.Mnogo_kompositorov.AddRange(Kompositori);

            collection.Add(song);
            string line = $"{song.Name_music}|{song.Name_songer}|{song.Komposito}|{song.Year}|{song.Text}|{string.Join(",", song.Mnogo_kompositorov)}";
            Manager_for_file.Save_file(line);
            Console.WriteLine("Пісня додана.");
        }


        public static void Save_Songs()
        {
            Console.WriteLine("Сохраняємо всі пісні");
            collection.Save_all_song();
            Console.WriteLine("Сохраняємо всі пісні");
        }
        public static void RemoveSong()
        {
            Console.Write("Введіть назву пісні для видалення: ");
            string name = Console.ReadLine();
            var found = collection.Find_By_Name(name);

            if (found.Count > 0)
            {
                for (int i = 0; i < found.Count; i++)
                {
                    Console.WriteLine($"{i}: {found[i]}");
                }
                Console.Write("Оберіть індекс для видалення: ");
                int index = int.Parse(Console.ReadLine());
                collection.Remove(found[index]);
                Console.WriteLine("Пісня видалена.");
            }
            else Console.WriteLine("Пісню не знайдено.");
        }

        public static void EditSong()
        {
            Console.Write("Введіть назву пісні для редагування: ");
            string name = Console.ReadLine();
            var found = collection.Find_By_Name(name);

            if (found.Count > 0)
            {
                for (int i = 0; i < found.Count; i++)
                {
                    Console.WriteLine($"{i}: {found[i]}");
                }

                Console.Write("Оберіть індекс для редагування: ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine("Введіть нову інформацію:");

                var newSong = new Add_music();

                Console.Write("Назва пісні: ");
                newSong.Name_music = Console.ReadLine();

                Console.Write("Автор пісні: ");
                newSong.Name_songer = Console.ReadLine();

                Console.Write("Композитор: ");
                newSong.Komposito = Console.ReadLine();

                Console.Write("Рік написання: ");
                newSong.Year = int.Parse(Console.ReadLine());

                Console.Write("Текст пісні: ");
                newSong.Text = Console.ReadLine();

                Console.Write("Виконавці (через кому): ");
                var Kompositori = Console.ReadLine().Split(',');
                newSong.Mnogo_kompositorov.AddRange(Kompositori);

                int realIndex = collection.Find_By_Name(name).IndexOf(found[index]);
                collection.EditSong(realIndex, newSong);
                Console.WriteLine("Пісню оновлено.");
            }
            else Console.WriteLine("Пісню не знайдено.");
        }
        public static void Vivang_in_file()
        {
            Console.Write("Введіть шлях до файлу: ");
            string path = Console.ReadLine();
            collection.Read_file(path);
            Console.WriteLine("Завантажено.");
        }

        public static void Show_songs()
        {
            Console.Write("Введіть виконавця: ");
            string Kompositori = Console.ReadLine();
            var songs_By_Kompositori = collection.Find_song(Kompositori);
            foreach (var song in songs_By_Kompositori)
                Console.WriteLine(song);
        }
        public static void SearchSongs()
        {
            Console.WriteLine("Пошук за:");
            Console.WriteLine("1. Назвою");
            Console.WriteLine("2. Автором");
            Console.WriteLine("3. Композитором");
            Console.WriteLine("4. Роком");
            Console.WriteLine("5. Текстом");
            Console.Write("Оберіть опцію: ");
            List<Add_music> result = new List<Add_music>();

            switch (Program.Checking())
            {
                case 1:
                    Console.Write("Назва: ");
                    result = collection.Find_By_Name(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Автор: ");
                    result = collection.Find_BY_Avtor(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Композитор: ");
                    result = collection.Find_BY_Compositor(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Рік: ");
                    result = collection.Find_By_Year(int.Parse(Console.ReadLine()));
                    break;
                case 5:
                    Console.Write("Фрагмент тексту: ");
                    result = collection.Find_By_Text(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Невірна опція.");
                    return;
            }

            if (result.Count == 0)
                Console.WriteLine("Нічого не знайдено.");
            else
                foreach (var song in result)
                    Console.WriteLine(song);
        }
    }
}
