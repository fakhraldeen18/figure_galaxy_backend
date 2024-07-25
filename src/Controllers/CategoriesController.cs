using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Controllers;
public class CategoriesController : CustomController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<CategoryReadDto>> FindAll()
    {
        return Ok(_categoryService.FindAll());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CategoryReadDto> CreateOne([FromBody] CategoryCreateDto NewCategory)
    {
        CategoryReadDto? CreatedCategory = _categoryService.CreateOne(NewCategory);
        if (CreatedCategory == null) return BadRequest();
        return CreatedAtAction(nameof(CreateOne), CreatedCategory);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CategoryReadDto> FindOne(Guid Id)
    {
        CategoryReadDto? FindCategory = _categoryService.FindOne(Id);
        if (FindCategory == null) return NotFound();
        return Ok(FindCategory);
    }

    [HttpDelete("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid Id)
    {
        CategoryReadDto? FindCategory = _categoryService.FindOne(Id);
        if (FindCategory == null) return NotFound();
        _categoryService.DeleteOne(Id);
        return NoContent();
    }

    [HttpPatch("{Id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CategoryReadDto> UpdateOne(Guid Id, [FromBody] CategoryUpdateDto UpdateCategory)
    {
        CategoryReadDto? FindCategory = _categoryService.FindOne(Id);
        if (FindCategory == null) return NotFound();
        CategoryReadDto? UpdatedCategory = _categoryService.UpdateOne(Id, UpdateCategory);
        return Accepted(UpdatedCategory);

    }
}
