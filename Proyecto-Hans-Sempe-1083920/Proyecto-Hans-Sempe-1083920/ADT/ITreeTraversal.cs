using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Se utilizo el mismo árbol avl que se creo en el lbaoratorio 3

namespace Proyecto_Hans_Sempe_1083920.ADT
{
    public interface ITreeTraversal<T>
    {
        void Walk(T value);
    }
}
