using ProyectoFinal.EstructuraDatos;
using ProyectoFinal.Modelos;

namespace ProyectoFinal.Servicios
{
    public class ClienteS
    {
        private readonly TablaHash<string, Cliente> clientes = new();

        public void AgregarCliente(Cliente c)
        {
            clientes.Insert(c.DPI, c);
        }

        public Cliente ObtenerCliente(string dpi)
        {
            return clientes.Get(dpi);
        }

        public List<Cliente> ObtenerTodos()
        {
            return clientes.ToList();
        }
    }
}
