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
//using CsvHelper;
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
        //private static BinarySearchTree<String, Paciente arbolVehiculosABB = new BinarySearchTree<String, Paciente>(new Models.Comparadores.CompareNumbers().Compare);
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
            GC.Collect();
            orden = 1;
            if (orden == 1)
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
                ViewBag.tiempo = "tardp " + tiempo + "ms o " + stopwatch.ElapsedTicks + " ticks en ordenarse.";
            }
            GC.Collect();
            nuevoRecorrido = new Recorrido<Paciente>();
            arbolPacientesAVL.InOrder(nuevoRecorrido);
            ViewBag.Altura = "El árbol tiene una altura de " + arbolPacientesAVL.getAltura();
            ViewBag.Nodes = "El árbol tiene  " + arbolPacientesAVL.getNodes() + " elementos.";
            ViewData["Pacientes"] = nuevoRecorrido.arbolEnLista;
            return View();
        }

        public IActionResult recibirDatosAVL()
        {
            return View();
        } 

        public IActionResult recibirManualAVL()
        {
            return View();
        }

        public IActionResult guardarPacienteAVL(String _n1, String _n2, String _a1, String _a2, int _dpi, int _edad, int _phone, DateTime _lastC, String  _descrip)
        {

            Paciente nuevoPaciente = new Paciente(_n1, _n2, _a1, _a2, _dpi, _edad, _phone, _lastC, _descrip);
            arbolPacientesAVL.Add(nuevoPaciente, new Models.Comparadores.ComparerDPI());
            if (arbolPacientesAVL.getRotaciones() != 1)
            {
                ViewBag.rotaciones = "Se realizaron " + arbolPacientesAVL.getRotaciones() + " rotaciones.";
            }
            else
            {
                ViewBag.rottaciones = "Se realizo " + arbolPacientesAVL.getRotaciones() + " rotaciones.";
            }
            return View();
        }


        public IActionResult buscarID(String _id)
        {


            return View();
        }

        public IActionResult buscarNombre(String _name)
        {



            return View();
        }










    }
}
