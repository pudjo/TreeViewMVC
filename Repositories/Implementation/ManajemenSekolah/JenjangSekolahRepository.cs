using Microsoft.EntityFrameworkCore;
using Sekolah.Data;
using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;

namespace Sekolah.Repositories.Implementation.ManajemenSekolah
{
    public class JenjangSekolahRepository : IJenjangSekolahRepository
    {
            private readonly ApplicationDbContext _context;

            public JenjangSekolahRepository(ApplicationDbContext context)
            {
                _context = context;
            }

       

        public async Task<JenjangSekolah> GetByIdAsync(int id)
        {
                var j = await _context.JenjangSekolahs.FindAsync(id);
                if (j == null) return null;
                return j;
                
        }

        public async Task<JenjangSekolah> CreateAsync(JenjangSekolah js)
        {
                
                _context.JenjangSekolahs.Add(js);
                await _context.SaveChangesAsync();
                
                return js;
            }

            public async Task<bool> UpdateAsync(JenjangSekolah entity)
            {
                var Currrententity = await _context.JenjangSekolahs.FindAsync(entity.ID);
                if (Currrententity == null) return false;
            Currrententity.Nama = entity.Nama;
            Currrententity.NamaSekolah = entity.NamaSekolah;
                _context.JenjangSekolahs.Update(Currrententity);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var entity = await _context.JenjangSekolahs.FindAsync(id);
                if (entity == null) return false;
                // note: consider checking/handling child entities (TingkatSekolah) before delete
                _context.JenjangSekolahs.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }

        public async Task<List<JenjangSekolah>> GetByTahunAjaranAsync(int tahunAjaranId)
        {
            return await _context.JenjangSekolahs
                .Where(j=>j.TahunAjaranID== tahunAjaranId).ToListAsync();
            
        }
        
    }
  }
