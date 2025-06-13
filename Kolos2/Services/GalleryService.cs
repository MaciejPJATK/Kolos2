using Kolos2.DAL;
using Kolos2.Exceptions;
using Kolos2.Model;
using Kolos2.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Services;

public class GalleryService : IGalleryService
{
    private readonly GalleryDbContext _context;

    public GalleryService(GalleryDbContext context) => _context = context;

    public async Task<GalleryDto> GetGalleryExhibitionsAsync(int galleryId, CancellationToken token)
    {
        var gallery = await _context.Galleries
            .Include(g => g.Exhibitions)!
            .ThenInclude(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .FirstOrDefaultAsync(g => g.GalleryId == galleryId, token);

        if (gallery == null)
            throw new NotFoundException($"Gallery with id {galleryId} not found");

        return new GalleryDto
        {
            GalleryId = gallery.GalleryId,
            Name = gallery.Name,
            EstablishedDate = gallery.EstablishedDate,
            Exhibitions = gallery.Exhibitions.Select(e => new ExhibitionDetailsDto
            {
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                NumberOfArtworks = e.ExhibitionArtworks.Count,
                Artworks = e.ExhibitionArtworks.Select(ea => new ArtworkDto
                {
                    Title = ea.Artwork.Title,
                    YearCreated = ea.Artwork.YearCreated,
                    InsuranceValue = ea.InsuranceValue,
                    Artist = new ArtistDto
                    {
                        FirstName = ea.Artwork.Artist.FirstName,
                        LastName = ea.Artwork.Artist.LastName,
                        BirthDate = ea.Artwork.Artist.BirthDate
                    }
                }).ToList()
            }).ToList()
        };
    }
    public async Task AddExhibitionAsync(NewExhibitionRequest request, CancellationToken token)
    {
        var gallery = await _context.Galleries
            .FirstOrDefaultAsync(g => g.Name == request.Gallery, token);

        if (gallery == null)
            throw new NotFoundException($"Gallery '{request.Gallery}' not found");

        var artworks = await _context.Artworks
            .Where(a => request.Artworks.Select(x => x.ArtworkId).Contains(a.ArtworkId))
            .ToListAsync(token);

        if (artworks.Count != request.Artworks.Count)
            throw new NotFoundException("One or more artworks not found");

        var exhibition = new Exhibition
        {
            Title = request.Title,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            GalleryId = gallery.GalleryId,
            ExhibitionArtworks = request.Artworks.Select(x => new ExhibitionArtwork
            {
                ArtworkId = x.ArtworkId,
                InsuranceValue = x.InsuranceValue
            }).ToList()
        };

        _context.Exhibitions.Add(exhibition);
        await _context.SaveChangesAsync(token);
    }

}


/*
dotnet tool install --global dotnet-ef
dotnet --info
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet ef migrations add Init
dotnet ef database update
*/