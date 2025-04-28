using Lb_7.Task_3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_3
{
    class ACiper : ICipher
    {  

        public string encode(string text)
        {
            return ShiftText(text, 1);
        }
        public string decode(string text)
        {
            return ShiftText(text, -1);
        }
        private string ShiftText(string text, int shift)
        {
            var result = new System.Text.StringBuilder();

            foreach (char c in text)
            {
                result.Append(ShiftChar(c, shift));
            }

            return result.ToString();
        }
        private char ShiftChar(char c, int shift)
        {
            // Алфавіт без урахування Ґ, Є, Ї, І
            const int alphabetSize = 32;

            if (char.IsLower(c) && c >= 'а' && c <= 'я')
            {
                return (char)('а' + (c - 'а' + shift + alphabetSize) % alphabetSize);
            }
            else if (char.IsUpper(c) && c >= 'А' && c <= 'Я')
            {
                return (char)('А' + (c - 'А' + shift + alphabetSize) % alphabetSize);
            }
            else
            {
                return c;
            }
        }


    }

}
