using backend_myper.DTOs.Trabajador;

namespace backend_myper.Services.Interfaces
{
    public interface ITrabajadorService
    {
        Task<List<TrabajadorReadDTO>> GetAllAsync();
        Task<TrabajadorReadDTO?> GetByIdAsync(int id);
        Task CreateAsync(TrabajadorCreateDTO dto);
        Task<bool> UpdateAsync(int id, TrabajadorUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
