
namespace Core.Domain.Models;

public class ItemResponse : ResultResponse
{
}
public class ItemResponse<T> : ItemResponse
{
    public T? Content { get; set; }
}
