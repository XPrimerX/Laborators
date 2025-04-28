using Lb_7.Task_3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_3
{
    class BCipher : ICipher
    {
        public string encode(string text)
        {
            return MirrorText(text);
        }
        public string decode(string text)
        {
            return MirrorText(text);
        }
        private string MirrorText(string text)
        {
            var result = new System.Text.StringBuilder();

            foreach (char c in text)
            {
                result.Append(MirrorChar(c));
            }

            return result.ToString();
        }
        private char MirrorChar(char c)
        {
            if (char.IsLower(c) && c >= 'а' && c <= 'я')
            {
                return (char)('я' - (c - 'а'));
            }
            else if (char.IsUpper(c) && c >= 'А' && c <= 'Я')
            {
                return (char)('Я' - (c - 'А'));
            }
            else
            {
                return c;
            }
        }
    }
}
