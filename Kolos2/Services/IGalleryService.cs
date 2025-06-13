using Kolos2.Model.DTO;

namespace Kolos2.Services;

public interface IGalleryService
{
    Task<GalleryDto> GetGalleryExhibitionsAsync(int galleryid, CancellationToken token);
    
    // Task AddCustomerWithTicketsAsync(InsertCustomerWithTicketsRequest request, CancellationToken token);
}