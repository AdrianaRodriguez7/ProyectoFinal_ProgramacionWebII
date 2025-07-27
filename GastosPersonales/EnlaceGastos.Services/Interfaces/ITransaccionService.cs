using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosGastos.Data.Entidades;

namespace EnlaceGastos.Services.Interfaces
{
    public interface ITransaccionService
    {
        Task<List<Transaccion>> ObtenerTodasAsync();
        Task<Transaccion?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Transaccion transaccion);
        Task EditarAsync(Transaccion transaccion);
        Task EliminarAsync(int id);
    }
}
