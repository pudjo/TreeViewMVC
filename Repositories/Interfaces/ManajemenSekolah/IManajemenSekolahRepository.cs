using Sekolah.DTO.ManajemenSekolah;

namespace Sekolah.Repositories.Interfaces.ManajemenSekolah
{
    public interface IManajemenSekolahRepository
    {
        Task<IEnumerable<TahunAjaranDto>> GetHierarchyAsync();
    }
}
