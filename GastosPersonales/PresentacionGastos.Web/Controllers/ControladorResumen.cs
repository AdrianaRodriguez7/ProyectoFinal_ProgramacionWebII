using EnlaceGastos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PresentacionGastos.Web.Models;
using EnlaceGastos.Services.DTOs;

namespace PresentacionGastos.Web.Controllers
{
    public class ControladorResumen : Controller
    {
        private readonly IResumenService _resumenService;

        public ControladorResumen(IResumenService resumenService)
        {
            _resumenService = resumenService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var modelo = new ResumenVM
            {
                FechaInicio = DateTime.Today.AddDays(-7),
                FechaFin = DateTime.Today
            };

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResumenVM modelo)
        {
            if (modelo.FechaInicio > modelo.FechaFin)
            {
                ModelState.AddModelError("", "La fecha de inicio no puede ser mayor que la fecha de fin.");
                return View(modelo);
            }

            var resultado = await _resumenService.GenerarResumenAsync(modelo.FechaInicio, modelo.FechaFin);

            modelo.TotalIngresos = resultado.TotalIngresos;
            modelo.TotalEgresos = resultado.TotalEgresos;
            modelo.Mensaje = resultado.Mensaje;
            modelo.MontosPorCategoria = resultado.MontosPorCategoria;
            modelo.CategoriaMayorGasto = resultado.CategoriaMayorGasto;
            return View(modelo);
        }
    }
}
