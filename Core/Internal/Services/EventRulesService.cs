using Core.Domain.Models;

namespace Core.Internal.Services;

public class EventRulesService
{
    public async Task<RulesResponse> AddRules()
    {
        try
        {

        }
        catch (Exception ex) { return new RulesResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }
    public async Task<RulesResponse> GetRules()
    {
        try
        {

        }
        catch (Exception ex) { return new RulesResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }
    
    public async Task<RulesResponse> UpdateRules()
    {
        try
        {

        }
        catch (Exception ex) { return new RulesResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }

    public async Task<RulesResponse> DeleteRules()
    {
        try
        {

        }
        catch (Exception ex) { return new RulesResponse { Success = false, StatusCode = 500, Message = $"{ex.Message}" }; }
    }

}
