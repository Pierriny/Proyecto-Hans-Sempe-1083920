using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace Proyecto_Hans_Sempe_1083920.Models.Comparadores
{
    class ComparerDPIfiltrados : IComparer<Paciente>
    {
        public int Compare(Paciente x, Paciente y)
        {
            return x.NextConsulta.CompareTo(y.NextConsulta);
        }
    }
}
