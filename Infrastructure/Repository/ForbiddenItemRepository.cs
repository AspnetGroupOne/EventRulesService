using Core.Domain.Entities;
using Core.Domain.Models.Reponses;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ForbiddenItemRepository(DataContext context) : BaseRepository<ForbiddenEntity>(context), IForbiddenItemRepository
{
    public async Task<RepoResponse<IEnumerable<ForbiddenEntity>>> GetAllItemsAsync(string id)
    {
        try
        {
            if (id == null) { return new RepoResponse<IEnumerable<ForbiddenEntity>> { Success = false, StatusCode = 400, Message = "The id is null", Content = [] }; }

            var entities = await _dbSet.Where(item => item.EventId == id ).ToListAsync();

            return new RepoResponse<IEnumerable<ForbiddenEntity>> { Success = true, StatusCode = 200, Content = entities };
        }
        catch (Exception ex) { return new RepoResponse<IEnumerable<ForbiddenEntity>> { Success = false, StatusCode = 500, Message = $"{ex.Message}", Content = [] }; }
    }


    public async Task<RepoResponse> RemoveAllById(string id)
    {
        try
        {
            if (id == null) { return new RepoResponse() { Success = false, StatusCode = 400, Message = "The id is null" }; }

            var entities = await _dbSet.Where(item => item.EventId == id).ToListAsync();
            if (entities.Count == 0) { return new RepoResponse() { Success = false, StatusCode = 404, Message = "No entities found." }; }

            foreach (var entity in entities)
            {
                _dbSet.Remove(entity);
            }
            await _context.SaveChangesAsync();
            return new RepoResponse() { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new RepoResponse() { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }
}
