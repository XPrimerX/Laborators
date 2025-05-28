using Modul_3.Abstra_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3.Clasi
{
    class Worker : Profesia
    {
        public Worker(string? pi, int age, int adress_bilding, int adress_apartament, string? street, string? email, string? phone, int age_work, string? family_stan, int money, string posada, DateTime date) : 
        base(pi, age, adress_bilding,adress_apartament,street, email, phone, age_work, family_stan, money, posada,date) { }
        public Worker() { }
        public static void AddWorker(Worker worker)
        {
            Criteria_for_otbora.AddWorker(worker);
        }
    }
}
