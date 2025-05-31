using System;
using System.Collections.Generic;

namespace ProyectoFinal.EstructuraDatos
{
    public class TablaHash<K, V>
    {
        private readonly int tamaño = 100;
        private List<KeyValuePair<K, V>>[] tabla;

        public TablaHash()
        {
            tabla = new List<KeyValuePair<K, V>>[tamaño];
            for (int i = 0; i < tamaño; i++)
                tabla[i] = new List<KeyValuePair<K, V>>();
        }

        private int ObtenerIndice(K clave)
        {
            if (clave == null)
                throw new ArgumentNullException(nameof(clave), "La clave no puede ser null.");
            return Math.Abs(clave.GetHashCode()) % tamaño;
        }

        public void Insert(K clave, V valor)
        {
            if (clave == null)
                throw new ArgumentNullException(nameof(clave), "La clave no puede ser null.");

            int indice = ObtenerIndice(clave);
            var lista = tabla[indice];

            for (int i = 0; i < lista.Count; i++)
            {
                if (EqualityComparer<K>.Default.Equals(lista[i].Key, clave))
                {
                    lista[i] = new KeyValuePair<K, V>(clave, valor);
                    return;
                }
            }

            lista.Add(new KeyValuePair<K, V>(clave, valor));
        }

        public V Get(K clave)
        {
            if (clave == null)
                throw new ArgumentNullException(nameof(clave), "La clave no puede ser null.");

            int indice = ObtenerIndice(clave);
            var lista = tabla[indice];

            foreach (var kvp in lista)
            {
                if (EqualityComparer<K>.Default.Equals(kvp.Key, clave))
                    return kvp.Value;
            }

            return default;
        }

        public List<V> ToList()
        {
            var resultado = new List<V>();
            foreach (var lista in tabla)
                foreach (var kvp in lista)
                    resultado.Add(kvp.Value);
            return resultado;
        }
    }
}
