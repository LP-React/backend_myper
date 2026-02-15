
namespace backend_myper.Entities
{
    public class TipoDocumento
    {
        public int TipoDocumentoId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Trabajador> Trabajadores { get; set; }
    }
}

