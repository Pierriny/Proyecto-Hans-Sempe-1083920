using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Se utilizo el mismo árbol avl que se creo en el lbaoratorio 3

namespace Proyecto_Hans_Sempe_1083920.NonLineartStructures
{
    public class NodeAVL<T>
    {
        public T value { get; set; }
        public NodeAVL<T> Izquierda { get; set; }
        public NodeAVL<T> Derecha { get; set; }
        public int balance { get; set; }
        public NodeAVL() { }
        public NodeAVL(T value)
        {
            this.value = value;
        }

    }
}
