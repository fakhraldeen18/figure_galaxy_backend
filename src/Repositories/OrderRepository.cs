using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.Databases;
using Anime_figures_backend.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anime_figures_backend.src.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DbSet<Order> _orders;
    private readonly DatabaseContext _databaseContext;

    public OrderRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _orders = databaseContext.Orders;
    }

    public Order? CreateOne(Order NewOrder)
    {
        _orders.Add(NewOrder);
        _databaseContext.SaveChanges();
        return NewOrder;
    }

    public Order? DeleteOne(Guid id)
    {
        var FindOrder = _orders.FirstOrDefault(o => o.Id == id);
        _orders.Remove(FindOrder!);
        _databaseContext.SaveChanges();
        return FindOrder;
    }

    public IEnumerable<Order> FindAll()
    {
        return _orders;
    }
}
