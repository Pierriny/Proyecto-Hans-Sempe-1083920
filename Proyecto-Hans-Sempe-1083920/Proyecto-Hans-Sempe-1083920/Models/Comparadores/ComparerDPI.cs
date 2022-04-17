using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Proyecto_Hans_Sempe_1083920.Models.Comparadores
{
    class ComparerDPI : IComparer<Proyecto_Hans_Sempe_1083920.Models.Paciente>
    {
        public int Compare(Paciente x, Paciente y)
        {
            return x.DPI.CompareTo(y.DPI);
        }

    }
}
