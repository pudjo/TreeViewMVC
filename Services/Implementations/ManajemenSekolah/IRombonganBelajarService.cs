using Sekolah.DTO.ManajemenSekolah;

namespace Sekolah.Services.Implementations.ManajemenSekolah
{
    public interface IRombonganBelajarService
    {
        Task<List<RombonganBelajarDto>> GetByTingkatAsync(int tingkatId);
        Task<RombonganBelajarDto?> GetByIdAsync(int id);
        Task<RombonganBelajarDto> CreateAsync(RombonganBelajarDto dto);
        Task<bool> UpdateAsync(RombonganBelajarDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
