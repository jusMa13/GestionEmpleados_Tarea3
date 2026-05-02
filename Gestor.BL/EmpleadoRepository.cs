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
        // Implementación de los métodos de la interfaz IEmpleadoRepository
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

        public int ContarTotal(string? busqueda)//metodo donde se cuenta el total de registros de empleados, si hay busqueda se filtra por nombre, apellidos o departamento
        {
            if(string.IsNullOrEmpty(busqueda))
                return _context.Empleados.Count ();

            return _context.Empleados.Count(e => e.Nombre.Contains(busqueda) ||
            e.Apellidos.Contains(busqueda) || e.Departamento.Contains(busqueda));

        }

        public Empleado? ObtenerPorId(int id)//metodo donde se obtiene un empleado por su id
        {
            return _context.Empleados.Find(id);
        }

        public void Agregar(Empleado empleado)//metodo donde se agrega un empleado a la base de datos
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)//metodo donde se actualiza un empleado en la base de datos
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public IEnumerable<Empleado> ObtenerTodos()//metodo donde se obtienen todos los empleados de la base de datos
        {
            return _context.Empleados.ToList();
        }

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)//metodo donde se buscan empleados por nombre, apellidos o departamento
        {
            return _context.Empleados.Where(e => e.Nombre.Contains(termino) ||
            e.Apellidos.Contains(termino) ||
            e.Departamento.Contains(termino)).ToList();
        }

        public void Eliminar(int id)//metodo donde se elimina un empleado de la base de datos
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }

        }
    }
}
