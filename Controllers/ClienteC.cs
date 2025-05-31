using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Modelos;
using ProyectoFinal.Servicios;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteC : ControllerBase
    {
        private readonly ClienteS _clienteS;

        //Inyección de dependencias del servicio ClienteS
        public ClienteC(ClienteS clienteS)
        {
            _clienteS = clienteS;
        }

        /// <summary>
        /// Agrega un nuevo cliente.
        /// </summary>
        [HttpPost]
        public IActionResult CrearCliente([FromBody] Cliente cliente)
        {
            _clienteS.AgregarCliente(cliente);
            return Ok("Cliente creado exitosamente.");
        }

        /// <summary>
        /// Obtiene un cliente por su DPI.
        /// </summary>
        [HttpGet("{dpi}")]
        public ActionResult<Cliente> ObtenerCliente(string dpi)
        {
            var cliente = _clienteS.ObtenerCliente(dpi);
            if (cliente == null) return NotFound("Cliente no encontrado.");
            return Ok(cliente);
        }

        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Cliente>> ObtenerTodos()
        {
            return Ok(_clienteS.ObtenerTodos());
        }
    }
}