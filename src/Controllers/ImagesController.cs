using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Controllers;
public class ImagesController : CustomController
{
    private readonly IImageService _imageService;

    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ImageReadDto>> FindAll()
    {
        IEnumerable<ImageReadDto> Images = _imageService.FindAll();
        return Ok(Images);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ImageReadDto> FindOne(Guid Id)
    {
        ImageReadDto? FindImage = _imageService.FindOne(Id);
        if (FindImage == null) return NotFound();
        return Ok(FindImage);
    }

    [HttpPost]
    [Authorize(Roles = "Admin , SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ImageReadDto> CreateOne([FromBody] ImageCreateDto NewImage)
    {
        if (NewImage == null) return BadRequest();
        ImageReadDto? CreateImage = _imageService.CreateOne(NewImage);
        return CreatedAtAction(nameof(CreateOne), CreateImage);
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid Id)
    {
        ImageReadDto? FindImage = _imageService.FindOne(Id);
        if (FindImage == null) return NotFound();
        _imageService.DeleteOne(Id);
        return NoContent();
    }

    [HttpPatch("{Id}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ImageReadDto> UpdateOne(Guid Id , [FromBody]ImageUpdateDto UpdateImage)
    {
        ImageReadDto? FindImage = _imageService.FindOne(Id);
        if (FindImage == null) return NotFound();
        ImageReadDto? UpdatedImage = _imageService.UpdateOne(Id, UpdateImage);
        return Accepted(UpdatedImage);
    }
}
