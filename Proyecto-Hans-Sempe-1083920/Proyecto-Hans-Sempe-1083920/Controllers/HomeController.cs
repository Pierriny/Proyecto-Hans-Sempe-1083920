using Proyecto_Hans_Sempe_1083920.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Proyecto_Hans_Sempe_1083920.NonLineartStructures;
using Proyecto_Hans_Sempe_1083920.LinearStructures;
using CsvHelper;
using System.IO;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;


namespace Proyecto_Hans_Sempe_1083920.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static AVLTree<Paciente> arbolPacientesAVL = new AVLTree<Paciente>();

        private static AVLTree<PacienteFiltrado> arbolPacientesFiltrados = new AVLTree<PacienteFiltrado>();

        Stopwatch stopwatch = new Stopwatch();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult mostrarArbolAVL(int orden)
        {
            Recorrido<Paciente> nuevoRecorrido = new Recorrido<Paciente>();
            arbolPacientesAVL.InOrder(nuevoRecorrido);
            arbolPacientesAVL = null;
            DateTime time = new DateTime();
            DateTime time2 = new DateTime();
            DateTime time3 = new DateTime();
            DateTime time4 = new DateTime();
            GC.Collect();
            if (orden == 1)
            {
                stopwatch.Reset();
                stopwatch.Start();
                
                arbolPacientesAVL = new AVLTree<Paciente>();
                foreach (var item in nuevoRecorrido.arbolEnLista as List<Paciente>)
                {
                    arbolPacientesAVL.Add(item, new Models.Comparadores.comparerNombre());
                }
                nuevoRecorrido = null;
                stopwatch.Stop();
                var tiempo = stopwatch.ElapsedMilliseconds;
                time2 = DateTime.Now;

                ViewBag.tiempo = "Tardó " + tiempo + " ms o " + stopwatch.ElapsedTicks + " ticks en ordenarse.";
                ViewBag.Hora = "Fecha y hora que se hizo el ordenamiento: " + time2;
            }
            else if(orden == 2)
            {
                stopwatch.Reset();
                stopwatch.Start();
                arbolPacientesAVL = new AVLTree<Paciente>();
                foreach (var item in nuevoRecorrido.arbolEnLista as List<Paciente>)
                {
                    arbolPacientesAVL.Add(item, new Models.Comparadores.ComparerDPI());
                }
                nuevoRecorrido = null;
                stopwatch.Stop();
                var tiempo = stopwatch.ElapsedMilliseconds;
                time3 = DateTime.Now;

                ViewBag.tiempo = "Tardó " + tiempo + " ms o " + stopwatch.ElapsedTicks + " ticks en ordenarse.";
                ViewBag.Hora = "Fecha y hora que se hizo el ordenamiento: " + time3;
            }
            else
            {
                stopwatch.Reset();
                stopwatch.Start();
                arbolPacientesAVL = new AVLTree<Paciente>();

                foreach (var item in nuevoRecorrido.arbolEnLista as List<Paciente>)
                {
                    arbolPacientesAVL.Add(item, new Models.Comparadores.ComparerDPIfiltrados());
                }
                nuevoRecorrido = null;
                stopwatch.Stop();
                var tiempo = stopwatch.ElapsedMilliseconds;
                time4 = DateTime.Now;
                ViewBag.tiempo = "Tardó " + tiempo + " ms o " + stopwatch.ElapsedTicks + " ticks en ordenarse.";
                ViewBag.Hora = "Fecha y hora a la que se aplico seguimiento a los pacientes: " + time4;
            }

            time = DateTime.Now;
            GC.Collect();
            nuevoRecorrido = new Recorrido<Paciente>();
            arbolPacientesAVL.InOrder(nuevoRecorrido);
            ViewBag.Altura = "El árbol tiene una altura de " + arbolPacientesAVL.getAltura();
            ViewBag.Nodes = "El árbol tiene  " + arbolPacientesAVL.getNodes() + " elementos.";
            ViewBag.FyH = "Fecha y hora a la que se accedio al registro de pacientes: " + time;
            ViewData["Paciente"] = nuevoRecorrido.arbolEnLista;
            return View();
        }

        public IActionResult recibirManualAVL()
        {
            return View();
        }

        public IActionResult guardarPacienteAVL(String _n1, String _n2, String _a1, String _a2, long _dpi, int _edad, int _phone, int _lastC, String  _descrip)
        {
            DateTime timee = new DateTime();
            String _ProxConsulta;
          
            if(_descrip == "Sin Diagnostico previo" && _lastC >= 6)
            {
                _ProxConsulta = "Limpieza Dental";             
            }
            else if (_descrip == "Ortodoncia" && _lastC >= 2)
            {
                _ProxConsulta = "Tratamiento de ortodoncia";
            }
            else if(_descrip == "Caries" && _lastC >= 4)
            {
                _ProxConsulta = "Tratamiento contra las caries";
            }
            else if (_descrip == "Otro" && _lastC == 6)
            {
                _ProxConsulta = "Tratamiento específico";
            }
            else
            {
                _ProxConsulta = "Sin tratamiento especifico recomendaro";
            }

            Paciente nuevoPaciente = new Paciente(_n1, _n2, _a1, _a2, _dpi, _edad, _phone, _lastC, _descrip, _ProxConsulta);
            arbolPacientesAVL.Add(nuevoPaciente, new Models.Comparadores.ComparerDPI());
            timee = DateTime.Now;
            if (arbolPacientesAVL.getRotaciones() != 1)
            {
                ViewBag.rotaciones = "Se realizaron " + arbolPacientesAVL.getRotaciones() + " rotaciones.";    
                ViewBag.fecha = "Fecha y hora a la que se guardo el registro del paciente: " + timee;
            }
            else
            {
                ViewBag.rotaciones = "Se realizo " + arbolPacientesAVL.getRotaciones() + " rotaciones.";
                ViewBag.fecha = "Fecha y hora a la que se guardo el registro del paciente: " + timee;
            }

            return View();
        }

        public IActionResult buscarDPI(int _dpi)
        {
            Paciente buscarDPI = new Paciente();
            buscarDPI.DPI = _dpi;
            Recorrido<Paciente> nuevoRecorrido = new Recorrido<Paciente>();
            arbolPacientesAVL.InOrder(nuevoRecorrido);
            AVLTree<Paciente> arbolBuscarIDAVL = new AVLTree<Paciente>();
            foreach (var item in nuevoRecorrido.arbolEnLista as List<Paciente>)
            {
                arbolBuscarIDAVL.Add(item, new Models.Comparadores.ComparerDPI());
            }
            if (arbolBuscarIDAVL.Contains(buscarDPI, new Models.Comparadores.ComparerDPI()))
            {
                Paciente encontrado = arbolBuscarIDAVL.Find(buscarDPI, new Models.Comparadores.ComparerDPI());
                ViewBag.VehiculoFound = "El Paciente con el DPI " + encontrado.DPI + " esta registrado en el sistema ";
                ViewBag.comparaciones = "Se realizaron " + arbolBuscarIDAVL.getComparaciones() + " comparaciones.";
            }
            else
            {
                ViewBag.VehiculoFound = "No se encontró.";
                ViewBag.comparaciones = "";
            }
            return View();
        }

        public IActionResult buscarNombre(String _name)
        {
            Paciente buscarN = new Paciente();
            buscarN.Nombre1 = _name;

            Recorrido<Paciente> nuevoRecorrido = new Recorrido<Paciente>();
            arbolPacientesAVL.InOrder(nuevoRecorrido);
            AVLTree<Paciente> arbolBuscarSerieAVL = new AVLTree<Paciente>();
            foreach (var item in nuevoRecorrido.arbolEnLista as List<Paciente>)
            {
                arbolBuscarSerieAVL.Add(item, new Models.Comparadores.comparerNombre());
            }
            if (arbolBuscarSerieAVL.Contains(buscarN, new Models.Comparadores.comparerNombre()))
            {
                Paciente encontrado = arbolBuscarSerieAVL.Find(buscarN, new Models.Comparadores.comparerNombre());
                ViewBag.PacienteFound = "El/Los Pacientes de nombre" + encontrado.Nombre1 + " esta registrado en el Sistema ";
                ViewBag.comparaciones = "Se realizaron " + arbolBuscarSerieAVL.getComparaciones() + " comparaciones.";
            }
            else
            {
                ViewBag.VehiculoFound = "No se encontró al Paciente.";
                ViewBag.comparaciones = "";
            }
            return View();
        }

        public IActionResult Filtrar(int _Seguimiento)
        {
            Recorrido<Paciente> Nrecorrido = new Recorrido<Paciente>();
            arbolPacientesAVL.InOrder(Nrecorrido);
            arbolPacientesAVL = null;
            GC.Collect();

            if(_Seguimiento == 1)
            {
                stopwatch.Reset();
                stopwatch.Start();
                arbolPacientesAVL = new AVLTree<Paciente>();

                foreach (var item in Nrecorrido.arbolEnLista as List<Paciente>)
                {
                    arbolPacientesAVL.Add(item, new Models.Comparadores.ComparerDPIfiltrados());
                }
                Nrecorrido = null;
                stopwatch.Stop();
                var tiempo = stopwatch.ElapsedMilliseconds;
                ViewBag.tiempo = "Tardó " + tiempo + " ms o " + stopwatch.ElapsedTicks + " ticks en ordenarse.";
            }

            GC.Collect();
            Nrecorrido = new Recorrido<Paciente>();
            arbolPacientesAVL.InOrder(Nrecorrido);
            ViewBag.Altura = "El árbol tiene una altura de " + arbolPacientesAVL.getAltura();
            ViewBag.Nodes = "El árbol tiene  " + arbolPacientesAVL.getNodes() + " elementos.";
            ViewData["Paciente"] = Nrecorrido.arbolEnLista;
            return View();
        }

    }
}
