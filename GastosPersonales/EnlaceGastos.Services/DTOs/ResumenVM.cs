using System;
using System.Collections.Generic;

namespace EnlaceGastos.Services.DTOs
{
    public class ResumenVM
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }

        public string Mensaje { get; set; }

        public List<CategoriaMontoVM> MontosPorCategoria { get; set; } = new();
        public string CategoriaMayorGasto { get; set; }
    }

    public class CategoriaMontoVM
    {
        public string Categoria { get; set; }
        public decimal Monto { get; set; }
    }
}
