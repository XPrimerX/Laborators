namespace Laboratorka_6.Task_1
{
    //9
    public class Wild_animals : Animals
    {
        public Wild_animals(string name, int age, double weight,bool iswild, Predatory_animal info) : base(name,age,weight,true, info)
        {

        }
        public Wild_animals(){ }
        public override bool IsDangerous()
        {
            return true;
        }
       
    }
}

