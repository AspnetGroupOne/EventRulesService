namespace Core.Domain.Models.Reponses;

public class ItemResponse : ResultResponse
{
}
public class ItemResponse<T> : ItemResponse
{
    public T? Content { get; set; }
}
