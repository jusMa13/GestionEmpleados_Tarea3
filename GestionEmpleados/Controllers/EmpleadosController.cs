using Gestor.BL;
using Gestor.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEmpleados.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;

        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string busqueda = "", int pagina = 1)//metodo donde se obtiene un listado de empleados paginado, si hay busqueda se filtra por nombre, apellidos o departamento
        {
            int tamanoPagina = 5;
            var lista = _repo.ObtenerPaginado(pagina, tamanoPagina, busqueda);
            int totalRegistros = _repo.ContarTotal(busqueda);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)totalRegistros / tamanoPagina);
            ViewBag.TotalRegistros = totalRegistros;
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        public IActionResult Edit(int id)
        {
            var empleado = _repo.ObtenerPorId(id);
            if(empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)//metodo donde se edita un empleado en la base de datos
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        [HttpPost]
        public IActionResult ToggleActivo(int id)//metodo donde se cambia el estado de un empleado a activo o inactivo
        {
            var empleado = _repo.ObtenerPorId(id);
            if(empleado != null)
            {
                empleado.Activo = !empleado.Activo;
                _repo.Actualizar(empleado);

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
