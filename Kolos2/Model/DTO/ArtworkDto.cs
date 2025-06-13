namespace Kolos2.Model.DTO;

public class ArtworkDto
{
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public decimal InsuranceValue { get; set; }
    public ArtistDto Artist { get; set; }
}
    