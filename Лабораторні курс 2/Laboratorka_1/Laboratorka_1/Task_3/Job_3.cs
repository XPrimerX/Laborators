using Laboratorka_1.Task_1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_3
{
    public class Job_3
    {
        public List<string> rozdrug { get; set; } = new List<string>();

        public  async Task Printing(List<Print_work> Print_work)
        {
            if (Print_work.Count == 0)
            {
                Console.WriteLine("Черга порожня!");
                return;
            }

            // Сортування за пріоритетом, потім за часом додавання
            var ordered = Print_work.OrderBy(j => j.Priority).ThenBy(j => j.Time).ToList();

            foreach (var job in ordered)
            {
                Console.WriteLine($"\nДрук завдання: {job.PID}, сторінок: {job.Pages}");
                Thread.Sleep(job.Pages * 300); // Імітація друку
                string log = $"{DateTime.Now:HH:mm:ss} | {job.PID} | {job.Pages} сторінок";
                rozdrug.Add(log);
                Console.WriteLine("Завдання надруковано!");
            }

            Print_work.Clear();
            await Task.CompletedTask;
        }
        public async Task ShowStatsAsync()
        {
            if (rozdrug.Count == 0)
            {
                Console.WriteLine("Статистика порожня!");
                return;
            }

            Console.WriteLine("\n=== СТАТИСТИКА ДРУКУ ===");
            foreach (var record in rozdrug)
                Console.WriteLine(record);
            await Job_1.Serilezid_by_json(rozdrug, "Static_druk.json");
        }
    }
}
