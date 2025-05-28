
using Modul_3.Clasi;

class Program
{
    static void Main(string[] args)
    {
        // Створення об'єктів працівників
        var worker1 = new Worker("Іван Петренко", 35, 10, 22, "Шевченка", "ivan@gmail.com", "+380931234567", 5, "Одружений", 15000, "Інженер", new DateTime(1989, 5, 12));
        var worker2 = new Worker("Оксана Коваль", 25, 12, 45, "Грушевського", "oksana@gmail.com", "+380501234567", 0, "Неодружена", 12000, "Інженер", new DateTime(1999, 3, 25));
        var worker3 = new Worker("Петро Сидоренко", 40, 8, 33, "Соборна", "petro@gmail.com", "+380671234567", 15, "Одружений", 20000, "Інженер", new DateTime(1984, 10, 5));
        var worker4 = new Worker("Марина Шевчук", 30, 6, 28, "Франка", "marina@gmail.com", "+380931112233", 10, "Розлучена", 14000, "Бухгалтер", new DateTime(1994, 8, 18));
        var worker5 = new Worker("Ольга Шевченко", 35, 8, 27, "Франка", "marina@gmail.com", "+380931112233", 8, "Розлучена", 12000, "Інженер", new DateTime(1993, 8, 18));
        // Додавання до списку працівників
        Worker.AddWorker(worker1);
        Worker.AddWorker(worker2);
        Worker.AddWorker(worker3);
        Worker.AddWorker(worker4);
        Worker.AddWorker(worker5);

        // Встановлення директора
        Director.SetDirector(new Director("Директор Геннадій", 40, 18000, 5, "Інженер", new DateTime(1974, 1, 1)));

        // Виклик методів відбору
        Console.WriteLine("📌 Працівник з найбільшим стажем:");
        Console.WriteLine(Criteria_for_otbora.More_worke_age());

        Console.WriteLine("\n📌 Працівник без досвіду:");
        Console.WriteLine(Criteria_for_otbora.Without_worke_age());

        Console.WriteLine("\n📌 Найближча дата народження до директора:");
        Console.WriteLine(Criteria_for_otbora.DataMax_for_director());

        Console.WriteLine("\n📌 Парний будинок + непарна квартира:");
        Console.WriteLine(Criteria_for_otbora.Houses());

        Console.WriteLine("\n📌 Вибір 5 найкращих кандидатів:");
        Criteria_for_otbora.Print_five();



    }
}