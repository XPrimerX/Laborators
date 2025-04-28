using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_1
{
    enum TransportType
    {
        Ground,
        Air,
        Water
    }
    class Detail_from_lb5: IComparable<Detail_from_lb5>, ICloneable
    {
        public Person_from_lb5 Manufactur;
        public string opis_detail;
        public double Weight;
        //Конструктор з трьома параметрами
        public Detail_from_lb5(Person_from_lb5 manufactur, string opis_detail, double weight)
        {
            Manufactur = manufactur;
            this.opis_detail = opis_detail;
            Weight = weight;
        }
        //Конструктор без параметрів
        public Detail_from_lb5()
        {
            Manufactur = new Person_from_lb5();
            opis_detail = "Опис";
            Weight = 20;
        }
        public Person_from_lb5 ManuFactur
        {
            get { return Manufactur; }
            set
            {
                if (value != null) Manufactur = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Opis
        {
            get { return opis_detail; }
            set
            {
                if (value.Length > 0) opis_detail = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double Weight_detail
        {
            get { return Weight; }
            set
            {
                if (value > 0) Weight = value;
                else throw new ArgumentOutOfRangeException();

            }

        }
        // Реалізація IComparable
        public int CompareTo(Detail_from_lb5 other)
        {
            if (other == null) return 1;
            return Weight.CompareTo(other.Weight);// Порівнюємо за вагою
        }
        // Реалізація ICloneable
        public object Clone()
        {
            return new Detail_from_lb5((Person_from_lb5)Manufactur.Clone(), opis_detail,Weight);
        }
        public override string ToString()
        {
            return "Виробник деталі: " + Manufactur + "\nОпис деталі: " + opis_detail + "\nВага деталі: " + Weight;
        }


    }
}
