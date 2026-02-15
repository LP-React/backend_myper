using backend_myper.Context;
using backend_myper.DTOs.Trabajador;
using backend_myper.Entities;
using backend_myper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_myper.Controllers
{
    [Route("api/trabajadores")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadorService _service;

        public TrabajadorController(ITrabajadorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrabajadorCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Trabajador registrado correctamente");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit(int id, TrabajadorUpdateDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return Ok("Trabajador modificado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok("Trabajador eliminado exitosamente");
        }
    }
}