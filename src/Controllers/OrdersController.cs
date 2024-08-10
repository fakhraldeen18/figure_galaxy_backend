using System.Security.Claims;
using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Enums;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost]
    [Authorize(Roles = "Admin , SuperAdmin , Customer")]
    public ActionResult<OrderReadDto> CreateOne([FromBody] List<CheckoutDto> CheckOutOrder)
    {
        string? Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (Id == null && CheckOutOrder == null) return BadRequest();
        var createdOrder = _orderService.Checkout(CheckOutOrder, Id!);
        return CreatedAtAction(nameof(CreateOne), createdOrder);
    }
}
