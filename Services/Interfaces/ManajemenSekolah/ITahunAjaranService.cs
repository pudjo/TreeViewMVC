using Sekolah.DTO.ManajemenSekolah;

namespace Sekolah.Services.Interfaces.ManajemenSekolah
{
    public interface ITahunAjaranService
    {
        Task<List<TahunAjaranDto>> GetAllAsync();
        Task<TahunAjaranDto?> GetByIdAsync(int id);
        Task<TahunAjaranDto> CreateAsync(TahunAjaranDto dto);
        Task<bool> UpdateAsync(TahunAjaranDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
