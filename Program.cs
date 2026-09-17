using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sekolah.Data;
using Sekolah.Models;
using Sekolah.Repositories.Implementation.HR;
using Sekolah.Repositories.Implementation.ManajemenSekolah;
using Sekolah.Repositories.Interfaces.HR;
using Sekolah.Repositories.Interfaces.ManajemenSekolah;
using Sekolah.Services.Implementations.HR;
using Sekolah.Services.Implementations.ManajemenSekolah;
using Sekolah.Services.Interfaces.HR;
using Sekolah.Services.Interfaces.ManajemenSekolah;
using System;

/*
dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=AppPegawai.db"
  }
}
// SESUDAHNYA (SQLite):
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

# Hapus folder Migrations lama (jika ada), lalu jalankan di Terminal/PMC:
dotnet ef migrations add InitialSQLite
dotnet ef database update
*/
namespace Sekolah
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionSTring=builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionSTring));
            // Add services to the container.
            builder.Services.AddScoped<ITahunAjaranRepository, TahunAjaranRepository>();
            builder.Services.AddScoped<ITahunAjaranService, TahunAjaranService>();

            // make sure existing ManajemenSekolah repo/service are also registered if not already
            builder.Services.AddScoped<IManajemenSekolahRepository, ManajemenSekolahRepository>();
            builder.Services.AddScoped<IManajemenSekolahService, ManajemenSekolahService>();
            builder.Services.AddScoped<IJenjangSekolahRepository, JenjangSekolahRepository>(); 
            builder.Services.AddScoped<IJenjangSekolahService, JenjangSekolahService>();
            
// Tingkat
            builder.Services.AddScoped<ITingkatSekolahRepository, TingkatSekolahRepository>();
            builder.Services.AddScoped<ITingkatSekolahService, TingkatSekolahService>();
            builder.Services.AddScoped<IJurusanRepository, JurusanRepository>();
            builder.Services.AddScoped<IJurusanService, JurusanService>();
            builder.Services.AddScoped<IRombonganBelajarRepository, RombonganBelajarRepository>();
            builder.Services.AddScoped<IRombonganBelajarService, RombonganBelajarService>();
            builder.Services.AddScoped<IGuruRepository, GuruRepository>();
            builder.Services.AddScoped<IGuruService, GuruService>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");




            // create the roles and the first admin user if not available yet
            
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await DatabaseInitializer.SeedDataAsync(userManager, roleManager);
            }
            app.Run();
        }
    }
}
