using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnlaceGastos.Services.Interfaces
{
    public interface IResumenService
    {
        Task<(decimal TotalIngresos, decimal TotalEgresos, string Mensaje)>
            GenerarResumenAsync(DateTime desde, DateTime hasta);
    }
}
