using Sekolah.Models.ManajemenSekolah;

namespace Sekolah.Services.Interfaces.ManajemenSekolah
{
    public interface IJurusanService
    {
        Task<List<Jurusan>> GetAllAsync();
        Task<Jurusan?> GetByIdAsync(int id);
        Task<Jurusan> CreateAsync(Jurusan entity);
        Task<bool> UpdateAsync(Jurusan entity);
        Task<bool> DeleteAsync(int id);

    }
}
