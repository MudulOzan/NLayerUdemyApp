using NLayer.Core.DTOs;

namespace NLayer.Core.Services;

public interface ICategoryService : IService<Category>
{
    public Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryByIdWithProductAsync(int categoryId);
}
