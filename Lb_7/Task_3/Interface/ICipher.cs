using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_3.Interface
{
    public interface ICipher
    {
        string encode(string text);
        string decode(string text);
    }
}
