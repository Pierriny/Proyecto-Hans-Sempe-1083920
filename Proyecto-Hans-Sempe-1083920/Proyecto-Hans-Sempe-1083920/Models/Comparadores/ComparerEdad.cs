using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Hans_Sempe_1083920.Models.Comparadores
{
    public class ComparerEdad :IComparer<Proyecto_Hans_Sempe_1083920.Models.Paciente>
    {
        public int Compare(Paciente x, Paciente y)
        {
            return x.Edad.CompareTo(y.Edad);
        }
    }
    
}
