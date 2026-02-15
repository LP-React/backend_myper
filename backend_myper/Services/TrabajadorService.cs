using backend_myper.Context;
using backend_myper.DTOs.Trabajador;
using backend_myper.Entities;
using backend_myper.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_myper.Services
{
    public class TrabajadorService : ITrabajadorService
    {

        private readonly AppDbContext _context;

        public TrabajadorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TrabajadorReadDTO>> GetAllAsync()
        {
            return await _context.Trabajador
                .Include(t => t.TipoDocumento)
                .Where(t => t.Estado)
                .Select(item => new TrabajadorReadDTO
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
                })
                .ToListAsync();
        }

        public async Task<TrabajadorReadDTO?> GetByIdAsync(int id)
        {
            var item = await _context.Trabajador
                .Include(t => t.TipoDocumento)
                .FirstOrDefaultAsync(t => t.TrabajadorId == id && t.Estado);

            if (item == null) return null;

            return new TrabajadorReadDTO
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
        }

        public async Task CreateAsync(TrabajadorCreateDTO dto)
        {
            var trabajador = new Trabajador
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                TipoDocumentoId = dto.TipoDocumentoId,
                NumeroDocumento = dto.NumeroDocumento,
                FechaNacimiento = dto.FechaNacimiento,
                Sexo = dto.Sexo,
                FotoUrl = dto.FotoUrl,
                Direccion = dto.Direccion,
                Estado = true
            };

            await _context.Trabajador.AddAsync(trabajador);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, TrabajadorUpdateDTO dto)
        {
            var item = await _context.Trabajador.FindAsync(id);
            if (item == null) return false;

            if (dto.Nombres != null) item.Nombres = dto.Nombres;
            if (dto.Apellidos != null) item.Apellidos = dto.Apellidos;
            if (dto.TipoDocumentoId != null) item.TipoDocumentoId = dto.TipoDocumentoId.Value;
            if (dto.NumeroDocumento != null) item.NumeroDocumento = dto.NumeroDocumento;
            if (dto.FechaNacimiento != null) item.FechaNacimiento = dto.FechaNacimiento.Value;
            if (dto.Sexo != null) item.Sexo = dto.Sexo;
            if (dto.FotoUrl != null) item.FotoUrl = dto.FotoUrl;
            if (dto.Direccion != null) item.Direccion = dto.Direccion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Trabajador.FindAsync(id);
            if (item == null) return false;

            item.Estado = false;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
