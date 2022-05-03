using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Proyecto_Hans_Sempe_1083920.Models
{
    public class Paciente
    {
        // constructor
        public Paciente() { }

        // obtiene y define el primer nombre del paciente
        public String Nombre1 { get; set; }

        // obtiene y define el segundo nombre del paciente
        public String Nombre2 { get; set; }

        // obtiene y define el Primer apellido del paciente
        public String Apellido1 { get; set; }

        // obtiene y define el Segundo apellido del paciente
        public String Apellido2 { get; set; }

        // obtiene y define el DPI del paciente
        public int DPI { get; set; }

        // obtiene y define la edad del paciente
        public int Edad { get; set; }

        // obtiene y define el numero telefonico del paciente
        public int Telefono { get; set; }

        // obtiene y define la ultima fecha de consulta del paciente
        public DateTime LastConsulta { get; set; }

        // obtiene y define una breve descripcion del ultimo diganostico o tratamiento actual
        public String Descripcion { get; set; }

        public Paciente(String nombre1, String nombre2, String apellido1, String apellido2, int dpi,  int edad, int telefono, DateTime consulta, String descrip)
        {
            this.Nombre1 = nombre1;
            this.Nombre2 = nombre2;
            this.Apellido1 = apellido1;
            this.Apellido1 = apellido2;
            this.DPI = dpi;
            this.Edad = edad;
            this.Telefono = telefono;
            this.LastConsulta = consulta;
            this.Descripcion = descrip;
        }


    }
}
