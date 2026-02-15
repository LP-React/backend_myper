using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using backend_myper.Entities;
using backend_myper.Context;
using backend_myper.DTOs.TipoDocumento;

namespace backend_myper.Controllers
{
    [Route("api/tipo-documentos")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TipoDocumentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentoDTO>>> Get()
        {
            var listaDTO = new List<TipoDocumentoDTO>();

            foreach(var item in await _context.TipoDocumento.ToListAsync()){
                listaDTO.Add(new TipoDocumentoDTO
                {
                    TipoDocumentoId = item.TipoDocumentoId,
                    Nombre = item.Nombre
                });
            };

            return Ok(listaDTO);
        }
    }
}
