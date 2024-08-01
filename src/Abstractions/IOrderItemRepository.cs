using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;

public interface IOrderItemRepository
{
    public IEnumerable<OrderItem> FindAll();
    public OrderItem? CreateOne(OrderItem NewOrderItem);
}
