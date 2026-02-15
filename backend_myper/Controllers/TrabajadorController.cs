using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using backend_myper.Entities;
using backend_myper.Context;
using backend_myper.DTOs.Trabajador;

namespace backend_myper.Controllers
{
    [Route("api/trabajadores")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TrabajadorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrabajadorReadDTO>>> GetAll()
        {
            var listaDTO = new List<TrabajadorReadDTO>();

            foreach (var item in await _context.Trabajador.Include(t => t.TipoDocumento).Where(t => t.Estado == true).ToListAsync())
            {
                listaDTO.Add(new TrabajadorReadDTO
                {
                    TrabajadorId = item.TrabajadorId,
                    Nombres = item.Nombres,
                    Apellidos = item.Apellidos,
                    TipoDocumento = item.TipoDocumento.Nombre,
                    NumeroDocumento = item.NumeroDocumento,
                    FechaNacimiento = item.FechaNacimiento,
                    Sexo = item.Sexo,
                    FotoUrl = item.FotoUrl,
                    Direccion = item.Direccion
                });
            };

            return Ok(listaDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TrabajadorReadDTO>> GetById(int id)
        {
            var item = await _context.Trabajador.Include(t => t.TipoDocumento).Where(t => t.TrabajadorId == id && t.Estado == true).FirstOrDefaultAsync();
            if (item == null)
                return NotFound();
            var trabajadorReadDTO = new TrabajadorReadDTO
            {
                TrabajadorId = item.TrabajadorId,
                Nombres = item.Nombres,
                Apellidos = item.Apellidos,
                TipoDocumento = item.TipoDocumento.Nombre,
                NumeroDocumento = item.NumeroDocumento,
                FechaNacimiento = item.FechaNacimiento,
                Sexo = item.Sexo,
                FotoUrl = item.FotoUrl,
                Direccion = item.Direccion
            };
            return Ok(trabajadorReadDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TrabajadorCreateDTO>> Post(TrabajadorCreateDTO trabajadorDTO)
        {
            var trabajadorDB = new Trabajador
            {
                Nombres = trabajadorDTO.Nombres,
                Apellidos = trabajadorDTO.Apellidos,
                TipoDocumentoId = trabajadorDTO.TipoDocumentoId,
                NumeroDocumento = trabajadorDTO.NumeroDocumento,
                FechaNacimiento = trabajadorDTO.FechaNacimiento,
                Sexo = trabajadorDTO.Sexo,
                FotoUrl = trabajadorDTO.FotoUrl,
                Direccion = trabajadorDTO.Direccion,
                Estado = true
                
            };

            await _context.Trabajador.AddAsync(trabajadorDB);
            await _context.SaveChangesAsync();
            return Ok("Trabajador registrado correctamente");
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<TrabajadorUpdateDTO>> Edit(int id, TrabajadorUpdateDTO dto)
        {
            var item = await _context.Trabajador.FindAsync(id);
            if (item == null)
                return NotFound();
            if (dto.Nombres != null) item.Nombres = dto.Nombres;
            if (dto.Apellidos != null) item.Apellidos = dto.Apellidos;
            if (dto.TipoDocumentoId != null) item.TipoDocumentoId = dto.TipoDocumentoId.Value;
            if (dto.NumeroDocumento != null) item.NumeroDocumento = dto.NumeroDocumento;
            if (dto.FechaNacimiento != null) item.FechaNacimiento = dto.FechaNacimiento.Value;
            if (dto.Sexo != null) item.Sexo = dto.Sexo;
            if (dto.FotoUrl != null) item.FotoUrl = dto.FotoUrl;
            if (dto.Direccion != null) item.Direccion = dto.Direccion;

            await _context.SaveChangesAsync();
            return Ok("Trabajador modificado");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<String>> Delete(int id)
        {
            var item = await _context.Trabajador.Where(t => t.TrabajadorId == id).FirstOrDefaultAsync();
            if (item == null)
                return NotFound();
            item.Estado = false;
            _context.Trabajador.Update(item);
            await _context.SaveChangesAsync();
            return Ok("Trabajador eliminado exitosamente");
        }
    }
}