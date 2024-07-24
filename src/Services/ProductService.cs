using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;
using AutoMapper;

namespace Anime_figures_backend.src.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public ProductReadDto? CreateOne(ProductCreateDto NewProduct)
    {
        Product? Product = _mapper.Map<Product>(NewProduct);
        Product? CreatedProduct = _productRepository.CreateOne(Product);
        if (CreatedProduct == null) return null;
        return _mapper.Map<ProductReadDto>(CreatedProduct);
    }

    public bool DeleteOne(Guid id)
    {
        Product? FindProduct = _productRepository.FindOne(id);
        if (FindProduct == null) return false;
        _productRepository.DeleteOne(id);
        return true;
    }

    public IEnumerable<ProductReadDto> FindAll()
    {
        IEnumerable<Entities.Product>? Products = _productRepository.FindAll();
        IEnumerable<ProductReadDto>? ReadProducts = _mapper.Map<IEnumerable<ProductReadDto>>(Products);
        return ReadProducts;
    }

    public ProductReadDto? FindOne(Guid id)
    {
        Product? FindProduct = _productRepository.FindOne(id);
        if (FindProduct == null) return null;
        return _mapper.Map<ProductReadDto>(FindProduct);

    }

    public ProductReadDto? UpdateOne(Guid id, ProductUpdateDto UpdatedProduct)
    {
        var Product = _productRepository.FindOne(id);
        if (Product == null) return null;
        Product.CategoryId = UpdatedProduct.CategoryId;
        Product.Name = UpdatedProduct.Name;
        Product.Description = UpdatedProduct.Description;
        _productRepository.UpdateOne(Product);
        return _mapper.Map<ProductReadDto>(Product);
    }
}
