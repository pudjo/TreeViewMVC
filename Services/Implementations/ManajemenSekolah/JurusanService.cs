using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;
using Sekolah.Services.Interfaces.ManajemenSekolah;

namespace Sekolah.Services.Implementations.ManajemenSekolah
{
    public class JurusanService : IJurusanService
    {
        private readonly IJurusanRepository _repo;

        public JurusanService(IJurusanRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Jurusan>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Jurusan?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<Jurusan> CreateAsync(Jurusan entity) => _repo.CreateAsync(entity);

        public Task<bool> UpdateAsync(Jurusan entity) => _repo.UpdateAsync(entity);

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

    }
}
