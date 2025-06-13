using Kolos2.Model.DTO;

namespace Kolos2.Model;

public class Gallery
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }

    public IEnumerable<Exhibition>? Exhibitions { get; set; }
}
