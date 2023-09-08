using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface IProductServiceWithDto : IProductServiceWithDto<Product, ProductDto>
    {
        Task<CustomResponseDto<List<ProductWithCategory>>> GetProductsWithCategory();

        Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto);

        Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto dto);

    }
}
