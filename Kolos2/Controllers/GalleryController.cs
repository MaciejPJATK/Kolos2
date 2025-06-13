using Kolos2.Model.DTO;
using Kolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos2.Controllers;

[ApiController]
public class GalleryController : ControllerBase
{
    private readonly IGalleryService _galleryService;

    public GalleryController(IGalleryService galleryService)
    {
        _galleryService = galleryService;
    }

    [HttpGet("api/galleries/{id}/exhibitions")]
    public async Task<IActionResult> GetGalleryExhibitions(int id, CancellationToken token)
    {
        var response = await _galleryService.GetGalleryExhibitionsAsync(id, token);
        return Ok(response);
    }

    // [HttpPost("api/exhibitions")]
    // public async Task<IActionResult> AddCustomerWithTickets([FromBody] InsertCustomerWithTicketsRequest request, CancellationToken token)
    // {
    //     await _galleryService.AddCustomerWithTicketsAsync(request, token);
    //     return StatusCode(201);
    // }
}