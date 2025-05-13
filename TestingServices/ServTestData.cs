using Core.Domain.Entities;
using Core.Domain.Models;

namespace TestingServices;

public class ServTestData
{
    public static readonly ForbiddenEntity[] ValidForbiddenEntities = {
        new ForbiddenEntity
        {
            EventId = "1",
            Alcohol = true,
            Bike = false,
            Camera = false,
            Hazard = false,
            Knife = false,
            Merch = false,
            Noise = false,
            Pets = false,
            Picnic = false,
            Pill = false,
            Tent = false,
            Umbrella = false
        }
    };
    public static readonly AddRulesForm[] ValidForbiddenAddForm = {
        new AddRulesForm
        {
            EventId = "1",
            Alcohol = true,
            Bike = false,
            Camera = false,
            Hazard = false,
            Knife = false,
            Merch = false,
            Noise = false,
            Pets = false,
            Picnic = false,
            Pill = false,
            Tent = false,
            Umbrella = false
        }
    };
    public static readonly UpdateRulesForm[] ValidUpdateForbiddenAddForm = {
        new UpdateRulesForm
        {
            EventId = "1",
            Alcohol = true,
            Bike = false,
            Camera = false,
            Hazard = false,
            Knife = false,
            Merch = false,
            Noise = false,
            Pets = false,
            Picnic = false,
            Pill = false,
            Tent = false,
            Umbrella = false
        }
    };
    public static readonly AddRulesForm[] InvalidForbiddenAddForm = {
        new AddRulesForm
        {
            EventId = "1",
        },
        new AddRulesForm
        {
            EventId = "2",
            Alcohol = false,
            Bike = false,
            Camera = false,
            Hazard = false,
        }
    };
}
