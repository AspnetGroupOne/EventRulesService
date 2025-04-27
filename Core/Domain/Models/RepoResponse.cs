namespace Core.Domain.Models;

public class RepoResponse : ResultResponse
{
    
}
public class RepoResponse<T> : RepoResponse
{
    public T? Content { get; set; }
}