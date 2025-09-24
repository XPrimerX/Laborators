using Lb_7.Task_1.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_1
{
    class Container:IFileContainer,IContainer, IEnumerable
    {
        private List<Transport_from_lb5> transport = new List<Transport_from_lb5>();
        private bool isDataSaved = false;

        public int Count
        {
            get { return transport.Count; }
        }
        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= transport.Count) throw new IndexOutOfRangeException();
                return transport[index];
            }
            set
            {
                if (index < 0 || index >= transport.Count)
                    throw new IndexOutOfRangeException();
                if (value is Transport_from_lb5)
                    transport[index] = (Transport_from_lb5)value;
                else
                    throw new ArgumentException();
            }
        }

        public void Add(Transport_from_lb5 element)
        {
            if (element != null)
            {
                transport.Add(element);
                isDataSaved = false;
            }
            else throw new ArgumentNullException();
        }

        public void Delete(Transport_from_lb5 element)
        {
            if (transport.Contains(element))
            {
                transport.Remove(element);
                isDataSaved = false;
            }
            else
                throw new ArgumentException("Element not found");
        }
        // Реалізація IFileContainer
        public void Save(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var t in transport)
                {
                    sw.WriteLine($"{t.ToShortString()}");
                }
            }
            isDataSaved = true;
        }
        public void Load(string fileName)
        {
            transport.Clear();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        var t = new Transport_from_lb5(parts[0], (TransportType)Enum.Parse(typeof(TransportType), parts[1]), DateTime.Parse(parts[2]), double.Parse(parts[3]), new Detail_from_lb5[0]);
                        transport.Add(t);
                    }
                }
            }
            isDataSaved = true;
        }
        public bool IsDataSaved => isDataSaved;

        // Реалізація IEnumerable
        public IEnumerator<Transport_from_lb5> GetEnumerator()
        {
            return transport.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}

