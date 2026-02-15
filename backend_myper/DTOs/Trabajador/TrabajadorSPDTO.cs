namespace backend_myper.DTOs.Trabajador
{
    public class TrabajadorSPDTO
    {
        public int TrabajadorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string FotoUrl { get; set; }
        public string Direccion { get; set; }
    }
}
