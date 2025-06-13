namespace Kolos2.Model.DTO;
public class GalleryDto
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public IEnumerable<ExhibitionDetailsDto> Exhibitions { get; set; }
}