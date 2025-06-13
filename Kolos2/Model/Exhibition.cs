namespace Kolos2.Model;

public class Exhibition
{
    public int ExhibitionId { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public int GalleryId { get; set; }
    public Gallery Gallery { get; set; }

    public ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set; }
}
