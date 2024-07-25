using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;
using AutoMapper;

namespace Anime_figures_backend.src.Mappers;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Category, CategoryReadDto>();
        CreateMap<CategoryCreateDto, Category>();

        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductCreateDto, Product>();

        CreateMap<Inventory, InventoryReadDto>();
        CreateMap<InventoryCreateDto, Inventory>();
    }
}
