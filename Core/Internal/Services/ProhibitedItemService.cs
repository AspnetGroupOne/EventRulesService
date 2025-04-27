using Core.Domain.Models;
using Core.Interfaces;

namespace Core.Internal.Services;

public class ProhibitedItemService(IProhibitedItemRepository prohibitedItemRepository)
{
    private readonly IProhibitedItemRepository _prohibitedItemRepository = prohibitedItemRepository;

    public async Task<ItemResponse> AddItem()
    {
        try
        {

        }
        catch (Exception ex) { return new ItemResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }
    public async Task<ItemResponse> GetItems()
    {
        try
        {
            var items = 
        }
        catch (Exception ex) { return new ItemResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }
    public async Task<ItemResponse> UpdateItems()
    {
        try
        {

        }
        catch (Exception ex) { return new ItemResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }
    public async Task<ItemResponse> DeleteItems(string id)
    {
        try
        {

        }
        catch (Exception ex) { return new ItemResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }

}
