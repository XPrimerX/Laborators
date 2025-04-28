using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_1.Interface
{
    interface IFileContainer:IContainer
    {
        // Зберегти вміст контейнера у текстовий файл.
        void Save(string fileName);
        // Завантажити дані з текстового файлу до контейнера.
        void Load(string fileName);
        // Повертає true, якщо дані контейнеру були збережені у файл.
        // Повертає false, якщо дані контейнеру не були збережені у файл.
        bool IsDataSaved { get; }
    }
}
