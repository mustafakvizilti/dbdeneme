using Microsoft.EntityFrameworkCore;
using dbdeneme.Models;

namespace dbdeneme.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Maas> Maaslar { get; set; }
        public DbSet<Egitim> Egitimler { get; set; }
        public DbSet<PersonelEgitim> PersonelEgitimler { get; set; }

        public DbSet<Personel> Personeller { get; set; } = null!;
        public DbSet<Departman> Departmanlar { get; set; } = null!;
        public DbSet<Pozisyon> Pozisyonlar { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Maas>(entity =>
            {
                entity.Property(m => m.Tutar)
                    .HasColumnType("decimal(18,2)"); 
            });
        }

    }
}
