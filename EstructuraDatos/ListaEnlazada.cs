using System.Collections.Generic;

namespace ProyectoFinal.EstructuraDatos
{
    public class NodoLista<T>
    {
        public T Valor { get; set; }
        public NodoLista<T> Siguiente { get; set; }

        public NodoLista(T valor)
        {
            Valor = valor;
        }
    }

    public class ListaEnlazada<T>
    {
        public NodoLista<T> Cabeza { get; private set; }

        public void AgregarAlFinal(T valor)
        {
            var nuevo = new NodoLista<T>(valor);
            if (Cabeza == null)
            {
                Cabeza = nuevo;
                return;
            }

            var actual = Cabeza;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;

            actual.Siguiente = nuevo;
        }

        public List<T> ToList()
        {
            var resultado = new List<T>();
            var actual = Cabeza;
            while (actual != null)
            {
                resultado.Add(actual.Valor);
                actual = actual.Siguiente;
            }
            return resultado;
        }
    }
}
