using Sekolah.DTO.ManajemenSekolah;

namespace Sekolah.Services.Interfaces.ManajemenSekolah
{
    public interface IManajemenSekolahService
    {
        Task<IEnumerable<TahunAjaranDto>> GetHierarchyAsync();
    }
}
