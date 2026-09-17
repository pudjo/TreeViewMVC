using Sekolah.Models.ManajemenSekolah;

namespace Sekolah.Repositories.Interfaces.ManajemenSekolah
{
    public interface IJurusanRepository
    {
        Task<List<Jurusan>> GetAllAsync();
        Task<Jurusan?> GetByIdAsync(int id);
        Task<Jurusan> CreateAsync(Jurusan entity);
        Task<bool> UpdateAsync(Jurusan entity);
        Task<bool> DeleteAsync(int id);
    }
}
