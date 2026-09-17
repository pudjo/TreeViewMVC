using Microsoft.EntityFrameworkCore;
using Sekolah.Data;
using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;

namespace Sekolah.Repositories.Implementation.ManajemenSekolah
{
    public class TahunAjaranRepository : ITahunAjaranRepository
    {
        private readonly ApplicationDbContext _context;

        public TahunAjaranRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TahunAjaran>> GetAllAsync()
        {
            return await _context.TahunAjarans
                .ToListAsync();
        }

        public async Task<TahunAjaran?> GetByIdAsync(int id)
        {
            var t = await _context.TahunAjarans.FindAsync(id);
            if (t == null) return null;
            return t;
            
        }

        public async Task<TahunAjaran> CreateAsync(TahunAjaran dto)
        {
            
            _context.TahunAjarans.Add(dto);
            await _context.SaveChangesAsync();
            
            return dto;
        }

        public async Task<bool> UpdateAsync(TahunAjaran dto)
        {
            var entity = await _context.TahunAjarans.FindAsync(dto.ID);
            if (entity == null) return false;
            entity.Nama = dto.Nama;
            entity.TanggalMulai = dto.TanggalMulai;
            entity.TanggalAKhir = dto.TanggalAKhir;
            _context.TahunAjarans.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TahunAjarans.FindAsync(id);
            if (entity == null) return false;
            _context.TahunAjarans.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
