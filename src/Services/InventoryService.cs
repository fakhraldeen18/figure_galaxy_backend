using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;
using AutoMapper;

namespace Anime_figures_backend.src.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }

    public InventoryReadDto? CreateOne(InventoryCreateDto NewInventory)
    {
        Inventory? Inventory = _mapper.Map<Inventory>(NewInventory);
        Inventory? CreatedInventory = _inventoryRepository.CreateOne(Inventory);
        if (CreatedInventory == null) return null;
        return _mapper.Map<InventoryReadDto>(CreatedInventory);
    }

    public bool DeleteOne(Guid id)
    {
        Inventory? FindInventory = _inventoryRepository.FindOne(id);
        if (FindInventory == null) return false;
        _inventoryRepository.DeleteOne(id);
        return true;
    }

    public IEnumerable<InventoryReadDto> FindAll()
    {
        IEnumerable<Inventory>? Inventories = _inventoryRepository.FindAll();
        IEnumerable<InventoryReadDto>? ReadInventories = _mapper.Map<IEnumerable<InventoryReadDto>>(Inventories);
        return ReadInventories;
    }

    public InventoryReadDto? FindOne(Guid id)
    {
        Inventory? FindInventory = _inventoryRepository.FindOne(id);
        if(FindInventory == null) return null;
        return _mapper.Map<InventoryReadDto>(FindInventory);
    }

    public InventoryReadDto? UpdateOne(Guid id, InventoryUpdateDto UpdateInventory)
    {
        Inventory? Inventory = _inventoryRepository.FindOne(id);
        if (Inventory == null) return null;
        Inventory.ProductId = UpdateInventory.ProductId;
        Inventory.Quantity = UpdateInventory.Quantity;
        Inventory.Price = UpdateInventory.Price;
        Inventory.Size = UpdateInventory.Size;
        _inventoryRepository.UpdateOne(Inventory);
        return _mapper.Map<InventoryReadDto>(Inventory);
    }
}
