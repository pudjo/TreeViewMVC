using Sekolah.DTO.ManajemenSekolah;

namespace Sekolah.Services.Interfaces.ManajemenSekolah
{
    public interface IJenjangSekolahService
    {
        Task<List<JenjangSekolahDto>> GetByTahunAjaranAsync(int tahunAjaranId);
        Task<JenjangSekolahDto?> GetByIdAsync(int id);
        Task<JenjangSekolahDto> CreateAsync(JenjangSekolahDto dto);
        Task<bool> UpdateAsync(JenjangSekolahDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
