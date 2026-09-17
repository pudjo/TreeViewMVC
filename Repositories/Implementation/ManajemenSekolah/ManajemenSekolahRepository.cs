using Microsoft.EntityFrameworkCore;
using Sekolah.Data;
using Sekolah.DTO.ManajemenSekolah;
using Sekolah.Models.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;

namespace Sekolah.Repositories.Implementation.ManajemenSekolah
{
    public class ManajemenSekolahRepository : IManajemenSekolahRepository
    {
        private readonly ApplicationDbContext _context;

        public ManajemenSekolahRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TahunAjaranDto>> GetHierarchyAsync()
        {
            // Load all sets then build hierarchy in memory (avoids having to rely on navigation properties configuration)
            var tahunList = await _context.TahunAjarans.OrderBy(t => t.Nama).ToListAsync();
            var jenjangList = await _context.JenjangSekolahs.OrderBy(j => j.Nama).ToListAsync();
            var tingkatList = await _context.TingkatSekolahs.OrderBy(t => t.Nama).ToListAsync();
            var rombongList = await _context.RombonganBelajars.OrderBy(r => r.Nama).ToListAsync();

            var result = tahunList.Select(t => new TahunAjaranDto
            {
                ID = t.ID,
                Nama = t.Nama,
                TanggalMulai = t.TanggalMulai,
                TanggalAKhir = t.TanggalAKhir,
                Jenjangs = jenjangList
                    .Where(j => j.TahunAjaranID == t.ID)
                    .Select(j => new JenjangSekolahDto
                    {
                        ID = j.ID,
                        Nama = j.Nama,
                        TahunAjaranID = j.TahunAjaranID,
                        NamaSekolah=j.NamaSekolah,
                        Tingkats = tingkatList
                            .Where(tk => tk.JenjangSekolahID == j.ID )
                            .Select(tk => new TingkatSekolahDto
                            {
                                ID = tk.ID,
                                Nama = tk.Nama,
                                JenjangSekolahID = tk.JenjangSekolahID,
                                TahunAjaranID = tk.TahunAjaranID,
                                Rombongans = rombongList
                                    .Where(r => r.TingkatSekolahID == tk.ID && r.JenjangSekolahID == j.ID && r.TahunAjaranID == t.ID)
                                    .Select(r => new RombonganBelajarDto
                                    {
                                        ID = r.ID,
                                        Nama = r.Nama,
                                        JenjangSekolahID = r.JenjangSekolahID,
                                        TingkatSekolahID = r.TingkatSekolahID,
                                        TahunAjaranID = r.TahunAjaranID
                                    })
                                    .ToList()
                            })
                            .ToList()
                    })
                    .ToList()
            }).ToList();

            return result;
        }

    }
}
