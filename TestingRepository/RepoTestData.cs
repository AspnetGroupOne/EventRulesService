using Core.Domain.Entities;

namespace TestingRepository;

public class RepoTestData
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
        },
        new ForbiddenEntity
        {
            EventId = "2",
            Alcohol = false,
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
    public static readonly ForbiddenEntity[] InvalidForbiddenEntities = {
        new ForbiddenEntity
        {
            EventId = "1",
        },
        new ForbiddenEntity
        {
            EventId = "6767676",
            Alcohol = false,
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


}
