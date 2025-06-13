namespace Kolos2.Model;

public class Artist
{
    public int ArtistId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public ICollection<Artwork> Artworks { get; set; }
}
