using Core.Domain.Entities;
using Core.Domain.Models;

namespace Core.Factories;

public class RuleFactory
{
    public static ForbiddenEntity Create(string id, string item)
    {
        if (id == null) { return null!; }

        var entity = new ForbiddenEntity() 
        { 
            EventId = id,
            ItemName = item
        };
        return entity;
    }

    public static ForbiddenItem Create(ForbiddenEntity entity)
    {
        if (entity == null) { return null!; }

        var item = new ForbiddenItem() 
        { 
            EventId = entity.EventId,
            ItemName = entity.ItemName
        };
        return item;
    }
}
