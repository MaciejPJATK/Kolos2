namespace Kolos2.Model;

public class ExhibitionArtwork
{
    public int ExhibitionId { get; set; }
    public Exhibition Exhibition { get; set; }

    public int ArtworkId { get; set; }
    public Artwork Artwork { get; set; }

    public decimal InsuranceValue { get; set; }
}
