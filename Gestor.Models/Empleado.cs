using System.ComponentModel.DataAnnotations;

namespace Gestor.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(80)]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        // metodo donde se valida que los apellidos estén dentro del rango especificado
        [StringLength(100)]
        public string Apellidos { get; set; } = "";

        [Required]
        public string Departamento { get; set; } = "";

        [Required]
        [Range(400000, 10000000, ErrorMessage = "El salario debe estar entre 400000 y 10000000")]
        // metodo donde se valida que el salario esté dentro del rango especificado
        public decimal Salario { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;

        public string NombreCompleto => $"{Nombre} {Apellidos}";

    }
}
