using Microsoft.AspNetCore.Mvc;
using EnlaceGastos.Services.Interfaces;
using DatosGastos.Data.Entidades;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentacionGastos.Web.Controllers
{
    public class ControladorTransacciones : Controller
    {
        private readonly ITransaccionService _transaccionService;
        private readonly ICategoriaService _categoriaService;

        public ControladorTransacciones(ITransaccionService transaccionService, ICategoriaService categoriaService)
        {
            _transaccionService = transaccionService;
            _categoriaService = categoriaService;
        }

        /// ///////////////////CREAR//////////////////

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var categorias = await _categoriaService.ObtenerCategoriasAsync();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");

            ViewBag.Tipos = new SelectList(new[]
            {
                new { Id = 1, Nombre = "Ingreso" },
                new { Id = 2, Nombre = "Gasto" }
            }, "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Transaccion transaccion)
        {
            ModelState.Remove("Categoria");
            ModelState.Remove("TipoTransaccion");


            if (!ModelState.IsValid)
            {
                var categorias = await _categoriaService.ObtenerCategoriasAsync();
                ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");

                ViewBag.Tipos = new SelectList(new[]
                {
                    new { Id = 1, Nombre = "Ingreso" },
                    new { Id = 2, Nombre = "Gasto" }
                }, "Id", "Nombre");

                return View(transaccion);
            }

            await _transaccionService.CrearAsync(transaccion);
            return RedirectToAction("Crear");
        }

        /// ///////////////////EDITAR//////////////////

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {

            var transaccion = await _transaccionService.ObtenerPorIdAsync(id);
            if (transaccion == null)
                return NotFound();

            var categorias = await _categoriaService.ObtenerCategoriasAsync();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre", transaccion.CategoriaId);

            ViewBag.Tipos = new SelectList(new[]
            {
        new { Id = 1, Nombre = "Ingreso" },
        new { Id = 2, Nombre = "Gasto" }
    }, "Id", "Nombre", transaccion.TipoTransaccionId);

            return View(transaccion);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Transaccion transaccion)
        {
            ModelState.Remove("Categoria");
            ModelState.Remove("TipoTransaccion");
            if (!ModelState.IsValid)
                return View(transaccion);

            await _transaccionService.EditarAsync(transaccion);
            return RedirectToAction("Index");
        }

        /// ///////////////////ELIMINAR//////////////////

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var transaccion = await _transaccionService.ObtenerPorIdAsync(id);
            if (transaccion == null)
                return NotFound();

            return View(transaccion);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _transaccionService.EliminarAsync(id);
            return RedirectToAction("Index");
        }

        /// ///////////////////INDEX//////////////////

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var transacciones = await _transaccionService.ObtenerTodasAsync();
            return View(transacciones);
        }


    }
}

