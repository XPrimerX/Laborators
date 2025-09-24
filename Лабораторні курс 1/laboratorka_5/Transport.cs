using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laboratorka_5
{
    class Transport
    {
        private string name;
        private TransportType type;
        private DateTime register;
        private double price;
        private Detail[] details;
        //Конструктор з параметрами
        public Transport(string _name,TransportType _type, DateTime _register,double price, Detail[] details)
        {
            name = _name;
            type = _type;
            register = _register;
            this.price = price;
            this.details = details;
        }
        //Конструктор без параметрів
        public Transport()
        {
            name = new string("Name");
            type = TransportType.Water;
            register = DateTime.Now;
            price = 0;

        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 200) name = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public TransportType Type
        {
            get { return type; }
            set { type = value;
                
            }
        }
        public DateTime Register
        {
            get { return register; }
            set
            {
                register = value;
              
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0) price = value;
                else throw new ArgumentOutOfRangeException();

            }
        }
        public Detail[] Details
        {
            get { return details; }
            set
            {
                if (value != null) details = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double TotalWight
        {
            get
            {
                double total = 0;
                foreach (var detal in details)
                {
                    total += detal.Weight;
                }
                return total;
            }
        }

        public bool this[TransportType type]
        {
            get
            {
                return this.type == type;
            }
        }
        public void AddDetails(params Detail[] newDetails)
        {
            if (newDetails == null || newDetails.Length == 0) return;

            int oldLength = details.Length;
            int newLength = oldLength + newDetails.Length;
            Detail[] updatedDetails = new Detail[newLength];

            // Копіюємо старі деталі в новий масив
            for (int i = 0; i < oldLength; i++)
            {
                updatedDetails[i] = details[i];
            }

            // Додаємо нові деталі
            for (int i = 0; i < newDetails.Length; i++)
            {
                updatedDetails[oldLength + i] = newDetails[i];
            }

            // Оновлюємо масив деталей
            details = updatedDetails;
        }
        public override string ToString()
        {
            string detailsInfo = "Немає деталей";

            if (details.Length > 0)
            {
                detailsInfo = "";
                for (int i = 0; i < details.Length; i++)
                {
                    detailsInfo += details[i].ToString() + "\n";
                }
            }

            return "\nНазва: " + name +
                   "\nТип: " + type +
                   "\nДата реєстрації: " + register +
                   "\nЦіна: " + price +
                   "\nВага деталей: " + TotalWight +
                   "\nДеталі:\n" + detailsInfo;
        }
        public string ToShortString()
        {
            return "\nНазва: " + name + "\nТип: " + type + "\nДата реєстрації: " + register + "\nЦіна: " + price + "\nВага деталей: " + TotalWight;
        }




    }
}
