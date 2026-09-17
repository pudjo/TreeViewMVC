using Microsoft.EntityFrameworkCore;
using Sekolah.Data;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;

namespace Sekolah.Repositories.Implementation.ManajemenSekolah
{
    public class JurusanRepository: IJurusanRepository
    {
        private readonly ApplicationDbContext _context;

        public JurusanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Jurusan>> GetAllAsync()
        {
            return await _context.Jurusans
                .OrderBy(j => j.Nama)
                .ToListAsync();
        }

        public async Task<Jurusan?> GetByIdAsync(int id)
        {
            return await _context.Jurusans.FindAsync(id);
        }

        public async Task<Jurusan> CreateAsync(Jurusan entity)
        {
            _context.Jurusans.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Jurusan entity)
        {
            var existing = await _context.Jurusans.FindAsync(entity.Id);
            if (existing == null) return false;
            existing.Nama = entity.Nama;
            _context.Jurusans.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Jurusans.FindAsync(id);
            if (existing == null) return false;
            _context.Jurusans.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
