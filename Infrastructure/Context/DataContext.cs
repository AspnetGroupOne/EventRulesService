using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<EventRulesEntity> Events { get; set; }
    public virtual DbSet<ProhibitedItemEntity> ProhibitedItems { get; set; }

}
