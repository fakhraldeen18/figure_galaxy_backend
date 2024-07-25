using Anime_figures_backend.src.Abstractions;
using Anime_figures_backend.src.DTOs;
using Anime_figures_backend.src.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Anime_figures_backend.src.Services;
public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IMapper _mapper;

    public ImageService(IImageRepository imageRepository, IMapper mapper)
    {
        _imageRepository = imageRepository;
        _mapper = mapper;
    }

    public ImageReadDto? CreateOne(ImageCreateDto NewImage)
    {
        Image? Image = _mapper.Map<Image>(NewImage);
        Image? CreateImage = _imageRepository.CreateOne(Image);
        if (CreateImage == null) return null;
        return _mapper.Map<ImageReadDto>(CreateImage);
    }

    public bool DeleteOne(Guid id)
    {
        var FindImage = _imageRepository.FindOne(id);
        if (FindImage == null) return false;
        _imageRepository.DeleteOne(id);
        return true;
    }

    public IEnumerable<ImageReadDto> FindAll()
    {
        IEnumerable<Image> Images = _imageRepository.FindAll();
        IEnumerable<ImageReadDto> ReadImages = _mapper.Map<IEnumerable<ImageReadDto>>(Images);
        return ReadImages;
    }

    public ImageReadDto? FindOne(Guid id)
    {
        Image? FindImage = _imageRepository.FindOne(id);
        if (FindImage == null) return null;
        return _mapper.Map<ImageReadDto>(FindImage);
    }

    public ImageReadDto? UpdateOne(Guid id, ImageUpdateDto UpdateImage)
    {
        Image? Image = _imageRepository.FindOne(id);
        if (Image == null) return null;
        Image.InventoryId = UpdateImage.InventoryId;
        Image.Url = UpdateImage.Url;
        Image.IsPrimary = UpdateImage.IsPrimary;
        _imageRepository.UpdateOne(Image);
        return _mapper.Map<ImageReadDto>(Image);
    }
}
