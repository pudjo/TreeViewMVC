using Sekolah.Models.ManajemenSekolah;

namespace Sekolah.Repositories.Interfaces.ManajemenSekolah
{
    public interface IRombonganBelajarRepository
    {
        Task<List<RombonganBelajar>> GetByTingkatAsync(int tingkatId);
        Task<RombonganBelajar?> GetByIdAsync(int id);
        Task<RombonganBelajar> CreateAsync(RombonganBelajar entity);
        Task<bool> UpdateAsync(RombonganBelajar entity);
        Task<bool> DeleteAsync(int id);

    }
}
