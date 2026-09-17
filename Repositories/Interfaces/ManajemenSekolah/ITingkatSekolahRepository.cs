using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;

namespace Sekolah.Repositories.Interfaces.ManajemenSekolah
{
    public interface ITingkatSekolahRepository
    {
        Task<List<TingkatSekolah>> GetByJenjangAsync(int jenjangId);
        Task<TingkatSekolah?> GetByIdAsync(int id);
        Task<TingkatSekolah> CreateAsync(TingkatSekolah entity);
        Task<bool> UpdateAsync(TingkatSekolah dto);
        Task<bool> DeleteAsync(int id);
    }
}
