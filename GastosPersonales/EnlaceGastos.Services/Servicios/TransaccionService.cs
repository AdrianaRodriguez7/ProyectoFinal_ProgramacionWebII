using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosGastos.Data.Entidades;
using DatosGastos.Data;
using EnlaceGastos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnlaceGastos.Services.Servicios
{
    public class TransaccionService: ITransaccionService
    {
        private readonly ApplicationDbContext _context;

        public TransaccionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaccion>> ObtenerTodasAsync()
        {
            return await _context.Transacciones
                .Include(t => t.Categoria)
                .Include(t => t.TipoTransaccion)
                .ToListAsync();
        }

        public async Task<Transaccion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Transacciones.FindAsync(id);
        }

        public async Task CrearAsync(Transaccion transaccion)
        {
            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();
        }

        public async Task EditarAsync(Transaccion transaccion)
        {
            _context.Update(transaccion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var transaccion = await ObtenerPorIdAsync(id);
            if (transaccion != null)
            {
                _context.Transacciones.Remove(transaccion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
