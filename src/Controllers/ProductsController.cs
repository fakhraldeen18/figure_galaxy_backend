using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Controllers;

public class ProductsController : CustomController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProductReadDto>> FindAll()
    {
        return Ok(_productService.FindAll());
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProductReadDto> FindOne(Guid Id)
    {
        ProductReadDto? FindProduct = _productService.FindOne(Id);
        if (FindProduct == null) return NotFound();
        return Ok(FindProduct);
    }

    [HttpPost]
    [Authorize(Roles = "Admin , SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductReadDto> CreateOne([FromBody] ProductCreateDto NewProduct)
    {
        if (NewProduct == null) return BadRequest();
        ProductReadDto? CreatedProduct = _productService.CreateOne(NewProduct);
        return CreatedAtAction(nameof(CreateOne), CreatedProduct);
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid Id)
    {
        ProductReadDto? FindProduct = _productService.FindOne(Id);
        if (FindProduct == null) return NotFound();
        _productService.DeleteOne(Id);
        return NoContent();
    }

    [HttpPatch("{Id}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProductReadDto> UpdateOne(Guid Id, [FromBody] ProductUpdateDto UpdateProduct)
    {
        ProductReadDto? findProduct = _productService.FindOne(Id);
        if (findProduct == null) return NotFound();
        ProductReadDto? UpdatedProduct = _productService.UpdateOne(Id, UpdateProduct);
        return Accepted(UpdatedProduct);
    }
}
