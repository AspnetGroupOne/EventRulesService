using Core.Domain.Models;

namespace Presentation.Factory;

public class FormFactory
{
    public static AddRulesForm Create(AddRulesRequest addRulesRequest)
    {
        if (addRulesRequest == null) return null!;

        var addRulesForm = new AddRulesForm() 
        {
            EventId = addRulesRequest.EventId,
            Alcohol = addRulesRequest.Alcohol,
            Bike = addRulesRequest.Bike,
            Camera = addRulesRequest.Camera,
            Hazard = addRulesRequest.Hazard,
            Knife = addRulesRequest.Knife,
            Merch = addRulesRequest.Merch,
            Noise = addRulesRequest.Noise,
            Pets = addRulesRequest.Pets,
            Picnic = addRulesRequest.Picnic,
            Pill = addRulesRequest.Pill,
            Tent = addRulesRequest.Tent,
            Umbrella = addRulesRequest.Umbrella,
        };
        return addRulesForm;
    }

    public static UpdateRulesForm Create(UpdateRulesRequest updateRulesRequest)
    {
        if (updateRulesRequest == null) return null!;

        var updateRulesForm = new UpdateRulesForm()
        {
            EventId = updateRulesRequest.EventId,
            Alcohol = updateRulesRequest.Alcohol,
            Bike = updateRulesRequest.Bike,
            Camera = updateRulesRequest.Camera,
            Hazard = updateRulesRequest.Hazard,
            Knife = updateRulesRequest.Knife,
            Merch = updateRulesRequest.Merch,
            Noise = updateRulesRequest.Noise,
            Pets = updateRulesRequest.Pets,
            Picnic = updateRulesRequest.Picnic,
            Pill = updateRulesRequest.Pill,
            Tent = updateRulesRequest.Tent,
            Umbrella = updateRulesRequest.Umbrella
        };
        return updateRulesForm;
    }

}
