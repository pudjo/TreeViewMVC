using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sekolah.Models;
using Sekolah.Models.HR;
using Sekolah.Models.ManajemenSekolah;

namespace Sekolah.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Add your DbSet properties here for your entities     
        public DbSet<Product> Products { get; set; }
        public DbSet<Models.Sekolah> Pemdas { get; set; }
        public DbSet<OPD> OPDs{ get; set; }

        public DbSet<Golongan> Golongans{ get; set; }
        public DbSet<Pangkat> Pangkats { get; set; }
        public DbSet<Jabatan> Jabatans { get; set; }
        public DbSet<Pegawai> Pegawais { get; set; }
        public DbSet<PegawaiTugas> PegawaiTugass { get; set; }
        public DbSet<SuratTugas> SuratTugass { get; set; }

        public DbSet<TugasDasarHukkum> TugasDasarHukkums { get; set; }

        public DbSet<TahunAjaran> TahunAjarans { get; set; }
        public DbSet<JenjangSekolah> JenjangSekolahs { get; set; }
        public DbSet<TingkatSekolah> TingkatSekolahs { get; set; }
        public DbSet<RombonganBelajar> RombonganBelajars { get; set; }
        public DbSet<Jurusan> Jurusans { get; set; }

        public DbSet<Karyawan> Karyawans{ get; set; }
        public DbSet<Guru> Gurus { get; set; }
        
        /* SQLLite
         * 
         * using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Pegawai> Pegawais { get; set; }
    public DbSet<Jabatan> Jabatans { get; set; }
    public DbSet<Pangkat> Pangkats { get; set; }
    public DbSet<Golongan> Golongans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Data Seeding Golongan
        modelBuilder.Entity<Golongan>().HasData(
            new Golongan { Id = 1, Nama = "Golongan I" },
            new Golongan { Id = 2, Nama = "Golongan II" },
            new Golongan { Id = 3, Nama = "Golongan III" },
            new Golongan { Id = 4, Nama = "Golongan IV" }
        );

        // 2. Data Seeding Pangkat (Terikat pada GolonganId)
        modelBuilder.Entity<Pangkat>().HasData(
            // Golongan I
            new Pangkat { Id = 1, Nama = "Juru Muda (I/a)", GolonganId = 1 },
            new Pangkat { Id = 2, Nama = "Juru Muda Tingkat I (I/b)", GolonganId = 1 },
            new Pangkat { Id = 3, Nama = "Juru (I/c)", GolonganId = 1 },
            new Pangkat { Id = 4, Nama = "Juru Tingkat I (I/d)", GolonganId = 1 },

            // Golongan II
            new Pangkat { Id = 5, Nama = "Pengatur Muda (II/a)", GolonganId = 2 },
            new Pangkat { Id = 6, Nama = "Pengatur Muda Tingkat I (II/b)", GolonganId = 2 },
            new Pangkat { Id = 7, Nama = "Pengatur (II/c)", GolonganId = 2 },
            new Pangkat { Id = 8, Nama = "Pengatur Tingkat I (II/d)", GolonganId = 2 },

            // Golongan III
            new Pangkat { Id = 9, Nama = "Penata Muda (III/a)", GolonganId = 3 },
            new Pangkat { Id = 10, Nama = "Penata Muda Tingkat I (III/b)", GolonganId = 3 },
            new Pangkat { Id = 11, Nama = "Penata (III/c)", GolonganId = 3 },
            new Pangkat { Id = 12, Nama = "Penata Tingkat I (III/d)", GolonganId = 3 },

            // Golongan IV
            new Pangkat { Id = 13, Nama = "Pembina (IV/a)", GolonganId = 4 },
            new Pangkat { Id = 14, Nama = "Pembina Tingkat I (IV/b)", GolonganId = 4 },
            new Pangkat { Id = 15, Nama = "Pembina Utama Muda (IV/c)", GolonganId = 4 },
            new Pangkat { Id = 16, Nama = "Pembina Utama Madya (IV/d)", GolonganId = 4 },
            new Pangkat { Id = 17, Nama = "Pembina Utama (IV/e)", GolonganId = 4 }
        );

        // 3. Data Seeding Jabatan
        modelBuilder.Entity<Jabatan>().HasData(
            new Jabatan { Id = 1, Nama = "Kepala Dinas" },
            new Jabatan { Id = 2, Nama = "Sekretaris" },
            new Jabatan { Id = 3, Nama = "Kepala Bidang" },
            new Jabatan { Id = 4, Nama = "Kepala Subbagian" },
            new Jabatan { Id = 5, Nama = "Staf Pelaksana" }
        );
    }
}

        Berikut adalah cara menerapkan Server-Side Pagination dan Pencarian (Nama/NIP) yang efisien menggunakan EF Core Async dengan SQLite.

Pola ini mengeksekusi perhitungan jumlah total data (CountAsync) serta pengambilan potongan data (Skip dan Take) secara langsung di level database SQLite.

1. Buat Wrapper Class Pagination (PagedList.cs)
Buat kelas generic untuk menampung data hasil query, halaman saat ini, total halaman, dan metadata pendukung:

C#
        public class PagedList<T>
{
    public List<T> Items { get; private set; }
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int TotalCount { get; private set; }
    public int PageSize { get; private set; }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public PagedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        PageSize = pageSize;
        Items = items;
    }

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedList<T>(items, count, pageIndex, pageSize);
    }
}
        2. Update Controller (PegawaiController.cs)
Pada method Index, tambahkan parameter searchString dan pageNumber. Gunakan EF.Functions.Like agar pencarian Nama atau NIP di SQLite bersifat case-insensitive.

C#
        public async Task<IActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 10)
{
    // Simpan kata kunci pencarian ke ViewBag untuk ditampilkan kembali di input pencarian
    ViewBag.CurrentFilter = searchString;
    ViewBag.PageSize = pageSize;

    // 1. Inisialisasi Queryable dasar (belum dieksekusi ke database)
    var query = _context.Pegawais.AsNoTracking();

    // 2. Terapkan Filter Pencarian (Case-Insensitive untuk SQLite)
    if (!string.IsNullOrWhiteSpace(searchString))
    {
        var searchTerm = $"%{searchString.Trim()}%";
        query = query.Where(p => 
            EF.Functions.Like(p.Nama, searchTerm) || 
            EF.Functions.Like(p.NIP, searchTerm)
        );
    }

    // 3. Projection ke DTO dan Urutkan Data
    var projectedQuery = query
        .OrderBy(p => p.Nama)
        .Select(p => new PegawaiDto
        {
            Id = p.Id,
            NIP = p.NIP,
            Nama = p.Nama,
            NamaJabatan = p.Jabatan != null ? p.Jabatan.Nama : "-",
            NamaPangkat = p.Pangkat != null ? p.Pangkat.Nama : "-",
            NamaGolongan = p.Golongan != null ? p.Golongan.Nama : "-"
        });

    // 4. Eksekusi Pagination di level Database SQL
    var pagedData = await PagedList<PegawaiDto>.CreateAsync(projectedQuery, pageNumber, pageSize);

    return View(pagedData);
}
         
         3. Update View (Index.cshtml)
Sesuaikan tipe Model di halaman View menjadi PagedList<PegawaiDto> dan tambahkan form pencarian serta tombol navigasi halaman (pagination):

HTML

        @model PagedList<YourProject.DTOs.PegawaiDto>

<div class="card shadow-sm border-0">
    <div class="card-body">
        <!-- Form Pencarian dan Tombol Tambah -->
        <div class="row mb-3 align-items-center">
            <div class="col-md-6">
                <form asp-action="Index" method="get" class="d-flex gap-2">
                    <input type="text" 
                           name="searchString" 
                           value="@ViewBag.CurrentFilter" 
                           class="form-control" 
                           placeholder="Cari NIP atau Nama..." />
                    <button type="submit" class="btn btn-outline-primary">
                        <i class="bi bi-search"></i> Cari
                    </button>
                    @if (!string.IsNullOrEmpty(ViewBag.CurrentFilter as string))
                    {
                        <a asp-action="Index" class="btn btn-outline-secondary">Reset</a>
                    }
                </form>
            </div>
            <div class="col-md-6 text-end">
                <button type="button" class="btn btn-primary" onclick="openCreateModal()">
                    <i class="bi bi-plus-lg me-1"></i> Tambah Pegawai
                </button>
            </div>
        </div>

        <!-- Tabel Data -->
        <div class="table-responsive">
            <table class="table table-hover align-middle">
                <thead class="table-light">
                    <tr>
                        <th>NIP</th>
                        <th>Nama Pegawai</th>
                        <th>Jabatan</th>
                        <th>Golongan</th>
                        <th>Pangkat</th>
                        <th class="text-center">Aksi</th>
                    </tr>
                </thead>
                <tbody>
                    @if (Model.Items.Any())
                    {
                        @foreach (var item in Model.Items)
                        {
                            <tr>
                                <td>@item.NIP</td>
                                <td class="fw-semibold">@item.Nama</td>
                                <td>@item.NamaJabatan</td>
                                <td>@item.NamaGolongan</td>
                                <td>@item.NamaPangkat</td>
                                <td class="text-center">
                                    <button class="btn btn-sm btn-outline-warning" onclick="openEditModal(@item.Id)">
                                        <i class="bi bi-pencil"></i>
                                    </button>
                                </td>
                            </tr>
                        }
                    }
                    else
                    {
                        <tr>
                            <td colspan="6" class="text-center text-muted py-4">Data tidak ditemukan.</td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>

        <!-- Pagination Controls -->
        <div class="d-flex justify-content-between align-items-center mt-3">
            <span class="small text-muted">
                Menampilkan <b>@Model.Items.Count</b> dari total <b>@Model.TotalCount</b> data (Halaman @Model.PageIndex dari @Model.TotalPages)
            </span>
            <nav>
                <ul class="pagination pagination-sm mb-0">
                    <!-- Tombol Previous -->
                    <li class="page-item @(!Model.HasPreviousPage ? "disabled" : "")">
                        <a asp-action="Index"
                           asp-route-pageNumber="@(Model.PageIndex - 1)"
                           asp-route-searchString="@ViewBag.CurrentFilter"
                           class="page-link">Previous</a>
                    </li>

                    <!-- Link Halaman -->
                    @for (int i = 1; i <= Model.TotalPages; i++)
                    {
                        <li class="page-item @(i == Model.PageIndex ? "active" : "")">
                            <a asp-action="Index"
                               asp-route-pageNumber="@i"
                               asp-route-searchString="@ViewBag.CurrentFilter"
                               class="page-link">@i</a>
                        </li>
                    }

                    <!-- Tombol Next -->
                    <li class="page-item @(!Model.HasNextPage ? "disabled" : "")">
                        <a asp-action="Index"
                           asp-route-pageNumber="@(Model.PageIndex + 1)"
                           asp-route-searchString="@ViewBag.CurrentFilter"
                           class="page-link">Next</a>
                    </li>
                </ul>
            </nav>
        </div>
    </div>
</div>
         * 
         * */

    }
}
