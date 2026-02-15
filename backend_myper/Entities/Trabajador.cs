namespace backend_myper.Entities
{
    public class Trabajador
    {
        public int TrabajadorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string FotoUrl { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}