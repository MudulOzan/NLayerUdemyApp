using AutoMapper;
using Microsoft.AspNetCore.Http;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;

namespace NLayer.Service.Services
{
    public class ProductServiceWithDto : ServiceWithDto<Product, ProductDto>, IProductServiceWithDto
    {
        private readonly IProductRepository _productRepository;

        public ProductServiceWithDto(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto dto)
        {
            var newEntity = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = _mapper.Map<ProductDto>(newEntity);

            return CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<ProductWithCategory>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategory>>(products);
            return CustomResponseDto<List<ProductWithCategory>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            _productRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<IEnumerable<ProductDto>>> AddRangedAsync(IEnumerable<ProductCreateDto> dtos)
        {
            var newEntities = _mapper.Map<IEnumerable<Product>>(dtos);

            await _productRepository.AddRangedAsync(newEntities);
            await _unitOfWork.CommitAsync();

            var newDtos = _mapper.Map<IEnumerable<ProductDto>>(newEntities);
            return CustomResponseDto<IEnumerable<ProductDto>>.Success(StatusCodes.Status200OK, newDtos);
        }
    }
}
