using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;
using AutoMapper;

namespace Anime_figures_backend.src.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IInventoryService _inventoryService;
    private readonly IOrderItemService _orderItemService;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IInventoryService inventoryService, IOrderItemService orderItemService, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _inventoryService = inventoryService;
        _orderItemService = orderItemService;
        _mapper = mapper;
    }
    public OrderReadDto? Checkout(List<CheckoutDto> CheckOutOrder, string userId)
    {
        Order order = new();
        order.UserId = new Guid(userId);
        _orderRepository.CreateOne(order);
        foreach (var Item in CheckOutOrder)
        {
            var inventory = _inventoryService.FindAll().FirstOrDefault(i => i.ProductId == Item.ProductId && i.Size == Item.Size);
            if (inventory == null)
            {
                order.Status = "Failed";
                _orderRepository.DeleteOne(order.Id);
                continue;
            }
            if (Item.Quantity >= inventory.Quantity)
            {
                order.Status = "Failed";
                _orderRepository.DeleteOne(order.Id);
                continue;
            }
            OrderItemCreateDto orderItem = new()
            {
                OrderId = order.Id,
                InventoryId = inventory.Id,
                Quantity = Item.Quantity,
                TotalPrice = Item.Quantity * inventory.Price
            };
            int UpdatedQuantity = inventory.Quantity - Item.Quantity;
            _inventoryService.UpdateQuantity(inventory.Id, UpdatedQuantity);
            order.Status = "Succeed";
            _orderItemService.CreateOne(orderItem);
        }
        return _mapper.Map<OrderReadDto>(order);

    }

    public IEnumerable<OrderReadDto> FindAll()
    {
        IEnumerable<Order> orders = _orderRepository.FindAll();
        IEnumerable<OrderReadDto> readerOrder = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
        return readerOrder;
    }
}
