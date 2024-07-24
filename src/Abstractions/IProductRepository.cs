using Anime_figures_backend.src.Entities;

namespace Anime_figures_backend.src.Abstractions;

public interface IProductRepository
{

    public IEnumerable<Product> FindAll();
    public Product? FindOne(Guid id);
    public Product CreateOne(Product NewProduct);
    public Product? DeleteOne (Guid id);
    public Product UpdateOne (Product UpdatedProduct);

}
