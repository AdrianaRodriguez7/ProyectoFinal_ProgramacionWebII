using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosGastos.Data;
using EnlaceGastos.Services.Estrategias;
using Microsoft.EntityFrameworkCore;
using EnlaceGastos.Services.Interfaces;

namespace EnlaceGastos.Services.Servicios
{
    public class ResumenService : IResumenService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnalisisFinancieroStrategy _estrategia;

        public ResumenService(ApplicationDbContext context, IAnalisisFinancieroStrategy estrategia)
        {
            _context = context;
            _estrategia = estrategia;
        }

        public async Task<(decimal TotalIngresos, decimal TotalEgresos, string Mensaje)> GenerarResumenAsync(DateTime desde, DateTime hasta)
        {
            var ingresos = await _context.Transacciones
                .Where(t => t.Fecha.Date >= desde.Date && t.Fecha.Date <= hasta.Date && t.TipoTransaccionId == 1)
                .SumAsync(t => t.Monto);

            var egresos = await _context.Transacciones
                .Where(t => t.Fecha.Date >= desde.Date && t.Fecha.Date <= hasta.Date && t.TipoTransaccionId == 2)
                .SumAsync(t => t.Monto);

            var mensaje = _estrategia.Evaluar(ingresos, egresos);

            return (ingresos, egresos, mensaje);
        }
    }
}
