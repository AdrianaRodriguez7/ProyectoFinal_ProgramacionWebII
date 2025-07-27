using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosGastos.Data.Entidades;

namespace EnlaceGastos.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task CrearCategoriaAsync(Categoria categoria);
        Task<List<Categoria>> ObtenerCategoriasAsync();
    }
}
