namespace Kolos2.Model.DTO;

public class NewExhibitionRequest
{
    public string Title { get; set; }
    public string Gallery { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<NewExhibitionArtworkDto> Artworks { get; set; }
}

