using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;

public interface IInventoryRepository
{

    public IEnumerable<Inventory> FindAll();
    public Inventory? FindOne(Guid id);
    public Inventory? CreateOne(Inventory NewInventory);
    public Inventory? DeleteOne(Guid id);
    public Inventory? UpdateOne(Inventory UpdateInventory);

}
