using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
                [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [Range(400000, 10000000, ErrorMessage = "El salario debe estar entre 400000 y 10000000")]
        public decimal Salario { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;

        public string NombreCompleto => $"{Nombre} {Apellido}";

    }
}
