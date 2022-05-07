using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Hans_Sempe_1083920.Models
{
    public class PacienteFiltrado
    {

        // constructor
        public PacienteFiltrado() { }

        // obtiene y define el primer nombre del paciente
        public String FNombre1 { get; set; }

        // obtiene y define el segundo nombre del paciente
        public String FNombre2 { get; set; }

        // obtiene y define el Primer apellido del paciente
        public String FApellido1 { get; set; }

        // obtiene y define el Segundo apellido del paciente
        public String FApellido2 { get; set; }

        // obtiene y define el DPI del paciente
        public long FDPI { get; set; }

        // obtiene y define la edad del paciente
        public int FEdad { get; set; }

        // obtiene y define el numero telefonico del paciente
        public int FTelefono { get; set; }

        // obtiene y define la ultima fecha de consulta del paciente
        public int FLastConsulta { get; set; }

        // obtiene y define una breve descripcion del ultimo diganostico o tratamiento actual
        public String FDescripcion { get; set; }

        // obtiene y define cual deberia ser la sigueinte consulta sugerida
        public String FNextConsulta { get; set; }

        public PacienteFiltrado(String Fnombre1, String Fnombre2, String Fapellido1, String Fapellido2, long Fdpi, int Fedad, int Ftelefono, int Fconsulta, String Fdescrip, String F_nextC)
        {
            this.FNombre1 = Fnombre1;
            this.FNombre2 = Fnombre2;
            this.FApellido1 = Fapellido1;
            this.FApellido2 = Fapellido2;
            this.FDPI = Fdpi;
            this.FEdad = Fedad;
            this.FTelefono = Ftelefono;
            this.FLastConsulta = Fconsulta;
            this.FDescripcion = Fdescrip;
            this.FNextConsulta = F_nextC;
        }
    }
}
