using NLayer.Core.DTOs;
using System.Linq.Expressions;

namespace NLayer.Core.Services
{
    public interface IProductServiceWithDto<Entity, Dto> where Entity : BaseEntity where Dto : class
    {
        Task<CustomResponseDto<Dto>> GetByIdAsync(int id);
        Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync();
        Task<CustomResponseDto<IEnumerable<Dto>>> Where(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDto<Dto>> AddAsync(Dto dto);
        Task<CustomResponseDto<IEnumerable<Dto>>> AddRangedAsync(IEnumerable<Dto> dtos);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(Dto dto);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id);
        Task<CustomResponseDto<NoContentDto>> RemoveRangedAsync(IEnumerable<int> ids);
    }
}
