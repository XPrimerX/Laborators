

namespace Laboratorka_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus[] buses = 
            {
                util_bus.generateBus(),
                util_bus.generateBus(),
                util_bus.generateBus(),
                util_bus.generateBus(),
                util_bus.generateBus(),
                util_bus.generateBus(),
                util_bus.generateBus()
            };
            Console.WriteLine("Серіалізація об'єктів в усі формати");
            Formate_serelizete_date.Formate_Byte_date(buses);
            Formate_serelizete_date.Serilezid_by_json(buses);
            Formate_serelizete_date.Serilezid_by_xml(buses);

            Console.WriteLine("\nДесеріалізовані об'єктів:");
            Formate_serelizete_date.Deserilezasia_byte_date();
            Formate_serelizete_date.Deserilezid_by_json();
            Formate_serelizete_date.Deserilezid_by_xml();

            Console.WriteLine("\nФільтровані автобуси:");
            Formate_serelizete_date.Print_for_criteria(buses);


        }
    }

}