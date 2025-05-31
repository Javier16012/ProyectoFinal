namespace ProyectoFinal.Modelos
{
    public class Transaccion
    {
        public string NumeroTarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // "Pago", "Consumo"
        public decimal Monto { get; set; }
    }
}
