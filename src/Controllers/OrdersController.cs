
using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Controllers;
public class OrdersController : CustomController
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<OrderReadDto>> FindAll()
    {
        return Ok(_orderService.FindAll());
    }

    [HttpPost("{Id}")]
    public ActionResult<OrderReadDto> CreateOne(string Id, [FromBody] List<CheckoutDto> CheckOutOrder)
    {
        if (Id == null && CheckOutOrder == null) return BadRequest();
        var createdOrder = _orderService.Checkout(CheckOutOrder, Id!);
        return CreatedAtAction(nameof(CreateOne), createdOrder);
    }
}
