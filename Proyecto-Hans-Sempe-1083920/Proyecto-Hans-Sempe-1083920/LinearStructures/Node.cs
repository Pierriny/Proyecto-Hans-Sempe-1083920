using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Se utilizo el mismo árbol avl que se creo en el lbaoratorio 3

namespace Proyecto_Hans_Sempe_1083920.LinearStructures
{
    public class Node<T>
    {
        public T value { get; set; }
        public Node<T> next { get; set; }
        public Node<T> previous { get; set; }

        public Node() { }
        public Node(T value)
        {
            this.value = value;
        }

    }
}
