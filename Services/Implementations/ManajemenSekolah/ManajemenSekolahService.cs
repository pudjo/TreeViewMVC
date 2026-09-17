using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;
using Sekolah.Services.Interfaces.ManajemenSekolah;

namespace Sekolah.Services.Implementations.ManajemenSekolah
{
    public class ManajemenSekolahService : IManajemenSekolahService

    {
        private readonly IManajemenSekolahRepository _repo;

        public ManajemenSekolahService(IManajemenSekolahRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<TahunAjaranDto>> GetHierarchyAsync()
        {
            return _repo.GetHierarchyAsync();
        }

    }
}
