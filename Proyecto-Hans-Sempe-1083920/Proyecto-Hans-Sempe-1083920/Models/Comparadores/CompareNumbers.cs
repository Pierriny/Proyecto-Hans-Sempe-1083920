using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Proyecto_Hans_Sempe_1083920.Models.Comparadores
{
    class CompareNumbers : IComparer<String>
    {
        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
}
