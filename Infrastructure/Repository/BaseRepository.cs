using Infrastructure.Context;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Core.Domain.Models.Reponses;

namespace Infrastructure.Repository;

public class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
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
            if (!exists) { return new RepoResponse { Success = false, StatusCode = 404, Message = "Entity not found." }; }

            return new RepoResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new RepoResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }


    public virtual async Task<RepoResponse<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(predicate);
            if (entity == null) { return new RepoResponse<TEntity> { Success = false, StatusCode = 404, Message = "Entity is null." }; }

            return new RepoResponse<TEntity> { Success = true, StatusCode = 200, Content = entity };
        }
        catch (Exception ex) { return new RepoResponse<TEntity> { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }

    public virtual async Task<RepoResponse<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _dbSet.ToListAsync();
            return new RepoResponse<IEnumerable<TEntity>> { Success = true, StatusCode = 200, Content = entities };
        }
        catch (Exception ex) { return new RepoResponse<IEnumerable<TEntity>> { Success = false, Message = $"{ex.Message}", StatusCode = 500, Content = [] }; }
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
