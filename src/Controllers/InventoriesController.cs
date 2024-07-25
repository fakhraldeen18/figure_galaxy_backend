using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Controllers;

public class InventoriesController : CustomController
{
    private readonly IInventoryService _inventoryService;

    public InventoriesController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<InventoryReadDto>> FindAll()
    {
        IEnumerable<InventoryReadDto>? Inventories = _inventoryService.FindAll();
        return Ok(Inventories);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<InventoryReadDto> FindOne(Guid Id)
    {
        InventoryReadDto? FindInventory = _inventoryService.FindOne(Id);
        if (FindInventory == null) return NotFound();
        return Ok(FindInventory);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<InventoryReadDto> CreateOne([FromBody] InventoryCreateDto NewInventory)
    {
        InventoryReadDto? CreatedInventory = _inventoryService.CreateOne(NewInventory);
        if (CreatedInventory == null) return BadRequest();
        return CreatedAtAction(nameof(CreateOne), CreatedInventory);
    }

    [HttpDelete("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid Id)
    {
        InventoryReadDto? FindInventory = _inventoryService.FindOne(Id);
        if (FindInventory == null) return NotFound();
        _inventoryService.DeleteOne(Id);
        return NoContent();
    }

    [HttpPatch("{Id}")]
    public ActionResult<InventoryReadDto> UpdateOne(Guid Id, [FromBody] InventoryUpdateDto UpdateInventory)
    {
        InventoryReadDto? FindInventory = _inventoryService.FindOne(Id);
        if (FindInventory == null) return NotFound();
        InventoryReadDto? UpdatedInventory = _inventoryService.UpdateOne(Id, UpdateInventory);
        return Accepted(UpdatedInventory);
    }
}
