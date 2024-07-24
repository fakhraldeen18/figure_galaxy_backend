using Anime_figures_backend.src.DTOs;

namespace Anime_figures_backend.src.Abstractions;

public interface IProductService
{

    public IEnumerable<ProductReadDto> FindAll();
    public ProductReadDto? FindOne(Guid id);
    public ProductReadDto? CreateOne(ProductCreateDto NewProduct);
    public bool DeleteOne(Guid id);
    public ProductReadDto? UpdateOne(Guid id, ProductUpdateDto UpdatedProduct);

}
