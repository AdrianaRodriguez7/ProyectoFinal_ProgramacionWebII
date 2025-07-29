using System;
using System.Linq;
using System.Threading.Tasks;
using DatosGastos.Data;
using EnlaceGastos.Services.Estrategias;
using EnlaceGastos.Services.Interfaces;
using EnlaceGastos.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public async Task<ResumenVM> GenerarResumenAsync(DateTime desde, DateTime hasta)
        {
            var ingresos = await _context.Transacciones
                .Where(t => t.Fecha.Date >= desde.Date && t.Fecha.Date <= hasta.Date && t.TipoTransaccionId == 1)
                .SumAsync(t => t.Monto);

            var egresos = await _context.Transacciones
                .Where(t => t.Fecha.Date >= desde.Date && t.Fecha.Date <= hasta.Date && t.TipoTransaccionId == 2)
                .SumAsync(t => t.Monto);

            var mensaje = _estrategia.Evaluar(ingresos, egresos);

            // Agrupamos egresos por categoría
            var egresosPorCategoria = await _context.Transacciones
                .Where(t => t.Fecha.Date >= desde.Date && t.Fecha.Date <= hasta.Date && t.TipoTransaccionId == 2)
                .Include(t => t.Categoria)
                .GroupBy(t => t.Categoria.Nombre)
                .Select(g => new CategoriaMontoVM
                {
                    Categoria = g.Key,
                    Monto = g.Sum(t => t.Monto)
                })
                .ToListAsync();

            var mayorCategoria = egresosPorCategoria
                .OrderByDescending(c => c.Monto)
                .FirstOrDefault()?.Categoria ?? "ninguna categoría";

            return new ResumenVM
            {
                FechaInicio = desde,
                FechaFin = hasta,
                TotalIngresos = ingresos,
                TotalEgresos = egresos,
                Mensaje = mensaje,
                MontosPorCategoria = egresosPorCategoria,
                CategoriaMayorGasto = mayorCategoria
            };
        }
    }
}
