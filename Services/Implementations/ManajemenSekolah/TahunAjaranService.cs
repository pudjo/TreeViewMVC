using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;
using Sekolah.Services.Interfaces.ManajemenSekolah;

namespace Sekolah.Services.Implementations.ManajemenSekolah
{
    public class TahunAjaranService : ITahunAjaranService
        {
            private readonly ITahunAjaranRepository _repo;

            public TahunAjaranService(ITahunAjaranRepository repo)
            {
                _repo = repo;
            }

          public async Task<List<TahunAjaranDto>> GetAllAsync()
        {
            List<TahunAjaran> listTahunAjaran = await _repo.GetAllAsync();
            var listTahunAjaranDto = listTahunAjaran
                .Select(x => new TahunAjaranDto
            {
                ID = x.ID,
                Nama = x.Nama,
                TanggalMulai = x.TanggalMulai,
                TanggalAKhir = x.TanggalAKhir
            }).ToList();

            return listTahunAjaranDto;

        } 


        public async Task<TahunAjaranDto?> GetByIdAsync(int id)
        {
            var t =  _repo.GetByIdAsync(id).Result;

            return new TahunAjaranDto
            {
                ID = t.ID,
                Nama = t.Nama,
                TanggalMulai = t.TanggalMulai,
                TanggalAKhir = t.TanggalAKhir
            };
   
        }

        public async Task<TahunAjaranDto> CreateAsync(TahunAjaranDto dto)
        {
            var t = new TahunAjaran
            {
                ID = dto.ID,
                Nama = dto.Nama,
                TanggalMulai = dto.TanggalMulai,
                TanggalAKhir = dto.TanggalAKhir
            };
            TahunAjaran newt = await _repo.CreateAsync(t);

            return new TahunAjaranDto
            {
                ID = newt.ID,
                Nama = newt.Nama,
                TanggalMulai = newt.TanggalMulai,
                TanggalAKhir = newt.TanggalAKhir
            };
         }

         public  async Task<bool> UpdateAsync(TahunAjaranDto dto)
        {
            var t = new TahunAjaran
            {
                ID = dto.ID,
                Nama = dto.Nama,
                TanggalMulai = dto.TanggalMulai,
                TanggalAKhir = dto.TanggalAKhir
            };
            return  await _repo.UpdateAsync(t);
        
        }
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

        }
    }
