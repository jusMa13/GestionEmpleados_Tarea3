using Gestor.Models;

namespace Gestor.BL
{
    public interface IEmpleadoRepository
    {
      IEnumerable<Gestor.Models.Empleado> ObtenerTodos();
       Empleado? ObtenerPorId(int id);

       IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino);

       IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda);//metodo donde se obtiene un listado de empleados paginado, si hay busqueda se filtra por nombre, apellidos o departamento
        int ContarTotal(string? busqueda);

           void Agregar(Empleado empleado);
        void Actualizar(Empleado empleado);
        void Eliminar(int id);
    }
}
