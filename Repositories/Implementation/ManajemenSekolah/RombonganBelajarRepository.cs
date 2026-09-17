using Microsoft.EntityFrameworkCore;
using Sekolah.Data;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;

namespace Sekolah.Repositories.Implementation.ManajemenSekolah
{
    public class RombonganBelajarRepository : IRombonganBelajarRepository
    {

        private readonly ApplicationDbContext _context;

    public RombonganBelajarRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<RombonganBelajar>> GetByTingkatAsync(int tingkatId)
    {
        return await _context.RombonganBelajars
            .Where(r => r.TingkatSekolahID == tingkatId)
            .OrderBy(r => r.Nama)
            .ToListAsync();
    }

    public async Task<RombonganBelajar?> GetByIdAsync(int id)
    {
        return await _context.RombonganBelajars.FindAsync(id);
    }

    public async Task<RombonganBelajar> CreateAsync(RombonganBelajar entity)
    {
            try
            {
                _context.RombonganBelajars.Add(entity);
                 await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Ambil pesan error asli dari .NET (bisa cek ex.InnerException juga jika perlu)
                string errorMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception("Gagal menyimpan ke database: " + (ex.InnerException?.Message ?? ex.Message));

                // Kembalikan sebagai JSON agar frontend tidak crash SyntaxError
                //return JSon(new { success = false, message = errorMsg });
            }
        }

    public async Task<bool> UpdateAsync(RombonganBelajar entity)
    {
        var existing = await _context.RombonganBelajars.FindAsync(entity.ID);
        if (existing == null) return false;
        existing.Nama = entity.Nama;
        existing.JurusanID = entity.JurusanID;
        existing.TingkatSekolahID = entity.TingkatSekolahID;
        existing.JenjangSekolahID = entity.JenjangSekolahID;
        existing.TahunAjaranID = entity.TahunAjaranID;
        _context.RombonganBelajars.Update(existing);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.RombonganBelajars.FindAsync(id);
        if (existing == null) return false;
        _context.RombonganBelajars.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}

    }

