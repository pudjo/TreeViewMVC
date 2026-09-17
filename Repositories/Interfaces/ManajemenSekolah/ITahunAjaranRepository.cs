using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;

namespace Sekolah.Repositories.Interfaces.ManajemenSekolah
{
    public interface ITahunAjaranRepository
    {
        Task<List<TahunAjaran>> GetAllAsync();
        Task<TahunAjaran?> GetByIdAsync(int id);
        Task<TahunAjaran> CreateAsync(TahunAjaran dto);
        Task<bool> UpdateAsync(TahunAjaran dto);
        Task<bool> DeleteAsync(int id);

    }
}
