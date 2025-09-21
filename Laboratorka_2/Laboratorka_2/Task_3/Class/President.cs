using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_2.Task_3.Class
{
    public class President:Employer
    {
        public President() { }
        public President(string firstname, string lastname, DateTime birthDate, string levelOfEducation, int opit, float salary, string position) 
            : base(firstname, lastname, levelOfEducation, opit, salary, position, birthDate) { }
    }
}
