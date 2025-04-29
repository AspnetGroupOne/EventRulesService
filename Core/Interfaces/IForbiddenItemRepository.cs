using Core.Domain.Entities;
using Core.Domain.Models.Reponses;
using Core.Interfaces;

namespace Infrastructure.Repository;

public interface IForbiddenItemRepository : IBaseRepository<ForbiddenEntity>
{
    Task<RepoResponse<IEnumerable<ForbiddenEntity>>> GetAllItemsAsync(string id);
    Task<RepoResponse> RemoveAllById(string id);
}