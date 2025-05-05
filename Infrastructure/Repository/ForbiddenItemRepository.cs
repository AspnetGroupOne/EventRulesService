using Core.Domain.Entities;
using Core.Domain.Models.Reponses;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ForbiddenItemRepository(DataContext context) : BaseRepository<ForbiddenEntity>(context), IForbiddenItemRepository
{
}
