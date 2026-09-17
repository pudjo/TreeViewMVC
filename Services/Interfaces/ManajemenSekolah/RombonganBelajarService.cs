using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;
using Sekolah.Services.Implementations.ManajemenSekolah;

namespace Sekolah.Services.Interfaces.ManajemenSekolah
{
    public class RombonganBelajarService : IRombonganBelajarService
    {
        private readonly IRombonganBelajarRepository _repo;

        public RombonganBelajarService(IRombonganBelajarRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<RombonganBelajarDto>> GetByTingkatAsync(int tingkatId)
        {
            var list = await _repo.GetByTingkatAsync(tingkatId);
            return list.Select(r => new RombonganBelajarDto
            {
                ID = r.ID,
                Nama = r.Nama,
                JenjangSekolahID = r.JenjangSekolahID,
                TingkatSekolahID = r.TingkatSekolahID,
                JurusanID = r.JurusanID,
                TahunAjaranID = r.TahunAjaranID
            }).ToList();
        }

        public async Task<RombonganBelajarDto?> GetByIdAsync(int id)
        {
            var r = await _repo.GetByIdAsync(id);
            if (r == null) return null;
            return new RombonganBelajarDto
            {
                ID = r.ID,
                Nama = r.Nama,
                JenjangSekolahID = r.JenjangSekolahID,
                TingkatSekolahID = r.TingkatSekolahID,
                JurusanID = r.JurusanID,
                TahunAjaranID = r.TahunAjaranID
            };
        }

        public async Task<RombonganBelajarDto> CreateAsync(RombonganBelajarDto dto)
        {

            try
            {
                
                var entity = new RombonganBelajar
                {
                    Nama = dto.Nama,
                    JenjangSekolahID = dto.JenjangSekolahID,
                    TingkatSekolahID = dto.TingkatSekolahID,
                    JurusanID = dto.JurusanID,
                    TahunAjaranID = dto.TahunAjaranID
                };
                var created = await _repo.CreateAsync(entity);
                dto.ID = created.ID;
                return dto;
            }
            catch (Exception ex)
            {
                string pesanError = ex.InnerException?.Message ?? ex.Message;

                // Lempar kembali ke Controller
                throw new Exception(pesanError);
                
            }
        }

        public async Task<bool> UpdateAsync(RombonganBelajarDto dto)
        {
            var entity = new RombonganBelajar
            {
                ID = dto.ID,
                Nama = dto.Nama,
                JenjangSekolahID = dto.JenjangSekolahID,
                TingkatSekolahID = dto.TingkatSekolahID,
                JurusanID = dto.JurusanID,
                TahunAjaranID = dto.TahunAjaranID
            };
            return await _repo.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
