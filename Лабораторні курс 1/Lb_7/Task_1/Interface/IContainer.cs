using Lb_7.Task_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lb_7.Task_1.Interface
{
    interface IContainer
    {
        //Кількість елементів у контейнері.
        int Count { get; }
        // Індексатор контейнера.
        object this[int index] { get; set; }
        // Додати елемент у контейнер.
        void Add(Transport_from_lb5 element);
        // Видалити елемент з контейнеру.
        void Delete(Transport_from_lb5 element);
    }
}
