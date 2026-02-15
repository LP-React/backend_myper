using backend_myper.Validations;
using System.ComponentModel.DataAnnotations;
using backend_myper.Validations;

namespace backend_myper.DTOs.Trabajador
{
    public class TrabajadorCreateDTO
    {
        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$",
            ErrorMessage = "Nombres solo puede contener letras")]
        public string Nombres { get; set; }


        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$",
            ErrorMessage = "Apellidos solo puede contener letras")]
        public string Apellidos { get; set; }


        [Required]
        public int TipoDocumentoId { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroDocumento { get; set; }


        [Required]
        [MinimumAge(18)]
        public DateTime FechaNacimiento { get; set; }


        [Required]
        [RegularExpression("^(Masculino|Femenino)$",
            ErrorMessage = "Sexo debe ser Masculino o Femenino")]
        public string Sexo { get; set; }


        public string? FotoUrl { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }
    }
}
