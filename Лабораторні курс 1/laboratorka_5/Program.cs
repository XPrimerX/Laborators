

using laboratorka_5;

class Program
{
    static void Main()
    {
        // Варіант 10
        Detail engine = null;
        Detail wheel = null;
        Transport Transport = null;

        try
         {
            engine = util_inform_detail.generateDetail();
            wheel = util_inform_detail.generateDetail();
         }
         catch (Exception exc)
         {
                Console.WriteLine(exc.Message);

         }
        try
        {
            Transport = util_Transport.generateTransport();
            Console.WriteLine(Transport.ToShortString());
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);

        }
        try
        {
            if (Transport != null && engine != null && wheel != null)
            {
                Console.WriteLine("\tОновлена інформація");
                Transport.AddDetails(engine, wheel);
                Console.WriteLine(Transport.ToString());
            }
            else
            {
                Console.WriteLine("Не вдалося оновити інформацію через відсутні дані.");
            }
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);

        }



    }
}