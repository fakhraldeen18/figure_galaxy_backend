using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;
using AutoMapper;

namespace Anime_figures_backend.src.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public CategoryReadDto CreateOne(CategoryCreateDto NewCategory)
    {
        Category category = _mapper.Map<Category>(NewCategory);
        Category? CreatedCategory = _categoryRepository.CreateOne(category);
        CategoryReadDto? ReadCategory = _mapper.Map<CategoryReadDto>(CreatedCategory);
        return ReadCategory;
    }

    public bool DeleteOne(Guid id)
    {
        var FindCategory = _categoryRepository.FindOne(id);
        if (FindCategory == null) return false;
        _categoryRepository.DeleteOne(id);
        return true;
    }

    public IEnumerable<CategoryReadDto> FindAll()
    {
        IEnumerable<Category> categories = _categoryRepository.FindAll();
        IEnumerable<CategoryReadDto> readCategories = _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
        return readCategories;
    }

    public CategoryReadDto? FindOne(Guid Id)
    {
        Category? FindCategory = _categoryRepository.FindOne(Id);
        if(FindCategory == null) return null;
        return _mapper.Map<CategoryReadDto>(FindCategory);
    }

    public CategoryReadDto? UpdateOne(Guid id,CategoryUpdateDto UpdatedCategory)
    {
        var category = _categoryRepository.FindOne(id);
        if (category == null) return null;
        category.Type = UpdatedCategory.Type;
        _categoryRepository.UpdateOne(category);
        return _mapper.Map<CategoryReadDto>(category);
    }
}
