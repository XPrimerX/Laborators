using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3.Clasi
{
    class Criteria_for_otbora
    {
        private static List<Worker> workers = new List<Worker>();
        private static Director director = new Director();
        public static Worker More_worke_age()
        {
            return workers.Where(find => find.Posada.Equals(director.Posada, StringComparison.OrdinalIgnoreCase) 
             && find.Money <= director.Money).MaxBy(find => find.Age_work);
           
        }
        public static Worker Without_worke_age()
        {
            return workers.FirstOrDefault(find => find.Posada.Equals(director.Posada, StringComparison.OrdinalIgnoreCase) 
            && find.Money <= director.Money 
            && find.Age_work == 0);
            
        }
        public static Worker DataMax_for_director()
        {
            return workers.OrderBy(worker => Math.Abs((worker.Date - director.Date).TotalDays)).FirstOrDefault();
            
        }
        public static Worker Houses()
        {
            return workers.FirstOrDefault(find => find.adress_bilding % 2 == 0
             && find.adress_apartament % 2 != 0
             && find.Money <= director.Money
             );
           
        }
        public static Worker Kogo_zahotele()
        {
            string pi = Console.ReadLine();
            return workers.FirstOrDefault(find => find.PI.Equals(pi, StringComparison.OrdinalIgnoreCase));
          
        }
        public static void AddWorker(Worker w) => workers.Add(w);
        public static void SetDirector(Director d) => director = d;
        public static List<Worker> Save_five()
        {
            var selected = new HashSet<Worker>();

            var one = More_worke_age(); if (one != null) selected.Add(one);
            var two = Without_worke_age(); if (two != null) selected.Add(two);
            var three = DataMax_for_director(); if (three != null) selected.Add(three);
            var four = Houses(); if (four != null) selected.Add(four);
            var five = Kogo_zahotele(); if (five != null) selected.Add(five);
            foreach (var w in workers)
            {
                if (!selected.Contains(w)) { selected.Add(w); break; }
            }

            return selected.ToList();
        }
        public static void Print_five()
        {
            var selected = Save_five();
            Console.WriteLine("Відібрані працівники:");

            foreach (var worker in selected)
            {
                Console.WriteLine(worker);
                Console.WriteLine(new string('-', 50)); 
            }
        }
    }
}
