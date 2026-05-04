using BinaDaireYonetim.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BinaDaireYonetim.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bina> Binalar { get; set; }
        public DbSet<Daire> Daireler { get; set; }
        public DbSet<KatMaliki> KatMalikleri { get; set; }
        public DbSet<Kiracı> Kiracıları { get; set; }
        public DbSet<Hesap> Hesaplar { get; set; }
        public DbSet<HesapIslem> HesapIslemler { get; set; }
        public DbSet<Not> Notlar { get; set; }
        public DbSet<Gecmis> Gecmisler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Bina - Daire ilişkisi (1-N)
            modelBuilder.Entity<Bina>()
                .HasMany(b => b.Daireler)
                .WithOne(d => d.Bina)
                .HasForeignKey(d => d.BinaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Daire - KatMaliki ilişkisi (1-N)
            modelBuilder.Entity<Daire>()
                .HasMany(d => d.KatMalikleri)
                .WithOne(k => k.Daire)
                .HasForeignKey(k => k.DaireId)
                .OnDelete(DeleteBehavior.Cascade);

            // Daire - Kiracı ilişkisi (1-N)
            modelBuilder.Entity<Daire>()
                .HasMany(d => d.Kiracıları)
                .WithOne(k => k.Daire)
                .HasForeignKey(k => k.DaireId)
                .OnDelete(DeleteBehavior.Cascade);

            // Daire - Hesap ilişkisi (1-N)
            modelBuilder.Entity<Daire>()
                .HasMany(d => d.Hesaplar)
                .WithOne(h => h.Daire)
                .HasForeignKey(h => h.DaireId)
                .OnDelete(DeleteBehavior.Cascade);

            // Hesap - HesapIslem ilişkisi (1-N)
            modelBuilder.Entity<Hesap>()
                .HasMany(h => h.Islemler)
                .WithOne(i => i.Hesap)
                .HasForeignKey(i => i.HesapId)
                .OnDelete(DeleteBehavior.Cascade);

            // Daire - Not ilişkisi (1-N)
            modelBuilder.Entity<Daire>()
                .HasMany(d => d.Notlar)
                .WithOne(n => n.Daire)
                .HasForeignKey(n => n.DaireId)
                .OnDelete(DeleteBehavior.Cascade);

            // Daire - Gecmis ilişkisi (1-N)
            modelBuilder.Entity<Daire>()
                .HasMany(d => d.Gecmisler)
                .WithOne(g => g.Daire)
                .HasForeignKey(g => g.DaireId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}