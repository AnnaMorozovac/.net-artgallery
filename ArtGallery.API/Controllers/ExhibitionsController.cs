using ArtGallery.BLL.DTOs;
using ArtGallery.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExhibitionsController : ControllerBase
{
    private readonly IExhibitionService _service;

    public ExhibitionsController(IExhibitionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExhibitionDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExhibitionDto>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ExhibitionDto>> Create(CreateExhibitionDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateExhibitionDto dto)
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