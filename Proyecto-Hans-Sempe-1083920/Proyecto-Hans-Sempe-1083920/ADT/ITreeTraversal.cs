using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Hans_Sempe_1083920.ADT
{
    public interface ITreeTraversal<T>
    {
        void Walk(T value);
    }
}
