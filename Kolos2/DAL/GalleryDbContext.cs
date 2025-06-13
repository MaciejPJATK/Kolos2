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

            modelBuilder.Entity<Gallery>().HasData(
                new Gallery { GalleryId = 1, Name = "Modern Art Space", EstablishedDate = new DateTime(2001, 9, 12) }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, FirstName = "Pablo", LastName = "Picasso", BirthDate = new DateTime(1881, 10, 25) },
                new Artist { ArtistId = 2, FirstName = "Frida", LastName = "Kahlo", BirthDate = new DateTime(1907, 7, 6) }
            );

            modelBuilder.Entity<Artwork>().HasData(
                new Artwork { ArtworkId = 1, Title = "Guernica", YearCreated = 1937, ArtistId = 1 },
                new Artwork { ArtworkId = 2, Title = "The Two Fridas", YearCreated = 1939, ArtistId = 2 }
            );
        }
    }
}
