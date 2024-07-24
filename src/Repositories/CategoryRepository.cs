using System.Data.Common;
using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.Databases;
using Anime_figures_backend.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anime_figures_backend.src.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly DbSet<Category> _categories;

    public CategoryRepository(DatabaseContext databaseContext)
    {
        _categories = databaseContext.Categories;
        _databaseContext = databaseContext;
    }
    public Category CreateOne(Category NewCategory)
    {
        _categories.Add(NewCategory);
        _databaseContext.SaveChanges();
        return NewCategory;
    }

    public Category? DeleteOne(Guid id)
    {
        Category? FindCategory = FindOne(id);
        _categories.Remove(FindCategory!);
        _databaseContext.SaveChanges();
        return FindCategory;

    }

    public IEnumerable<Category> FindAll()
    {
        var Categories = _categories;
        return Categories;
    }

    public Category? FindOne(Guid Id)
    {
        Category? FindCategory = FindAll().FirstOrDefault(c => c.Id == Id);
        return FindCategory;
    }

    public Category UpdateOne(Category UpdatedCategory)
    {
        _categories.Update(UpdatedCategory);
        _databaseContext.SaveChanges();
        return UpdatedCategory;
    }
}
