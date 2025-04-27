using Core.Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class ProhibitedItemRepository(DataContext context) : BaseRepository<ProhibitedItemEntity>(context)
{

}
