using Core.Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class EventRulesRepository(DataContext context) : BaseRepository<EventRulesEntity>(context)
{

}
