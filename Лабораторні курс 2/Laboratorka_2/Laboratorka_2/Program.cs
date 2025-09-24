using Laboratorka_2.Task_1;
using Laboratorka_2.Task_2;
using Laboratorka_2.Task_3.Class;
using System.Text;

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
    static void Task_3()
    {
        Company company = new Company { Name = "TechCorp" };
        company.Employers = Util_employeer.GenerateEmployers(15);
        Console.WriteLine("Уся інформація про працівників");
        foreach (var e in company.Employers)
            Console.WriteLine(e);
        var workerCount = (from w in company.Employers
                           where w is Worker
                           select w).Count();
        Console.WriteLine($"\nКількість робітників: {workerCount}");
        var totalSalary = (from e in company.Employers
                           select e.Salary).Sum();
        Console.WriteLine($"Загальний фонд заробітної платні: {totalSalary}$");
        var top10ByExp = (from w in company.Employers
                          where w is Worker && w.LevelofEducation == "Higher"
                          orderby w.Opit descending
                          select w).Take(10);
        var youngTop10 = (from w in top10ByExp
                             orderby w.BirthDate descending
                             select w).FirstOrDefault();
        Console.WriteLine("\nНаймолодший з топ-10 за стажем (з вищою освітою):");
        Console.WriteLine(youngTop10);
        var managers = from m in company.Employers
                       where m is Manager
                       select m;
        var youngManager = (from m in managers
                               orderby m.BirthDate descending
                               select m).FirstOrDefault();

        var oldManager = (from m in managers
                             orderby m.BirthDate ascending
                             select m).FirstOrDefault();
        Console.WriteLine("\nНаймолодший менеджер:");
        Console.WriteLine(youngManager);
        Console.WriteLine("Найстарший менеджер:");
        Console.WriteLine(oldManager);
        var octoberWorkers = from e in company.Employers
                             where e.BirthDate.Month == 10
                             select e;

        Console.WriteLine("Працівники, народжені у жовтні:");
        foreach (var w in octoberWorkers)
            Console.WriteLine(w);
        var volodymyrs = from e in company.Employers
                         where e.FirstName == "Володимир"
                         select e;

        Console.WriteLine("Усі Володимири на підприємстві:");
        foreach (var v in volodymyrs)
            Console.WriteLine(v);
        var youngVolodymyr = (from v in volodymyrs
                                 orderby v.BirthDate descending
                                 select v).FirstOrDefault();

        if (youngVolodymyr != null)
        {
            var bonus = youngVolodymyr.Salary / 3;
            Console.WriteLine($"Вітаємо {youngVolodymyr.FirstName} з премією {bonus}$!");
        }


    }
    static void Task_2()
    {
        var phones = Util_phone.GeneratePhones(10);
        Console.WriteLine("Вся інформація про телефони: ");
        foreach (var item in phones)
        {
            Console.WriteLine(item.ToString());
        }
        int count = 0;
        int count_more = 0;
        int count_400_700 = 0;
        int countFirm = 0;
        foreach (var phone in phones)
        {
            count++;
            if (phone.Price > 100) count_more++;
            if(phone.Price > 400 && phone.Price < 700) count_400_700++;
            if(phone.Firms == "Apple") countFirm ++;
        }
        var minPrice = (from p in phones select p.Price).Min();
        var minPricePhones = from p in phones where p.Price == minPrice select p;

        var maxPrice = (from p in phones select p.Price ).Max();
        var maxPricePhones = from p in phones where p.Price == maxPrice select p;
        
        var minDate =(from p in phones select p.Date).Min();
        var maxDate = (from p in phones select p.Date).Max();

        var minDatePhones = from p in phones where p.Date == minDate select p;
        var maxDatePhones = from p in phones where p.Date == maxDate select p;

        var avgPrice = (from p in phones select p.Price).Average();

        var top5Exp = (from p in phones orderby p.Price descending select p).Take(5);
        var top5UnExp = (from p in phones orderby p.Price ascending select p).Take(5);

        var top3Old = (from p in phones orderby p.Date ascending select p).Take(3);
        
        var top3Jungl =(from p in phones orderby p.Date descending select p).Take(3);

        var firmStats = from p in phones group p by p.Firms into g select new { Firm = g.Key, Count = g.Count() };
        var modelStats = from p in phones group p by p.Name into g select new { Name = g.Key, Count = g.Count() };
        var dateStats = from p in phones group p by p.Date.Year into g select new { Date = g.Key,Count = g.Count() };
        Console.WriteLine($"\nКількість телефонів: {count}");
        Console.WriteLine($"\nКількість телефонів із ціною більше 100:{count_more} ");
        Console.WriteLine($"\nКількість телефонів із ціною в діапазоні від 400 до 700:{count_400_700} ");
        Console.WriteLine($"\nКількість телефонів Apple:{countFirm} ");
        Console.WriteLine("Телефон   з мінімальною ціною:");
        foreach (var phone in minPricePhones)
            Console.WriteLine(phone);
        Console.WriteLine("Телефон з максимальною ціною:");
        foreach (var phone in maxPricePhones)
            Console.WriteLine(phone);
        Console.WriteLine("Найстаріший телефонb:");
        foreach (var p in minDatePhones)
            Console.WriteLine(p);
        Console.WriteLine("Найсвіжіший телефон:");
        foreach (var p in maxDatePhones)
            Console.WriteLine(p);
        Console.WriteLine($"Середня ціна: {avgPrice} $");
        Console.WriteLine("5 найдорожчих телефонів:");
        foreach (var phone in top5Exp)
            Console.WriteLine(phone);
        Console.WriteLine("5 найдешевших телефонів:");
        foreach (var phone in top5UnExp)
            Console.WriteLine(phone);
        Console.WriteLine("3 найстаріші телефони:");
        foreach (var phone in top3Old)
            Console.WriteLine(phone);
        Console.WriteLine("3 найновіші телефони:");
        foreach (var phone in top3Jungl)
            Console.WriteLine(phone);
        Console.WriteLine("Статистика по фірмам:");
        foreach (var f in firmStats)
        {
            Console.WriteLine($"{f.Firm} – {f.Count}");
        }
        Console.WriteLine("Статистика по моделям:");
        foreach (var f in modelStats)
        {
            Console.WriteLine($"{f.Name} – {f.Count}");
        }
        Console.WriteLine("Статистика по рокам:");
        foreach (var f in dateStats)
        {
            Console.WriteLine($"{f.Date} – {f.Count}");
        }
    }
    static void Task_1()
    {

        var firms = Util_firma.GenerateFirms(10);

        Console.WriteLine("Вся інформація про фірми: ");
        foreach (var item in firms)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Фірми з назвою Food:");
        //LINQ method syntax
        //Це повертає конкретне поле (string, int и т.д.)
        var Food = firms.Where(f => f.Profile == "Food");

        //LINQ query syntax
        //Це повертає обєкт целиком Firm
        var Foods = from f in firms where f.Profile == "Food" select f;
        foreach (var item in Food)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Працюють у галузі маркетингу:");
        var Marketing = from m in firms where m.Profile == "Marketing" select m;
        foreach (var item in Marketing)
        {
            Console.WriteLine(item.ToString());
        }
        var Marketing_or_IT = from m in firms where m.Profile == "Marketing" || m.Profile == "IT" select m;
        Console.WriteLine("Працюють у галузі маркетингу або IT:");
        foreach (var item in Marketing_or_IT)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Кількість співробітників більше 100:");
        var More_100 = from e in firms where e.Employeers >100 select e;
        foreach (var item in More_100) 
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Кількістю співробітників у діапазоні від 100 до 300:");
        var More_100_300 = from e in firms where e.Employeers >= 100 && e.Employeers <= 300 select e;
        foreach (var item in More_100_300)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Фірми, що знаходяться у Лондоні:");
        var London = from l in firms where l.Adrees == "Лондон" select l;
        foreach (var item in London)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Фірми, які мають прізвище директора White:");
        var White = from w in firms where w.Pid_derector.Split(' ').Last() == "White" select w;
        foreach (var item in White)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Фірми, які засновані понад два роки тому:");
        var More_two_years = from m in firms where (DateTime.Now - m.Date).TotalDays > 365 * 2 select m;
        foreach (var item in More_two_years)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Фірми, з дня заснування яких минуло більше 150 днів:");
        var More_150_days = from m in firms where (DateTime.Now - m.Date).TotalDays > 150 select m;
        foreach (var item in More_150_days)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Фірми, у яких прізвище директора Black та назва фірми містить слово White:");
        var Black_White = from b in firms where b.Pid_derector.Split(' ').Last() == "Black" && b.Name =="White" select b;
        foreach (var item in Black_White)
        {
            Console.WriteLine(item.ToString());
        }
    }
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        bool flag = true;

        while (flag)
        {
            Console.WriteLine("\nВиберіть завдання:");
            Console.WriteLine("1. Завдання 1");
            Console.WriteLine("2. Завдання 2");
            Console.WriteLine("3. Завдання 3");
            Console.WriteLine("4. Вийти");
            Console.Write("Напишіть число: ");

            int task = Checking();

            switch (task)
            {
                case 1:
                    Task_1();
                    break;

                case 2:
                    Task_2();
                    break;

                case 3:
                    Console.WriteLine("Завдання 3 ще не реалізоване");
                    break;

                case 4:
                    flag = false;
                    break;

                default:
                    Console.WriteLine("Невірне число. Введіть від 1 до 4.");
                    break;
            }
        }
    }


}

