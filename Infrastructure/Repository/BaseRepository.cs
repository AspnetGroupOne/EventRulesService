using Infrastructure.Classes.Responses;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository;

public class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();


    public virtual async Task<RepoResponse> CreateAsync(TEntity entity)
    {
        try
        {
            if (entity == null) 
            { return new RepoResponse { Success = false, StatusCode = 400, Message = "Entity is null." }; }

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new RepoResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new RepoResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }

    public virtual async Task<RepoResponse> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var exists = await _dbSet.AnyAsync(predicate);
            if (!exists) { return new RepoResponse { Success = false, StatusCode = 404, Message = $"{predicate} not found." }; }

            return new RepoResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new RepoResponse<IEnumerable<TEntity>> { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }


    public virtual async Task<RepoResponse> GetAsync(string id)
    {
        try
        {

        }
        catch (Exception ex) { return new RepoResponse<IEnumerable<TEntity>> { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }

    public virtual async Task<RepoResponse> GetAllAsync(string id)
    {
        try
        {

        }
        catch (Exception ex) { return new RepoResponse<IEnumerable<TEntity>> { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }

    public virtual async Task<RepoResponse> UpdateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
            { return new RepoResponse { Success = false, StatusCode = 400, Message = "Entity is null." }; }

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return new RepoResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new RepoResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }

    public virtual async Task<RepoResponse> RemoveAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
            { return new RepoResponse { Success = false, StatusCode = 400, Message = "Entity is null." }; }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return new RepoResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new RepoResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }
}
