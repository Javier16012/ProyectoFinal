namespace ProyectoFinal.Modelos
{
    public class TarjetaCredito
    {
        public string Numero { get; set; }
        public string DPICliente { get; set; }
        public decimal Saldo { get; set; }
        public decimal LimiteCredito { get; set; }
        public string Estado { get; set; } = "Activa";
        public string PIN { get; set; }
    }
}