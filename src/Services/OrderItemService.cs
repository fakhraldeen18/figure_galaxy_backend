using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;
using AutoMapper;
namespace Anime_figures_backend.src.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public OrderItemReadDto? CreateOne(OrderItemCreateDto NewOrderItem)
    {
        OrderItem? OrderItem = _mapper.Map<OrderItem>(NewOrderItem);
        OrderItem? CreatedOrderItem = _orderItemRepository.CreateOne(OrderItem);
        return _mapper.Map<OrderItemReadDto>(CreatedOrderItem);
    }

    public IEnumerable<OrderItemReadDto> FindAll()
    {
        IEnumerable<OrderItem> OrderItems = _orderItemRepository.FindAll();
        IEnumerable<OrderItemReadDto> ReadOrderItems = _mapper.Map<IEnumerable<OrderItemReadDto>>(OrderItems);
        return ReadOrderItems;
    }
}
