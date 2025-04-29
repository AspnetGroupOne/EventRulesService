using Core.Domain.Models;
using Core.Domain.Models.Reponses;

namespace Core.Interfaces
{
    public interface IForbiddenItemService
    {
        Task<ItemResponse> AddAForbiddenItem(AddRulesForm addRulesForm);

        //Dont know if i will need this..
        //Task<ItemResponse> GetAForbiddenItem(string id);
        Task<ItemResponse> GetAllForbiddenItemsById(string id);
        Task<ItemResponse> RemoveForbiddenItems(string id);
        Task<ItemResponse> UpdateForbiddenItems(UpdateRulesForm updateRulesForm);
    }
}