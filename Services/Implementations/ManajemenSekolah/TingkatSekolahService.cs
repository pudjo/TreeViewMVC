using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;
using Sekolah.Services.Interfaces.ManajemenSekolah;

namespace Sekolah.Services.Implementations.ManajemenSekolah
{
    public class TingkatSekolahService : ITingkatSekolahService
    {
        private readonly ITingkatSekolahRepository _repo;

        public TingkatSekolahService(ITingkatSekolahRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TingkatSekolahDto>> GetByJenjangAsync(int jenjangId)
        {
           var  listJenjang = await _repo.GetByJenjangAsync(jenjangId);
           List<TingkatSekolahDto> result=listJenjang.Select(t => new TingkatSekolahDto
            {
                ID = t.ID,
                Nama = t.Nama,
                JenjangSekolahID = t.JenjangSekolahID,
                TahunAjaranID = t.TahunAjaranID
            }).ToList();
            return result;


        }
        public async Task<TingkatSekolahDto?> GetByIdAsync(int id)
        {
            TingkatSekolah? t = await _repo.GetByIdAsync(id);
            if (t == null)
            {
                return null;
            }
                return new TingkatSekolahDto
                {
                    ID = t.ID,
                    Nama = t.Nama,
                    JenjangSekolahID = t.JenjangSekolahID,
                    TahunAjaranID = t.TahunAjaranID
                };

        }

        public async Task<TingkatSekolahDto> CreateAsync(TingkatSekolahDto dto)
        {
            TingkatSekolah t = new TingkatSekolah
            {
                Nama = dto.Nama,
                JenjangSekolahID = dto.JenjangSekolahID,
                TahunAjaranID = dto.TahunAjaranID

            };
            t= await _repo.CreateAsync(t);
            if (t == null)
            {
                throw new Exception("Failed to create TingkatSekolah");
            }
            return new TingkatSekolahDto
            {
                ID = t.ID,
                Nama = t.Nama,
                JenjangSekolahID = t.JenjangSekolahID,
                TahunAjaranID = t.TahunAjaranID

            };
        }

        public async Task<bool> UpdateAsync(TingkatSekolahDto dto)
        {
            TingkatSekolah t = new TingkatSekolah
            {
                ID = dto.ID,
                Nama = dto.Nama,
                JenjangSekolahID = dto.JenjangSekolahID,
                TahunAjaranID = dto.TahunAjaranID
            };
           return await  _repo.UpdateAsync(t);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }

}

