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

    public bool DeleteOne(Guid Id)
    {
        Inventory? FindInventory = _inventoryRepository.FindOne(Id);
        if (FindInventory == null) return false;
        _inventoryRepository.DeleteOne(Id);
        return true;
    }

    public IEnumerable<InventoryReadDto> FindAll()
    {
        IEnumerable<Inventory>? Inventories = _inventoryRepository.FindAll();
        IEnumerable<InventoryReadDto>? ReadInventories = _mapper.Map<IEnumerable<InventoryReadDto>>(Inventories);
        return ReadInventories;
    }

    public InventoryReadDto? FindOne(Guid Id)
    {
        Inventory? FindInventory = _inventoryRepository.FindOne(Id);
        if (FindInventory == null) return null;
        return _mapper.Map<InventoryReadDto>(FindInventory);
    }

    public InventoryReadDto? UpdateOne(Guid Id, InventoryUpdateDto UpdateInventory)
    {
        Inventory? Inventory = _inventoryRepository.FindOne(Id);
        if (Inventory == null) return null;
        Inventory.ProductId = UpdateInventory.ProductId;
        Inventory.Quantity = UpdateInventory.Quantity;
        Inventory.Price = UpdateInventory.Price;
        Inventory.Size = UpdateInventory.Size;
        _inventoryRepository.UpdateOne(Inventory);
        return _mapper.Map<InventoryReadDto>(Inventory);
    }

    public InventoryReadDto? UpdateQuantity(Guid Id, int Quantity)
    {
        var findInventory = _inventoryRepository.FindOne(Id);
        if (findInventory == null) return null;
        findInventory.Quantity = Quantity;
        var UpdatedInventory = _inventoryRepository.UpdateOne(findInventory);
        return _mapper.Map<InventoryReadDto>(UpdatedInventory);
    }
}
