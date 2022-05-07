using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_Hans_Sempe_1083920.ADT;

//Se utilizo el mismo árbol avl que se creo en el lbaoratorio 3

namespace Proyecto_Hans_Sempe_1083920.LinearStructures
{
    public class CustomLinkedList<T> : ICustomLinkedList<T>, IEnumerable<T>, ISortable<T>
    {
        private int count;
        private Node<T> start;
        private Node<T> end;
        public int Count()
        {
            return count;
        }

        public void Delete(int index)
        {
            int indexDelete = 0;
            Node<T> auxDelete = start;
            if (index < count)
            {
                if (index == 0)
                {
                    start = start.next;
                    start.previous = end;
                    count--;
                }
                else if (index == count - 1)
                {
                    end = end.previous;
                    end.next = null;
                    count--;
                }
                else
                {
                    while (indexDelete < index && auxDelete != null)
                    {
                        indexDelete++;
                        auxDelete = auxDelete.next;
                    }
                    auxDelete.previous.next = auxDelete.next;
                    auxDelete.next.previous = auxDelete.previous;
                    count--;
                }
            }
        }

        public T Get(int index)
        {
            T dato;
            if (!isEmpty() && index >= 0)
            {

                int buscar = 0;
                Node<T> temp = start;
                while (buscar < index)
                {
                    buscar++;
                    temp = temp.next;
                }
                dato = temp.value;
                if (dato != null) return dato;
            }
            return default;
        }


        public void Insert(T value)
        {
            Node<T> nuevoNodo = new Node<T>(value);
            if (isEmpty())
            {
                start = nuevoNodo;
                end = nuevoNodo;
            }
            else
            {
                Node<T> temp = end;
                start.previous = nuevoNodo;
                end.next = nuevoNodo;
                end = nuevoNodo;
                end.previous = temp;
                end.next = null;
            }
            count++;
        }

        public void Insert(T value, int index)
        {
            Node<T> nuevoNodo = new Node<T>(value);
            if (index <= count)
            {
                if (isEmpty())
                {
                    start = nuevoNodo;
                    end = nuevoNodo;
                }
                else
                {
                    int posicion = 0;
                    Node<T> AuxInsertar = start;
                    while (posicion < index)
                    {
                        posicion++;
                        AuxInsertar = AuxInsertar.next;
                    }
                    nuevoNodo.next = AuxInsertar.next;
                    AuxInsertar.next = nuevoNodo;
                    nuevoNodo.previous = AuxInsertar;
                }
                count++;
            }
        }

        public bool isEmpty()
        {
            return (count == 0);
        }

        public int Search(T data, IComparer<T> comparer)
        {
            Node<T> sData = new Node<T>();
            sData.value = data;
            Node<T> elementoA = start;
            int size = Count();
            for (int i = 0; i < size; i++)
            {
                if (sData.value != null && elementoA.value != null)
                {
                    if (comparer.Compare(sData.value, elementoA.value) == 0)
                    {
                        return i;
                    }
                }
                elementoA = elementoA.next;
            }
            return -1;
        }
        //
        //IEnumerable
        //
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            var node = start;
            while (node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }
        //
        //ISortable
        //
        public void Sort(IComparer<T> comparer)
        {
            if (Count() <= 1) return;
            Node<T> first = start;
            Node<T> elementoA = start;
            Node<T> elementoB = start;
            for (int i = 0; i < Count() - 1; i++)
            {
                for (int j = 0; j < Count() - 1; j++)
                {
                    elementoB = elementoA.next;
                    if (comparer.Compare(elementoA.value, elementoB.value) > 0)
                    {
                        Swap(ref elementoA, ref elementoB);
                    }
                }
            }
        }

        public void Swap(ref Node<T> a, ref Node<T> b)
        {
            T aux = b.value;
            b.value = a.value;
            a.value = aux;
        }

    }
}
