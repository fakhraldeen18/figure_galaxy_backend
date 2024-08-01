using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Controllers;
public class OrderItemsController : CustomController
{
    private readonly IOrderItemService _orderItemsService;

    public OrderItemsController(IOrderItemService orderItemsService)
    {
        _orderItemsService = orderItemsService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<OrderItemReadDto>> FindAll()
    {
        return Ok(_orderItemsService.FindAll());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderItemReadDto> CreateOne([FromBody] OrderItemCreateDto NewOrderItem)
    {
        var CreatedOrderItems = _orderItemsService.CreateOne(NewOrderItem);
        if (CreatedOrderItems == null) return BadRequest();
        return CreatedAtAction(nameof(CreateOne), CreatedOrderItems);

    }
}
