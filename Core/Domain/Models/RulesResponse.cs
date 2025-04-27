
namespace Core.Domain.Models;

public class RulesResponse : ResultResponse
{
}
public class RulesResponse<T> : RulesResponse
{
    public T? Content { get; set; }
}
