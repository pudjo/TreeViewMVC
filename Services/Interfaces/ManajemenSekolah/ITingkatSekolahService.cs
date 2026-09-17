using Sekolah.DTO.ManajemenSekolah;

namespace Sekolah.Services.Interfaces.ManajemenSekolah
{
    public interface ITingkatSekolahService
    {
        Task<List<TingkatSekolahDto>> GetByJenjangAsync(int jenjangId);
        Task<TingkatSekolahDto?> GetByIdAsync(int id);
        Task<TingkatSekolahDto> CreateAsync(TingkatSekolahDto dto);
        Task<bool> UpdateAsync(TingkatSekolahDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
