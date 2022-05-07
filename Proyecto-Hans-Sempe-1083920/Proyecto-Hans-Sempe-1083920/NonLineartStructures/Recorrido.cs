using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Hans_Sempe_1083920.ADT;

//Se utilizo el mismo árbol avl que se creo en el lbaoratorio 3

namespace Proyecto_Hans_Sempe_1083920.NonLineartStructures
{
    public class Recorrido<T> : ITreeTraversal<T>
    {

        public List<T> arbolEnLista = new List<T>();
        public void Walk(T value)
        {
            arbolEnLista.Add(value);
        }

    }
}
