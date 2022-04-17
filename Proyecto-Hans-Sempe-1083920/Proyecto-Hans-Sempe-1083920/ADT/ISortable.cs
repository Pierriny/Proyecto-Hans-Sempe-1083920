﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Hans_Sempe_1083920.ADT
{
    interface ISortable<T>
    {
        /// <summary>
        /// Este metodo ordena una lista de elementos
        /// </summary>
        /// <param name="comparer">Necesita una forma de comparar los datos</param>
        void Sort(IComparer<T> comparer);
    }
}
