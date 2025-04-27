using Core.Domain.Models;

namespace Infrastructure.Classes.Responses;

public class RepoResponse : ResultResponse
{
    
}
public class RepoResponse<T> : RepoResponse
{
    public T? Content { get; set; }
}