using Core.External.Models;

namespace Core.External.Interfaces
{
    public interface IEventValidationService
    {
        Task<ExternalResponse> EventExistanceCheck(string eventId);
    }
}