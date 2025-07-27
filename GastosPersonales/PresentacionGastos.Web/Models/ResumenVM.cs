namespace PresentacionGastos.Web.Models
{
    public class ResumenVM
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }

        public string Mensaje { get; set; } = "";
    }
}
