using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Hans_Sempe_1083920.Models.Comparadores
{
    public class ComparerNextConsulta : IComparer<Paciente>
    {
        public int Compare(Paciente x, Paciente y)
        {
            return x.NextConsulta.CompareTo(y.NextConsulta);
        }
    }
}

