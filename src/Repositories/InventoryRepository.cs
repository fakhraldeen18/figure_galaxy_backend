using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.Databases;
using Anime_figures_backend.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anime_figures_backend.src.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly DbSet<Inventory> _inventories;
    private readonly DatabaseContext _databaseContext;

    public InventoryRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _inventories = databaseContext.Inventories;
    }

    public Inventory? CreateOne(Inventory NewInventory)
    {
        _inventories.Add(NewInventory);
        _databaseContext.SaveChanges();
        return NewInventory;
    }

    public Inventory? DeleteOne(Guid id)
    {
        Inventory? FindInventory = FindOne(id);
        _inventories.Remove(FindInventory!);
        _databaseContext.SaveChanges();
        return FindInventory;
    }

    public IEnumerable<Inventory> FindAll()
    {
        var Inventories = _inventories;
        return Inventories;
    }

    public Inventory? FindOne(Guid id)
    {
        Inventory? FindInventory = _inventories.FirstOrDefault(i => i.Id == id);
        return FindInventory;
    }

    public Inventory? UpdateOne(Inventory UpdateInventory)
    {
        _inventories.Update(UpdateInventory);
        _databaseContext.SaveChanges();
        return UpdateInventory;
    }
}
