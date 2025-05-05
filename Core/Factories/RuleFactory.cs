using Core.Domain.Entities;
using Core.Domain.Models;

namespace Core.Factories;

public class RuleFactory
{
    public static ForbiddenEntity Create(AddRulesForm addRulesForm)
    {
        if (addRulesForm == null) { return null!; }

        var entity = new ForbiddenEntity() 
        { 
            EventId = addRulesForm.EventId,
            Alcohol = addRulesForm.Alcohol,
            Bike = addRulesForm.Bike,
            Camera = addRulesForm.Camera,
            Hazard = addRulesForm.Hazard,
            Knife = addRulesForm.Knife,
            Merch = addRulesForm.Merch,
            Noise = addRulesForm.Noise,
            Pets = addRulesForm.Pets,
            Picnic = addRulesForm.Picnic,
            Pill = addRulesForm.Pill,
            Tent = addRulesForm.Tent,
            Umbrella = addRulesForm.Umbrella
        };
        return entity;
    }

    public static ForbiddenEntity Create(UpdateRulesForm updateRulesForm)
    {
        if (updateRulesForm == null) { return null!; }

        var entity = new ForbiddenEntity()
        {
            EventId = updateRulesForm.EventId,
            Alcohol = updateRulesForm.Alcohol,
            Bike = updateRulesForm.Bike,
            Camera = updateRulesForm.Camera,
            Hazard = updateRulesForm.Hazard,
            Knife = updateRulesForm.Knife,
            Merch = updateRulesForm.Merch,
            Noise = updateRulesForm.Noise,
            Pets = updateRulesForm.Pets,
            Picnic = updateRulesForm.Picnic,
            Pill = updateRulesForm.Pill,
            Tent = updateRulesForm.Tent,
            Umbrella = updateRulesForm.Umbrella
        };
        return entity;
    }

    public static ForbiddenItem Create(ForbiddenEntity entity)
    {
        if (entity == null) { return null!; }

        var item = new ForbiddenItem() 
        { 
            EventId = entity.EventId,
            Alcohol = entity.Alcohol,
            Bike = entity.Bike,
            Camera = entity.Camera,
            Hazard = entity.Hazard,
            Knife = entity.Knife,
            Merch = entity.Merch,
            Noise = entity.Noise,
            Pets = entity.Pets,
            Picnic = entity.Picnic,
            Pill = entity.Pill,
            Tent = entity.Tent,
            Umbrella = entity.Umbrella,
        };
        return item;
    }
}
