using System;

namespace ProyectoFinal.EstructuraDatos
{
    public class NodoABB<T> where T : IComparable<T>
    {
        public T Valor { get; set; }
        public NodoABB<T> Izquierda { get; set; }
        public NodoABB<T> Derecha { get; set; }

        public NodoABB(T valor)
        {
            Valor = valor;
            Izquierda = null;
            Derecha = null;
        }
    }

    public class ABB<T> where T : IComparable<T>
    {
        public NodoABB<T> Raiz { get; private set; }

        public void Insertar(T valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private NodoABB<T> InsertarRecursivo(NodoABB<T> nodo, T valor)
        {
            if (nodo == null)
                return new NodoABB<T>(valor);

            int comparacion = valor.CompareTo(nodo.Valor);

            if (comparacion < 0)
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
            else if (comparacion > 0)
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);

            return nodo;
        }

        public bool Buscar(T valor)
        {
            return BuscarRecursivo(Raiz, valor) != null;
        }

        private NodoABB<T> BuscarRecursivo(NodoABB<T> nodo, T valor)
        {
            if (nodo == null) return null;

            int comparacion = valor.CompareTo(nodo.Valor);

            if (comparacion == 0)
                return nodo;
            else if (comparacion < 0)
                return BuscarRecursivo(nodo.Izquierda, valor);
            else
                return BuscarRecursivo(nodo.Derecha, valor);
        }
    }
}