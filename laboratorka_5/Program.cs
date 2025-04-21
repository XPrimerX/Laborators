

using laboratorka_5;

class Program
{
    static void Main()
    {
        // Варіант 10
        try
        {
            //Person manufacturer = new Person("Іван", "Бондарчук", new DateTime(1980, 5, 20));
            Detail engine = util_inform_detail.generateDetail();
            Detail wheel = util_inform_detail.generateDetail();
            Transport Transport = util_Transport.generateTransport();
            Console.WriteLine(Transport.ToShortString());
            Console.WriteLine("\tОновленнв інформація");
            Transport.AddDetails(engine, wheel);
            Console.WriteLine(Transport.ToString());
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
            Console.WriteLine(" Уведіть знову!");
        }
    
    }
}