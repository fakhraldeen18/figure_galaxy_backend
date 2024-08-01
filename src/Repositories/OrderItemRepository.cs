using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.Databases;
using Anime_figures_backend.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anime_figures_backend.src.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly DbSet<OrderItem> _orderItems;
    private readonly DatabaseContext _databaseContext;

    public OrderItemRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _orderItems = databaseContext.OrderItems;
    }

    public OrderItem? CreateOne(OrderItem NewOrderItem)
    {
        _orderItems.Add(NewOrderItem);
        _databaseContext.SaveChanges();
        return NewOrderItem;
    }

    public IEnumerable<OrderItem> FindAll()
    {
        return _orderItems;
    }
}
