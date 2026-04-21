using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallery.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(a => a.FullName).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Country).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.Property(aw => aw.Title).IsRequired().HasMaxLength(200);
                entity.Property(aw => aw.Price).HasColumnType("decimal(18,2)");

                entity.HasOne(aw => aw.Artist).WithMany(a => a.Artworks)
                .HasForeignKey(aw => aw.ArtistId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(aw => aw.Category).WithMany(c => c.Artworks)
                .HasForeignKey(aw => aw.CategoryId);
            });

            modelBuilder.Entity<Exhibition>(entety =>
            {
                entety.Property(e => e.Name).IsRequired().HasMaxLength(200);
            });
        }
    }
}
