using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Modelos;
using ProyectoFinal.Servicios;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionC : ControllerBase
    {
        private readonly TransaccionS _transaccionS = new();
        private readonly TarjetaS _tarjetaS = new();

        /// <summary>
        /// Realiza un pago en una tarjeta.
        /// </summary>
        [HttpPost("pago")]
        public IActionResult RealizarPago([FromBody] Transaccion trans)
        {
            var exito = _tarjetaS.RealizarPago(trans.NumeroTarjeta, trans.Monto);
            if (!exito) return BadRequest("No se pudo realizar el pago.");

            trans.Tipo = "Pago";
            _transaccionS.RegistrarTransaccion(trans);
            return Ok("Pago realizado.");
        }

        /// <summary>
        /// Realiza un consumo con la tarjeta.
        /// </summary>
        [HttpPost("consumo")]
        public IActionResult RealizarConsumo([FromBody] Transaccion trans)
        {
            var exito = _tarjetaS.RealizarConsumo(trans.NumeroTarjeta, trans.Monto);
            if (!exito) return BadRequest("No se pudo realizar el consumo.");

            trans.Tipo = "Consumo";
            _transaccionS.RegistrarTransaccion(trans);
            return Ok("Consumo registrado.");
        }

        /// <summary>
        /// Consulta el historial de transacciones de una tarjeta.
        /// </summary>
        [HttpGet("historial/{numeroTarjeta}")]
        public ActionResult<List<Transaccion>> ObtenerTransacciones(string numeroTarjeta)
        {
            var lista = _transaccionS.ObtenerPorTarjeta(numeroTarjeta);
            return Ok(lista);
        }
    }
}