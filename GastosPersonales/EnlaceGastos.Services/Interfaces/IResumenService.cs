using System;
using System.Threading.Tasks;
using EnlaceGastos.Services.DTOs;


namespace EnlaceGastos.Services.Interfaces
{
    public interface IResumenService
    {
        Task<ResumenVM> GenerarResumenAsync(DateTime desde, DateTime hasta);
    }
}
