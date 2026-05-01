using Gestion.DATA;
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

        public IEnumerable<Gestor.Models.Empleado> ObtenerTodos()
        {
           
        }


    }
}
