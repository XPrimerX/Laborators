using Laboratorka_6.Task_2.Interface_and_Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_2
{
    class Autopark
    {
        private List<Vehicle> Vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }
        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }
        public void Clear()
        {
            Vehicles.Clear();
        }
        public int CountPeople()
        {
            int total = 0;
            foreach (var vehicle in Vehicles)
            {
                //Якщо підтримується інтерфейс і вага не більше 500 то рахуємо людей
                if (vehicle.Weight <= 500)
                {
                    total += vehicle.People;
                }
            }
            return total;
        }
    

    }
}
