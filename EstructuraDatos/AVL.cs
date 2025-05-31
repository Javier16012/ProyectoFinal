using System;

namespace ProyectoFinal.EstructuraDatos
{
    public class NodoAVL<T> where T : IComparable<T>
    {
        public T Valor { get; set; }
        public NodoAVL<T> Izquierda { get; set; }
        public NodoAVL<T> Derecha { get; set; }
        public int Altura { get; set; }

        public NodoAVL(T valor)
        {
            Valor = valor;
            Altura = 1;
        }
    }

    public class AVL<T> where T : IComparable<T>
    {
        public NodoAVL<T> Raiz { get; private set; }

        private int Altura(NodoAVL<T> nodo) => nodo?.Altura ?? 0;

        private int Balance(NodoAVL<T> nodo) => nodo == null ? 0 : Altura(nodo.Izquierda) - Altura(nodo.Derecha);

        private NodoAVL<T> RotarDerecha(NodoAVL<T> y)
        {
            var x = y.Izquierda;
            var T2 = x.Derecha;

            x.Derecha = y;
            y.Izquierda = T2;

            y.Altura = Math.Max(Altura(y.Izquierda), Altura(y.Derecha)) + 1;
            x.Altura = Math.Max(Altura(x.Izquierda), Altura(x.Derecha)) + 1;

            return x;
        }

        private NodoAVL<T> RotarIzquierda(NodoAVL<T> x)
        {
            var y = x.Derecha;
            var T2 = y.Izquierda;

            y.Izquierda = x;
            x.Derecha = T2;

            x.Altura = Math.Max(Altura(x.Izquierda), Altura(x.Derecha)) + 1;
            y.Altura = Math.Max(Altura(y.Izquierda), Altura(y.Derecha)) + 1;

            return y;
        }

        public void Insertar(T valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private NodoAVL<T> InsertarRecursivo(NodoAVL<T> nodo, T valor)
        {
            if (nodo == null) return new NodoAVL<T>(valor);

            int cmp = valor.CompareTo(nodo.Valor);
            if (cmp < 0)
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
            else if (cmp > 0)
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
            else
                return nodo;

            nodo.Altura = 1 + Math.Max(Altura(nodo.Izquierda), Altura(nodo.Derecha));

            int balance = Balance(nodo);

            if (balance > 1 && valor.CompareTo(nodo.Izquierda.Valor) < 0)
                return RotarDerecha(nodo);

            if (balance < -1 && valor.CompareTo(nodo.Derecha.Valor) > 0)
                return RotarIzquierda(nodo);

            if (balance > 1 && valor.CompareTo(nodo.Izquierda.Valor) > 0)
            {
                nodo.Izquierda = RotarIzquierda(nodo.Izquierda);
                return RotarDerecha(nodo);
            }

            if (balance < -1 && valor.CompareTo(nodo.Derecha.Valor) < 0)
            {
                nodo.Derecha = RotarDerecha(nodo.Derecha);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }
    }
}