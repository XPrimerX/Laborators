namespace Laboratorka_6.Task_1
{
    //9
    public class Wild_animals
    {
        public string name;
        public int age;
        public double weight;
        public Wild_animals(string name, int age, double weight)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
        }
        public Wild_animals()
        {
            name = "Name";
            age = 0;
            weight = 5;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 70) name = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (age > 100 || age < 0) age = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else weight = value;
            }
        }
        //замінює значення двох властивостей об’єкта
        public virtual void ReplaceFields(string newName, int newAge, double newweight)
        {
            name = newName;
            age = newAge;
            weight = newweight;
        }

        public override string ToString()
        {
            return "\nНазва: " + name + "\nВік: " + age + "\nВага: " + weight + "кг";
        }
        public override bool Equals(object obj)
        {
            if (obj is Wild_animals) { return ToString().Equals(((Wild_animals)obj).ToString()); }
            return false;
        }
        public override int GetHashCode() { return ToString().GetHashCode(); }
       
    }
}

