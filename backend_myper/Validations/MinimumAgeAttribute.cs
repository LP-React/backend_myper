using System.ComponentModel.DataAnnotations;

namespace backend_myper.Validations
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Fecha de nacimiento es requerida");

            DateTime fechaNacimiento = (DateTime)value;
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                edad--;

            if (edad < _minimumAge)
                return new ValidationResult($"Debe tener al menos {_minimumAge} años");

            return ValidationResult.Success;
        }
    }
}
