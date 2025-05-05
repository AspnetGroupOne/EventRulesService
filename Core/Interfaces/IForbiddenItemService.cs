using Core.Domain.Models;
using Core.Domain.Models.Reponses;

namespace Core.Interfaces
{
    public interface IForbiddenItemService
    {
        Task<ItemResponse> AddAForbiddenItem(AddRulesForm addRulesForm);
        Task<ItemResponse> GetAForbiddenItem(string id);
        Task<ItemResponse> RemoveForbiddenItem(string id);
        Task<ItemResponse> UpdateForbiddenItems(UpdateRulesForm updateRulesForm);
    }
}