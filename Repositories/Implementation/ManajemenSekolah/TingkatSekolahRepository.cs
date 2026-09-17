using Microsoft.EntityFrameworkCore;
using Sekolah.Data;
using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;

namespace Sekolah.Repositories.Implementation.ManajemenSekolah
{
    public class TingkatSekolahRepository : ITingkatSekolahRepository
    {
        private readonly ApplicationDbContext _context;

        public TingkatSekolahRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TingkatSekolah>> GetByJenjangAsync(int jenjangId)
        {
            return await _context.TingkatSekolahs
                .Where(t => t.JenjangSekolahID == jenjangId)
                .ToListAsync();
        }

        public async Task<TingkatSekolah?> GetByIdAsync(int id)
        {
            return  await _context.TingkatSekolahs.FindAsync(id);
        }

        public async Task<TingkatSekolah> CreateAsync(TingkatSekolah entity)
        {
            
            _context.TingkatSekolahs.Add(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async Task<bool> UpdateAsync(TingkatSekolah entity)
        {
            var newentity = await _context.TingkatSekolahs.FindAsync(entity.ID);
            if (newentity == null) return false;
            newentity.Nama = entity.Nama;
            _context.TingkatSekolahs.Update(newentity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TingkatSekolahs.FindAsync(id);
            if (entity == null) return false;
            // consider FK children (RombonganBelajar) - DB may block delete
            _context.TingkatSekolahs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
