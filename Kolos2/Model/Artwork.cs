namespace Kolos2.Model;

public class Artwork
{
    public int ArtworkId { get; set; }
    public string Title { get; set; }
    public int YearCreated { get; set; }

    public int ArtistId { get; set; }
    public Artist Artist { get; set; }

    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; }
}
