namespace laboratorka_5
{
    
    enum TransportType
    {
        Ground,//індекс = 0
        Air,
        Water
    }
    class Detail
    {
        public Person Manufactur;
        public string opis_detail;
        public double Weight;
        //Конструктор з трьома параметрами
        public Detail(Person manufactur, string opis_detail, double weight)
        {
            Manufactur = manufactur;
            this.opis_detail = opis_detail;
            Weight = weight;
        }
        //Конструктор без параметрів
        public Detail()
        {
            Manufactur = new Person();
            opis_detail = "Опис";
            Weight = 20;
        }
        public Person ManuFactur
        {
            get { return Manufactur; }
            set { if (value != null) Manufactur = value;
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
            set { if (value > 0) Weight = value;
                else throw new ArgumentOutOfRangeException();

            }
        
        }
        public override string ToString()
        {

            return "Виробник деталі: " + Manufactur + "\nОпис деталі: " + opis_detail + "\nВага деталі: " + Weight;
        }



    }
}
