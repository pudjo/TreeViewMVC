using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;

namespace Sekolah.Repositories.Interfaces.ManajemenSekolah
{
    public interface IJenjangSekolahRepository
    {
        Task<List<JenjangSekolah>> GetByTahunAjaranAsync(int tahunAjaranId);
        Task<JenjangSekolah?> GetByIdAsync(int id);
        Task<JenjangSekolah> CreateAsync(JenjangSekolah dto);
        Task<bool> UpdateAsync(JenjangSekolah dto);
        Task<bool> DeleteAsync(int id);

    }
}
