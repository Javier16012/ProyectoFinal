using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Modelos;
using ProyectoFinal.Servicios;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarjetaC : ControllerBase
    {
        private readonly TarjetaS _tarjetaS = new();

        /// <summary>
        /// Crea una nueva tarjeta de crédito.
        /// </summary>
        [HttpPost]
        public IActionResult CrearTarjeta([FromBody] TarjetaCredito tarjeta)
        {
            _tarjetaS.AgregarTarjeta(tarjeta);
            return Ok("Tarjeta creada.");
        }

        /// <summary>
        /// Consulta el saldo de una tarjeta.
        /// </summary>
        [HttpGet("{numero}")]
        public ActionResult<decimal> ConsultarSaldo(string numero)
        {
            var tarjeta = _tarjetaS.ObtenerTarjeta(numero);
            if (tarjeta == null) return NotFound("Tarjeta no encontrada.");
            return Ok(tarjeta.Saldo);
        }

        /// <summary>
        /// Cambia el estado de una tarjeta (ej. "Bloqueada", "Activa").
        /// </summary>
        [HttpPut("estado/{numero}")]
        public IActionResult CambiarEstado(string numero, [FromQuery] string estado)
        {
            var resultado = _tarjetaS.CambiarEstado(numero, estado);
            return resultado ? Ok("Estado cambiado.") : NotFound("Tarjeta no encontrada.");
        }

        /// <summary>
        /// Cambia el PIN de una tarjeta.
        /// </summary>
        [HttpPut("pin/{numero}")]
        public IActionResult CambiarPIN(string numero, [FromQuery] string nuevoPIN)
        {
            var resultado = _tarjetaS.CambiarPIN(numero, nuevoPIN);
            return resultado ? Ok("PIN actualizado.") : NotFound("Tarjeta no encontrada.");
        }
    }
}
