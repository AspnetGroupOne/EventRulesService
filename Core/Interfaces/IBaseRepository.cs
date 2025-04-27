using Core.Domain.Models;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<RepoResponse> CreateAsync(TEntity entity);
        Task<RepoResponse> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<RepoResponse<IEnumerable<TEntity>>> GetAllAsync();
        Task<RepoResponse<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<RepoResponse> RemoveAsync(TEntity entity);
        Task<RepoResponse> UpdateAsync(TEntity entity);
    }
}