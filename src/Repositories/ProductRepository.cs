using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.Databases;
using Anime_figures_backend.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anime_figures_backend.src.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly DbSet<Product> _products;

    public ProductRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _products = databaseContext.Products;
    }

    public Product CreateOne(Product NewProduct)
    {
        _products.Add(NewProduct);
        _databaseContext.SaveChanges();
        return NewProduct;
    }

    public Product? DeleteOne(Guid id)
    {
        Product? FindProduct = FindOne(id);
        _products.Remove(FindProduct!);
        _databaseContext.SaveChanges();
        return FindProduct;
    }

    public IEnumerable<Product> FindAll()
    {
        IEnumerable<Product> Products = _products;
        return Products;
    }

    public Product? FindOne(Guid id)
    {
        Product? FindProduct = _products.FirstOrDefault(p => p.Id == id);
        return FindProduct;
    }

    public Product UpdateOne(Product UpdatedProduct)
    {
        _products.Update(UpdatedProduct);
        _databaseContext.SaveChanges();
        return UpdatedProduct;
    }
}
