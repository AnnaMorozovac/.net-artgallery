using ArtGallery.BLL.DTOs;
using ArtGallery.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtworksController : ControllerBase
{
    private readonly IArtworkService _service;
    private readonly IBlobService _blobService;
    public ArtworksController(IArtworkService service, IBlobService blobService)
    {
        _service = service;
        _blobService = blobService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArtworkDto>>> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<ArtworkDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ArtworkDto>> Create([FromForm] CreateArtworkDto dto, IFormFile? imageFile)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            try
            {
                using var stream = imageFile.OpenReadStream();
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                string imageUrl = await _blobService.UploadFileAsync(stream, fileName, imageFile.ContentType);

                dto.ImageUrl = imageUrl;
            }
            catch (Exception ex)
            {
                return BadRequest($"Azure Error: {ex.Message}");
            }
        }

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateArtworkDto dto)
    {
        if (id != dto.Id) return BadRequest();
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}