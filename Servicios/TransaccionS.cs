using ProyectoFinal.EstructuraDatos;
using ProyectoFinal.Modelos;

namespace ProyectoFinal.Servicios
{
    public class TransaccionS
    {
        private readonly ListaEnlazada<Transaccion> transacciones = new();

        public void RegistrarTransaccion(Transaccion t)
        {
            t.Fecha = DateTime.Now;
            transacciones.AgregarAlFinal(t);
        }

        public List<Transaccion> ObtenerTodas()
        {
            return transacciones.ToList();
        }

        public List<Transaccion> ObtenerPorTarjeta(string numeroTarjeta)
        {
            return transacciones.ToList().Where(t => t.NumeroTarjeta == numeroTarjeta).ToList();
        }
    }
}
