using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;
using Sekolah.Services.Interfaces.ManajemenSekolah;

namespace Sekolah.Services.Implementations.ManajemenSekolah
{
    public class JenjangSekolahService : IJenjangSekolahService
    {
 

        private readonly IJenjangSekolahRepository _repo;

        public JenjangSekolahService(IJenjangSekolahRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<JenjangSekolahDto>> GetByTahunAjaranAsync(int tahunAjaranId)
        {
            // Panggil repo yang mengembalikan List<JenjangSekolah>
            var entities = await _repo.GetByTahunAjaranAsync(tahunAjaranId);

            // Map dari JenjangSekolah ke JenjangSekolahDto
            return entities.Select(e => new JenjangSekolahDto
            {
                ID = e.ID,
                TahunAjaranID = e.TahunAjaranID,
                Nama = e.Nama,
                NamaSekolah = e.NamaSekolah,
                // Jika di entitas ada relasi Tingkats, Anda bisa map juga di sini jika diperlukan
            }).ToList();
        }

        public async Task<JenjangSekolahDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;

            return new JenjangSekolahDto
            {
                ID = entity.ID,
                TahunAjaranID = entity.TahunAjaranID,
                Nama = entity.Nama,
                NamaSekolah = entity.NamaSekolah
            };
        }

        public async Task<JenjangSekolahDto> CreateAsync(JenjangSekolahDto dto)
        {
            // 1. Map DTO ke Entity Database (JenjangSekolah)
            var entity = new JenjangSekolah
            {
                ID = dto.ID,
                TahunAjaranID = dto.TahunAjaranID,
                Nama = dto.Nama,
                NamaSekolah = dto.NamaSekolah
            };

            // 2. Kirim entity ke repository
            var createdEntity = await _repo.CreateAsync(entity);

            // 3. Map kembali entity hasil ke DTO untuk dikembalikan
            return new JenjangSekolahDto
            {
                ID = createdEntity.ID,
                TahunAjaranID = createdEntity.TahunAjaranID,
                Nama = createdEntity.Nama,
                NamaSekolah = createdEntity.NamaSekolah
            };
        }

        public async Task<bool> UpdateAsync(JenjangSekolahDto dto)
        {
            // Map DTO ke Entity sebelum dikirim ke repository
            var entity = new JenjangSekolah
            {
                ID = dto.ID,
                TahunAjaranID = dto.TahunAjaranID,
                Nama = dto.Nama,
                NamaSekolah = dto.NamaSekolah
            };

            return await _repo.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}


