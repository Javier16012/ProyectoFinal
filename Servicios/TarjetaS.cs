using ProyectoFinal.EstructuraDatos;
using ProyectoFinal.Modelos;

namespace ProyectoFinal.Servicios
{
    public class TarjetaS
    {
        private readonly TablaHash<string, TarjetaCredito> tarjetas = new();

        public void AgregarTarjeta(TarjetaCredito t)
        {
            tarjetas.Insert(t.Numero, t);
        }

        public TarjetaCredito ObtenerTarjeta(string numero)
        {
            return tarjetas.Get(numero);
        }

        public List<TarjetaCredito> ObtenerTodas()
        {
            return tarjetas.ToList();
        }

        public bool RealizarPago(string numero, decimal monto)
        {
            var tarjeta = tarjetas.Get(numero);
            if (tarjeta == null || tarjeta.Estado != "Activa")
                return false;

            tarjeta.Saldo -= monto;
            return true;
        }

        public bool RealizarConsumo(string numero, decimal monto)
        {
            var tarjeta = tarjetas.Get(numero);
            if (tarjeta == null || tarjeta.Estado != "Activa")
                return false;

            if (tarjeta.Saldo + monto > tarjeta.LimiteCredito)
                return false;

            tarjeta.Saldo += monto;
            return true;
        }

        public bool CambiarEstado(string numero, string nuevoEstado)
        {
            var tarjeta = tarjetas.Get(numero);
            if (tarjeta == null)
                return false;

            tarjeta.Estado = nuevoEstado;
            return true;
        }

        public bool CambiarPIN(string numero, string nuevoPIN)
        {
            var tarjeta = tarjetas.Get(numero);
            if (tarjeta == null)
                return false;

            tarjeta.PIN = nuevoPIN;
            return true;
        }
    }
}
