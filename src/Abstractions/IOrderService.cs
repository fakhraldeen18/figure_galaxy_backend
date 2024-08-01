using Anime_figures_backend.src.DTOs;

namespace Anime_figures_backend.src.Abstractions;

public interface IOrderService
{
    public IEnumerable<OrderReadDto> FindAll();
    public OrderReadDto Checkout(List<CheckoutDto> CheckOutOrder, string userId);
}
