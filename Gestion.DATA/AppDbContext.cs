using Microsoft.EntityFrameworkCore;

namespace Gestion.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Gestor.Models.Empleado> Empleados { get; set; }
    }
}
