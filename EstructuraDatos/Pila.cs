using System.Collections.Generic;

namespace ProyectoFinal.EstructuraDatos
{
    public class Pila<T>
    {
        private LinkedList<T> elementos = new();

        public void Push(T item) => elementos.AddFirst(item);

        public T Pop()
        {
            if (elementos.Count == 0)
                return default(T); // o lanzar excepción

            var valor = elementos.First.Value;
            elementos.RemoveFirst();
            return valor;
        }

        public T Peek()
        {
            if (elementos.First == null)
                return default(T); // o lanzar excepción

            return elementos.First.Value;
        }

        public bool EstaVacia() => elementos.Count == 0;

        public List<T> ToList() => new(elementos);
    }
}
