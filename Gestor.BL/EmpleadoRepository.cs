using Gestion.DATA;
using Gestor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.BL
{
    public class EmpleadoRepository : IEmpleadoRepository

    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gestor.Models.Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();
            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e => e.Nombre.Contains(busqueda) ||
                e.Apellidos.Contains(busqueda) ||
                e.Departamento.Contains(busqueda));
            }

            return query.Skip((pagina - 1) * tamano).Take(tamano).ToList();

        }

        public int ContarTotal(string? busqueda)
        {

            if (!string.IsNullOrEmpty(busqueda)) return _context.Empleados.Count();
            return _context.Empleados.Count(e => e.Nombre.Contains(busqueda) || e.Apellidos.Contains(busqueda) || e.Departamento.Contains(busqueda));


        }

        public Empleado? ObtenerPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return _context.Empleados.ToList();
        }

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            return _context.Empleados.Where(e => e.Nombre.Contains(termino) ||
            e.Apellidos.Contains(termino) ||
            e.Departamento.Contains(termino)).ToList();
        }

        public void Eliminar(int id)
        {


        }
    }
}
