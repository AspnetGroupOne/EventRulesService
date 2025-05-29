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
            if (rulesForm == null) { return new ItemResponse() { Success = false, StatusCode = 400, Message = "The form is null." }; }

            var entity = RuleFactory.Create(rulesForm);
            if (entity == null) { return new ItemResponse() { Success = false, StatusCode = 404, Message = "Entities is null." }; }

            var result = await _forbiddenItemRepository.CreateAsync(entity);
            if (!result.Success) { return new ItemResponse() { Success = false, StatusCode = 400, Message = "Something went wrong when adding the entity." }; }

            return new ItemResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }


    public async Task<ItemResponse<ForbiddenItem>> GetAForbiddenItem(string id)
    {
        try
        {
            var result = await _forbiddenItemRepository.GetAsync(entity => entity.EventId == id);
            if (result.Content == null) { return new ItemResponse<ForbiddenItem>() { Success = result.Success, StatusCode = result.StatusCode, Message = result.Message, Content = null }; }

            var item = RuleFactory.Create(result.Content);
            if (item == null) { return new ItemResponse<ForbiddenItem>() { Success = false, StatusCode = 400, Message = "Could not create the rule.", Content = null }; }

            return new ItemResponse<ForbiddenItem> { Success = true, StatusCode = 200, Content = item };
        }
        catch (Exception ex) { return new ItemResponse<ForbiddenItem> { Success = false, Message = $"{ex.Message}", StatusCode = 500, Content = null }; }
    }

    public async Task<ItemResponse> UpdateForbiddenItems(UpdateRulesForm updateRulesForm)
    {
        try
        {
            if (updateRulesForm == null) { return new ItemResponse() { Success = false, StatusCode = 400, Message = "The form is null." }; }

            var entity = RuleFactory.Create(updateRulesForm);
            if (entity == null) { return new ItemResponse() { Success = false, StatusCode = 400, Message = "Entity is null." }; }

            var result = await _forbiddenItemRepository.UpdateAsync(entity);
            if (!result.Success) { return new ItemResponse() { Success = false, StatusCode = 400, Message = "Something went wrong when updating." }; }

            return new ItemResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }
    public async Task<ItemResponse> RemoveForbiddenItem(string id)
    {
        try
        {
            if (id == null) { return new ItemResponse() { Success = false, StatusCode = 400, Message = "Id is null." }; }

            var result = await _forbiddenItemRepository.GetAsync(entity => entity.EventId == id);
            if (result.Content == null) { return new ItemResponse() { Success = false, StatusCode = 400, Message = "Entity is null." }; }

            var resultRemoval = await _forbiddenItemRepository.RemoveAsync(result.Content);
            if (!resultRemoval.Success) { return new ItemResponse() { Success = resultRemoval.Success, StatusCode = resultRemoval.StatusCode, Message = resultRemoval.Message }; }

            return new ItemResponse { Success = true, StatusCode = 200 };
        }
        catch (Exception ex) { return new ItemResponse { Success = false, Message = $"{ex.Message}", StatusCode = 500 }; }
    }
}
