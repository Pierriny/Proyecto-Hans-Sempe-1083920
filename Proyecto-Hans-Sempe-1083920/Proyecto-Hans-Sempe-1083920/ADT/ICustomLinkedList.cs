using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Se utilizo el mismo árbol avl que se creo en el lbaoratorio 3

namespace Proyecto_Hans_Sempe_1083920.ADT
{
    interface ICustomLinkedList<T>
    {

        /// <summary>
        /// Inserta un elemento en la lista
        /// </summary>
        /// <param name="value">Dato</param>
        void Insert(T value);
        /// <summary>
        /// Inserta un elemento en la lista en la posicion deseada
        /// </summary>
        /// <param name="value">Dato</param>
        /// <param name="index">Posicion del dato</param>
        void Insert(T value, int index);
        /// <summary>
        /// Elimina un elemento en la posicion deseada
        /// </summary>
        /// <param name="index">posicion del elemento</param>
        void Delete(int index);
        /// <summary>
        /// Regresa un elemento de la posiicion deseada
        /// </summary>
        /// <param name="index">posicion del elemento</param>
        /// <returns></returns>
        T Get(int index);
        /// <summary>
        /// Verifica si la lista esta vacia
        /// </summary>
        /// <returns>true: esta vacia </returns>
        bool isEmpty();
        /// <summary>
        /// retorna el tamano de la lista
        /// </summary>
        /// <returns>tamano de la lista</returns>
        int Count();
        /// <summary>
        /// Busca un dato y retorna su posicion en la custom list
        /// </summary>
        /// <param name="data">Dato que se desea buscar</param>
        ///<param name="comparer">método utilizado para comparar</param>
        /// <returns>posiscion en la lista</returns>
        int Search(T data, IComparer<T> comparer);


    }
}
