using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;

public interface IOrderRepository
{
    public IEnumerable<Order> FindAll();
    public Order? CreateOne(Order NewOrder);
    public Order? DeleteOne(Guid id);
}
