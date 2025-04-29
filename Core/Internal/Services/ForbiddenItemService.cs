using Core.Domain.Models;
using Core.Domain.Models.Reponses;
using Core.Factories;
using Core.Interfaces;
using Infrastructure.Repository;

namespace Core.Internal.Services;

public class ForbiddenItemService(IForbiddenItemRepository forbiddenItemRepository) : IForbiddenItemService
{
    private readonly IForbiddenItemRepository _forbiddenItemRepository = forbiddenItemRepository;

    public async Task<ItemResponse> AddAForbiddenItem(AddRulesForm rulesForm)
    {
        try
        {
            if (rulesForm == null) { return new ItemResponse() { Success = false, StatusCode = 500, Message = "The form is null." }; }

            var entities = rulesForm.RuleItems.Select(rule => RuleFactory.Create(rulesForm.EventId, rule)).ToList();
            if (entities == null) { return new ItemResponse() { Success = false, StatusCode = 500, Message = "Entities is null." }; }

            foreach ( var entity in entities ) { await _forbiddenItemRepository.CreateAsync(entity); }
            
            return new ItemResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }

    //Dont know if i need this..

    //public async Task<ItemResponse> GetAForbiddenItem(string id)
    //{
    //    try
    //    {
    //        return new ItemResponse<ForbiddenItem> { Success = true, StatusCode = 200, Content = ruleItem };
    //    }
    //    catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    //}

    public async Task<ItemResponse> GetAllForbiddenItemsById(string id)
    {
        try
        {
            var result = await _forbiddenItemRepository.GetAllItemsAsync(id);

            if (result.Content == null) { return new ItemResponse() { Success = false, StatusCode = 500, Message = "Entities is null." }; }

            var entities = result.Content.Select(RuleFactory.Create).ToList();
            return new ItemResponse<IEnumerable<ForbiddenItem>> { Success = true, StatusCode = 200, Content = entities };
        }
        catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }

    public async Task<ItemResponse> UpdateForbiddenItems(UpdateRulesForm updateRulesForm)
    {
        try
        {
            //Create a check if the entity with the item is in the db or not. If in updateform and not in DB then add and remove if reverse.




            return new ItemResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }
    public async Task<ItemResponse> RemoveForbiddenItems(string id)
    {
        try
        {
            if (id == null) { return new ItemResponse() { Success = false, StatusCode = 500, Message = "Id is null." }; }

            var result = await _forbiddenItemRepository.RemoveAllById(id);
            if (!result.Success) { return new ItemResponse() { Success = false, StatusCode = 500, Message = "Something went wrong when removing entities." }; }

            return new ItemResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }
}
