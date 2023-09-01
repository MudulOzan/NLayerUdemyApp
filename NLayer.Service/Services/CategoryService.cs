using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;

namespace NLayer.Service.Services;

public class CategoryService : Service<Category>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryByIdWithProductAsync(int categoryId)
    {
        var category = await _categoryRepository.GetSingleCategoryByIdWithProductAsync(categoryId);

        var categoryDto = _mapper.Map<CategoryWithProductDto>(category);

        return CustomResponseDto<CategoryWithProductDto>.Success(200, categoryDto);
    }
}
