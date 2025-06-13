using Kolos2.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.DAL
{
    public class GalleryDbContext : DbContext
    {
        public GalleryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Gallery> Galleries => Set<Gallery>();
        public DbSet<Exhibition> Exhibitions => Set<Exhibition>();
        public DbSet<Artwork> Artworks => Set<Artwork>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<ExhibitionArtwork> ExhibitionArtworks => Set<ExhibitionArtwork>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ExhibitionArtwork composite key
            modelBuilder.Entity<ExhibitionArtwork>()
                .HasKey(ea => new { ea.ExhibitionId, ea.ArtworkId });

            modelBuilder.Entity<ExhibitionArtwork>()
                .HasOne(ea => ea.Exhibition)
                .WithMany(e => e.ExhibitionArtworks)
                .HasForeignKey(ea => ea.ExhibitionId);

            modelBuilder.Entity<ExhibitionArtwork>()
                .HasOne(ea => ea.Artwork)
                .WithMany(a => a.ExhibitionArtworks)
                .HasForeignKey(ea => ea.ArtworkId);

            modelBuilder.Entity<Exhibition>()
                .HasOne(e => e.Gallery)
                .WithMany(g => g.Exhibitions)
                .HasForeignKey(e => e.GalleryId);

            modelBuilder.Entity<Artwork>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Artworks)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<ExhibitionArtwork>()
                .Property(ea => ea.InsuranceValue)
                .HasPrecision(12, 2);
        }
    }
}