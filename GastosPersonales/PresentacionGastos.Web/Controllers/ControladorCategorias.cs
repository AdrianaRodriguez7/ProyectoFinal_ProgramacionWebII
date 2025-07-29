using Microsoft.AspNetCore.Mvc;
using EnlaceGastos.Services.Interfaces;

using DatosGastos.Data.Entidades;
using EnlaceGastos.Services.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PresentacionGastos.Web.Controllers
{
    public class ControladorCategorias : Controller
    {

        private readonly ICategoriaService _categoriaService;

        public ControladorCategorias(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
      
        /// ///////////////////CREAR//////////////////
      
        [HttpGet] // Acción para mostrar el formulario
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]  // Acción para procesar el formulario
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);

            await _categoriaService.CrearCategoriaAsync(categoria);
            return RedirectToAction("Index"); //redirigir al Index
        }

        [HttpGet] //mostrar la lista de categorias
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObtenerCategoriasAsync();
            return View(categorias);
        }

        ///////////////////////ELIMINAR//////////////////
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _categoriaService.EliminarCategoriaAsync(id);
            return RedirectToAction("Index");
        }


    }
}
