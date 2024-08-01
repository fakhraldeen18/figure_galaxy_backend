using Anime_figures_backend.src.DTOs;

namespace Anime_figures_backend.src.Abstractions;

public interface IOrderItemService
{
    public IEnumerable<OrderItemReadDto> FindAll();
    public OrderItemReadDto? CreateOne(OrderItemCreateDto NewOrderItem);
}
