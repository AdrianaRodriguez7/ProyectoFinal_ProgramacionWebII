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
    public class CategoriaService : ICategoriaService
    {
        private readonly ApplicationDbContext _context;

        public CategoriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CrearCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            return await _context.Categorias
            .Where(c => !c.Eliminado)
                         .ToListAsync();
        }

        
           public async Task EliminarCategoriaAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                categoria.Eliminado = true; // Marcar como eliminado
                _context.Categorias.Update(categoria); 
                await _context.SaveChangesAsync(); // Guardar cambios en la base de datos
            }
        }

    }
}

