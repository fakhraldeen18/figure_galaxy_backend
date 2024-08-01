using Anime_figures_backend.src.DTOs;

namespace Anime_figures_backend.src.Abstractions;

public interface IInventoryService
{
    public IEnumerable<InventoryReadDto> FindAll();
    public InventoryReadDto? FindOne(Guid id);
    public InventoryReadDto? CreateOne(InventoryCreateDto NewInventory);
    public bool DeleteOne(Guid id);
    public InventoryReadDto? UpdateOne(Guid id, InventoryUpdateDto UpdateInventory);
    public InventoryReadDto? UpdateQuantity(Guid id, int Quantity);

}
